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
using System.IO;

namespace Diagnostic_Center
{
    public partial class Add_Employee : Form
    {
        Image im,em_sig,nom_sig,nom_im;
        connection db = new connection();
       
        public Add_Employee(string x)
        {
            InitializeComponent();
            textBox1.Text = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                if (od.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(od.FileName);

                }
            }
            catch
            
            {
            
            }
        }
        //insert
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into employee(employee_id,name,f_name,m_name,gender,birth_date,post_code,thana,zela,city,phone,nid,job_post,department,salary,additional,joining_date,image,nom_im,em_sig,nom_sig,nom_name,edu,marital,security,type_of_stuff,stuff_grade,blood,bank_ac,resign_date,pf_start_date,pf_amount)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + dateTimePicker2.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox5.Text + "','" + textBox10.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + dateTimePicker1.Text + "',@Image,@nom_im,@em_sig,@nom_sig,'" + textBox17.Text + "','" + textBox28.Text + "','" + comboBox2.Text + "','" + textBox11.Text + "','" + textBox26.Text + "','" + textBox27.Text + "','" + textBox25.Text + "','" + textBox24.Text + "','" + dateTimePicker4.Text + "','" + dateTimePicker5.Text + "','" + textBox21.Text + "')", db.sql);
                cmd.Parameters.AddWithValue("@Image", save());
                cmd.Parameters.AddWithValue("@nom_im", save1());
                cmd.Parameters.AddWithValue("@em_sig", save3());
                cmd.Parameters.AddWithValue("@nom_sig", save2());
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Information Saved Sucessfull");
                }
                db.sql.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
        public byte[] save()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms,pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        public byte[] save1()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
            return ms.GetBuffer();
        }
        public byte[] save2()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox4.Image.Save(ms, pictureBox4.Image.RawFormat);
            return ms.GetBuffer();
        }
        public byte[] save3()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }


        //show
        void show_employee()
        {
            try
            {
                int cc = 0;
                string a = "";
                string b = "";
                string c = "";
                string d = "";
                string ee = "";
                string f= "";
                string g = "";
                string h = "";
                string i = "";
                string j = "";
                string k = "";
                string l = "";
                string m = "";
                string n = "";
                string o = "";
                string p = "";
                string q = "";
                string r = "";
                //new added
                string edu = "";
                string pf_start_date = "";
                string pf_amount = "";
                string nom_name = "";
                string resign_date = "";
                string bank_ac = "";
                string blood = "";
                string stuff_grade = "";
                string type_of_stuff = "";
                string security = "";
                string marital = "";
               
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from employee where employee_id='"+textBox1.Text+"'",db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cc++;
                    a = read[0].ToString();
                    b = read[1].ToString();
                    c = read[2].ToString();
                    d = read[3].ToString();
                    ee = read[4].ToString();
                    f = read[5].ToString();
                    g = read[6].ToString();
                    h = read[7].ToString();
                    i = read[8].ToString();
                    j = read[9].ToString();
                    k = read[10].ToString();
                    l = read[11].ToString();
                    m = read[12].ToString();
                    n = read[13].ToString();
                    o = read[14].ToString();
                    p = read[15].ToString();
                    q = read[16].ToString();
                    r = read[28].ToString();
                    MemoryStream ms = new MemoryStream((byte[])read[17]);
                    im = Image.FromStream(ms);

                    //new added
                    
                    marital = read[20].ToString();
                    security = read[21].ToString();
                    type_of_stuff = read[22].ToString();
                    stuff_grade = read[23].ToString();
                    blood = read[24].ToString();
                    bank_ac = read[25].ToString();
                    resign_date = read[26].ToString();
                    nom_name = read[27].ToString();
                    pf_start_date = read[28].ToString();
                    pf_amount = read[29].ToString();
                    edu = read[30].ToString();
                    

                    MemoryStream ms1 = new MemoryStream((byte[])read[18]);
                    nom_im = Image.FromStream(ms1);
                    MemoryStream ms2 = new MemoryStream((byte[])read[19]);
                    em_sig = Image.FromStream(ms2);
                    MemoryStream ms3 = new MemoryStream((byte[])read[31]);
                    nom_sig = Image.FromStream(ms3);

                }
               
                if (cc > 0)
                {
                   // textBox1.Text = a;
                    textBox2.Text = b;
                    textBox3.Text = c;
                    textBox4.Text = d;
                    comboBox1.Text = ee;
                    dateTimePicker2.Text = f;
                    textBox6.Text = g;
                    textBox7.Text = h;
                    textBox8.Text = i;
                    textBox9.Text = j;
                    textBox5.Text = k;
                    textBox10.Text = l;
                    textBox12.Text = m;
                    textBox13.Text = n;
                    textBox14.Text = o;
                    textBox15.Text = p;
                    dateTimePicker1.Text = q;
                    dateTimePicker5.Text = r;

                    pictureBox1.Image = im;

                    //new
                    pictureBox2.Image = em_sig;
                    pictureBox3.Image = nom_im;
                    pictureBox4.Image = nom_sig;
                    
                     comboBox2.Text = marital;
                     textBox11.Text= security;
                     textBox26.Text= type_of_stuff;
                     textBox27.Text= stuff_grade;
                     textBox25.Text= blood;
                     textBox24.Text= bank_ac;
                     dateTimePicker4.Text= resign_date;
                     textBox17.Text= nom_name;
                     dateTimePicker5.Text= pf_start_date;
                     textBox21.Text= pf_amount;
                     textBox28.Text= edu;


                    db.sql.Close();
                }
                else
                {
                   // textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker2.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox5.Text = "";
                    textBox10.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    dateTimePicker1.Text = "";


                    pictureBox1.Image = null;

                    //new
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;

                    comboBox2.Text = "";
                    textBox11.Text = "";
                    textBox26.Text = "";
                    textBox27.Text = "";
                    textBox25.Text = "";
                    textBox24.Text = "";
                    dateTimePicker4.Text = "";
                    textBox17.Text = "";
                    dateTimePicker5.Text = "";
                    textBox21.Text = "";
                    textBox28.Text = "";
                    db.sql.Close();
                }
            }
            catch
            { }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                show_employee();
                db.sql.Close();
                db.sql.Open();
                string a = ""; string d = ""; string n = "";
                SqlCommand cmd = new SqlCommand("select * from employee_inc  where em_id='" + textBox1.Text + "' order by inc_no asc ", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    n = read[2].ToString();
                    a = read[3].ToString();
                    d = read[4].ToString();
                }

               // dateTimePicker5.Text = d;
                textBox18.Text = a;
                textBox16.Text = n;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.sql.Close();
        }
        //update
        private void button3_Click(object sender, EventArgs e)
        {
           try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("update employee set name='" + textBox2.Text + "',f_name='" + textBox3.Text + "',m_name='" + textBox4.Text + "',gender='" + comboBox1.Text + "',birth_date='" + dateTimePicker2.Text + "',post_code='" + textBox6.Text + "',thana='" + textBox7.Text + "',zela='" + textBox8.Text + "',city='" + textBox9.Text + "',phone='" + textBox5.Text + "',nid='" + textBox10.Text + "',job_post='" + textBox12.Text + "',department='" + textBox13.Text + "',salary='" + textBox14.Text + "',additional='" + textBox15.Text + "',joining_date='" + dateTimePicker1.Text + "',marital='" + comboBox2.Text + "',security='" + textBox11.Text + "',type_of_stuff='" + textBox26.Text + "',stuff_grade='" + textBox27.Text + "',blood='" + textBox25.Text + "',bank_ac='" + textBox24.Text + "',resign_date='" + dateTimePicker4.Text + "',nom_name='" + textBox17.Text + "',pf_start_date='" + dateTimePicker5.Text + "',pf_amount='" + textBox21.Text + "',edu='" + textBox28.Text + "',Image=@image,em_sig=@em_sig,nom_sig=@nom_sig,nom_im=@nom_im where employee_id='" + textBox1.Text + "'", db.sql);
                cmd.Parameters.AddWithValue("@Image", save());
                cmd.Parameters.AddWithValue("@nom_im", save1());
                cmd.Parameters.AddWithValue("@em_sig", save3());
                cmd.Parameters.AddWithValue("@nom_sig", save2());
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Update Sucessfull");
                    show_employee();
                }
            }
            catch
            { 
            
            }
            db.sql.Close();
        }
        //print
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Print_Employee_Info pei = new Print_Employee_Info(textBox1.Text);
                pei.Show();
            }
            catch
            { 
            
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                if (od.ShowDialog() == DialogResult.OK)
                {
                    pictureBox4.Image = new Bitmap(od.FileName);

                }
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                if (od.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = new Bitmap(od.FileName);

                }
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                if (od.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = new Bitmap(od.FileName);

                }
            }
            catch
            {

            }
        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("DELETE from employee where employee_id='" + textBox1.Text + "'", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("DELETE Sucessfull");
                    show_employee();
                }
            }
            catch
            {

            }
            db.sql.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd4 = new SqlCommand("select * from employee_inc where em_id='" + textBox1.Text + "' and inc_no='" + textBox16.Text + "'", db.sql);
                SqlDataReader read = cmd4.ExecuteReader();
                int ab = 0;
                while (read.Read())
                {

                    ab ++;
                }
                if (ab > 0)
                {
                    MessageBox.Show("Already Inserted !! Try UPDATE or DELETE");
                }
                else
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO employee_inc(em_id,inc_no,inc_amount,inc_date)VALUES('" + textBox1.Text + "','" + textBox16.Text + "','" + textBox18.Text + "','" + dateTimePicker3.Text + "')", db.sql);
                    int a = cmd2.ExecuteNonQuery();
                    if (a > 0)
                    {
                        int inc = Convert.ToInt32(textBox18.Text);
                        SqlCommand cmd11 = new SqlCommand("UPDATE employee set salary +='" + inc + "' where employee_id='" + textBox1.Text + "'  ", db.sql);
                        int a1 = cmd11.ExecuteNonQuery();
                        MessageBox.Show("INSERT Sucessfull");
                        show_employee();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.sql.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("DELETE from employee_inc where em_id='" + textBox1.Text + "' and inc_no='" + textBox16.Text + "' ", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    int inc = Convert.ToInt32(textBox18.Text);
                    SqlCommand cmd11 = new SqlCommand("UPDATE employee set salary -='" + inc + "' where employee_id='" + textBox1.Text + "'  ", db.sql);
                    int a1 = cmd11.ExecuteNonQuery();
                    MessageBox.Show("DELETE Sucessfull");
                    show_employee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.sql.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd4 = new SqlCommand("select inc_amount from employee_inc where em_id='" + textBox1.Text + "' and inc_no='" + textBox16.Text + "'", db.sql);
                SqlDataReader read = cmd4.ExecuteReader();
                string old_inc = "";
                while (read.Read())
                {

                    old_inc = read[0].ToString();
                }
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("update employee_inc set inc_amount='" + textBox18.Text + "' where inc_no='" + textBox16.Text + "' and em_id='" + textBox1.Text + "'  ", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    int inc = Convert.ToInt32(textBox18.Text);
                    SqlCommand cmd11 = new SqlCommand("UPDATE employee set salary -='" + old_inc + "' where employee_id='" + textBox1.Text + "'  ", db.sql);
                    int a1 = cmd11.ExecuteNonQuery();
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd111 = new SqlCommand("UPDATE employee set salary +='" + inc + "' where employee_id='" + textBox1.Text + "'  ", db.sql);
                    int a11 = cmd111.ExecuteNonQuery();
                    MessageBox.Show("UPDATE Sucessfull");
                    show_employee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.sql.Close();
        }
    }
}
