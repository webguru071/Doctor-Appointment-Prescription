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
using System.Globalization;
using System.IO;
namespace Diagnostic_Center
{
    public partial class total_accounts : Form
    {
        connection db = new connection();
       // SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\database\reception.mdf;Integrated Security=True;Connect Timeout=30");
        public total_accounts()
        {
            InitializeComponent();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }


        Image logo;
        string base64String;


        void header()
        {
            try
            {
                string date1 = dateTimePicker1.Text;
            
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
                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            {

            }
        }
        private void total_accounts_Load(object sender, EventArgs e)
        {
            header();
            account();
            this.reportViewer1.RefreshReport();
        }
        void account()
        {
            Double admission_fee = 0;
            Double Operation_fee = 0;
           
            Double bed_bill = 0;
            Double opd_due = 0;
            Double hospita_due = 0;
            Double diagnostic_bill = 0;
            Double due_paid = 0;
            Double expense = 0;
            Double hospital = 0;
            Double diagnostic = 0;
            Double total_cash = 0;
            Double pharmacy = 0;
            Double doctor_visit = 0;
            Double opd = 0;
            try
            {
                string date = dateTimePicker1.Text;
              
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_hospital where date='" + date + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    bed_bill = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            { 
            
            }

            try
            {
                string date = dateTimePicker1.Text;

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_OPD where date='" + date + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    opd = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }



            try
            {
                string date = dateTimePicker1.Text;

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_pharmacy where date='" + date + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    pharmacy = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }


            try
            {
                string date = dateTimePicker1.Text;

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_doctor where date='" + date + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    doctor_visit = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }
           
           
            try
            {
                string date = dateTimePicker1.Text;
                string dd = "";
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dd = d.ToString("yyyy/MM/dd");

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from paid_and_due where date2='" + dd + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    diagnostic_bill = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }


            try
            {
                string date = dateTimePicker1.Text;
                string dd = "";
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dd = d.ToString("yyyy/MM/dd");


                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(due_paid),sum(discount2) from due_collection where date2 ='" + dd + "'  and test_date !=paid_date", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    due_paid = Convert.ToDouble(read[0].ToString());

                }
            }
            catch
            {

            }


            try
            {
                string date = dateTimePicker1.Text;
                string dd = "";
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(amount) from expense where date='" + dd + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    expense = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }


            try
            {
                string date = dateTimePicker1.Text;
                string dd = "";
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(due_paid) from hospital_due_collection where date='" + date + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    hospita_due = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }

            try
            {
                string date = dateTimePicker1.Text;
                string dd = "";
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(due_paid) from opd_due_collection where date='" + date + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    opd_due = Convert.ToDouble(read[0].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }



            //hospital = 0;
            hospital = bed_bill;
           diagnostic = diagnostic_bill + due_paid;
           total_cash = (hospital + diagnostic + hospita_due + pharmacy + opd + opd_due + doctor_visit) - expense;
            ReportParameterCollection r = new ReportParameterCollection();
            r.Add(new ReportParameter("hospital", hospital.ToString()));
            r.Add(new ReportParameter("diagnostic", diagnostic.ToString()));
            r.Add(new ReportParameter("pharmacy", pharmacy.ToString()));
            r.Add(new ReportParameter("opd",opd.ToString()));
            r.Add(new ReportParameter("expense", expense.ToString()));
         
            r.Add(new ReportParameter("hospital_due", hospita_due.ToString()));
            r.Add(new ReportParameter("opd_due", opd_due.ToString()));
            r.Add(new ReportParameter("doctor_visit", doctor_visit.ToString()));
            r.Add(new ReportParameter("total", total_cash.ToString()));
            this.reportViewer1.LocalReport.SetParameters(r);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            header();
            account();
            this.reportViewer1.RefreshReport();
        }
    }
}
