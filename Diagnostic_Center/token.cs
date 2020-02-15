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
using Microsoft.Reporting.WinForms;
using System.IO;
namespace Diagnostic_Center
{
    public partial class token : Form
    {
        string reg_no = "";
        connection db = new connection();
        public token(string r)
        {
            
        
            InitializeComponent();
            reg_no = r;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }

        private void token_Load(object sender, EventArgs e)
        {
            header();
            string name = "notfound";
            string date = "notfound";
            string doctor = "notfound";
            string fees = "notfound";
            string address = "notfound";
            string age = "notfound";
            string sex = "notfound";
            string weight = "notfound";
            string hospital_id = "";
            string card_id = "";
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from appointment where reg_no='" + reg_no + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    name = read[1].ToString();
                    date = read[6].ToString();
                    doctor = read[7].ToString();
                    fees = read[8].ToString();
                    address = read[2].ToString();
                    age = read[3].ToString();
                    sex = read[4].ToString();
                    weight = read[9].ToString();
                    hospital_id = read[14].ToString();
                    card_id = read[11].ToString();

                }
            }
            catch
            {
            }
            ReportParameterCollection r = new ReportParameterCollection();
            r.Add(new ReportParameter("reg_no", reg_no));
            r.Add(new ReportParameter("name", name));
            r.Add(new ReportParameter("doctor", doctor));
            r.Add(new ReportParameter("date", date));
            r.Add(new ReportParameter("fees", fees));
            r.Add(new ReportParameter("address", address));
            r.Add(new ReportParameter("age", age));
            r.Add(new ReportParameter("sex", sex));
            r.Add(new ReportParameter("weight", weight));
            r.Add(new ReportParameter("hospital_id", hospital_id));
            r.Add(new ReportParameter("card_id", card_id));
            this.reportViewer1.LocalReport.SetParameters(r);
            db.sql.Close();
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
                r.Add(new ReportParameter("name2", name.ToString()));
                r.Add(new ReportParameter("address2", address.ToString()));
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
    }
}
