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
namespace Diagnostic_Center
{
    public partial class Ultrasno_Male : Form
    {
        string reg = "";
        int id = 0;
        connection db = new connection();
        public Ultrasno_Male(string x)
        {
            InitializeComponent();
            reg = x;
            id = Convert.ToInt32(x);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            pathologist();
        }

        private void Ultrasno_Male_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet58.ultrasono_male' table. You can move, or remove it, as needed.
            this.ultrasono_maleTableAdapter.Fill(this.DataSet58.ultrasono_male,reg);
            // TODO: This line of code loads data into the 'DataSet58.diagnostic_person' table. You can move, or remove it, as needed.
            this.diagnostic_personTableAdapter.Fill(this.DataSet58.diagnostic_person,id);

            this.reportViewer1.RefreshReport();
        }

        void pathologist()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from pathologist", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    comboBox1.Items.Add(read[1].ToString());
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                string designation = "";
                try
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select * from pathologist where pathologist='" + comboBox1.Text + "'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        name = read[1].ToString();
                        designation = read[2].ToString();
                    }
                    db.sql.Close();
                }
                catch
                {

                }
                ReportParameterCollection r = new ReportParameterCollection();
                r.Add(new ReportParameter("pathologist", name.ToString()));
                r.Add(new ReportParameter("designation", designation.ToString()));
                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            {

            }
            this.reportViewer1.RefreshReport();
        }


    }
}
