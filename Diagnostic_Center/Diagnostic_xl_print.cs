using Microsoft.Reporting.WinForms;
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
namespace Diagnostic_Center
{
    public partial class Diagnostic_xl_print : Form
    {
        connection db = new connection();
        string reg_no = "";
        int early_paid = 0;
        int reg = 0;
        public Diagnostic_xl_print(string x)
        {
            InitializeComponent();
            reg_no = x;
            reg = Convert.ToInt32(x);
           // early_paid = Convert.ToInt32(paid);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }

        private void Diagnostic_xl_print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.due_collection' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'DataSet1.lab_copy' table. You can move, or remove it, as needed.
            
            header();
            // TODO: This line of code loads data into the 'DataSet1.diagnostic_bill' table. You can move, or remove it, as needed.
            this.diagnostic_billTableAdapter.Fill(this.DataSet1.diagnostic_bill,reg);
            // TODO: This line of code loads data into the 'DataSet1.user_cash_collection' table. You can move, or remove it, as needed.
            this.user_cash_collectionTableAdapter.Fill(this.DataSet1.user_cash_collection,reg_no);
            this.due_collectionTableAdapter.Fill(this.DataSet1.due_collection,reg);
            this.lab_copy.Fill(this.DataSet1.lab_copy, reg);
            this.reportViewer1.RefreshReport();
        }


        Image logo;
        string base64String;


        void header()
        {
            try
            {
                string name = "";
                string address = "";
                string phone = "";
                string mobile = "";
                string establish = "";

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from print_head", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    name = read[1].ToString();
                    address = read[2].ToString();
                    phone = read[3].ToString();
                    mobile = read[4].ToString();
                    establish = read[5].ToString();
                    MemoryStream ms = new MemoryStream((byte[])read[6]);
                    logo = Image.FromStream(ms);
                    try
                    {

                        // Convert Image to byte[]

                        byte[] imageBytes = ms.ToArray();

                        // Convert byte[] to Base64 String
                        base64String = Convert.ToBase64String(imageBytes);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                ReportParameterCollection r = new ReportParameterCollection();
                r.Add(new ReportParameter("name", name.ToString()));
                r.Add(new ReportParameter("address", address.ToString()));
                r.Add(new ReportParameter("phone", phone.ToString()));
                r.Add(new ReportParameter("mobile", mobile.ToString()));
                r.Add(new ReportParameter("establish", establish.ToString()));
                r.Add(new ReportParameter("logo", base64String.ToString()));

                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xerox xx = new xerox(reg_no);
            xx.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            only_lab_copy pc = new only_lab_copy(reg);
            pc.Show();
        }


    }
}
