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
    public partial class Card_Registration : Form
    {
        connection db = new connection();
        string type;
        public Card_Registration()
        {
            InitializeComponent();
            datagrid_fill();
        }
        //DATAGRID FILL
        void datagrid_fill()
        {
            try
            {
                richTextBox2.Text = "";
                richTextBox3.Text = "";
                richTextBox4.Text = "";
                richTextBox5.Text = "";
                richTextBox6.Text = "";
                richTextBox7.Text = "";
                richTextBox8.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(5);
                dataGridView1.Rows[0].Cells[0].Value = "1";
                dataGridView1.Rows[1].Cells[0].Value = "2";
                dataGridView1.Rows[2].Cells[0].Value = "3";
                dataGridView1.Rows[3].Cells[0].Value = "4";
                dataGridView1.Rows[4].Cells[0].Value = "5";
                dataGridView1.Rows[0].Cells[4].Value = "গর্ভকালীন সেবা";
                dataGridView1.Rows[1].Cells[4].Value = "প্রসবোত্তর সেবা ও অন্যান্য সাধারণ রোগের চিকিৎসা ";
                dataGridView1.Rows[2].Cells[4].Value = "বিশেষজ্ঞ চিকিৎসা সেবা ";
                dataGridView1.Rows[3].Cells[4].Value = "সকল প্রকার ল্যাবরেটরী পরীক্ষা নিরীক্ষা";
                dataGridView1.Rows[4].Cells[4].Value = "সকল প্রকার অপারেশন ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SAVE
        void save_card()
        {
            try
            {
                string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                
                if (type == "F")
                {
                    SqlCommand cmd = new SqlCommand("insert into card_details(reg_no,issue_date,expire_date,owner_name,age,mobile,address,seller_name,seller_title,price,date2,card_type)values(N'" + richTextBox1.Text + "',N'" + dateTimePicker1.Text + "',N'" + dateTimePicker2.Text + "',N'" + richTextBox2.Text + "',N'" + richTextBox3.Text + "',N'" + richTextBox5.Text + "',N'" + richTextBox6.Text + "',N'" + richTextBox7.Text + "',N'" + richTextBox8.Text + "',N'" + richTextBox4.Text + "',N'" + dd + "','F')", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Family Card Registration Sucessfull");
                    }
                }
                else if (type == "P")
                {
                    SqlCommand cmd = new SqlCommand("insert into card_details(reg_no,issue_date,expire_date,owner_name,age,mobile,address,seller_name,seller_title,price,date2,card_type)values(N'" + richTextBox1.Text + "',N'" + dateTimePicker1.Text + "',N'" + dateTimePicker2.Text + "',N'" + richTextBox2.Text + "',N'" + richTextBox3.Text + "',N'" + richTextBox5.Text + "',N'" + richTextBox6.Text + "',N'" + richTextBox7.Text + "',N'" + richTextBox8.Text + "',N'" + richTextBox4.Text + "',N'" + dd + "','P')", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Pregnency Card Registration Sucessfull");
                    }
                }
                else
                {
                    MessageBox.Show("SELECT CARD TYPE");
                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SAVE CARD SERVICE
        void save_card_service()
        {

            try
            {
                int exe = 0;
                int id = 0; ;
                string val1 = "";
                string val2 = "";
                string val3 = "";
                string val4 = "";
                string val5 = "";
                int n = 0;
                int c = dataGridView1.Rows.Count;
                db.sql.Close();
                db.sql.Open();
                for (n = 0; n < c; n++)
                {
                    try
                    {
                        val1 = Convert.ToString(dataGridView1.Rows[n].Cells[0].Value);
                    }
                    catch
                    {
                        val1 = "";
                    }
                    try
                    {
                        val2 = Convert.ToString(dataGridView1.Rows[n].Cells[1].Value);
                    }
                    catch
                    {
                        val2 = "";
                    }
                    try
                    {
                        val3 = Convert.ToString(dataGridView1.Rows[n].Cells[2].Value);
                    }
                    catch
                    {
                        val3 = "";
                    }
                    try
                    {
                        val4 = Convert.ToString(dataGridView1.Rows[n].Cells[3].Value);
                    }
                    catch
                    {
                        val4 = "";
                    }
                    try
                    {
                        val5 = Convert.ToString(dataGridView1.Rows[n].Cells[4].Value);

                    }
                    catch
                    {
                        val5 = "";
                    }
                    if(type == "F"){
                        SqlCommand cmd = new SqlCommand("insert into card_service(reg_no,sl,name,age,relation,service,card_type)values(N'" + richTextBox1.Text + "',N'" + val1 + "',N'" + val2 + "',N'" + val3 + "',N'" + val4 + "',N'" + val5 + "','F')", db.sql);
                        exe = cmd.ExecuteNonQuery();
                    }
                    else if (type == "P") {
                        SqlCommand cmd = new SqlCommand("insert into card_service(reg_no,sl,name,age,relation,service,card_type)values(N'" + richTextBox1.Text + "',N'" + val1 + "',N'" + val2 + "',N'" + val3 + "',N'" + val4 + "',N'" + val5 + "','P')", db.sql);
                        exe = cmd.ExecuteNonQuery();
                    }
                    else{
                       
                    }
                    

                }
                db.sql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //UPDATE CARD SERVICE
        void update_card_service()
        {
            try
            {
                int exe = 0;
                int id = 0; ;
                string val1 = "";
                string val2 = "";
                string val3 = "";
                string val4 = "";
                string val5 = "";
                int n = 0;
                int c = dataGridView1.Rows.Count;
                db.sql.Close();
                db.sql.Open();
                for (n = 0; n < c; n++)
                {

                    try
                    {
                        val1 = Convert.ToString(dataGridView1.Rows[n].Cells[0].Value);
                    }
                    catch
                    {
                        val1 = "";
                    }
                    try
                    {
                        val2 = Convert.ToString(dataGridView1.Rows[n].Cells[1].Value);
                    }
                    catch
                    {
                        val2 = "";
                    }
                    try
                    {
                        val3 = Convert.ToString(dataGridView1.Rows[n].Cells[2].Value);
                    }
                    catch
                    {
                        val3 = "";
                    }
                    try
                    {
                        val4 = Convert.ToString(dataGridView1.Rows[n].Cells[3].Value);
                    }
                    catch
                    {
                        val4 = "";
                    }
                    try
                    {
                        val5 = Convert.ToString(dataGridView1.Rows[n].Cells[4].Value);

                    }
                    catch
                    {
                        val5 = "";
                    }

                    
                    if (type == "F")
                    {
                        SqlCommand cmd = new SqlCommand("update card_service set name=N'" + val2 + "',age=N'" + val3 + "',relation=N'" + val4 + "',service=N'" + val5 + "',card_type='F' where reg_no=N'" + richTextBox1.Text + "' and sl=N'" + val1 + "'", db.sql);
                        exe = cmd.ExecuteNonQuery();
                    }
                    else if (type == "P")
                    {
                        SqlCommand cmd = new SqlCommand("update card_service set name=N'" + val2 + "',age=N'" + val3 + "',relation=N'" + val4 + "',service=N'" + val5 + "',card_type='P' where reg_no=N'" + richTextBox1.Text + "' and sl=N'" + val1 + "'", db.sql);
                        exe = cmd.ExecuteNonQuery();
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
        //UPDATE CARD DETAILS
        void update_card_details()
        {

            try
            {
                db.sql.Close();
                db.sql.Open();
                
                if (type == "F")
                {
                    SqlCommand cmd = new SqlCommand("update card_details set card_type='F',issue_date='" + dateTimePicker1.Text + "',expire_date='" + dateTimePicker2.Text + "', owner_name=N'" + richTextBox2.Text + "',age=N'" + richTextBox3.Text + "',mobile=N'" + richTextBox5.Text + "',address=N'" + richTextBox6.Text + "',seller_name=N'" + richTextBox7.Text + "',seller_title=N'" + richTextBox8.Text + "',price=N'" + richTextBox4.Text + "' where reg_no=N'" + richTextBox1.Text + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Family card Update Sucessfull");
                    }
                }
                else if (type == "P")
                {
                    SqlCommand cmd = new SqlCommand("update card_details set card_type='P',issue_date='" + dateTimePicker1.Text + "',expire_date='" + dateTimePicker2.Text + "', owner_name=N'" + richTextBox2.Text + "',age=N'" + richTextBox3.Text + "',mobile=N'" + richTextBox5.Text + "',address=N'" + richTextBox6.Text + "',seller_name=N'" + richTextBox7.Text + "',seller_title=N'" + richTextBox8.Text + "',price=N'" + richTextBox4.Text + "' where reg_no=N'" + richTextBox1.Text + "'", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Pregnency Card Update Sucessfull");
                    }
                }
                else
                {

                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //SHOW CARD VALIDITY
        void show_card_details()
        {
            try
            {
                richTextBox2.Text = "";
                richTextBox3.Text = "";
                richTextBox5.Text = "";

                richTextBox6.Text = "";
                richTextBox7.Text = "";
                richTextBox8.Text = "";
                richTextBox4.Text = "";
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
                dateTimePicker2.Text = DateTime.Now.ToShortDateString();
                db.sql.Close();
                db.sql.Open();
                int loop = 0;
                SqlCommand cmd = new SqlCommand("select * from card_details where reg_no='" + richTextBox1.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    loop++;
                    richTextBox2.Text = read[3].ToString();
                    richTextBox3.Text = read[4].ToString();
                    richTextBox5.Text = read[5].ToString();

                    richTextBox6.Text = read[6].ToString();
                    richTextBox7.Text = read[7].ToString();
                    richTextBox8.Text = read[8].ToString();
                    richTextBox4.Text = read[9].ToString();
                    DateTime convert = DateTime.ParseExact(read[1].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime convert2 = DateTime.ParseExact(read[2].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dateTimePicker1.Text = convert.ToString();
                    dateTimePicker2.Text = convert2.ToString();


                    string todays = DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime today = DateTime.ParseExact(todays, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var totaldays = (convert2 - today).TotalDays;
                    if (totaldays < 0)
                    {
                        label11.Text = "Card Expired";
                        label11.ForeColor = Color.Red;
                    }
                    else
                    {
                        label11.Text = "Card Validate";
                        label11.ForeColor = Color.Green;
                    }

                    string check = read[11].ToString();
                    if (check == "F") {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else{
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                }
                if (loop == 0)
                {
                    datagrid_fill();
                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SHOW CARD SERVICE
        void show_card_service()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from card_service where reg_no=N'" + richTextBox1.Text + "'", db.sql);
                dataGridView1.Rows.Clear();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int loop=0;
                foreach (DataRow item in dt.Rows)
                {
                    loop++;
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();

                }
                db.sql.Close();
                if (loop == 0)
                {
                    datagrid_fill();
                }
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from card_details where reg_no='" + richTextBox1.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;

                }
                if (c > 0)
                {
                    MessageBox.Show("Already added");
                }
                else
                {
                    save_card();
                    save_card_service();
                }
                db.sql.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datagrid_fill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update_card_details();
            update_card_service();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label11.Text = "";
            show_card_details();
            show_card_service();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "F";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = "P";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("DELETE from card_details where reg_no='" + richTextBox1.Text + "'", db.sql);
                int exe = cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("DELETE from card_service where reg_no='" + richTextBox1.Text + "'", db.sql);
                int exe1 = cmd1.ExecuteNonQuery();
                datagrid_fill();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("SELECT CARD HOLDER FIRST");
            }
            else
            {
                string s = richTextBox1.Text;
                card_prints cp = new card_prints(s);
                cp.Show();
            }
        }

    }
}
