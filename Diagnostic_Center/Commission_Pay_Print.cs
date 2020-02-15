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
using Microsoft.Reporting.WinForms;
namespace Diagnostic_Center
{
    public partial class Commission_Pay_Print : Form
    {
        connection db = new connection();
        String doc = "";
        string d1 = "";
        string d2 = "";
        string p = "";
        public Commission_Pay_Print(string doctor,string date1,string date2,string paid)
        {
            InitializeComponent();
            doc = doctor;
            d1 = date1;
            d2 = date2;
            p = paid;
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }



        Image logo;
        string base64String;


        void header()
        {
            try
            {
                string date1 = d1;
                string date2 = d2;
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
                r.Add(new ReportParameter("doctor", doc));
                r.Add(new ReportParameter("paid", p));
                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void Commission_Pay_Print_Load(object sender, EventArgs e)
        {
            header();
            // TODO: This line of code loads data into the 'DataSet66.commission_print' table. You can move, or remove it, as needed.
            this.commission_printTableAdapter.Fill(this.DataSet66.commission_print);

            this.reportViewer1.RefreshReport();
        }
    }
}
