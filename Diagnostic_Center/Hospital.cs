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
using Microsoft.Reporting.WinForms;
using System.IO;
namespace Diagnostic_Center
{
    public partial class Hospital : Form
    {
        
        connection db = new connection();
        string referance_doctor = "";
        string update_time = "";
        string bill_title = "";
        string bill = "";
        string delete_surgeon = "";
        string bill_id = "";
        string select_delete = "";
        string user_name = "";
        string password = "";
        string user_type = "";
        string take_bill_edit_id="";
        string patient_hostory_print_id = "";
        string due_date = "";
        string consultant = "";
        string referance = "";
        public Hospital( string user,string pass,string type)
        {
            InitializeComponent();
            view_room();
            id_generate();
            refere_doctor();
            refere_doctor2();
            show_due_list();
            current_patient();
            user_name = user;
            password = pass;
            user_type = type;
            label99.Visible = false; label100.Visible = false; label101.Visible = false; label102.Visible = false;
        }
        void view_room()
        {
            try
            {/*
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select distinct bed_type,room_no,room.price from room,admission where room.room_no not in ( select room from admission)", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                }
                db.sql.Close();*/

                
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter(@"select distinct bed_type,room_no,room.price from room LEFT JOIN admission  ON admission.room = room.room_no
WHERE admission.room IS NULL", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();


               
                }
                db.sql.Close();
            }
            catch
            {
               
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select  bed_type,room_no,room.price from room ", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    

                }
             
                    db.sql.Close();
                
            }
        }

