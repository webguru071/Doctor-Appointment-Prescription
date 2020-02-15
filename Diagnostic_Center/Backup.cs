using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
namespace Diagnostic_Center
{
    public partial class Backup : Form
    {
        connection db = new connection();
        public Backup()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    richTextBox16.Text = dlg.SelectedPath;
                }
            }
            catch
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                if (op.ShowDialog() == DialogResult.OK)
                {
                    richTextBox17.Text = op.FileName;
                }
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionstring = @"Data Source=.\sqlexpress;Initial Catalog=master;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Close();
            conn.Open();
            string db = @"\hms.bak";
            string path = richTextBox16.Text + db;
            string sql = "BACKUP DATABASE hms TO DISK ='" + path + "'";
            try
            {
                File.Delete(path);
            }
            catch
            {

            }
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Database Backup Sucessfull To:" + path);
                    Process.Start(richTextBox16.Text);
                }
                else
                {
                    MessageBox.Show("Database Backup Sucessfull To:" + path);
                    Process.Start(richTextBox16.Text);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                string connectionstring = @"Data Source=.\sqlexpress;Initial Catalog=master;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionstring);
               
                conn.Open();
                string loc = richTextBox17.Text;

             //   string ss = "RESTORE DATABASE hms FROM DISK ='" + loc + "'  WITH REPLACE;";
                //MessageBox.Show(ss);
              //  SqlCommand cmd = new SqlCommand(ss, conn);

              //  int a = cmd.ExecuteNonQuery();
              //  if (a > 0)
                {

                  //  MessageBox.Show("Restore Sucessfull");
                }
             //   MessageBox.Show("Restore Sucessfull");
             //   conn.Close();




                string UseMaster = "USE master";
                SqlCommand UseMasterCommand = new SqlCommand(UseMaster, conn);
                UseMasterCommand.ExecuteNonQuery();

                string Alter1 = @"ALTER DATABASE hms SET Single_User WITH Rollback Immediate";
                SqlCommand Alter1Cmd = new SqlCommand(Alter1, conn);
                Alter1Cmd.ExecuteNonQuery();

                string Restore = @"RESTORE DATABASE hms FROM DISK = N'" + loc + @"' WITH  FILE = 1,  NOUNLOAD,  STATS = 10";
                SqlCommand RestoreCmd = new SqlCommand(Restore, conn);
                RestoreCmd.ExecuteNonQuery();

                string Alter2 = @"ALTER DATABASE hms SET Multi_User";
                SqlCommand Alter2Cmd = new SqlCommand(Alter2, conn);
                Alter2Cmd.ExecuteNonQuery();

                MessageBox.Show("Restore Sucessfull");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
