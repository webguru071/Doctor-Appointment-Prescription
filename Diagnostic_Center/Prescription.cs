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
    public partial class Prescription : Form
    {
        connection db = new connection();
        string id;
        int re;
        public Prescription(string x)
        {
            InitializeComponent();
            id = x;
            re = Convert.ToInt32(x);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            var setup = this.reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.reportViewer1.SetPageSettings(setup);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }

       
        private void Prescription_Load(object sender, EventArgs e)
        {
            try
            {
                header();
                // TODO: This line of code loads data into the 'DataSet22.prescription' table. You can move, or remove it, as needed.
                this.prescriptionTableAdapter.Fill(this.DataSet22.prescription, id);
                // TODO: This line of code loads data into the 'DataSet22.appointment' table. You can move, or remove it, as needed.
                this.appointmentTableAdapter.Fill(this.DataSet22.appointment, re);
                // TODO: This line of code loads data into the 'DataSet22.diagnosis' table. You can move, or remove it, as needed.
                this.diagnosisTableAdapter.Fill(this.DataSet22.diagnosis, id);
                // TODO: This line of code loads data into the 'DataSet22.patient_test' table. You can move, or remove it, as needed.
                this.patient_testTableAdapter.Fill(this.DataSet22.patient_test, id);
                // TODO: This line of code loads data into the 'DataSet22.symptoms' table. You can move, or remove it, as needed.
                this.symptomsTableAdapter.Fill(this.DataSet22.symptoms, re);


                string advice = "not found";
                string days = "";
                string nextApp = "";
                string appNo = "";
                string imageUrl = @"E:\Upload\ff.jpg";
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from advice where reg_no='" + id + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    advice = read[1].ToString();

                    days = read[2].ToString();
                }
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmdNextAppointment = new SqlCommand("select * from nextAppointment where reg_no='" + id + "'", db.sql);
                SqlDataReader readNextAppointment = cmdNextAppointment.ExecuteReader();
                while (readNextAppointment.Read())
                {
                    nextApp = readNextAppointment[2].ToString();
                    appNo = readNextAppointment[1].ToString();
                }

                ReportParameterCollection r = new ReportParameterCollection();
                r.Add(new ReportParameter("advice", advice));
                r.Add(new ReportParameter("days", days));
                r.Add(new ReportParameter("nextApp", nextApp));
                r.Add(new ReportParameter("appNo", appNo));
                r.Add(new ReportParameter("imageUrl", imageUrl));
                this.reportViewer1.LocalReport.SetParameters(r);
                this.reportViewer1.RefreshReport();

                db.sql.Close();
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
    }
}
