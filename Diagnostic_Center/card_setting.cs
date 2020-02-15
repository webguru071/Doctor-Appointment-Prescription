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

namespace Diagnostic_Center
{
    public partial class card_setting : Form
    {
        connection db = new connection();
        public card_setting()
        {
            InitializeComponent();
            show();
        }

        void  show(){

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM card_setting", db.sql);
                SqlDataReader dt = cmd.ExecuteReader();
                dt.Read();
                textBoxX1.Text = dt[1].ToString();
                textBoxX2.Text = dt[2].ToString();
                textBoxX3.Text = dt[3].ToString();
                textBoxX4.Text = dt[4].ToString();
                textBoxX5.Text = dt[5].ToString();
                textBoxX6.Text = dt[6].ToString();
                textBoxX7.Text = dt[7].ToString();
                textBoxX8.Text = dt[8].ToString();


                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("UPDATE card_setting set lab = '" + textBoxX1.Text + "',doctor = '" + textBoxX2.Text + "',nd = '" + textBoxX3.Text + "',ndm = '" + textBoxX4.Text + "',sd = '" + textBoxX5.Text + "',sdm = '" + textBoxX6.Text + "',ms = '" + textBoxX7.Text + "',msm = '" + textBoxX8.Text + "' ", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0) { MessageBox.Show("SUCCESSFULL"); }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
