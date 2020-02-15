﻿using Microsoft.Reporting.WinForms;
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
    public partial class admission_form : Form
    {
        connection db = new connection();
        int reg = 0;
        string r = "";
        public admission_form(string x)
        {
            InitializeComponent();
            r = x;
            reg = Convert.ToInt32(x);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }

        private void admission_form_Load(object sender, EventArgs e)
        {
           try
            {
                header();
                admission_fee();
                // TODO: This line of code loads data into the 'DataSet10.user_cash_collection_hospital' table. You can move, or remove it, as needed.
                this.user_cash_collection_hospitalTableAdapter.Fill(this.DataSet10.user_cash_collection_hospital, r);
                // TODO: This line of code loads data into the 'DataSet10.admission' table. You can move, or remove it, as needed.
                this.admissionTableAdapter.Fill(this.DataSet10.admission, reg);
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
        void admission_fee()
        {
            try
            {
                int c = 0;
                string admission_fee = "";
                string admission_due = "";
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select paid from user_cash_collection_hospital where reg_no='"+reg+"' and type='Admission Fee'",db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while(read.Read())
                {
                    c++;
                    admission_fee = read[0].ToString();
                }
                if (c==0)
                {
                    admission_due ="400";
                
                }
                ReportParameterCollection r = new ReportParameterCollection();
                r.Add(new ReportParameter("admission_fee", admission_fee.ToString()));
                r.Add(new ReportParameter("admission_due", admission_due.ToString()));
                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            { 
            
            }
        }


    }
}
