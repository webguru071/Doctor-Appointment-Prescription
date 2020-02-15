using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagnostic_Center
{
    public partial class previlege : Form
    {
        connection db = new connection();
        public previlege()
        {
            InitializeComponent();
            show();
        }

        private void previlege_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previlege_Load(object sender, EventArgs e)
        {

        }

        void show()
        {

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

    }
}
