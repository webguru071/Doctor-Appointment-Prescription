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
    public partial class add_medicine : Form
    {
        connection db = new connection();
        public string val1 { get; set; }
       // SqlConnection sql = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=pharmacy;Integrated Security=True");
        public add_medicine(int x)
        {
            InitializeComponent();
            val1 = "";
            view_medicine();
        }

        private void add_medicine_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity_new;
                int quantity_2 = 0;
                int quantity_1 = 0;
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd4 = new SqlCommand("select * from medicine_pharmacy where name='" + richTextBox1.Text + "' and catagory = '" + comboBox1.Text + "' ", db.sql);
                SqlDataReader read1 = cmd4.ExecuteReader();
                while (read1.Read())
                {
                    c++;
                    quantity_1 = Convert.ToInt32(read1[4]);

                }

                quantity_2 = Convert.ToInt32(richTextBox3.Text);
                quantity_new = quantity_1 + quantity_2;

                if (c > 0)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("update medicine_pharmacy set quantity='" + quantity_new + "',price='" + richTextBox2.Text + "' where name='" + richTextBox1.Text + "' and catagory = '" + comboBox1.Text + "' ", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Sucessfull");
                    val1 = "1";
                    view_medicine();

                }
                else
                {
                    db.sql.Close();
                    db.sql.Open();

                    SqlCommand cmd = new SqlCommand("insert into medicine_pharmacy(catagory,name,price,quantity,date)values('" + comboBox1.Text + "','" + richTextBox1.Text + "','" + richTextBox2.Text + "','" + richTextBox3.Text + "','" + dateTimePicker1.Text + "')", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Insert Sucessfull");
                        view_medicine();
                        richTextBox1.Text = "";
                        richTextBox2.Text = "";
                        richTextBox3.Text = "";
                        val1 = "1";
                    }
                }



                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void view_medicine()
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from medicine_pharmacy ", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                    int due =Convert.ToInt32( dataGridView1.Rows[n].Cells[3].Value.ToString());
                    if (due <=20)
                    {
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                        dataGridView1.Rows[n].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        
                    }
                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Do You want to Delete this?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("delete from medicine_pharmacy where name='" + richTextBox1.Text + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Delete Sucessfull");
                        val1 = "1";
                        view_medicine();
                    }
                    db.sql.Close();
                }

            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("update medicine_pharmacy set catagory='" + comboBox1.Text + "',name='" + richTextBox1.Text + "',price='" + richTextBox2.Text + "',quantity='" + richTextBox3.Text + "' where name='" + richTextBox1.Text + "'", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Update Sucessfull");
                    val1 = "1";
                    view_medicine();
                }
                else
                {
                    MessageBox.Show(" Delete the item and add Again");
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                string catagory = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string price = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string quantity = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string date = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox1.Text = catagory;
                richTextBox1.Text = name;
                richTextBox2.Text = price;
                richTextBox3.Text = quantity;
                dateTimePicker1.Text = date;
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from medicine_pharmacy where name like'%" + richTextBox4.Text + "%' ", db.sql);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                    int due = Convert.ToInt32(dataGridView1.Rows[n].Cells[3].Value.ToString());
                    if (due <= 20)
                    {
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                        dataGridView1.Rows[n].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {

                    }
                }
                db.sql.Close();

            }
            catch
            {


            }
        }

        private void richTextBox4_Click(object sender, EventArgs e)
        {
            richTextBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Print_Medicine_Stock pm = new Print_Medicine_Stock();
            pm.Show();
        }

    }
}
