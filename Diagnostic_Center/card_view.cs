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
    public partial class card_view : Form
    {
        connection db = new connection();
        public card_view()
        {
            InitializeComponent();
            card_views();
        }

        void card_views()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from card_details", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[11].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                    
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string x = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                card_prints cp = new card_prints(x);
                cp.Show();
            }
            catch { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string x = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult r = MessageBox.Show("Do You want to delete this Employee", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    db.sql.Close();
                    db.sql.Open();

                    SqlCommand cmd = new SqlCommand("delete from card_details where reg_no='" + x + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("delete from card_service where reg_no='" + x + "'", db.sql);
                    int a1 = cmd1.ExecuteNonQuery();
                    if (a > 0 && a1 > 0)
                    {
                        MessageBox.Show("Delete SucessFull");
                        card_views();
                    }
                    db.sql.Close();
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Card_Print_All call = new Card_Print_All();
            call.Show();
        }


    }
}
