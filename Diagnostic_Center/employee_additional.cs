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
    public partial class employee_additional : Form
    {
        connection db = new connection();
        public employee_additional()
        {
            InitializeComponent();
            show_incriment();
            show_bonus();
            show_deduction();
            label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false;  label8.Visible = false; label9.Visible = false; label10.Visible = false; label11.Visible = false; label12.Visible = false; label13.Visible = false; label14.Visible = false;
        }
        //show incriment
        void show_incriment()
        {
            try
            {
                
                    db.sql.Close();
                    db.sql.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from employee_inc", db.sql);
                    dataGridViewX1.Rows.Clear();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dataGridViewX1.Rows.Add();
                        dataGridViewX1.Rows[n].Cells[0].Value = item[1].ToString();
                        dataGridViewX1.Rows[n].Cells[1].Value = item[2].ToString();
                        dataGridViewX1.Rows[n].Cells[2].Value = item[3].ToString();
                        dataGridViewX1.Rows[n].Cells[3].Value = item[4].ToString();
                    }
                    db.sql.Close();
                
            }
            catch
            { 
            
            }
        
        }

        //show bonus
        void show_bonus()
        {
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from bonus", db.sql);
                dataGridViewX3.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX3.Rows.Add();
                    dataGridViewX3.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridViewX3.Rows[n].Cells[1].Value = item[5].ToString();
                    dataGridViewX3.Rows[n].Cells[2].Value = item[4].ToString();
                    dataGridViewX3.Rows[n].Cells[3].Value = item[2].ToString();
                    dataGridViewX3.Rows[n].Cells[4].Value = item[3].ToString();
                }
                db.sql.Close();

            }
            catch
            {

            }

        }

        //show deduction
        void show_deduction()
        {
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from deduction", db.sql);
                dataGridViewX2.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX2.Rows.Add();
                    dataGridViewX2.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridViewX2.Rows[n].Cells[1].Value = item[8].ToString();
                    dataGridViewX2.Rows[n].Cells[2].Value = item[7].ToString();
                    dataGridViewX2.Rows[n].Cells[3].Value = item[2].ToString();
                    dataGridViewX2.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridViewX2.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridViewX2.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridViewX2.Rows[n].Cells[7].Value = item[3].ToString();
                    dataGridViewX2.Rows[n].Cells[8].Value = item[9].ToString();
                }
                db.sql.Close();

            }
            catch
            {

            }

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false; label10.Visible = false; label11.Visible = false; label12.Visible = false; label13.Visible = false; label14.Visible = false;
            show_incriment();
            show_bonus();
            show_deduction();
            textBoxX1.Text = "";
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if(textBoxX1.Text ==""){
                show_incriment();
                show_bonus();
                show_deduction();
                label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false; label8.Visible = false; label9.Visible = false; label10.Visible = false; label11.Visible = false; label12.Visible = false; label13.Visible = false; label14.Visible = false;

            }
            else{
                db.sql.Close();
                db.sql.Open();
                int c = 0;
                SqlCommand cmd = new SqlCommand("SELECT name,thana,phone,job_post,salary,joining_date FROM employee where employee_id = '"+textBoxX1.Text+"'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                    label2.Visible = true; label3.Visible = true; label4.Visible = true; label5.Visible = true; label6.Visible = true; label8.Visible = true; label9.Visible = true; label10.Visible = true; label11.Visible = true; label12.Visible = true; label13.Visible = true; label14.Visible = true;
                    label9.Text = read[0].ToString();
                    label10.Text = read[1].ToString();
                    label11.Text = read[2].ToString();
                    label12.Text = read[3].ToString();
                    label13.Text = read[4].ToString();
                    label14.Text = read[5].ToString();
                }
                db.sql.Close();
                if (c == 0) {
                    label2.Visible = false; label3.Visible = false; label4.Visible = false; label5.Visible = false; label6.Visible = false;  label8.Visible = false; label9.Visible = false; label10.Visible = false; label11.Visible = false; label12.Visible = false; label13.Visible = false; label14.Visible = false;
                
                }
            show_incriment_id();
            show_bonus_id();
            show_deduction_id();
            }
        }

        //show incriment for id
        void show_incriment_id()
        {
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from employee_inc where em_id = '"+textBoxX1.Text+"' ", db.sql);
                dataGridViewX1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridViewX1.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridViewX1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridViewX1.Rows[n].Cells[3].Value = item[4].ToString();
                }
                db.sql.Close();

            }
            catch
            {

            }

        }

        //show bonus for id
        void show_bonus_id()
        {
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from bonus  where em_id = '" + textBoxX1.Text + "'", db.sql);
                dataGridViewX3.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX3.Rows.Add();
                    dataGridViewX3.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridViewX3.Rows[n].Cells[1].Value = item[5].ToString();
                    dataGridViewX3.Rows[n].Cells[2].Value = item[4].ToString();
                    dataGridViewX3.Rows[n].Cells[3].Value = item[2].ToString();
                    dataGridViewX3.Rows[n].Cells[4].Value = item[3].ToString();
                }
                db.sql.Close();

            }
            catch
            {

            }

        }

        //show deduction for id
        void show_deduction_id()
        {
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from deduction  where em_id = '" + textBoxX1.Text + "'", db.sql);
                dataGridViewX2.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX2.Rows.Add();
                    dataGridViewX2.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridViewX2.Rows[n].Cells[1].Value = item[8].ToString();
                    dataGridViewX2.Rows[n].Cells[2].Value = item[7].ToString();
                    dataGridViewX2.Rows[n].Cells[3].Value = item[2].ToString();
                    dataGridViewX2.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridViewX2.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridViewX2.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridViewX2.Rows[n].Cells[7].Value = item[3].ToString();
                    dataGridViewX2.Rows[n].Cells[8].Value = item[9].ToString();
                }
                db.sql.Close();

            }
            catch
            {

            }

        }
    }
}
