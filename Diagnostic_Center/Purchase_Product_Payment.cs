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
    public partial class Purchase_Product_Payment : Form
    {
        connection db = new connection();
        string id = "";
        string name = "";
        string company = "";
        string total = "";
        string serial="";
        public Purchase_Product_Payment(string x,string y, string z,string t)
        {
            InitializeComponent();
            id = x;
            name = y;
            company = z;
            total = t;
            label2.Text =y;
            label3.Text = z;
            label7.Text = total;
             history();
            
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
                SqlCommand cmd = new SqlCommand("insert into purchase_product(product_id,p_name,seller,initial_pay,payment_method,date,date2)values('"+id+"','" + name + "','" + company + "','" + richTextBox1.Text + "','" + comboBox1.Text + "','" + date + "','" + dd + "')", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Payment Sucessfull");
                    history();
                }
                else
                {
                    MessageBox.Show("Failed Payment");
                }

                db.sql.Close();

            }
            catch
            { 
            
            }
        }
        void history()
        {

            try
            {
                db.sql.Close();
                db.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select * from purchase_product where product_id='" + id + "'", db.sql);
                DataTable dt = new DataTable();
                dataGridView1.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[9].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[0].ToString();
                    
                }
                db.sql.Close();
                paid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }




        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                serial= dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                
            }
            catch
            { 
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("update purchase_product set initial_pay='" + richTextBox1.Text + "',payment_method='" + comboBox1.Text + "' where id='" + serial + "'  ", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Update Sucessfull");
                    history();
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
                db.sql.Close();
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
                 DialogResult r=MessageBox.Show("Do you want to deleteit??","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                 if (r == DialogResult.Yes)
                 {
                     SqlCommand cmd = new SqlCommand("delete from purchase_product where id='" + serial + "'", db.sql);
                     int a = cmd.ExecuteNonQuery();
                     if (a > 0)
                     {
                         MessageBox.Show("Delte Sucessfull");
                         history();
                     }
                     db.sql.Close();
                 }
                 else

                 { 
                 
                 }
            }
            catch
            { 
            
            }
        }




        void paid()
        {
            double paid = 0;
            double t = Convert.ToDouble(total);
            double due = 0;

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(initial_pay) from purchase_product where product_id='" + id + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    label9.Text = read[0].ToString();
                
                }

                db.sql.Close();
                paid = Convert.ToDouble(label9.Text);
                due = t - paid;
                label11.Text = due.ToString();
            }
            catch
            { 
            
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Purchase_Product_Print ppp = new Purchase_Product_Print(id);
            ppp.Show();
        }




    }
}
