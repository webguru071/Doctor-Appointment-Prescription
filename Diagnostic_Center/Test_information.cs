using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Diagnostic_Center
{
    public partial class Test_information : Form
    {
        connection db = new connection();
        public Test_information()
        {
            InitializeComponent();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            header();
        }

        private void Test_information_Load(object sender, EventArgs e)
        {
            try
            {
                header();
                this.reportViewer1.RefreshReport();
                string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                string date2 = dateTimePicker2.Text;
                DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd2 = d2.ToString("yyyy/MM/dd");
                // TODO: This line of code loads data into the 'DataSet30.diagnostic_bill' table. You can move, or remove it, as needed.
                this.diagnostic_billTableAdapter.Fill(this.DataSet30.diagnostic_bill, dd, dd2);

                this.reportViewer1.RefreshReport();
            }
            catch
            { 
            
            }
        }


        Image logo;
        string base64String;


        void header()
        {
            try
            {
                string date1 = dateTimePicker1.Text;
                string date2 = dateTimePicker2.Text;
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
                r.Add(new ReportParameter("date1", date1));
                r.Add(new ReportParameter("date2", date2));
                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            {

            }
        }
        private void Load_Click(object sender, EventArgs e)
        {
            header();
            this.reportViewer1.RefreshReport();
            string date = dateTimePicker1.Text;
            DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd = d.ToString("yyyy/MM/dd");
            string date2 = dateTimePicker2.Text;
            DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd2 = d2.ToString("yyyy/MM/dd");
            // TODO: This line of code loads data into the 'DataSet30.diagnostic_bill' table. You can move, or remove it, as needed.
            this.diagnostic_billTableAdapter.Fill(this.DataSet30.diagnostic_bill, dd, dd2);

            this.reportViewer1.RefreshReport();
        }
    }
}