        void current_patient()
        {

            try
            {
                db.sql.Close(); ;
                db.sql.Open(); ;
                SqlDataAdapter sda = new SqlDataAdapter("select * from admission", db.sql);
                dataGridView2.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item[5].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item[8].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item[6].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item[7].ToString();
                }
                db.sql.Close(); ;
            }
            catch
            {

            }
        }

        void current_patient2()
        {

            try
            {
                db.sql.Close(); ;
                db.sql.Open(); ;
                SqlDataAdapter sda = new SqlDataAdapter("select * from admission", db.sql);
                dataGridView4.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView4.Rows.Add();
                    dataGridView4.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView4.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView4.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView4.Rows[n].Cells[3].Value = item[5].ToString();
                    dataGridView4.Rows[n].Cells[4].Value = item[8].ToString();
                }
                db.sql.Close(); ;
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                db.sql.Close(); ;
                db.sql.Open(); ;
                int c = 0;
                SqlCommand cmd = new SqlCommand("select max(reg_no) from patient_histroy", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    x = Convert.ToInt32(read[0].ToString());
                    c++;
                }

                if (c > 0)
                {
                    patient_id.Text = (x + 1).ToString();
                    richTextBox1.Clear();
                    richTextBox2.Clear();
                    richTextBox3.Clear();
                    richTextBox10.Clear();
                    richTextBox4.Clear();
                    richTextBox8.Clear();
                    richTextBox9.Clear();
                    room.Text = "";
                    comboBox2.Text = "";
                    richTextBox5.Text = "0";
                    richTextBox21.Text = "0";
                    rate.Text = "";
                    richTextBox7.Clear();
                }
                else
                {
                    patient_id.Text = "1";
                }
                db.sql.Close(); ;
            }
            catch
            {
                patient_id.Text = "1";
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                rate.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                room.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }
        void id_generate()
        {
            int id = 0;
            try
            {
                db.sql.Close(); ;
                db.sql.Open(); ;
                SqlCommand cmd = new SqlCommand("select max(reg_no) from patient_histroy", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    id = Convert.ToInt32(read[0]);
                    patient_id.Text = (id + 1).ToString();
                }
                db.sql.Close(); ;
            }
            catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (consultant == "")
                {
                    consultant = comboBox3.Text;
                }

                if (referance == "")
                {
                    referance = comboBox4.Text;
                 
                }
                string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                if (patient_id.Text == "" || richTextBox1.Text == "" || richTextBox3.Text == "" || dateTimePicker1.Text == "" || room.Text == "")
                {
                    MessageBox.Show("Give Reg no,Patient Name,admit date,and select room");
                }
                else
                {
                    db.sql.Close(); 
                    db.sql.Open(); 
                    SqlCommand cmd = new SqlCommand("insert into admission(reg_no,name,contact,gender,age,address,date,time,room,price,gurdian,word,thana,district)values('" + patient_id.Text + "','" + richTextBox1.Text + "','" + richTextBox2.Text + "','" + comboBox2.Text + "','" + richTextBox7.Text + "','" + richTextBox3.Text + "','" + dateTimePicker1.Text + "','" + label66.Text + "','" + room.Text + "','" + rate.Text + "','" + richTextBox10.Text + "','" + richTextBox4.Text + "','" + richTextBox8.Text + "','" + richTextBox9.Text + "')", db.sql);
                    SqlCommand cmd1 = new SqlCommand("insert into patient_histroy(reg_no,name,contact,gender,age,address,date,time,room,price,gurdian,word,thana,district,discharge_date,ref_dr,consultant,date2,card_id,type)values('" + patient_id.Text + "','" + richTextBox1.Text + "','" + richTextBox2.Text + "','" + comboBox2.Text + "','" + richTextBox7.Text + "','" + richTextBox3.Text + "','" + dateTimePicker1.Text + "','" + label66.Text + "','" + room.Text + "','" + rate.Text + "','" + richTextBox10.Text + "','" + richTextBox4.Text + "','" + richTextBox8.Text + "','" + richTextBox9.Text + "','','" + consultant + "','" + referance + "','" + dd + "','" + richTextBox27.Text + "','" + richTextBox29.Text+ "')", db.sql);
                 
                    SqlCommand cmdddd = new SqlCommand("insert into user_cash_collection_hospital(user_name,password,reg_no,name,paid,date,type,date2) values('" + user_name + "','" + password + "','" + patient_id.Text + "','" + richTextBox1.Text + "','" + richTextBox5.Text + "','" + date + "','Advanced','"+dd+"')", db.sql);
                    SqlCommand cmddddd = new SqlCommand("insert into user_cash_collection_hospital(user_name,password,reg_no,name,paid,date,type,date2) values('" + user_name + "','" + password + "','" + patient_id.Text + "','" + richTextBox1.Text + "','" + richTextBox21.Text + "','" + date + "','Admission Fee','"+dd+"')", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    int b = cmd1.ExecuteNonQuery();

                    if (richTextBox5.Text == "" || richTextBox5.Text == "0")
                    {

                    }
                    else
                    {
                      
                        cmdddd.ExecuteNonQuery();
                    }
                    if (richTextBox21.Text == "" || richTextBox21.Text == "0")
                    {

                    }
                    else
                    {
                       
                        cmddddd.ExecuteNonQuery();
                    }
                    if (a > 0 && b > 0)
                    {
                        MessageBox.Show("Admission Complete");
                       
                        view_room();
                        current_patient();
                    }
                    else
                    {
                        MessageBox.Show("Admission Failed");

                    }
                    db.sql.Close(); 
                }
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void richTextBox6_Click(object sender, EventArgs e)
        {
            richTextBox6.Clear();
        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (richTextBox6.Text == "" || richTextBox6.Text == "Search Here...")
                {

                    db.sql.Close(); ;
                    db.sql.Open(); ;
                    SqlDataAdapter sda = new SqlDataAdapter("select * from admission", db.sql);
                    dataGridView2.Rows.Clear();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dataGridView2.Rows.Add();
                        dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                        dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                        dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                        dataGridView2.Rows[n].Cells[3].Value = item[5].ToString();
                        dataGridView2.Rows[n].Cells[4].Value = item[8].ToString();
                        dataGridView2.Rows[n].Cells[5].Value = item[6].ToString();
                        dataGridView2.Rows[n].Cells[6].Value = item[7].ToString();
                    }
                    db.sql.Close(); 

                }
                else
                {
                    db.sql.Close(); ;
                    db.sql.Open(); ;
                    SqlDataAdapter sda = new SqlDataAdapter("select * from admission where contact like '%" + richTextBox6.Text + "%' or name like '%" + richTextBox6.Text + "%' or reg_no like '%" + richTextBox6.Text + "%' or room like '%" + richTextBox6.Text + "%'", db.sql);
                    dataGridView2.Rows.Clear();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = dataGridView2.Rows.Add();
                        dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                        dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                        dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                        dataGridView2.Rows[n].Cells[3].Value = item[5].ToString();
                        dataGridView2.Rows[n].Cells[4].Value = item[8].ToString();
                        dataGridView2.Rows[n].Cells[5].Value = item[6].ToString();
                        dataGridView2.Rows[n].Cells[6].Value = item[7].ToString();
                    }
                    db.sql.Close(); ;
                }
            }
            catch
            {
                db.sql.Close(); ;
                db.sql.Open(); ;
                SqlDataAdapter sda = new SqlDataAdapter("select * from admission", db.sql);
                dataGridView2.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item[5].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item[8].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item[6].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item[7].ToString();
                }
                db.sql.Close(); 
            }
        }

        private void richTextBox6_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                patient_id.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                db.sql.Close(); ;
                db.sql.Open(); ;
                SqlCommand cmd = new SqlCommand("select * from admission where reg_no='" + patient_id.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    richTextBox1.Text = read[1].ToString();
                    richTextBox2.Text = read[2].ToString();
                    comboBox2.Text = read[3].ToString();
                    richTextBox7.Text = read[4].ToString();
                    richTextBox3.Text = read[5].ToString();
                    string date = read[6].ToString();
                    update_time = read[7].ToString();

                    DateTime convert = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dateTimePicker1.Text = convert.ToString();
                    room.Text = read[8].ToString();
                    rate.Text = read[9].ToString();
                    richTextBox10.Text = read[10].ToString();
                    richTextBox4.Text = read[11].ToString();
                    richTextBox8.Text = read[12].ToString();
                    richTextBox9.Text = read[13].ToString();
                    comboBox3.Text = read[17].ToString();
                    comboBox4.Text = read[18].ToString();
                }
                db.sql.Close(); ;
            }
            catch
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (consultant == "")
                {
                    consultant = comboBox3.Text;
                }
                if (referance == "")
                {
                    referance = comboBox4.Text;
                  
                }
                DialogResult r = MessageBox.Show("Do You want to Update this Records ..?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    db.sql.Close();
                    db.sql.Open();
                   
                    SqlCommand cmd = new SqlCommand("update admission set name='" + richTextBox1.Text + "',contact='" + richTextBox2.Text + "',gender='" + comboBox2.Text + "',age='" + richTextBox7.Text + "',address='" + richTextBox3.Text + "',date='" + dateTimePicker1.Text + "',time='" + update_time + "',room='" + room.Text + "',price='" + rate.Text + "',gurdian='" + richTextBox10.Text + "',word='" + richTextBox4.Text + "',thana='" + richTextBox8.Text + "',district='" + richTextBox9.Text + "' where reg_no='" + patient_id.Text + "'", db.sql);
                    SqlCommand cmd1 = new SqlCommand("update patient_histroy set name='" + richTextBox1.Text + "',contact='" + richTextBox2.Text + "',gender='" + comboBox2.Text + "',age='" + richTextBox7.Text + "',address='" + richTextBox3.Text + "',date='" + dateTimePicker1.Text + "',time='" + update_time + "',room='" + room.Text + "',price='" + rate.Text + "',gurdian='" + richTextBox10.Text + "',word='" + richTextBox4.Text + "',thana='" + richTextBox8.Text + "',district='" + richTextBox9.Text + "',ref_dr='" + consultant + "',consultant='" + referance + "',type='" + richTextBox29.Text+ "' where reg_no='" + patient_id.Text + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    int b = cmd1.ExecuteNonQuery();
                    if (a > 0 && b > 0)
                    {
                        MessageBox.Show("Update Sucessfull");
                        view_room();

                        current_patient();

                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                    db.sql.Close(); ;
                }

            }
            catch
            {
            }
        }

        private void dateTimeInput1_TextChanged(object sender, EventArgs e)
        {
            update_time = label66.Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // print print = new print();
            admission_form ad = new admission_form(patient_id.Text);
            ad.Show();
        }


        //***********************patient history*******************

        void all_patient()
        {

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from patient_histroy", db.sql);
                dataGridView3.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView3.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView3.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView3.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView3.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView3.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView3.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridView3.Rows[n].Cells[7].Value = item[8].ToString();
                    dataGridView3.Rows[n].Cells[8].Value = item[9].ToString();
                    
                    dataGridView3.Rows[n].Cells[9].Value = item[15].ToString();
                    dataGridView3.Rows[n].Cells[10].Value = item[16].ToString();
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            try
            {
                all_patient();
                current_patient2();
                current_patient();
                show_bill_list();
                refere_doctor();
                view_room();
                show_due_list();
            }
            catch
            { 
            }
        }

        //*****************take_bill******************


        private void dataGridView4_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox13.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
                richTextBox12.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void richTextBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                string date = "";
                string bt = "";
                string cost = "";
                // string fees = "";

                db.sql.Close();
                db.sql.Open();

                SqlCommand cmd = new SqlCommand("select date,room,price,name from admission where reg_no='" + richTextBox13.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {


                    date = r[0].ToString();

                    bt = r[1].ToString();
                    cost = r[2].ToString();
                    name = r[3].ToString();
                }
                label89.Text = date;

                label91.Text = cost.ToString();
                label92.Text = bt;
                richTextBox12.Text = name;
                string x = label89.Text;

                DateTime admit = DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                DateTime today = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var totaldays = (today - admit).TotalDays;
                if (totaldays == 0)
                {
                    richTextBox25.Text = "1";
                }
                else
                {
                    richTextBox25.Text = totaldays.ToString();
                }

                db.sql.Close();
            }
            catch
            {
                label94.Text = "0";
                label96.Text = "0";
                label95.Text = "0";
                richTextBox25.Text = "";
            }
            show_operation_bill();
           // show_operation_bill2();
            operation_bill_calculate();
            total_bill_taken_show();
        }

        private void richTextBox25_TextChanged(object sender, EventArgs e)
        {
            bill_calculate2();
        }
        void bill_calculate()
        {
            int paid = 0;
            int due = 0;
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_hospital where  reg_no='" + richTextBox19.Text + "'and (type='Bed Bill' or type='Advanced')", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    paid = Convert.ToInt32(read[0].ToString());

                }
                label95.Text = paid.ToString();
                label34.Text = paid.ToString();
                db.sql.Close();
            }
            catch
            {
                label34.Text = "0";
                label95.Text = "0";
            }
            try
            {


                int day = Convert.ToInt32(richTextBox15.Text);
                int cost = Convert.ToInt32(label38.Text);
                int t_paid = Convert.ToInt32(label34.Text);
                int total = day * cost;
                due = total - t_paid;
                label35.Text = total.ToString();
                label33.Text = due.ToString();
                if (label96.Text == "0")
                {
                    button14.Enabled = false;
                }
                else
                {
                    button14.Enabled = true;
                }

            }
            catch
            {
                label33.Text = "0";
                label34.Text = "0";
            }

        }

        void bill_calculate2()
        {
            int paid = 0;
            int due = 0;
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_hospital where reg_no='" + richTextBox13.Text + "' and (type='Bed Bill' or type='Advanced')", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    paid = Convert.ToInt32(read[0].ToString());

                }
                label95.Text = paid.ToString();
               
                db.sql.Close();
            }
            catch
            {
               
                label95.Text = "0";
            }
            try
            {


                int day = Convert.ToInt32(richTextBox25.Text);
                int cost = Convert.ToInt32(label91.Text);
                int t_paid = Convert.ToInt32(label95.Text);
                int total = day * cost;
                due = total - t_paid;
                label94.Text = total.ToString();
                label96.Text = due.ToString();
                if (label96.Text == "0")
                {
                    button14.Enabled = false;
                }
                else
                {
                    button14.Enabled = true;
                }

            }
            catch
            {
                label94.Text = "0";
                label96.Text = "0";
            }

        }
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                if (richTextBox26.Text == "")
                {
                    MessageBox.Show("Give an Amount");
                }
                else
                {
                    DialogResult r = MessageBox.Show("Did you get the Bill.?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int total = Convert.ToInt32(label94.Text);
                        int paid = Convert.ToInt32(label95.Text);
                        int cdue = Convert.ToInt32(label96.Text);
                        int pay = Convert.ToInt32(richTextBox26.Text);
                        int total_paid = paid + pay;
                        int due = total - total_paid;
                        int days = Convert.ToInt32(richTextBox25.Text);
                        if (pay > cdue)
                        {
                            MessageBox.Show("Paying amount can not be larger than Due amount");
                        }
                        else
                        {
                            db.sql.Close();
                            db.sql.Open();
                           
                            SqlCommand cmdddd = new SqlCommand("insert into user_cash_collection_hospital(user_name,password,reg_no,name,paid,date,type,date2) values('" + user_name + "','" + password + "','" + richTextBox13.Text + "','" + richTextBox12.Text + "','" + richTextBox26.Text + "','" + date + "','Bed Bill','"+dd+"')", db.sql);
                           
                           int a= cmdddd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("Bill Taken Sucessfully");
                                Bed_Bill_Print bed = new Bed_Bill_Print(richTextBox13.Text, richTextBox26.Text, user_name);
                                bed.Show();
                                bill_calculate2();
                                total_bill_taken_show();
                            }
                            db.sql.Close();

                        }

                    }
                }
            }
            catch
            {

            }
        }


        void total_bill_taken_show()
        {
            try
            {
                DataGridViewColumn column = dataGridView7.Columns[4];
                column.Width = 0;
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from user_cash_collection_hospital where reg_no='"+richTextBox13.Text+"'",db.sql);
                dataGridView7.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView7.Rows.Add();
                    dataGridView7.Rows[n].Cells[0].Value = item[4].ToString();
                    dataGridView7.Rows[n].Cells[1].Value = item[6].ToString();
                    dataGridView7.Rows[n].Cells[2].Value = item[0].ToString();
                    dataGridView7.Rows[n].Cells[3].Value = item[5].ToString();
                    dataGridView7.Rows[n].Cells[4].Value = item[8].ToString();
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        
        }
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {

                if (richTextBox13.Text == "")
                {
                    MessageBox.Show("Please  Give a Valid Registration Number");
                }
                else
                {
                    DialogResult r = MessageBox.Show("Did you get the amount?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (richTextBox14.Text == "")
                        {
                            MessageBox.Show("Give a valid amount");
                        }
                        else
                        {
                            string date = dateTimePicker3.Text;
                            DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            string dd = d.ToString("yyyy/MM/dd");
                            db.sql.Close();
                            db.sql.Open();
                            int total = Convert.ToInt32(richTextBox28.Text);


                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmdddd = new SqlCommand("insert into user_cash_collection_hospital(user_name,password,reg_no,name,paid,date,type,date2,total) values('" + user_name + "','" + password + "','" + richTextBox13.Text + "','" + richTextBox12.Text + "','" + richTextBox14.Text + "','" + date + "','Operation Bill','" + dd + "','" + richTextBox28.Text+ "')", db.sql);

                            int a = cmdddd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("Paid Sucessfull");
                                Operation_bill_Print operation_bill = new Operation_bill_Print(richTextBox13.Text, richTextBox14.Text,user_name);
                                operation_bill.Show();
                            }

                            db.sql.Close();
                            operation_bill_calculate();
                            total_bill_taken_show();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        void show_operation_bill()
        {

            try
            {
                int c = 0;
                string x = "";
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select total from user_cash_collection_hospital where reg_no='" + richTextBox13.Text + "' and type='Operation Bill'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    x = read[0].ToString();
                    c++;
                }
                if (c > 0)
                {
                    richTextBox28.Text = x;
                }
                else
                {
                    richTextBox28.Clear();
                }
                db.sql.Close();
            }

            catch
            {
                richTextBox28.Clear();
            }
        }



        void show_operation_bill2()
        {

            try
            {

                int c = 0;
                string y = "0";
                try
                {



                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_hospital where reg_no='" + richTextBox19.Text + "' and type='Operation Bill'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {

                        y = read[0].ToString();
                        c++;
                    }

                    if (y == "")
                    {
                        label29.Text = "0";
                    }
                    else
                    {

                        label29.Text = y;
                    }




                    db.sql.Close();
                }

                catch
                {
                    label29.Text = "0";
                }

                try
                {


                    string x = "0";
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select total from user_cash_collection_hospital where reg_no='" + richTextBox19.Text + "' and type='Operation Bill'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        x = read[0].ToString();

                        c++;
                    }
                    if (c > 0)
                    {
                        label30.Text = x;

                    }
                    else
                    {

                        label30.Text = "0";
                    }
                    db.sql.Close();
                }

                catch
                {
                    label30.Text = "0";
                }
            }
            catch
            { 
            
            }
            
        }

        private void richTextBox11_TextChanged(object sender, EventArgs e)
        {

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from patient_histroy where reg_no like '%" + richTextBox11.Text + "%' or name like'%" + richTextBox11.Text + "%'", db.sql);
                dataGridView3.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView3.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView3.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView3.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView3.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView3.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView3.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridView3.Rows[n].Cells[7].Value = item[8].ToString();
                    dataGridView3.Rows[n].Cells[8].Value = item[9].ToString();

                    dataGridView3.Rows[n].Cells[9].Value = item[15].ToString();
                    dataGridView3.Rows[n].Cells[10].Value = item[16].ToString();
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        //****************Discharge*********************

        void show_bill_list()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from bill_list", db.sql);
                dataGridView6.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView6.Rows.Add();
                    dataGridView6.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView6.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView6.Rows[n].Cells[2].Value = item[2].ToString();

                }
                db.sql.Close();
            }
            catch
            {

            }
        }

    

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into patient_bill(reg_no,bill_title,bill,bill_id)values('" + richTextBox19.Text + "','" + bill_title + "','" + bill + "','" + bill_id + "')", db.sql);
                int a = cmd.ExecuteNonQuery();

                show_bill();
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void dataGridView6_Click(object sender, EventArgs e)
        {
            try
            {
                bill_id = dataGridView6.SelectedRows[0].Cells[0].Value.ToString();
                bill_title = dataGridView6.SelectedRows[0].Cells[1].Value.ToString();
                bill = dataGridView6.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }
        void show_bill()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from patient_bill where reg_no='" + richTextBox19.Text + "'", db.sql);
                dataGridView5.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView5.Rows.Add();
                    dataGridView5.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView5.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridView5.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView5.Rows[n].Cells[3].Value = item[4].ToString();
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();

                db.sql.Open();

                SqlCommand cmd = new SqlCommand("delete from patient_bill where reg_no='" + richTextBox19.Text + "' and bill_id='" + select_delete + "'", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Delete Sucessfull");
                    show_bill();
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void dataGridView5_Click(object sender, EventArgs e)
        {
            try
            {
                select_delete = dataGridView5.SelectedRows[0].Cells[3].Value.ToString();
                delete_surgeon = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch { }
        }

        private void richTextBox19_TextChanged(object sender, EventArgs e)
        {

            try
            {
                label52.Text = "0";
                label55.Text = "0";
                label49.Text = "0";
                label75.Text = "0";
                label74.Text = "0";
                label27.Text = "0";
                string status = "0";
                
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from patient_histroy where reg_no='" + richTextBox19.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                    richTextBox18.Text = read[1].ToString();
                    status = read[15].ToString();
                    referance_doctor = read[18].ToString();

                }
                if (richTextBox19.Text == "")
                {
                    label64.Text = "";
                }
                if (status == "" && c > 0)
                {
                    label64.Text = "Admited";
                    button8.Enabled = true;
                    button7.Enabled = true;
                    button10.Enabled = true;
                }
                else if (status == "0")
                {
                    label64.Text = "";
                    button8.Enabled = false;
                    button7.Enabled = false;
                    button10.Enabled = false;
                }
                else
                {
                    label64.Text = "Discharged" + " on " + status;
                    button8.Enabled = false;
                    button7.Enabled = false;
                    button10.Enabled = false;
                }
                db.sql.Close();


            }
            catch
            {
                label64.Text = "";
            }
            show_bill();
            bed_bill();
            show_operation_bill2();
            diagnostic_bill();
            admission_fee();
            medicine_bill();
            doctor_bill();
            total_cash_paid();


            if (richTextBox19.Text == "")
            {
                label23.Text = "0";
                label20.Text = "0";
                label18.Text = "0";
            }
        }

        void doctor_bill()
        {
            try
            {
                if (richTextBox19.Text == "")
                {
                    label104.Text = "0";
                    label103.Text = "0";
                }
                else
                {
                string a = "";
                string aa = "";
                int b = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(fees) from appointment where hospital_id='" + richTextBox19.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    b++;
                    a = read[0].ToString();
                   
                }
                if (b > 0)
                {
                    label104.Text = a.ToString();
                    label103.Text = a.ToString();
                }
                else
                {
                    label104.Text = "0";
                    label103.Text = "0";
                }
                }
              }
                catch
                {
                    label104.Text = "0";
                    label103.Text = "0";
                    
                }
        
        }

        void medicine_bill()
        {
            try
            {
                string a = "";
                string aa = "";
                int b = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select total,paid from medicine_selling_history where reg_id='" + richTextBox19.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    b++;
                    a = read[0].ToString();
                    aa = read[1].ToString();
                }
                if (b > 0)
                {
                    label75.Text = a;
                    label74.Text = aa;
                }
                else
                {
                    label75.Text = "0";
                    label74.Text = "0";
                }
                if (richTextBox19.Text == "")
                {
                    label75.Text = "0";
                    label74.Text = "0";
                }
                db.sql.Close();
            }
            catch
            {
                label75.Text = "0";
                label74.Text = "0";
            }
        }
        void admission_fee()
        {
            try
            {
                string a = "";
                int b = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select paid from user_cash_collection_hospital where reg_no='" + richTextBox19.Text+ "' and type='Admission Fee'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    b++;
                    a= read[0].ToString();
                }
                if (b > 0)
                {
                    label6.Text = a;
                }
                else
                {
                    label6.Text ="0";
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        }

        void bed_bill()
        {

            try
            {
                string name = "";
                string date = "";
                string bt = "";
                string cost = "";
                // string fees = "";

                db.sql.Close();
                db.sql.Open();

                SqlCommand cmd = new SqlCommand("select date,room,price from patient_histroy where reg_no='" + richTextBox19.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {


                    date = r[0].ToString();

                    bt = r[1].ToString();
                    cost = r[2].ToString();
                }
                label40.Text = date;

                label38.Text = cost.ToString();
                label36.Text = bt;
                string x = label40.Text;

                DateTime admit = DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                DateTime today = DateTime.ParseExact(dateTimePicker4.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var totaldays = (today - admit).TotalDays;
                if (totaldays == 0)
                {
                    richTextBox15.Text = "1";
                }
                else
                {
                    richTextBox15.Text = totaldays.ToString();
                }

                db.sql.Close();
            }
            catch
            {
                label35.Text = "0";
                label34.Text = "0";
                label33.Text = "0";
                richTextBox15.Text = "";
            }
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                int sum = 0;
                for (int i = 0; i < dataGridView5.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView5.Rows[i].Cells[2].Value);
                }
                label55.Text = sum.ToString();
                label49.Text = sum.ToString();
            }
            catch
            { 
            
            }
        }

       

        private void richTextBox185_TextChanged(object sender, EventArgs e)
        {
            int paid = 0;
            int due = 0;
            try
            {

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_hospital where reg_no='" + richTextBox19.Text + "' and type='Bed Bill'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    paid = Convert.ToInt32(read[0].ToString());

                }
                label95.Text = paid.ToString();
                db.sql.Close();
            }
            catch
            {
                label95.Text = "0";
            }
            try
            {


                int day = Convert.ToInt32(richTextBox15.Text);
                int cost = Convert.ToInt32(label91.Text);
                int t_paid = Convert.ToInt32(label95.Text);
                int total = day * cost;
                due = total - t_paid;
                label94.Text = total.ToString();
                label96.Text = due.ToString();
                if (label96.Text == "0")
                {

                }
                else
                {

                }

            }
            catch
            {
                label94.Text = "0";
                label96.Text = "0";
            }

        }


        void total_cash_paid()
        {
            try
            {
                double bed = Convert.ToDouble(label34.Text);
                double operation = Convert.ToDouble(label29.Text);
                double diagnostic = Convert.ToDouble(label22.Text);
                double admission = Convert.ToDouble(label6.Text);
                double medicine_bill = Convert.ToDouble(label74.Text);
                double total = bed + operation + diagnostic + medicine_bill+admission;
                label27.Text = total.ToString();
                label47.Text = total.ToString();
            }
            catch
            {
                label27.Text = "0";
                label47.Text = "0";
            }
        }

    
        //**************************
        void diagnostic_bill()
        {
            try
            {
                int xx = Convert.ToInt32(richTextBox19.Text);
                int total = 0;
                int paid = 0;
                int due = 0;
                int due_paid = 0;
                int less = 0;
                int net_bill = 0;
                int net_paid = 0;
                int net_due = 0;
                try
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select sum(discount_total),sum(paid),sum(less) from paid_and_due,diagnostic_person where paid_and_due.invoice_no=diagnostic_person.id and diagnostic_person.others_id='" + richTextBox19.Text + "' and other_type='indoor' ", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        total = Convert.ToInt32(read[0]);
                        paid = Convert.ToInt32(read[1]);
                        less = Convert.ToInt32(read[2]);
                    }

                    db.sql.Close();
                }
                catch
                {

                }
                try
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd1 = new SqlCommand("select sum(due),sum(due_paid) from due_collection,diagnostic_person where due_collection.reg_no=diagnostic_person.id and due_collection.test_date!=due_collection.paid_date and diagnostic_person.others_id='" + richTextBox19.Text + "'and other_type='indoor'", db.sql);
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    while (read1.Read())
                    {
                        due = Convert.ToInt32(read1[0]);
                        due_paid = Convert.ToInt32(read1[1]);

                    }
                    net_bill = total - less;
                    net_paid = paid + (due_paid);
                    net_due = net_bill - net_paid;
                    label23.Text = net_bill.ToString();
                    label22.Text = net_paid.ToString();
                    label21.Text = net_due.ToString();
                    db.sql.Close();
                }
                catch
                {
                    label23.Text = "0";
                    label22.Text = "0";
                    label21.Text = "0";
                }
            }
            catch
            {
                label23.Text = "0";
                label22.Text = "0";
                label21.Text = "0";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                discharge_bill db = new discharge_bill(richTextBox19.Text, patient_id.Text);
                db.Show();
            }
            catch { 
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                DialogResult r = MessageBox.Show("Do You Want To Discharge This Patient ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("delete from admission where reg_no='" + richTextBox19.Text + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Discharge Sucessfull");
                    }
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void richTextBox15_TextChanged(object sender, EventArgs e)
        {
            bill_calculate();
        }
        void operation_bill_calculate()
        {
            try
            {
                int total =Convert.ToInt32(richTextBox28.Text);
                int paid = 0;
                int due = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select sum(paid) from user_cash_collection_hospital where reg_no='" + richTextBox13.Text + "' and type='Operation Bill'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    paid = Convert.ToInt32(read[0].ToString());
                }
                due = total - paid;
                label61.Text = paid.ToString();
                label62.Text = due.ToString();
                db.sql.Close();

            }
            catch
            {
                label61.Text ="0";
                label62.Text = "0";
            }
        
        }
        private void richTextBox16_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double a = 0;
                double b = 0;
                double c = 0;
                double y = 0;
                double x = 0;
                double due = 0;
                a = Convert.ToDouble(label55.Text);
                b = Convert.ToDouble(richTextBox16.Text);
                c = a - b;
                label49.Text = c.ToString();
                x = Convert.ToDouble(label49.Text);
                y = Convert.ToDouble(label47.Text);
                due = x - y;
                label52.Text = due.ToString();


            }
            catch
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into patient_bill(reg_no,bill_title,bill,bill_id)values('" + richTextBox19.Text + "','" + bill_title + "','" + bill + "','" + bill_id + "')", db.sql);
                int a = cmd.ExecuteNonQuery();

                show_bill();
                db.sql.Close();
            }
            catch
            {

            }

            try
            { 
                if (bill_title == "Surgeon Fee")
                {
                    string date = dateTimePicker4.Text;
                    DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string dd = d.ToString("yyyy/MM/dd");
                    string surjeon = "";
                    Surgeon ss = new Surgeon();
                    ss.ShowDialog();
                    surjeon = ss.sur;
                    db.sql.Close();
                    db.sql.Open();
         
                    SqlCommand cmd = new SqlCommand("insert into surgeon(reg_no,surgeon,date,date2)values('" + richTextBox19.Text + "','" + surjeon + "','"+date+"','"+dd+"')", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    db.sql.Close();
                }
            }

            catch
            { 
            
            
            }




            try
            {  
                if (bill_title == "Anaesthesia (gas)")
                {
                    string date = dateTimePicker4.Text;
                    DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string dd = d.ToString("yyyy/MM/dd");
                    string surjeon = "";
                    Anaesthesia ss = new Anaesthesia();
                    ss.ShowDialog();
                    surjeon = ss.sur;
                    db.sql.Close();
                    db.sql.Open();

                    SqlCommand cmd = new SqlCommand("insert into anastasia(reg_no,anastasia,date,date2)values('" + richTextBox19.Text + "','" + surjeon + "','" + date + "','" + dd + "')", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    db.sql.Close();
                }
            }

            catch
            { 
            
            }




        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();

                db.sql.Open();

                SqlCommand cmd = new SqlCommand("delete from patient_bill where id='" + select_delete + "'", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Delete Sucessfull");
                    show_bill();
                }
                db.sql.Close();
            }
            catch
            {

            }


            try
            {
              
                if (delete_surgeon == "Surgeon Fee")
                {
                    db.sql.Close();

                    db.sql.Open();

                    SqlCommand cmd = new SqlCommand("delete from surgeon where reg_no='" + richTextBox19.Text + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        
                        show_bill();
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



            try
            {

                if (delete_surgeon == "Anaesthesia (gas)")
                {
                    db.sql.Close();

                    db.sql.Open();

                    SqlCommand cmd = new SqlCommand("delete from anastasia where reg_no='" + richTextBox19.Text + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        show_bill();
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int exe = 0;
                int id = 0; ;
                string val1 = "";
                string val2 = "";
                string val3 = "";
                string val4 = "";
                int n = 0;
                int c = dataGridView5.Rows.Count;
                db.sql.Close();
                db.sql.Open();
                for (n = 0; n <= c - 1; n++)
                {
                    val1 = dataGridView5.Rows[n].Cells[0].Value.ToString();
                    val3 = dataGridView5.Rows[n].Cells[2].Value.ToString();
                    val4 = dataGridView5.Rows[n].Cells[3].Value.ToString();
                    SqlCommand cmd = new SqlCommand("update patient_bill set bill_title='"+val1+"',bill='" + val3 + "' where id='" + val4 + "'", db.sql);
                    exe = cmd.ExecuteNonQuery();

                }
                db.sql.Close();
            }
            catch
            {

            }

            try
            {
                Double aa = Convert.ToDouble(label52.Text);
                Double b = Convert.ToDouble(richTextBox17.Text);

                if (richTextBox17.Text == "")
                {
                    MessageBox.Show("Give a valid amount");
                }
                else
                {
                    double paid =Convert.ToDouble(label47.Text);
                    double now_paing = Convert.ToDouble(richTextBox17.Text);
                    double total_paid = paid + now_paing;
                        string date = dateTimePicker4.Text;
                        DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        string dd = d.ToString("yyyy/MM/dd");
                        db.sql.Close();
                        db.sql.Open();
                      
                        SqlCommand cmd3 = new SqlCommand("delete from user_cash_collection_hospital where reg_no='" + richTextBox19.Text + "' and type='Discharge Bill'", db.sql);
                        SqlCommand cmd4 = new SqlCommand("delete from hospital_referance where reg_no='" + richTextBox19.Text + "'", db.sql);
                    
                        cmd3.ExecuteNonQuery();
                        cmd4.ExecuteNonQuery();
                        db.sql.Close();
                        db.sql.Open();

                        SqlCommand cmdddd = new SqlCommand("insert into user_cash_collection_hospital(user_name,password,reg_no,name,paid,date,type,date2,total,discount,due) values('" + user_name + "','" + password + "','" + richTextBox19.Text + "','" + richTextBox18.Text + "','" + richTextBox17.Text + "','" + date + "','Discharge Bill','" + dd + "','" + label55.Text + "','" + richTextBox16.Text + "','" + label52.Text+ "')", db.sql);
                        SqlCommand cmdd = new SqlCommand("insert into hospital_referance(reg_no,patient_name,total,paid,referance,date)values('" + richTextBox19.Text + "','" + richTextBox18.Text + "','" + label55.Text + "','" + total_paid + "','" + referance_doctor + "','" + dd + "')", db.sql);
                       int a= cmdddd.ExecuteNonQuery();
                        cmdd.ExecuteNonQuery();
                     
                        if (a > 0)
                        {
                            MessageBox.Show("Bill taken Sucessfully");
                            discharge_bill2 db2 = new discharge_bill2(richTextBox19.Text, label27.Text);
                            db2.Show();
                        }
                        else
                        {
                            MessageBox.Show("Not Paid");
                        }
                        db.sql.Close();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


     
        private void label49_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                int b = 0;
                int c = 0;
                int y = 0;
                int x = 0;
                int due = 0;
                a = Convert.ToInt32(label55.Text);
                b = Convert.ToInt32(richTextBox16.Text);
                c = a - b;
                label49.Text = c.ToString();
                x = Convert.ToInt32(label49.Text);
                y = Convert.ToInt32(label47.Text);
                due = x - y;
                label52.Text = due.ToString();

            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            discharge_bill dbb = new discharge_bill(richTextBox19.Text, label27.Text);
            dbb.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                DialogResult r = MessageBox.Show("Do You Want To Discharge This Patient ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("delete from admission where reg_no='" + richTextBox19.Text + "'", db.sql);
                    SqlCommand cmd1 = new SqlCommand("update patient_histroy set discharge_date='" + dateTimePicker4.Text + "',total_days='" + richTextBox15.Text + "' where reg_no='" + richTextBox19.Text+ "'", db.sql);
                    cmd1.ExecuteNonQuery();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Discharge Sucessfull");
                    }
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void Hospital_Load(object sender, EventArgs e)
        {
            try
            {
                header();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                // TODO: This line of code loads data into the 'DataSet14.user_cash_collection_hospital' table. You can move, or remove it, as needed.
                this.user_cash_collection_hospitalTableAdapter.Fill(this.DataSet14.user_cash_collection_hospital, user_name, password, dateTimePicker5.Text);
                this.reportViewer1.RefreshReport();
            }
            catch
            {
            }
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                // TODO: This line of code loads data into the 'DataSet14.user_cash_collection_hospital' table. You can move, or remove it, as needed.
                this.user_cash_collection_hospitalTableAdapter.Fill(this.DataSet14.user_cash_collection_hospital, user_name, password, dateTimePicker5.Text);
                this.reportViewer1.RefreshReport();
            }
            catch
            { 
            
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                header();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                // TODO: This line of code loads data into the 'DataSet14.user_cash_collection_hospital' table. You can move, or remove it, as needed.
                this.user_cash_collection_hospitalTableAdapter.Fill(this.DataSet14.user_cash_collection_hospital, user_name, password, dateTimePicker5.Text);
                this.reportViewer1.RefreshReport();
            }
            catch
            { 
            }
        }

        private void richTextBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close(); ;
                db.sql.Open(); ;
                SqlDataAdapter sda = new SqlDataAdapter("select * from admission where reg_no Like'%" + richTextBox20.Text + "%' or name Like'%" + richTextBox20.Text + "%'", db.sql);
                dataGridView4.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView4.Rows.Add();
                    dataGridView4.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView4.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView4.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView4.Rows[n].Cells[3].Value = item[5].ToString();
                    dataGridView4.Rows[n].Cells[4].Value = item[8].ToString();
                }
                db.sql.Close(); ;
            }
            catch
            {

            }
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            try
            {
                patient_hostory_print_id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch
            { 
            
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                admission_form ad = new admission_form(patient_hostory_print_id);
                ad.Show();
            }
            catch
            { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label66.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            /*ComboBox cbo = sender as ComboBox;
            cbo.Focus();
            cbo.DroppedDown = true;*/
        }

        void refere_doctor()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select name from doctors", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                comboBox4.Items.Clear();
                while (read.Read())
                {
                    String name = read[0].ToString();
                    comboBox4.Items.Add(name);
                }

                db.sql.Close();
            }

            catch
            {


            }

        }


        void refere_doctor2()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select name from refer_doctor", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                comboBox3.Items.Clear();
                while (read.Read())
                {
                    String name = read[0].ToString();
                    comboBox3.Items.Add(name);
                }

                db.sql.Close();
            }

            catch
            {


            }

        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            /*ComboBox cbo = sender as ComboBox;
            cbo.Focus();
            cbo.DroppedDown = true;*/
        }

        private void comboBox4_Enter(object sender, EventArgs e)
        {
          /*  ComboBox cbo = sender as ComboBox;
            cbo.Focus();
            cbo.DroppedDown = true;*/
        }

        private void patient_id_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (patient_id.Text== "")
                {
                    richTextBox1.Clear();
                    richTextBox2.Clear();
                    richTextBox3.Clear();
                    richTextBox10.Clear();
                    richTextBox4.Clear();
                    richTextBox8.Clear();
                    richTextBox9.Clear();
                    richTextBox29.Clear();
                    room.Text = "";
                    comboBox2.Text = "";
                    richTextBox5.Text = "0" ;
                    rate.Text = "";
                    richTextBox7.Clear();
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                }
                db.sql.Close(); 
                db.sql.Open(); 
                SqlCommand cmd = new SqlCommand("select * from patient_histroy where reg_no='" + patient_id.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    richTextBox1.Text = read[1].ToString();
                    richTextBox2.Text = read[2].ToString();
                    comboBox2.Text = read[3].ToString();
                    richTextBox7.Text = read[4].ToString();
                    richTextBox3.Text = read[5].ToString();
                   
                    richTextBox10.Text = read[10].ToString();
                    richTextBox4.Text = read[11].ToString();
                    richTextBox8.Text = read[12].ToString();
                    richTextBox9.Text = read[13].ToString();
                    comboBox3.Text = read[17].ToString();
                    comboBox4.Text = read[18].ToString();
                    richTextBox29.Text = read[21].ToString();
                   
                   string date = read[6].ToString();
                    update_time = read[7].ToString();
                    
                    DateTime convert = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                  //  dateTimePicker1.Text = convert.ToString();
                     room.Text = read[8].ToString();
                    
                    rate.Text = read[9].ToString();
                }
              
                db.sql.Close(); 
            }
            catch
            {
               
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            add_room ar = new add_room();
            ar.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
             view_room();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                DialogResult r = MessageBox.Show("Do You want to Cancel this Admission..??","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                   
                    if (user_type == "Admin")
                    {
                        SqlCommand cmd = new SqlCommand("delete from admission where reg_no='" + patient_id.Text + "'", db.sql);
                        SqlCommand cmd1 = new SqlCommand("delete from patient_histroy where reg_no='" + patient_id.Text + "'", db.sql);
                        SqlCommand cmd2 = new SqlCommand("delete from bed_bill where reg_no='" + patient_id.Text + "'", db.sql);
                        SqlCommand cmd3 = new SqlCommand("delete from user_cash_collection_hospital where reg_no='" + patient_id.Text + "'", db.sql);
                        SqlCommand cmd4 = new SqlCommand("delete from operation where reg_no='" + patient_id.Text + "'", db.sql);
                        SqlCommand cmd5 = new SqlCommand("delete from hospital_referance where reg_no='" + patient_id.Text + "'", db.sql);
                      
                        SqlCommand cmd7 = new SqlCommand("delete from hospital_due_collection where reg_no='" + patient_id.Text + "'", db.sql);
                      
                 
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                        try
                        {
                            cmd1.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        try
                        {
                            cmd2.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        try
                        {
                            cmd3.ExecuteNonQuery();
                        }
                        catch
                        {
                        }

                        try
                        {
                            cmd4.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        try
                        {
                            cmd5.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                    
                        try
                        {
                            cmd7.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                     
                        
                        MessageBox.Show("Admission Cancel Sucessfull");
                        current_patient();
                        db.sql.Close();
                    }
                    else
                    {
                        MessageBox.Show("Only Admin Can Delete");
                    }
                }
               
            }
            catch
            { 
            
            }
        }

        private void room_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                string x = "";
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select price from room where room_no='" + room.Text+ "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                    x = read[0].ToString();
                }
                if (c > 0)
                {
                    rate.Text = x;
                }
                else
                {
                    rate.Text = "";
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Discharge_Certificate dc = new Discharge_Certificate();
            dc.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            discharge_bill2 db2 = new discharge_bill2(richTextBox19.Text, label27.Text);
            db2.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Add_bill_list abl = new Add_bill_list();
            abl.Show();
        }

        Image logo;
        string base64String;


        void header()
        {
            try
            {
                string name = "";
                string address = "";
                string phone = "";
                string mobile = "";
                string establish = "";

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from print_head", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    name = read[1].ToString();
                    address = read[2].ToString();
                    phone = read[3].ToString();
                    mobile = read[4].ToString();
                    establish = read[5].ToString();
                    MemoryStream ms = new MemoryStream((byte[])read[6]);
                    logo = Image.FromStream(ms);
                    try
                    {

                        // Convert Image to byte[]

                        byte[] imageBytes = ms.ToArray();

                        // Convert byte[] to Base64 String
                        base64String = Convert.ToBase64String(imageBytes);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                ReportParameterCollection r = new ReportParameterCollection();
                r.Add(new ReportParameter("name", name.ToString()));
                r.Add(new ReportParameter("address", address.ToString()));
                r.Add(new ReportParameter("phone", phone.ToString()));
                r.Add(new ReportParameter("mobile", mobile.ToString()));
                r.Add(new ReportParameter("establish", establish.ToString()));
                r.Add(new ReportParameter("logo", base64String.ToString()));

                this.reportViewer1.LocalReport.SetParameters(r);
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                Admission_receipt_Print arp = new Admission_receipt_Print(patient_id.Text);
                arp.Show();
            }
            catch
            { 
            
            }
        }

        void show_due_list()
        {
            try
            {
                int a = 0;
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select [reg_no],[name],[total],[discount],((total-discount-due)+due_paid),(due-due_paid),date from user_cash_collection_hospital where due>'" + a + "' and type='Discharge Bill' and due_paid<due", db.sql);
                dataGridView8.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView8.Rows.Add();
                    dataGridView8.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView8.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView8.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView8.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView8.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView8.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView8.Rows[n].Cells[6].Value = item[6].ToString();
             
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        }

        private void dataGridView8_Click(object sender, EventArgs e)
        {
            try
            {
                due_date = dataGridView8.SelectedRows[0].Cells[6].Value.ToString();
                label84.Text = dataGridView8.SelectedRows[0].Cells[0].Value.ToString();
                label86.Text = dataGridView8.SelectedRows[0].Cells[5].Value.ToString();
                richTextBox22.Text = dataGridView8.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch
            { 
            
            }
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            try
            {
                double old = 0;
                double payment=Convert.ToDouble(richTextBox22.Text);
                double new_payment = 0;
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                DialogResult r = MessageBox.Show("Did you get the due amount","?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmm = new SqlCommand("select due_paid from user_cash_collection_hospital where reg_no='" + label84.Text + "' and type='Discharge Bill'", db.sql);
                    SqlDataReader red = cmm.ExecuteReader();
                    while (red.Read())
                    {
                        old = Convert.ToDouble(red[0]);
                    }
                    new_payment = old + payment;
                    db.sql.Close();
                    db.sql.Open();


                    SqlCommand cmd = new SqlCommand("insert into hospital_due_collection(reg_no,due_paid,discount2,date,date2,user_name,password)values('" + label84.Text + "','" + richTextBox22.Text + "','" + label57.Text + "','" + date + "','" + dd + "','"+user_name+"','"+password+"')", db.sql);
                    SqlCommand cmd2 = new SqlCommand("update user_cash_collection_hospital set due_paid='" +new_payment+ "' where reg_no='" + label84.Text + "' and type='Discharge Bill'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Due collected Sucessfully");
                        Hospita_Due_Collection_Print due = new Hospita_Due_Collection_Print(label84.Text, richTextBox22.Text, user_name);
                        due.Show();
                        show_due_list();
                    }

                    db.sql.Close();
                }

            }
            catch
            { 
            
            }
        }

        private void richTextBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                double a = Convert.ToDouble(label49.Text);
                double b = Convert.ToDouble(label47.Text);
                double c = Convert.ToDouble(richTextBox17.Text);
              
                double ans = a - (b + c);
                label52.Text = ans.ToString();
                if (richTextBox17.Text == "")
                {
                    richTextBox17.Text = "0";
                }
            }
            catch
            { 
            
            }

        }

        private void richTextBox22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a =Convert.ToDouble(label86.Text);
                double b = Convert.ToDouble(richTextBox22.Text);
                double c = a - b;
                label57.Text = c.ToString();
            }
            catch
            { 
            
            }
        }

        private void prescription_id_TextChanged(object sender, EventArgs e)
        {
         
            try
            {
                string name = "";
                string contact = "";
                string age = "";
                string gender = "";
                string address = "";
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from appointment where reg_no='" + prescription_id.Text+ "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                    name = read[1].ToString();
                   
                    age = read[3].ToString();
                    gender = read[4].ToString();
                    address = read[2].ToString();
                }
                if (c > 0)
                {
                    richTextBox1.Text = name;
                    comboBox2.Text = gender;
                    richTextBox7.Text = age;
                    richTextBox3.Text = address;
                }
                else
                {
                    richTextBox1.Text = "";
                    comboBox2.Text = "";
                    richTextBox7.Text = "";
                    richTextBox3.Text = "";
                }
                db.sql.Close();

            }
            catch
            {
                richTextBox1.Text = "";
                comboBox2.Text = "";
                richTextBox7.Text = "";
                richTextBox3.Text = "";
            }
        
        }

        private void richTextBox23_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (opd.Text == "")
                {
                    richTextBox1.Clear();
                    richTextBox2.Clear();
                    richTextBox3.Clear();
                    richTextBox10.Clear();
                    richTextBox4.Clear();
                    richTextBox8.Clear();
                    richTextBox9.Clear();

                    comboBox2.Text = "";

                    richTextBox7.Clear();
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                }
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from opd where reg_no='" + opd.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    richTextBox1.Text = read[1].ToString();
                    richTextBox2.Text = read[2].ToString();
                    comboBox2.Text = read[3].ToString();
                    richTextBox7.Text = read[4].ToString();
                    richTextBox3.Text = read[5].ToString();

                    richTextBox10.Text = read[8].ToString();
                    richTextBox4.Text = read[9].ToString();
                    richTextBox8.Text = read[10].ToString();
                    richTextBox9.Text = read[11].ToString();
                    comboBox3.Text = read[12].ToString();
                    comboBox4.Text = read[13].ToString();

                    string date = read[6].ToString();
                    //   update_time = read[7].ToString();

                    DateTime convert = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dateTimePicker1.Text = convert.ToString();

                }

                db.sql.Close();
            }
            catch
            {

            }
        }

        private void dataGridView7_MouseUp(object sender, MouseEventArgs e)
        {
           take_bill_edit_id = dataGridView7.SelectedRows[0].Cells[4].Value.ToString();
           
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Single_Collection_Print usp = new User_Single_Collection_Print(take_bill_edit_id, richTextBox13.Text);
            usp.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Do You want to Delete this?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (user_type == "Admin")
                    {
                        db.sql.Close();
                        db.sql.Open();
                        SqlCommand cmd = new SqlCommand("delete from user_cash_collection_hospital where id='" + take_bill_edit_id + "'", db.sql);
                        int a=cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Delete Sucessfull");
                          
                            operation_bill_calculate();
                            bill_calculate2();
                            total_bill_taken_show();

                        }
                        db.sql.Close();
                    }
                    else
                    {
                        MessageBox.Show("Only Admin Can Delete");
                    }
                }
            }
            catch
            { 
            
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string tk = "";
                
                Update_Single_User_Cash_Collection log = new Update_Single_User_Cash_Collection(take_bill_edit_id);
                log.ShowDialog();
                tk = log.val1;
                if (tk == "")
                {

                }
                else
                {
                    try
                    {
                        if (user_type == "Admin")
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd = new SqlCommand("update user_Cash_collection_hospital set paid='" + tk + "' where id='" + take_bill_edit_id + "'", db.sql);
                            int a = cmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("Update Sucesshull");
                                operation_bill_calculate();
                                bill_calculate2();
                                total_bill_taken_show();

                            }
                            db.sql.Close();
                        }
                        else
                        {
                            MessageBox.Show("Only Admin Can Delete");
                        
                        }
                    }
                    catch
                    {
 
                    }
                
               
                   
                }
            }
            catch
            { 
            
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmdddd = new SqlCommand("insert into user_cash_collection_hospital(user_name,password,reg_no,name,paid,date,type,date2) values('" + user_name + "','" + password + "','" + richTextBox13.Text + "','" + richTextBox12.Text + "','" + richTextBox23.Text + "','" + date + "','Advanced','" + dd + "')", db.sql);
                int a = cmdddd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Advanced Taken Sucessfull");
                   
                    bill_calculate2();
                    total_bill_taken_show();
                }
                db.sql.Close();
            }
            catch
            { 
            
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmddddd = new SqlCommand("insert into user_cash_collection_hospital(user_name,password,reg_no,name,paid,date,type,date2) values('" + user_name + "','" + password + "','" + richTextBox13.Text + "','" + richTextBox12.Text + "','" + richTextBox24.Text + "','" + date + "','Admission Fee','" + dd + "')", db.sql);
                int a = cmddddd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Admission Fee Taken Sucessfull");
                    
                    bill_calculate2();
                    total_bill_taken_show();
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void dataGridView5_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView5_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int exe = 0;
                int id = 0; ;
                string val1 = "";
                string val2 = "";
                string val3 = "";
                string val4 = "";
                int n = 0;
                int c = dataGridView5.Rows.Count;
                db.sql.Close();
                db.sql.Open();
                for (n = 0; n <= c - 1; n++)
                {
                    val1 = dataGridView5.Rows[n].Cells[0].Value.ToString();
                    val3 = dataGridView5.Rows[n].Cells[2].Value.ToString();
                    val4 = dataGridView5.Rows[n].Cells[3].Value.ToString();
                    SqlCommand cmd = new SqlCommand("update patient_bill set bill_title='" + val1 + "',bill='" + val3 + "' where id='" + val4 + "'", db.sql);
                    exe = cmd.ExecuteNonQuery();

                }
                db.sql.Close();
            }
            catch
            {

            }


            try
            {

                int sum = 0;
                for (int i = 0; i < dataGridView5.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView5.Rows[i].Cells[2].Value);
                }
                label55.Text = sum.ToString();
                label49.Text = sum.ToString();
            }
            catch
            {

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from refer_doctor where name='" + comboBox3.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                // comboBox1.Items.Clear();
                while (read.Read())
                {
                    String name = read[1].ToString();
                    String desig = read[2].ToString();

                    consultant = name + "," + desig;
                    // refere_doctor();
                }

                db.sql.Close();
            }

            catch
            {


            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from doctors where name='" + comboBox4.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                // comboBox1.Items.Clear();
                while (read.Read())
                {
                    String name = read[1].ToString();
                    String desig = read[2].ToString();

                    referance = name;
                    // refere_doctor();
                }

                db.sql.Close();
            }

            catch
            {


            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            show_bill_list();
        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            previlege pv = new previlege();
            pv.Show();
        }

        private void richTextBox27_TextChanged(object sender, EventArgs e)
        {
            show_card_details();
        }

        void show_card_details()
        {
            try
            {

                dateTimePicker1.Text = DateTime.Now.ToShortDateString();

                db.sql.Close();
                db.sql.Open();
                int loop = 0;
                SqlCommand cmd = new SqlCommand("select * from card_details where reg_no='" + richTextBox27.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    loop++;

                    richTextBox1.Text = read[3].ToString();
                    richTextBox2.Text = read[5].ToString();
                    
                    richTextBox7.Text = read[4].ToString();
                    richTextBox3.Text = read[6].ToString();

                    DateTime convert = DateTime.ParseExact(read[1].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime convert2 = DateTime.ParseExact(read[2].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);



                    string todays = DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime today = DateTime.ParseExact(todays, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var totaldays = (convert2 - today).TotalDays;
                    if (totaldays < 0)
                    {
                        label100.Visible = true;
                        label102.Visible = false;
                    }
                    else
                    {
                        label102.Visible = true;
                        label100.Visible = false;
                    }

                    if (read[11].ToString() == "F")
                    {
                        label101.Visible = true;
                        label99.Visible = false;
                    }
                    else
                    {
                        label101.Visible = false;
                        label99.Visible = true;
                    }


                }
                if (loop == 0)
                {
                    richTextBox1.Clear();
                    richTextBox2.Clear();
                    richTextBox3.Clear();
                    richTextBox10.Clear();
                    richTextBox4.Clear();
                    richTextBox8.Clear();
                    richTextBox9.Clear();

                    comboBox2.Text = "";
                    label99.Visible = false; label100.Visible = false; label101.Visible = false; label102.Visible = false;
                    richTextBox7.Clear();
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Print_Hospital_Patient ph = new Print_Hospital_Patient();
            ph.Show();
        }

    }
}
