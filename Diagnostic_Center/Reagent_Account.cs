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
    public partial class Reagent_Account : Form
    {
        string id = "";
        connection db = new connection();
        public Reagent_Account()
        {
            InitializeComponent();

            show_inventory();
            show_pruches();
        }


        void show_inventory()
        {
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from lab_inventory order by product_name ASC", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                   
                }
                db.sql.Close();

            }
            catch
            {

            }

        }

    

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
               catch
               { 
            
               }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into reagent_account(reagent_name,quantity,total_price,date,date2)values('"+richTextBox1.Text+"','"+richTextBox2.Text+"','"+richTextBox3.Text+"','"+date+"','"+dd+"')",db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Reagent Purchase Sucessfull");
                    show_pruches();

               }
                else
                {
                    MessageBox.Show("Failed to purchase");
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        }

        void show_pruches()
        {

            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from reagent_account order by id DESC", db.sql);
                dataGridView2.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item[4].ToString();
                }
                db.sql.Close();

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
                SqlCommand cmd = new SqlCommand("update reagent_account set quantity='"+richTextBox2.Text+"',total_price='"+richTextBox3.Text+"' where id='"+id+"'",db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Update Sucessfull");
                    show_pruches();

                }
                else
                {

                    MessageBox.Show("Failed to update");
                }
                db.sql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                richTextBox1.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                richTextBox2.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                richTextBox3.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
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
                SqlCommand cmd = new SqlCommand("delete from reagent_account where id='" + id + "'", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Delte Sucessfull");
                    show_pruches();

                }
                else
                {
                    MessageBox.Show("Failed to delete");
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reagent_account_Print rap = new Reagent_account_Print();
            rap.Show();
        }

    }
}
