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
using System.Globalization;
namespace Diagnostic_Center
{
    public partial class Product_Purchase : Form
    {
        connection db = new connection();
        string id = "";
        public Product_Purchase()
        {
            InitializeComponent();
            view_product();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into purchase_product(product_id,p_name,t_price,initial_pay,due,seller,date,date2,type)values('" + richTextBox7.Text+ "','" + richTextBox1.Text + "','" + richTextBox2.Text + "','" + richTextBox3.Text + "','" + richTextBox4.Text + "','" + richTextBox5.Text + "','" + dateTimePicker1.Text + "','" + dd + "','Initial')", db.sql);
               
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Purchase Sucessfull");
                    view_product();
                }
                else
                {
                    MessageBox.Show("Something Wrong");
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        }


        void view_product()
        {

            try
            {
                db.sql.Close();
                db.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select * from purchase_product where type='Initial'",db.sql);
                DataTable dt = new DataTable();
                dataGridView1.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item[10].ToString();
                }
                db.sql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                id = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                richTextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                richTextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                richTextBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                richTextBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                richTextBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
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

                SqlCommand cmd = new SqlCommand("update purchase_product set p_name='"+richTextBox1.Text+"', t_price='"+richTextBox2.Text+"',initial_pay='"+richTextBox3.Text+"',due='"+richTextBox4.Text+"',seller='"+richTextBox5.Text+"' where id='"+id+"'",db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Update Sucessfull");
                    view_product();
                }
                else
                {
                    MessageBox.Show("Failed to update");
                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                DialogResult r=MessageBox.Show("Do you want to deleteit??","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    SqlCommand cmd = new SqlCommand("delete from purchase_product where id='" + id + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Delete Sucessfull");
                        view_product();
                    }
                    else
                    {

                        MessageBox.Show("Failed to delete");
                    }
                }
                else
                { 
                
                }
                db.sql.Close();

            }
            catch
            { 
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print_Purchased_Product_List ppl = new Print_Purchased_Product_List();
            ppl.Show();
        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

            try
            {
                db.sql.Close();
                db.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select * from purchase_product where type='Initial' and p_name like '%"+richTextBox6.Text+"%'", db.sql);
                DataTable dt = new DataTable();
                dataGridView1.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item[10].ToString();
                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void givePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Product_Payment ppp = new Purchase_Product_Payment(dataGridView1.SelectedRows[0].Cells[7].Value.ToString(), dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            ppp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            All_Purchase_histry_print aph = new All_Purchase_histry_print();
            aph.Show();
        }

    }
}
