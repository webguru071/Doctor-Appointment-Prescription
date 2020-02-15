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
    public partial class fixed_asset : Form
    {
        connection db = new connection();
        public fixed_asset()
        {
            InitializeComponent();
            show_fa();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into fixed_asset(id,name,quantity,location,present_state,remark,date)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "')", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Added Sucessfull");
                    show_fa();
                }
                db.sql.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void show_fa() {

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from fixed_asset", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

                }
                db.sql.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM fixed_asset where id ='" + textBox1.Text + "'", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("DELETE Sucessfull");
                    show_fa();
                }
                db.sql.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("UPDATE fixed_asset SET id='" + textBox1.Text + "',name='" + textBox2.Text + "',quantity='" + textBox3.Text + "',location='" + textBox4.Text + "',present_state='" + textBox5.Text + "',remark='" + textBox6.Text + "',date='" + dateTimePicker1.Text + "' where id ='" + textBox1.Text + "'", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Update Sucessfull");
                    show_fa();
                }
                db.sql.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            print_ass ps = new print_ass();
            ps.Show();
        }
    }
}
