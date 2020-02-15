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
    public partial class test_report : Form
    {
        int total_card_patient = 0;
        connection db = new connection();
        public test_report()
        {
            InitializeComponent();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            header();
        }

        private void test_report_Load(object sender, EventArgs e)

        {
            header();
            this.reportViewer1.RefreshReport();
            string date = dateTimePicker1.Text;
            DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd = d.ToString("yyyy/MM/dd");
            string date2 = dateTimePicker2.Text;
            DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd2 = d2.ToString("yyyy/MM/dd");

            // TODO: This line of code loads data into the 'DataSet52.diagnostic_bill' table. You can move, or remove it, as needed.
            this.diagnostic_billTableAdapter.Fill(this.DataSet52.diagnostic_bill,dd,dd2);
            // TODO: This line of code loads data into the 'DataSet53.patient_histroy' table. You can move, or remove it, as needed.
            this.patient_histroyTableAdapter.Fill(this.DataSet53.patient_histroy, dd, dd2);
            // TODO: This line of code loads data into the 'DataSet53.card_details' table. You can move, or remove it, as needed.
            this.card_detailsTableAdapter.Fill(this.DataSet53.card_details, dd, dd2);
            // TODO: This line of code loads data into the 'DataSet53.opd' table. You can move, or remove it, as needed.
            this.opdTableAdapter.Fill(this.DataSet53.opd, dd, dd2);
            // TODO: This line of code loads data into the 'DataSet53.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.DataSet53.appointment, dd, dd2);

          
          
            this.reportViewer1.RefreshReport();
        }

        Image logo;
        string base64String;

        void card_patient()
        {
            int diagnostic = 0;
            int hospital = 0;
            int opd = 0;
            int doctor = 0;
            int pharmacy = 0;
          
            string date = dateTimePicker1.Text;
            DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd = d.ToString("yyyy/MM/dd");
            string date2 = dateTimePicker2.Text;
            DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd2 = d2.ToString("yyyy/MM/dd");
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select count(id) from diagnostic_person where card_id !='' and date2 between '"+dd+"' and '"+dd2+"'",db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    diagnostic = Convert.ToInt32(read[0]);
                }
                db.sql.Close();
            }

            catch
            { 
            
            }


//*****************************************************************************************************

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select count(reg_no) from patient_histroy where card_id !='' and date2 between '" + dd + "' and '" + dd2 + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    hospital = Convert.ToInt32(read[0]);
                }
                db.sql.Close();
            }

            catch
            {

            }



            //*****************************************************************************************************

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select count(reg_no) from opd where card_id !='' and date2 between '" + dd + "' and '" + dd2 + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    opd = Convert.ToInt32(read[0]);
                }
                db.sql.Close();
            }

            catch
            {

            }

            //*****************************************************************************************************

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select count(reg_no) from appointment where card_id !='' and date between '" + dd + "' and '" + dd2 + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    doctor = Convert.ToInt32(read[0]);
                }
                db.sql.Close();
            }

            catch
            {

            }


            //*****************************************************************************************************

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select count(inv_id) from medicine_selling_history where card_id !='' and date2 between '" + dd + "' and '" + dd2 + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    pharmacy = Convert.ToInt32(read[0]);
                }
                db.sql.Close();
            }

            catch
            {

            }

            total_card_patient = diagnostic+hospital+opd+doctor+pharmacy;

        }
        void header()
        {
            try

            {
                card_patient();
                string d = dateTimePicker1.Text;
                string d2 = dateTimePicker2.Text;

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
                r.Add(new ReportParameter("date1", d.ToString()));
                r.Add(new ReportParameter("date2", d2.ToString()));
                r.Add(new ReportParameter("total_card_patient", total_card_patient.ToString()));
                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            header();
            this.reportViewer1.RefreshReport();
            string date = dateTimePicker1.Text;
            DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd = d.ToString("yyyy/MM/dd");
            string date2 = dateTimePicker2.Text;
            DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string dd2 = d2.ToString("yyyy/MM/dd");
            // TODO: This line of code loads data into the 'DataSet52.diagnostic_bill' table. You can move, or remove it, as needed.
            this.diagnostic_billTableAdapter.Fill(this.DataSet52.diagnostic_bill, dd, dd2);
            // TODO: This line of code loads data into the 'DataSet53.patient_histroy' table. You can move, or remove it, as needed.
            this.patient_histroyTableAdapter.Fill(this.DataSet53.patient_histroy, dd, dd2);
            // TODO: This line of code loads data into the 'DataSet53.card_details' table. You can move, or remove it, as needed.
            this.card_detailsTableAdapter.Fill(this.DataSet53.card_details, dd, dd2);
            // TODO: This line of code loads data into the 'DataSet53.opd' table. You can move, or remove it, as needed.
            this.opdTableAdapter.Fill(this.DataSet53.opd, dd, dd2);
            // TODO: This line of code loads data into the 'DataSet53.appointment' table. You can move, or remove it, as needed.
            this.appointmentTableAdapter.Fill(this.DataSet53.appointment, dd, dd2);
            
            

            this.reportViewer1.RefreshReport();
        }
    }
}
