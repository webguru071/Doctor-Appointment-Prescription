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
    public partial class Author_Settings : Form
    {
        Image im;
        connection db = new connection();
        public Author_Settings()
        {
            InitializeComponent();
            show_info();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            {
                int c =0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from print_head",db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                }
                if (c > 0)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand up = new SqlCommand("update print_head set hospital_name='"+richTextBox1.Text+"',address='"+richTextBox2.Text+"',phone='"+richTextBox3.Text+"',reg_no='"+richTextBox4.Text+"',establish='"+richTextBox5.Text+"',logo=@image",db.sql);
                    up.Parameters.AddWithValue("@image", save());
                    int a=up.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Update Sucessfull");
                    }
                    db.sql.Close();
                }
                else
                {
                  /*  db.sql.Close();
                    db.sql.Open();
                    SqlCommand save = new SqlCommand("",db.sql);
                    db.sql.Close();*/
                }
                db.sql.Close();
            }
          /*  catch
            { 
            
            }*/
        }

        public byte[] save()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
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

        void show_info()
        {
            try
            {
                int cc = 0;
                string a = "";
                string b = "";
                string c = "";
                string d = "";
                string ee = "";
                string f = "";
                string g = "";
                string h = "";
               
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from print_head",db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cc++;
                    a = read[1].ToString();
                    b = read[2].ToString();
                    c = read[3].ToString();
                    d = read[4].ToString();
                    ee = read[5].ToString();

                    try
                    {
                        MemoryStream ms = new MemoryStream((byte[])read[6]);
                        im = Image.FromStream(ms);
                    }
                    finally
                    { 
                    
                    }
                }
                if (cc > 0)
                {
                    richTextBox1.Text = a;
                    richTextBox2.Text = b;
                    richTextBox3.Text = c;
                    richTextBox4.Text = d;
                    richTextBox5.Text = ee;
                    pictureBox1.Image = im;
                }
                db.sql.Close();
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
