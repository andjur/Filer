using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ProcessDirectory(SqlConnection conn, long scanId, string directory, bool includeChecksum)
        {
            var directoryRoot = Directory.GetDirectoryRoot(directory);
            var path = Path.GetRelativePath(directoryRoot, directory);

            var cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[Path_insert]";
            cmd.Parameters.Add(new SqlParameter("@ScanId", scanId));
            cmd.Parameters.Add(new SqlParameter("@Path", path));
            var parId = new SqlParameter("@Id", DBNull.Value);
            parId.SqlDbType = SqlDbType.BigInt;
            parId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parId);
            cmd.ExecuteNonQuery();
            var pathId = (long)parId.Value;

            try
            {
                var files = Directory.GetFiles(directory);

                //rtbOutput.AppendText(directory + String.Format(" {0} file(s)", files.Count()) + "\n");
                //Application.DoEvents();

                foreach (string file in files)
                {
                    var fi = new FileInfo(file);

                    Object md5 = DBNull.Value;
                    try
                    {
                        if (includeChecksum)
                            md5 = CalculateMD5(file);
                    }
                    catch (IOException /*ioex*/)
                    {
                        // FIXME: report unable to compute MD5
                    }

                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[File_insert]";
                    cmd.Parameters.Add(new SqlParameter("@PathId", pathId));
                    cmd.Parameters.Add(new SqlParameter("@Name", fi.Name));
                    cmd.Parameters.Add(new SqlParameter("@Ext", fi.Extension.TrimStart('.')));
                    cmd.Parameters.Add(new SqlParameter("@Size", fi.Length));
                    cmd.Parameters.Add(new SqlParameter("@Created", fi.CreationTime));
                    cmd.Parameters.Add(new SqlParameter("@Modified", fi.LastWriteTime));
                    cmd.Parameters.Add(new SqlParameter("@MD5", md5));
                    cmd.ExecuteNonQuery();
                }

                var subDirectories = Directory.GetDirectories(directory);
                foreach (string subDirectory in subDirectories)
                {
                    ProcessDirectory(conn, scanId, subDirectory, includeChecksum);
                }
            }
            catch (Exception ex)
            {
                //rtbOutput.AppendText(ex.ToString() + "\n");
            }
        }

        private string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private string GetDriveLabel(string path)
        {
            var pathRoot = Path.GetPathRoot(Path.GetFullPath(path));

            var volumes = DriveInfo.GetDrives();
            foreach (var volume in volumes)
            {
                if (volume.Name.ToUpper() == pathRoot.ToUpper())
                    return volume.VolumeLabel;
            }
            return null;
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            txtFolder.Text = txtFolder.Text.Trim(); // normalize input

            var stopwatch = Stopwatch.StartNew();

            await Task.Run(() => 
            { 
                Scan(txtFolder.Text, chkIncludeMd5.Checked, txtConnectionString.Text); 
            });

            stopwatch.Stop();
            rtbOutput.AppendText("Elapsed time: " + stopwatch.Elapsed.ToString(@"h\:mm\:ss\.fff") + " (" + (chkIncludeMd5.Checked ? "with" : "without") + " checksums)\n\n");
        }

        private void Scan(string folder, bool includeMd5, string connectionString)
        {
            var startPath = folder;
            var driveLabel = GetDriveLabel(startPath);
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[Scan_insert]";
                cmd.Parameters.Add(new SqlParameter("@StartPath", startPath));
                cmd.Parameters.Add(new SqlParameter("@DriveLabel", driveLabel));
                //cmd.Parameters.Add(new SqlParameter("@DriveSerialNumber", N/A));
                SqlParameter parId = new SqlParameter("@Id", DBNull.Value);
                parId.SqlDbType = SqlDbType.BigInt;
                parId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parId);
                cmd.ExecuteNonQuery();
                var scanId = (long)parId.Value;

                ProcessDirectory(conn, scanId, startPath, includeMd5);

                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[Scan_update_Completed]";
                cmd.Parameters.Add(new SqlParameter("@Id", scanId));
                cmd.ExecuteNonQuery();
            }
        }

        /*
        private void button1_Click_old(object sender, EventArgs e)
        {
            var volumes = DriveInfo.GetDrives();
            foreach (var volume in volumes)
            {
                if (volume.VolumeLabel == "") // C:\
                {
                    var now = DateTime.Now;
                    using (var connecion = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Filer;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False"))
                    {
                        connecion.Open();
                        var cmd = connecion.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[dbo].[Scan_insert]";
                        cmd.Parameters.Add(new SqlParameter("@StartPath", volume.VolumeLabel));
                        //cmd.Parameters.Add(new SqlParameter("@SerialNumber", N/A));
                        cmd.Parameters.Add(new SqlParameter("@DriveLeter", volume.Name));
                        cmd.Parameters.Add(new SqlParameter("@AvailableFreeSpace", volume.AvailableFreeSpace));
                        cmd.Parameters.Add(new SqlParameter("@TotalSize", volume.TotalSize));
                        cmd.Parameters.Add(new SqlParameter("@EffectiveDate", now));
                        SqlParameter parId = new SqlParameter("@Id", volume.VolumeLabel);
                        parId.SqlDbType = SqlDbType.BigInt;
                        parId.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(parId);
                        cmd.ExecuteNonQuery();

                        var volumeId = (long)parId.Value;

                        ProcessDirectory(connecion, volumeId, volume.Name);
                    }
                }
            }
        }
        */
    }
}
