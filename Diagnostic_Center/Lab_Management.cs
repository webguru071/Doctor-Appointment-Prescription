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
    public partial class Lab_Management : Form
    {
        connection db = new connection();
        public Lab_Management()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void richTextBox42_TextChanged(object sender, EventArgs e)
        {
         //   try
            {
               
                show_diagnostic_test();
                show_xray();
                xray2();
                show_ultrasono();
                show_ultrasono_male();
                show_ultrasono_pregnency();
                show_ultrasono_text();
                show_urine_chemical();
                show_urine_micro();
                show_urine_phy();
                show_hematology();
                show_immunology();
                show_stool();
               /* show_report();
                
                
                show_blood_report();
                show_serum_report();
              
            
                show_ba();
               */
            }
           /* catch
            {

            }*/
        }


        void show_diagnostic_test()
        {

            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from diagnostic_bill where  invoice_id=N'" + richTextBox42.Text + "'", db.sql);
                DataTable dt = new DataTable();
                dataGridViewX3.Rows.Clear();
                sda.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    int nn = dataGridViewX3.Rows.Add();
                    dataGridViewX3.Rows[nn].Cells[0].Value = item[1].ToString();

                }
                db.sql.Close();

                string name = "";
                db.sql.Close();
                db.sql.Open();

                SqlCommand cmd = new SqlCommand("select name from diagnostic_person where id=N'" + richTextBox42.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {

                    name = r[0].ToString();
                   

                }
                richTextBox41.Text = name;
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save_xray();
        }

        void save_xray()
        {
            int x = 0;
            int y = 0;
            try
            {
                if (richTextBox42.Text == "" )
                {
                    MessageBox.Show("Registration Nomust needed");
                }
                else
                {

                    int n = 0;

                    string val1 = "";
                    string val2 = "";

                    int c = dataGridViewX2.Rows.Count;

                    for (n = 0; n <= c - 2; n++)
                    {
                        int cc = 0;
                        db.sql.Close();
                        db.sql.Open();
                        val1 = dataGridViewX2.Rows[n].Cells[0].Value.ToString();
                        val2 = dataGridViewX2.Rows[n].Cells[1].Value.ToString();



                        SqlCommand cmd = new SqlCommand("select * from xray_report where reg_no='" + richTextBox42.Text + "'  and test_name='" + val1 + "'", db.sql);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            cc++;

                        }


                        if (cc > 0)
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd2 = new SqlCommand("update xray_report set test_name='" + val1 + "', result='" + val2 + "',title='" + richTextBox2.Text + "',comment='" + richTextBox3.Text + "' where reg_no='" + richTextBox42.Text + "' and test_name='" + val1 + "'", db.sql);
                            x = cmd2.ExecuteNonQuery();


                        }

                        else
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into xray_report(reg_no,title,test_name,result,comment)values('" + richTextBox42.Text + "','" + richTextBox2.Text + "','" + val1 + "','" + val2 + "','" + richTextBox3.Text + "')", db.sql);
                            y = cmd1.ExecuteNonQuery();


                        }


                    }
                    if (x > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                    }
                    if (y > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                    }
                    db.sql.Close();
                }
            }
            catch
            {

            }

        }


        //*********************************************xray*****************

        void show_xray()
        {

            try
            {
                int c = 0;
                string title = "";
                string comment = "";
                db.sql.Close();
                db.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select * from xray_report where reg_no='" + richTextBox42.Text + "'", db.sql);
                DataTable dt = new DataTable();
                dataGridViewX2.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX2.Rows.Add();
                    dataGridViewX2.Rows[n].Cells[0].Value = item[2].ToString();
                    dataGridViewX2.Rows[n].Cells[1].Value = item[3].ToString();


                }
                db.sql.Close();

                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select title,comment from xray_report  where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    c++;
                    title = r[0].ToString();
                    comment = r[1].ToString();
                }
                if (c > 0)
                {
                    richTextBox2.Text = title;
                    richTextBox3.Text = comment;
                }
                else
                {
                    richTextBox2.Clear();
                    richTextBox3.Clear();
                }
                db.sql.Close();
            }
            catch
            {

            }

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = comboBox9.Text;
                dataGridViewX2.Rows.Clear();
                dataGridViewX2.Rows.Add(7);
                dataGridViewX2.Rows[0].Cells[0].Value = "TRACHEA-";
                dataGridViewX2.Rows[1].Cells[0].Value = "HEART-";
                dataGridViewX2.Rows[2].Cells[0].Value = "LUNG-";
                dataGridViewX2.Rows[3].Cells[0].Value = "COSTO-PHRENIC ANGLE-";
                dataGridViewX2.Rows[4].Cells[0].Value = "DIAPHRAGM-";
                dataGridViewX2.Rows[5].Cells[0].Value = "ANGLE-";
                dataGridViewX2.Rows[6].Cells[0].Value = "BONY CASE-";
                dataGridViewX2.Rows[0].Cells[1].Value = "Clearly Placed";
                dataGridViewX2.Rows[1].Cells[1].Value = "Normal in Size";
                dataGridViewX2.Rows[2].Cells[1].Value = "Clear";
                dataGridViewX2.Rows[3].Cells[1].Value = "Clear";
                dataGridViewX2.Rows[4].Cells[1].Value = "Normal";
                dataGridViewX2.Rows[5].Cells[1].Value = "Clear";
                dataGridViewX2.Rows[6].Cells[1].Value = "No bony lesson";
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                save_xray();
                xray_report xr = new xray_report(richTextBox42.Text);
                xr.Show();
            }
            catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (DataGridViewRow row in dataGridViewX2.SelectedRows)
                {

                    dataGridViewX2.Rows.RemoveAt(row.Index);

                }
            }
            catch
            {

            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox28.Text = comboBox10.Text;
                if (comboBox10.Text == "PLAIN X-RAY ABDOMEN ECREET POSTURE")
                {
                    richTextBox27.Text = "No gas shadow seen under diaphram.\nNo fluid level detected.\nGas shadow seen in internal lumen";
                }

                else if (comboBox10.Text == "L/S SPINE B/V")
                {
                    richTextBox27.Text = "*Normal Curvature of lumber spine is maintained\n with normal vertebral alignment\n*No bony lesion ogmarginal oosteophytes are noted at\n lumber vertebrace.\n*Disc Space are Preserved.\n*Posterior arch elements are normal.\n*Both SI Joints are normal.";
                }
            }
            catch
            {

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from xray2 where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                }

                if (c > 0)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd1 = new SqlCommand("update xray2 set title='" + richTextBox28.Text + "', result='" + richTextBox27.Text + "',comment='" + richTextBox29.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                    int a = cmd1.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Update Sucess Full");
                        Xray2 x2 = new Xray2(richTextBox42.Text);
                        x2.Show();
                    }
                    db.sql.Close();
                }
                else
                {

                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into xray2(reg_no,title,result,comment)values('" + richTextBox42.Text + "','" + richTextBox28.Text + "','" + richTextBox27.Text + "','" + richTextBox29.Text + "')", db.sql);
                    int x = cmd2.ExecuteNonQuery();
                    if (x > 0)
                    {
                        MessageBox.Show("Save Sucessfull");
                       Xray2 x2 = new Xray2(richTextBox42.Text);
                      x2.Show();
                    }
                    db.sql.Close();
                }
                db.sql.Close();
            }

            catch
            {

            }
        }
        void xray2()
        {
            try
            {
                richTextBox28.Text = "";
                richTextBox27.Text = "";
                richTextBox29.Text = "";
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from xray2 where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    richTextBox28.Text = read[3].ToString();
                    richTextBox27.Text = read[4].ToString();
                    richTextBox29.Text = read[5].ToString();


                }
                db.sql.Close();
            }
            catch
            {
                richTextBox28.Text = "";
                richTextBox27.Text = "";
                richTextBox29.Text = "";
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            ultrasonolist();
        }
        void ultrasonolist()
        {
            try
            {
                dataGridViewX1.Rows.Clear();
                dataGridViewX1.Rows.Add(15);
                dataGridViewX1.Rows[0].Cells[0].Value = "Liver";
                dataGridViewX1.Rows[0].Cells[1].Value = "Normal in size 13 cm size. parenchyma homogenous.Hepatic veins are marked a prominent";
                dataGridViewX1.Rows[1].Cells[0].Value = "Gallbladder";
                dataGridViewX1.Rows[1].Cells[1].Value = "Wall <2 mm.Lumen clear";
                dataGridViewX1.Rows[2].Cells[0].Value = "IHD";
                dataGridViewX1.Rows[2].Cells[1].Value = "Not Dilated";
                dataGridViewX1.Rows[3].Cells[0].Value = "EHD (CBD)";
                dataGridViewX1.Rows[3].Cells[1].Value = "CBD not Dilated";
                dataGridViewX1.Rows[4].Cells[0].Value = "Pancreas";
                dataGridViewX1.Rows[4].Cells[1].Value = "Size normal. Parenchyma normal.MPD not dilated";
                dataGridViewX1.Rows[5].Cells[0].Value = "Spleen";
                dataGridViewX1.Rows[5].Cells[1].Value = "Size normal. Parenchyma normal";
                dataGridViewX1.Rows[6].Cells[0].Value = "Rt. Kidney";
                dataGridViewX1.Rows[6].Cells[1].Value = "Size normal. Cortex normal.Withwell cortico-medullary differentiation.No hydronephrosis.No mass. No stone";
                dataGridViewX1.Rows[7].Cells[0].Value = "Left Kidney";
                dataGridViewX1.Rows[7].Cells[1].Value = "Size normal. Cortex normal.Withwell cortico-medullary differentiation.No hydronephrosis.No mass. No stone";
                dataGridViewX1.Rows[8].Cells[0].Value = "Rt. Ureters";
                dataGridViewX1.Rows[8].Cells[1].Value = "Not Dilated";
                dataGridViewX1.Rows[9].Cells[0].Value = "Left, Ureters";
                dataGridViewX1.Rows[9].Cells[1].Value = "Not Dilated";
                dataGridViewX1.Rows[10].Cells[0].Value = "Urinary bladder";
                dataGridViewX1.Rows[10].Cells[1].Value = "Mucosal Wall <2 mm.Lumen clear";
                dataGridViewX1.Rows[11].Cells[0].Value = "Uterus";
                dataGridViewX1.Rows[11].Cells[1].Value = "Normal in size.Antiverted.Endometrium normal.Myometrium normal";
                dataGridViewX1.Rows[12].Cells[0].Value = "R. Ovary";
                dataGridViewX1.Rows[12].Cells[1].Value = "Normal size and echotecture normal.";
                dataGridViewX1.Rows[13].Cells[0].Value = "L. Ovary";
                dataGridViewX1.Rows[13].Cells[1].Value = "Normal size and echotecture normal.";
                dataGridViewX1.Rows[14].Cells[0].Value = "Cul de sac";
                dataGridViewX1.Rows[14].Cells[1].Value = "Normal";

            }
            catch
            { 
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                save_ultrasono();
                ultrasono_report ur = new ultrasono_report(richTextBox42.Text);
                ur.Show();
            }

            catch
            {

            }
        }


        void save_ultrasono()
        {
            try
            {
                int x = 0;
                int y = 0;
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Registration No  and Invoice no must needed");
                }
                else
                {

                    int n = 0;

                    string val1 = "";
                    string val2 = "";

                    int c = dataGridViewX1.Rows.Count;

                    for (n = 0; n <= c - 1; n++)
                    {
                        int cc = 0;
                        db.sql.Close();
                        db.sql.Open();
                        try
                        {
                            val1 = dataGridViewX1.Rows[n].Cells[0].Value.ToString();
                            val2 = dataGridViewX1.Rows[n].Cells[1].Value.ToString();
                        }
                        catch
                        {
                        }


                        SqlCommand cmd = new SqlCommand("select * from ultrasono where reg_no='" + richTextBox42.Text + "' and name='" + val1 + "'", db.sql);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            cc++;

                        }


                        if (cc > 0)
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd2 = new SqlCommand("update ultrasono set name='" + val1 + "', result='" + val2 + "',comment='" + richTextBox4.Text + "' where reg_no='" + richTextBox42.Text + "'  and name='" + val1 + "'", db.sql);
                            x = cmd2.ExecuteNonQuery();


                        }

                        else
                        {
                            try
                            {
                                string xx = dataGridViewX1.Rows[n].Cells[1].Value.ToString(); ;
                                if (xx == "")
                                {
                                }
                                else
                                {
                                    db.sql.Close();
                                    db.sql.Open();
                                    SqlCommand cmd1 = new SqlCommand("insert into ultrasono(reg_no,name,result,comment)values('" + richTextBox42.Text + "','" + val1 + "','" + val2 + "','" + richTextBox4.Text + "')", db.sql);
                                    y = cmd1.ExecuteNonQuery();

                                }
                            }
                            catch
                            {

                            }

                        }


                    }
                    if (x > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                    }
                    if (y > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                    }
                    db.sql.Close();
                }
            }
            catch
            {

            }

        }

        void show_ultrasono()
        {

            try
            {
                int c = 0;
                string title = "";
                string comment = "";
                db.sql.Close();
                db.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select * from ultrasono where reg_no='" + richTextBox42.Text + "'", db.sql);
                DataTable dt = new DataTable();
                dataGridViewX1.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX1.Rows.Add();
                    dataGridViewX1.Rows[n].Cells[0].Value = item[2].ToString();
                    dataGridViewX1.Rows[n].Cells[1].Value = item[3].ToString();


                }
                db.sql.Close();

                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select comment from ultrasono  where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    c++;

                    comment = r[0].ToString();
                }
                if (c > 0)
                {

                    richTextBox4.Text = comment;
                }
                else
                {

                    richTextBox4.Clear();
                }
                db.sql.Close();
            }
            catch
            {

            }

        }

        void show_ultrasono_male()
        {

            try
            {
                int c = 0;
                string title = "";
                string comment = "";
                db.sql.Close();
                db.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select * from ultrasono_male where reg_no='" + richTextBox42.Text + "'", db.sql);
                DataTable dt = new DataTable();
                dataGridViewX4.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX4.Rows.Add();
                    dataGridViewX4.Rows[n].Cells[0].Value = item[2].ToString();
                    dataGridViewX4.Rows[n].Cells[1].Value = item[3].ToString();


                }
                db.sql.Close();

                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select comment from ultrasono_male  where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    c++;

                    comment = r[0].ToString();
                }
                if (c > 0)
                {

                    richTextBox1.Text = comment;
                }
                else
                {

                    richTextBox1.Clear();
                }
                db.sql.Close();
            }
            catch
            {

            }

        }


        void show_ultrasono_pregnency()
        {

            try
            {
                int c = 0;
                string title = "";
                string comment = "";
                db.sql.Close();
                db.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select * from ultrasono_pregnency where reg_no='" + richTextBox42.Text + "'", db.sql);
                DataTable dt = new DataTable();
                dataGridViewX5.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridViewX5.Rows.Add();
                    dataGridViewX5.Rows[n].Cells[0].Value = item[2].ToString();
                    dataGridViewX5.Rows[n].Cells[1].Value = item[3].ToString();


                }
                db.sql.Close();

                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select comment from ultrasono_pregnency  where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    c++;

                    comment = r[0].ToString();
                }
                if (c > 0)
                {

                    richTextBox5.Text = comment;
                }
                else
                {

                    richTextBox5.Clear();
                }
                db.sql.Close();
            }
            catch
            {

            }

        }


        void show_ultrasono_text()
        {
            try
            {
            
                richTextBox7.Text = "";
                richTextBox6.Text = "";
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from ultrasono_text where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                   
                    richTextBox7.Text = read[2].ToString();
                    richTextBox6.Text = read[3].ToString();


                }
                db.sql.Close();
            }
            catch
            {
               
                richTextBox7.Text = "";
                richTextBox6.Text = "";
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                save_ultrasono();
            }
            catch
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select reg_no from urine_physical where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    c++;
                }
                if (c > 0)
                {

                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd1 = new SqlCommand("update urine_physical set qunality='" + textBox1.Text + "',colour='" + textBox2.Text + "',apperrance='" + textBox3.Text + "',sediment='" + textBox4.Text + "',speci_gra='" + textBox5.Text + "'", db.sql);
                    SqlCommand cmd2 = new SqlCommand("Update urine_chemical set reaction='" + textBox10.Text + "',execes='" + textBox9.Text + "',albumin='" + textBox8.Text + "',suger='" + textBox7.Text + "',bence='" + textBox6.Text + "',bile_salt='" + textBox15.Text + "',bile_pig='" + textBox14.Text + "',ketone='" + textBox13.Text + "',uro='" + textBox12.Text + "'", db.sql);
                    SqlCommand cmd3 = new SqlCommand("update urine_micro set calcium='" + textBox23.Text + "',triple='" + textBox22.Text + "',amorphous='" + textBox21.Text + "',uric='" + textBox20.Text + "',pus='" + textBox18.Text + "',rb='" + textBox17.Text + "',ep='" + textBox16.Text + "',gran='" + textBox11.Text + "',sper='" + textBox26.Text + "',tri='" + textBox25.Text + "',mucas='" + textBox24.Text + "',others='" + textBox19.Text + "'", db.sql);
                    int a = cmd1.ExecuteNonQuery();
                    int b = cmd2.ExecuteNonQuery();
                    int cc = cmd3.ExecuteNonQuery();
                    if (a > 0 && b > 0 && cc > 0)
                    {
                        MessageBox.Show("Update Sucessfull");
                       urine_report ur = new urine_report(richTextBox42.Text);
                       ur.Show();
                    }


                }
                else
                {
                    save_urine_report();
                   urine_report ur = new urine_report(richTextBox42.Text);
                    ur.Show();
                }
                db.sql.Close();
            }
            catch
            {

            }
        }
        void save_urine_report()
        {

            try
            {
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Registration No  and Invoice no must needed");
                }
                else
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("insert into urine_physical(reg_no,qunality,colour,apperrance,sediment,speci_gra)values('" + richTextBox42.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", db.sql);
                    SqlCommand cmd1 = new SqlCommand("insert into urine_chemical(reg_no,reaction,execes,albumin,suger,bence,bile_salt,bile_pig,ketone,uro)values('" + richTextBox42.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + textBox13.Text + "','" + textBox12.Text + "')", db.sql);
                    SqlCommand cmd2 = new SqlCommand("insert into urine_micro(reg_no,calcium,triple,amorphous,uric,pus,rb,ep,gran,sper,tri,mucas,others)values('" + richTextBox42.Text + "','" + textBox23.Text + "','" + textBox22.Text + "','" + textBox21.Text + "','" + textBox20.Text + "','" + textBox18.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox11.Text + "','" + textBox26.Text + "','" + textBox25.Text + "','" + textBox24.Text + "','" + textBox19.Text + "')", db.sql);
                    int a = cmd.ExecuteNonQuery();
                    int b = cmd1.ExecuteNonQuery();
                    int c = cmd2.ExecuteNonQuery();
                    if (a > 0 && b > 0 && c > 0)
                    {
                        MessageBox.Show("Report Saved Successfully");
                    }
                    db.sql.Close();

                }
            }
            catch
            {

            }
        }
        void show_urine_phy()
        {

            try
            {
                int x = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from urine_physical where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    x++;
                    string qunality = read[2].ToString();
                    string colour = read[3].ToString();
                    string app = read[4].ToString();
                    string sediment = read[5].ToString();
                    string speci = read[6].ToString();
                    textBox1.Text = qunality;
                    textBox2.Text = colour;
                    textBox3.Text = app;
                    textBox4.Text = sediment;
                    textBox5.Text = speci;

                }
                if (x == 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        void show_urine_chemical()
        {

            try
            {
                int x = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from urine_chemical where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    x++;
                    string reaction = read[2].ToString();
                    string exece = read[3].ToString();
                    string albumin = read[4].ToString();
                    string suger = read[5].ToString();
                    string bence = read[6].ToString();
                    string bile_salt = read[7].ToString();
                    string bile_pig = read[8].ToString();
                    string ketone = read[9].ToString();
                    string uro = read[10].ToString();
                    textBox10.Text = reaction;
                    textBox9.Text = exece;
                    textBox8.Text = albumin;
                    textBox7.Text = suger;
                    textBox6.Text = bence;
                    textBox15.Text = bile_salt;
                    textBox14.Text = bile_pig;
                    textBox13.Text = ketone;
                    textBox12.Text = uro;
                }
                if (x == 0)
                {
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox15.Text = "";
                    textBox14.Text = "";
                    textBox13.Text = "";
                    textBox12.Text = "";
                }
                db.sql.Close();
            }
            catch
            {

            }
        }


        void show_urine_micro()
        {

            try
            {
                int x = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from urine_micro where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    x++;
                    string calcium = read[2].ToString();
                    string triple = read[3].ToString();
                    string amor = read[4].ToString();
                    string uric = read[5].ToString();
                    string pus = read[6].ToString();
                    string rb = read[7].ToString();
                    string ep = read[8].ToString();
                    string gran = read[9].ToString();
                    string sper = read[10].ToString();
                    string tri = read[11].ToString();
                    string mucas = read[12].ToString();
                    string others = read[13].ToString();
                    textBox23.Text = calcium;
                    textBox22.Text = triple;
                    textBox21.Text = amor;
                    textBox20.Text = uric;

                    textBox18.Text = pus;
                    textBox17.Text = rb;
                    textBox16.Text = ep;
                    textBox11.Text = gran;
                    textBox26.Text = sper;
                    textBox25.Text = tri;
                    textBox24.Text = mucas;
                    textBox19.Text = others;
                }
                if (x == 0)
                {
                    textBox23.Text = "";
                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";

                    textBox18.Text = "";
                    textBox17.Text = "";
                    textBox16.Text = "";
                    textBox11.Text = "";
                    textBox26.Text = "";
                    textBox25.Text = "";
                    textBox24.Text = "";
                    textBox19.Text = "";

                }
                db.sql.Close();
            }
            catch
            { }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select reg_no from urine_physical where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    c++;
                }
                if (c > 0)
                {

                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd1 = new SqlCommand("update urine_physical set qunality='" + textBox1.Text + "',colour='" + textBox2.Text + "',apperrance='" + textBox3.Text + "',sediment='" + textBox4.Text + "',speci_gra='" + textBox5.Text + "'", db.sql);
                    SqlCommand cmd2 = new SqlCommand("Update urine_chemical set reaction='" + textBox10.Text + "',execes='" + textBox9.Text + "',albumin='" + textBox8.Text + "',suger='" + textBox7.Text + "',bence='" + textBox6.Text + "',bile_salt='" + textBox15.Text + "',bile_pig='" + textBox14.Text + "',ketone='" + textBox13.Text + "',uro='" + textBox12.Text + "'", db.sql);
                    SqlCommand cmd3 = new SqlCommand("update urine_micro set calcium='" + textBox23.Text + "',triple='" + textBox22.Text + "',amorphous='" + textBox21.Text + "',uric='" + textBox20.Text + "',pus='" + textBox18.Text + "',rb='" + textBox17.Text + "',ep='" + textBox16.Text + "',gran='" + textBox11.Text + "',sper='" + textBox26.Text + "',tri='" + textBox25.Text + "',mucas='" + textBox24.Text + "',others='" + textBox19.Text + "'", db.sql);
                    int a = cmd1.ExecuteNonQuery();
                    int b = cmd2.ExecuteNonQuery();
                    int cc = cmd3.ExecuteNonQuery();
                    if (a > 0 && b > 0 && cc > 0)
                    {
                        MessageBox.Show("Update Sucessfull");
                       
                    }


                }
                else
                {
                    save_urine_report();
                   
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Please Give Registration NO and Invoice NO");
                }
                else
                {
                    int c = 0;
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select reg_no from haematology where reg_no='" + richTextBox42.Text + "'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        c++;

                    }
                    if (c > 0)
                    {
                        db.sql.Close();
                        db.sql.Open();
                        SqlCommand cmd1 = new SqlCommand("update haematology set hemo='" + textBox42.Text + "',esr='" + textBox43.Text + "',wbc='" + textBox44.Text + "',neu='" + textBox57.Text + "',lym='" + textBox45.Text + "',mono='" + textBox46.Text + "',eosin='" + textBox47.Text + "',baso='" + textBox48.Text + "',blast='" + textBox49.Text + "',mye='" + textBox50.Text + "',cir='" + textBox51.Text + "',platelet='" + textBox52.Text + "',mpv='" + textBox53.Text + "',pct='" + textBox54.Text + "',pdw='" + textBox55.Text + "',rbc='" + textBox56.Text + "',hct='" + textBox58.Text + "',mcv='" + textBox59.Text + "',mch='" + textBox60.Text + "',mchc='" + textBox61.Text + "',rdw='" + textBox62.Text + "',mala='" + textBox63.Text + "',reti='" + textBox64.Text + "',bleed='" + textBox65.Text + "',coa='" + textBox66.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                        int a = cmd1.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Report Update Sucessfully");
                            hematology hema = new hematology(richTextBox42.Text);
                            hema.Show();


                        }

                    }
                    else
                    {
                        save_haematology();
                        hematology hema = new hematology(richTextBox42.Text);
                        hema.Show();

                    }

                }
            }
            catch
            {

            }
        }


        void save_haematology()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into haematology(reg_no,hemo,esr,wbc,neu,lym,mono,eosin,baso,blast,mye,cir,platelet,mpv,pct,pdw,rbc,hct,mcv,mch,mchc,rdw,mala,reti,bleed,coa)values('" + richTextBox42.Text + "','" + textBox42.Text + "','" + textBox43.Text + "','" + textBox44.Text + "','" + textBox57.Text + "','" + textBox45.Text + "','" + textBox46.Text + "','" + textBox47.Text + "','" + textBox48.Text + "','" + textBox49.Text + "','" + textBox50.Text + "','" + textBox51.Text + "','" + textBox52.Text + "','" + textBox53.Text + "','" + textBox54.Text + "','" + textBox55.Text + "','" + textBox56.Text + "','" + textBox58.Text + "','" + textBox59.Text + "','" + textBox60.Text + "','" + textBox61.Text + "','" + textBox62.Text + "','" + textBox63.Text + "','" + textBox64.Text + "','" + textBox65.Text + "','" + textBox66.Text + "')", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Report Saved  Sucessfully");
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        void show_hematology()
        {
            try
            {

                int cc = 0;

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from haematology where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cc++;
                    string hemo = read[2].ToString();
                    string esr = read[3].ToString();
                    string wbc = read[4].ToString();
                    string neu = read[5].ToString();
                    string lym = read[6].ToString();
                    string mono = read[7].ToString();
                    string eosin = read[8].ToString();
                    string baso = read[9].ToString();
                    string blast = read[10].ToString();
                    string mye = read[11].ToString();
                    string cir = read[12].ToString();
                    string platelet = read[13].ToString();
                    string mpv = read[14].ToString();
                    string pct = read[15].ToString();
                    string pdw = read[16].ToString();
                    string rbc = read[17].ToString();
                    string hct = read[18].ToString();
                    string mcv = read[19].ToString();
                    string mch = read[20].ToString();
                    string mchc = read[21].ToString();
                    string rdw = read[22].ToString();
                    string mala = read[23].ToString();
                    string reti = read[24].ToString();
                    string bleed = read[25].ToString();
                    string coa = read[26].ToString();
                    textBox42.Text = hemo;
                    textBox43.Text = esr;
                    textBox44.Text = wbc;
                    textBox57.Text = neu;
                    textBox45.Text = lym;

                    textBox46.Text = mono;
                    textBox47.Text = eosin;
                    textBox48.Text = baso;
                    textBox49.Text = blast;
                    textBox50.Text = mye;

                    textBox51.Text = cir;
                    textBox52.Text = platelet;
                    textBox53.Text = mpv;
                    textBox54.Text = pct;
                    textBox55.Text = pdw;

                    textBox56.Text = rbc;
                    textBox58.Text = hct;
                    textBox59.Text = mcv;
                    textBox60.Text = mch;
                    textBox61.Text = mchc;
                    textBox62.Text = rdw;
                    textBox63.Text = mala;
                    textBox64.Text = reti;
                    textBox65.Text = bleed;
                    textBox66.Text = coa;


                }
                if (cc == 0)
                {
                    textBox42.Text = "";
                    textBox43.Text = "";
                    textBox44.Text = "";
                    textBox57.Text = "";
                    textBox45.Text = "";

                    textBox46.Text = "";
                    textBox47.Text = "";
                    textBox48.Text = "";
                    textBox49.Text = "";
                    textBox50.Text = "";

                    textBox51.Text = "";
                    textBox52.Text = "";
                    textBox53.Text = "";
                    textBox54.Text = "";
                    textBox55.Text = "";

                    textBox56.Text = "";
                    textBox58.Text = "";
                    textBox59.Text = "";
                    textBox60.Text = "";
                    textBox61.Text = "";
                    textBox62.Text = "";
                    textBox63.Text = "";
                    textBox64.Text = "";
                    textBox65.Text = "";
                    textBox66.Text = "";
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void tabItem11_Click(object sender, EventArgs e)
        {
            pathology path = new pathology(richTextBox42.Text);
            path.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from xray2 where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                }

                if (c > 0)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd1 = new SqlCommand("update xray2 set title='" + richTextBox28.Text + "', result='" + richTextBox27.Text + "',comment='" + richTextBox29.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                    int a = cmd1.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Update Sucess Full");
                       
                    }
                    db.sql.Close();
                }
                else
                {

                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into xray2(reg_no,title,result,comment)values('" + richTextBox42.Text + "','" + richTextBox28.Text + "','" + richTextBox27.Text + "','" + richTextBox29.Text + "')", db.sql);
                    int x = cmd2.ExecuteNonQuery();
                    if (x > 0)
                    {
                        MessageBox.Show("Save Sucessfull");
                        
                    }
                    db.sql.Close();
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
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Please Give Registration NO and Invoice NO");
                }
                else
                {
                    int c = 0;
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select reg_no from haematology where reg_no='" + richTextBox42.Text + "'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        c++;

                    }
                    if (c > 0)
                    {
                        db.sql.Close();
                        db.sql.Open();
                        SqlCommand cmd1 = new SqlCommand("update haematology set hemo='" + textBox42.Text + "',esr='" + textBox43.Text + "',wbc='" + textBox44.Text + "',neu='" + textBox57.Text + "',lym='" + textBox45.Text + "',mono='" + textBox46.Text + "',eosin='" + textBox47.Text + "',baso='" + textBox48.Text + "',blast='" + textBox49.Text + "',mye='" + textBox50.Text + "',cir='" + textBox51.Text + "',platelet='" + textBox52.Text + "',mpv='" + textBox53.Text + "',pct='" + textBox54.Text + "',pdw='" + textBox55.Text + "',rbc='" + textBox56.Text + "',hct='" + textBox58.Text + "',mcv='" + textBox59.Text + "',mch='" + textBox60.Text + "',mchc='" + textBox61.Text + "',rdw='" + textBox62.Text + "',mala='" + textBox63.Text + "',reti='" + textBox64.Text + "',bleed='" + textBox65.Text + "',coa='" + textBox66.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                        int a = cmd1.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Report Update Sucessfully");
                           


                        }

                    }
                    else
                    {
                        save_haematology();
                     
                    }

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
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Please Give Registration NO and Invoice NO");
                }
                else
                {
                    int c = 0;
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select reg_no from immunology where reg_no='" + richTextBox42.Text + "'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        c++;

                    }
                    if (c > 0)
                    {
                        db.sql.Close();
                        db.sql.Open();
                        SqlCommand cmd1 = new SqlCommand("update immunology set t3='" + textBox30.Text + "',t4='" + textBox29.Text + "',tsh='" + textBox32.Text + "',ft3='" + textBox31.Text + "',ft4='" + textBox34.Text + "',prolactin='" + textBox33.Text + "',testostorone='" + textBox39.Text + "',fsh='" + textBox38.Text + "',ige='" + textBox37.Text + "',troponin='" + textBox36.Text + "',sod='" + textBox40.Text + "',cut='" + textBox41.Text + "',openion='" + textBox35.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                        int a = cmd1.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Report Update Sucessfully");



                        }

                    }
                    else
                    {
                        save_immunology();

                    }

                }
            }
            catch
            {

            }
        }

        void save_immunology()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into immunology(reg_no,t3,t4,tsh,ft3,ft4,prolactin,testostorone,fsh,ige,troponin,sod,cut,openion)values('" + richTextBox42.Text + "','" + textBox30.Text + "','" + textBox29.Text + "','" + textBox32.Text + "','" + textBox31.Text + "','" + textBox34.Text + "','" + textBox33.Text + "','" + textBox39.Text + "','" + textBox38.Text + "','" + textBox37.Text + "','" + textBox36.Text + "','" + textBox40.Text + "','" + textBox41.Text + "','" + textBox35.Text + "')", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Report Saved  Sucessfully");
                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        void show_immunology()
        {
            try
            {

                int cc = 0;

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from immunology where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cc++;
                    string t3 = read[1].ToString();
                    string hemo = read[2].ToString();
                    string esr = read[3].ToString();
                    string wbc = read[4].ToString();
                    string neu = read[5].ToString();
                    string lym = read[6].ToString();
                    string mono = read[7].ToString();
                    string eosin = read[8].ToString();
                    string baso = read[9].ToString();
                    string blast = read[10].ToString();
                    string mye = read[11].ToString();
                    string cir = read[12].ToString();
                    string platelet = read[13].ToString();
                    textBox30.Text = t3;
                    textBox29.Text = hemo;
                    textBox32.Text = esr;
                    textBox31.Text = wbc;
                    textBox34.Text = neu;
                    textBox33.Text = lym;

                    textBox39.Text = mono;
                    textBox38.Text = eosin;
                    textBox37.Text = baso;
                    textBox36.Text = blast;
                    textBox40.Text = mye;

                    textBox41.Text = cir;
                    textBox35.Text = platelet;


                }
                if (cc == 0)
                {
                    textBox30.Text = "";
                    textBox29.Text = "";
                    textBox32.Text = "";
                    textBox31.Text = "";
                    textBox34.Text = "";
                    textBox33.Text = "";

                    textBox39.Text = "";
                    textBox38.Text = "";
                    textBox37.Text = "";
                    textBox36.Text = "";
                    textBox40.Text = "";

                    textBox41.Text = "";
                    textBox35.Text = "";
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Please Give Registration NO and Invoice NO");
                }
                else
                {
                    int c = 0;
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select reg_no from immunology where reg_no='" + richTextBox42.Text + "'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        c++;

                    }
                    if (c > 0)
                    {
                        db.sql.Close();
                        db.sql.Open();
                        SqlCommand cmd1 = new SqlCommand("update immunology set t3='" + textBox30.Text + "',t4='" + textBox29.Text + "',tsh='" + textBox32.Text + "',ft3='" + textBox31.Text + "',ft4='" + textBox34.Text + "',prolactin='" + textBox33.Text + "',testostorone='" + textBox39.Text + "',fsh='" + textBox38.Text + "',ige='" + textBox37.Text + "',troponin='" + textBox36.Text + "',sod='" + textBox40.Text + "',cut='" + textBox41.Text + "',openion='" + textBox35.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                        int a = cmd1.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Report Update Sucessfully");
                            Immunology_Report imm = new Immunology_Report(richTextBox42.Text);
                            imm.Show();


                        }

                    }
                    else
                    {
                        save_immunology();
                        Immunology_Report imm = new Immunology_Report(richTextBox42.Text);
                        imm.Show();

                    }

                }
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Please Give Registration NO and Invoice NO");
                }
                else
                {
                    int c = 0;
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select reg_no from stool where reg_no='" + richTextBox42.Text + "'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        c++;

                    }
                    if (c > 0)
                    {
                        db.sql.Close();
                        db.sql.Open();
                        SqlCommand cmd1 = new SqlCommand("update stool set quanality='" + textBox27.Text + "',consistency='" + textBox28.Text + "',blood='" + comboBox1.Text + "',helmint='" + comboBox2.Text + "',odour='" + textBox68.Text + "',mucus='" + textBox67.Text + "',colour='" + textBox69.Text + "',reaction='" + textBox72.Text + "',occult='" + textBox71.Text + "',reducing='" + textBox70.Text + "',protozoa='" + comboBox4.Text + "',cysts='" + comboBox3.Text + "',entamoeaba='" + comboBox5.Text + "',ovaal='" + textBox73.Text + "',ovatt='" + comboBox6.Text + "',vegetable='" + textBox76.Text + "',epithelial='" + textBox75.Text + "',pus='" + textBox74.Text + "',rbc='" + textBox77.Text + "',fat='" + comboBox8.Text + "',muscle='" + comboBox7.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                        int a = cmd1.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Report Update Sucessfully");



                        }

                    }
                    else
                    {
                        save_stool();

                    }

                }
            }
            catch
            {

            }
        }


        void save_stool()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("insert into stool(reg_no,quanality,consistency,blood,helmint,odour,mucus,colour,reaction,occult,reducing,protozoa,cysts,entamoeaba,ovaal,ovatt,vegetable,epithelial,pus,rbc,fat,muscle)values('" + richTextBox42.Text + "','" + textBox27.Text + "','" + textBox28.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox68.Text + "','" + textBox67.Text + "','" + textBox69.Text + "','" + textBox72.Text + "','" + textBox71.Text + "','" + textBox70.Text + "','" + comboBox4.Text + "','" + comboBox3.Text + "','" + comboBox5.Text + "','" + textBox73.Text + "','" + comboBox6.Text + "','" + textBox76.Text + "','" + textBox75.Text + "','" + textBox74.Text + "','" + textBox77.Text + "','" + comboBox8.Text + "','" + comboBox7.Text + "')", db.sql);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Report Saved  Sucessfully");
                }
                db.sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        void show_stool()
        {
            try
            {

                int cc = 0;

                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from stool where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cc++;
                    string quanality = read[1].ToString();
                    string hemo = read[2].ToString();
                    string esr = read[3].ToString();
                    string wbc = read[4].ToString();
                    string neu = read[5].ToString();
                    string lym = read[6].ToString();
                    string mono = read[7].ToString();
                    string eosin = read[8].ToString();
                    string baso = read[9].ToString();
                    string blast = read[10].ToString();
                    string mye = read[11].ToString();
                    string cir = read[12].ToString();
                    string platelet = read[13].ToString();
                    string mpv = read[14].ToString();
                    string pct = read[15].ToString();
                    string pdw = read[16].ToString();
                    string rbc = read[17].ToString();
                    string hct = read[18].ToString();
                    string mcv = read[19].ToString();
                    string mch = read[20].ToString();
                    string mchc = read[21].ToString();

                    textBox27.Text = quanality;
                    textBox28.Text = hemo;
                    comboBox1.Text = esr;
                    comboBox2.Text = wbc;
                    textBox68.Text = neu;
                    textBox67.Text = lym;

                    textBox69.Text = mono;
                    textBox72.Text = eosin;
                    textBox71.Text = baso;
                    textBox70.Text = blast;
                    comboBox4.Text = mye;

                    comboBox3.Text = cir;
                    comboBox5.Text = platelet;
                    textBox73.Text = mpv;
                    comboBox6.Text = pct;
                    textBox76.Text = pdw;

                    textBox75.Text = rbc;
                    textBox74.Text = hct;
                    textBox77.Text = mcv;
                    comboBox8.Text = mch;
                    comboBox7.Text = mchc;


                }
                if (cc == 0)
                {
                    textBox27.Text = "";
                    textBox28.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox68.Text = "";
                    textBox67.Text = "";

                    textBox69.Text = "";
                    textBox72.Text = "";
                    textBox71.Text = "";
                    textBox70.Text = "";
                    comboBox4.Text = "";

                    comboBox3.Text = "";
                    comboBox5.Text = "";
                    textBox73.Text = "";
                    comboBox6.Text = "";
                    textBox76.Text = "";

                    textBox75.Text = "";
                    textBox74.Text = "";
                    textBox77.Text = "";
                    comboBox8.Text = "";
                    comboBox7.Text = "";
                }
                db.sql.Close();
            }
            catch
            {

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox27.Text = "Sufficient";
            textBox28.Text = "Soft";
            comboBox1.Text = "Not Found";
            comboBox2.Text = "Not Found";
            textBox68.Text = "Offensive";
            textBox67.Text = "(+)";

            textBox69.Text = "Yellow";
            textBox72.Text = "Alkaline";
            textBox71.Text = "N/D";
            textBox70.Text = "N/D";
            comboBox4.Text = "Not Found";

            comboBox3.Text = "Not Found";
            comboBox5.Text = "Not Found";
            textBox73.Text = "(+)";
            comboBox6.Text = "Not Found";
            textBox76.Text = "(+)";

            textBox75.Text = "2-4 /HPF";
            textBox74.Text = "4-6 /HPF";
            textBox77.Text = "Nil";
            comboBox8.Text = "Not Found";
            comboBox7.Text = "Not Found";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Please Give Registration NO and Invoice NO");
                }
                else
                {
                    int c = 0;
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select reg_no from stool where reg_no='" + richTextBox42.Text + "'", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        c++;

                    }
                    if (c > 0)
                    {
                        db.sql.Close();
                        db.sql.Open();
                        SqlCommand cmd1 = new SqlCommand("update stool set quanality='" + textBox27.Text + "',consistency='" + textBox28.Text + "',blood='" + comboBox1.Text + "',helmint='" + comboBox2.Text + "',odour='" + textBox68.Text + "',mucus='" + textBox67.Text + "',colour='" + textBox69.Text + "',reaction='" + textBox72.Text + "',occult='" + textBox71.Text + "',reducing='" + textBox70.Text + "',protozoa='" + comboBox4.Text + "',cysts='" + comboBox3.Text + "',entamoeaba='" + comboBox5.Text + "',ovaal='" + textBox73.Text + "',ovatt='" + comboBox6.Text + "',vegetable='" + textBox76.Text + "',epithelial='" + textBox75.Text + "',pus='" + textBox74.Text + "',rbc='" + textBox77.Text + "',fat='" + comboBox8.Text + "',muscle='" + comboBox7.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                        int a = cmd1.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Report Update Sucessfully");
                            Stool_Report stool = new Stool_Report(richTextBox42.Text);
                            stool.Show();


                        }

                    }
                    else
                    {
                        save_stool();
                        Stool_Report stool = new Stool_Report(richTextBox42.Text);
                        stool.Show();
                    }

                }
            }
           catch
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX4.Rows.Clear();
                dataGridViewX4.Rows.Add(8);
                dataGridViewX4.Rows[0].Cells[0].Value = "Liver";
                dataGridViewX4.Rows[0].Cells[1].Value = "Normal in size with uniform in echo texture Fatty";
                dataGridViewX4.Rows[1].Cells[0].Value = "Gallbladder";
                dataGridViewX4.Rows[1].Cells[1].Value = "Normal in size and appearance. No stone or debris seen in the GB";
                dataGridViewX4.Rows[2].Cells[0].Value = "Biliary truct";
                dataGridViewX4.Rows[2].Cells[1].Value = "Intra hepatic or extra hepatic biliary channel are not dilated";
                dataGridViewX4.Rows[3].Cells[0].Value = "Pancreas";
                dataGridViewX4.Rows[3].Cells[1].Value = "Normal in size and appearance";
                dataGridViewX4.Rows[4].Cells[0].Value = "Spleen";
                dataGridViewX4.Rows[4].Cells[1].Value = "normal in size and appearance";
                dataGridViewX4.Rows[5].Cells[0].Value = "Kidneys";
                dataGridViewX4.Rows[5].Cells[1].Value = "Both the kidneys are normal in size with well defined cortex and medulla, no pelviscalyceal dilatation is seen";
                dataGridViewX4.Rows[6].Cells[0].Value = "U.Bladder";
                dataGridViewX4.Rows[6].Cells[1].Value = "Well filled and smooth outline";
                dataGridViewX4.Rows[7].Cells[0].Value = "Prostate";
                dataGridViewX4.Rows[7].Cells[1].Value = "Normal in size and uniform in tissue texture";

            }
            catch
            {
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                int y = 0;
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Registration No  and Invoice no must needed");
                }
                else
                {

                    int n = 0;

                    string val1 = "";
                    string val2 = "";

                    int c = dataGridViewX4.Rows.Count;

                    for (n = 0; n <= c - 1; n++)
                    {
                        int cc = 0;
                        db.sql.Close();
                        db.sql.Open();
                        try
                        {
                            val1 = dataGridViewX4.Rows[n].Cells[0].Value.ToString();
                            val2 = dataGridViewX4.Rows[n].Cells[1].Value.ToString();
                        }
                        catch
                        {
                        }


                        SqlCommand cmd = new SqlCommand("select * from ultrasono_male where reg_no='" + richTextBox42.Text + "' and name='" + val1 + "'", db.sql);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            cc++;

                        }


                        if (cc > 0)
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd2 = new SqlCommand("update ultrasono_male set name='" + val1 + "', result='" + val2 + "',comment='" + richTextBox1.Text + "' where reg_no='" + richTextBox42.Text + "'  and name='" + val1 + "'", db.sql);
                            x = cmd2.ExecuteNonQuery();


                        }

                        else
                        {
                            try
                            {
                                string xx = dataGridViewX1.Rows[n].Cells[1].Value.ToString(); ;
                                if (xx == "")
                                {
                                }
                                else
                                {
                                    db.sql.Close();
                                    db.sql.Open();
                                    SqlCommand cmd1 = new SqlCommand("insert into ultrasono_male(reg_no,name,result,comment)values('" + richTextBox42.Text + "','" + val1 + "','" + val2 + "','" + richTextBox1.Text + "')", db.sql);
                                    y = cmd1.ExecuteNonQuery();

                                }
                            }
                            catch
                            {

                            }

                        }


                    }
                    if (x > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                        Ultrasno_Male ultra_male = new Ultrasno_Male(richTextBox42.Text);
                        ultra_male.Show();
                    }
                    if (y > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                        Ultrasno_Male ultra_male = new Ultrasno_Male(richTextBox42.Text);
                        ultra_male.Show();
                    }
                    db.sql.Close();
                }
            }
            catch
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                int y = 0;
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Registration No  and Invoice no must needed");
                }
                else
                {

                    int n = 0;

                    string val1 = "";
                    string val2 = "";

                    int c = dataGridViewX4.Rows.Count;

                    for (n = 0; n <= c - 1; n++)
                    {
                        int cc = 0;
                        db.sql.Close();
                        db.sql.Open();
                        try
                        {
                            val1 = dataGridViewX4.Rows[n].Cells[0].Value.ToString();
                            val2 = dataGridViewX4.Rows[n].Cells[1].Value.ToString();
                        }
                        catch
                        {
                        }


                        SqlCommand cmd = new SqlCommand("select * from ultrasono_male where reg_no='" + richTextBox42.Text + "' and name='" + val1 + "'", db.sql);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            cc++;

                        }


                        if (cc > 0)
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd2 = new SqlCommand("update ultrasono_male set name='" + val1 + "', result='" + val2 + "',comment='" + richTextBox1.Text + "' where reg_no='" + richTextBox42.Text + "'  and name='" + val1 + "'", db.sql);
                            x = cmd2.ExecuteNonQuery();


                        }

                        else
                        {
                            try
                            {
                                string xx = dataGridViewX1.Rows[n].Cells[1].Value.ToString(); ;
                                if (xx == "")
                                {
                                }
                                else
                                {
                                    db.sql.Close();
                                    db.sql.Open();
                                    SqlCommand cmd1 = new SqlCommand("insert into ultrasono_male(reg_no,name,result,comment)values('" + richTextBox42.Text + "','" + val1 + "','" + val2 + "','" + richTextBox1.Text + "')", db.sql);
                                    y = cmd1.ExecuteNonQuery();

                                }
                            }
                            catch
                            {

                            }

                        }


                    }
                    if (x > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                    }
                    if (y > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                    }
                    db.sql.Close();
                }
            }
            catch
            {

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewX5.Rows.Clear();
                dataGridViewX5.Rows.Add(8);
                dataGridViewX5.Rows[0].Cells[0].Value = "Gravid uterus";
                dataGridViewX5.Rows[0].Cells[1].Value = "Contains with presentaion during examination.";
                dataGridViewX5.Rows[1].Cells[0].Value = "BPD";
                dataGridViewX5.Rows[1].Cells[1].Value = " mm";
                dataGridViewX5.Rows[2].Cells[0].Value = "FL";
                dataGridViewX5.Rows[2].Cells[1].Value = " mm";
                dataGridViewX5.Rows[3].Cells[0].Value = "Gestational age";
                dataGridViewX5.Rows[3].Cells[1].Value = "";
                dataGridViewX5.Rows[4].Cells[0].Value = "Fetal heart movement";
                dataGridViewX5.Rows[4].Cells[1].Value = "";
                dataGridViewX5.Rows[5].Cells[0].Value = "Placenta";
                dataGridViewX5.Rows[5].Cells[1].Value = "";
                dataGridViewX5.Rows[6].Cells[0].Value = "Amniotic fluid";
                dataGridViewX5.Rows[6].Cells[1].Value = "";
                dataGridViewX5.Rows[7].Cells[0].Value = "E.D.D";
                dataGridViewX5.Rows[7].Cells[1].Value = "";
                richTextBox5.Text = "   PREGNANCY WITH   PRESENTATION";
            }
            catch
            {
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                int y = 0;
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Registration No  and Invoice no must needed");
                }
                else
                {

                    int n = 0;

                    string val1 = "";
                    string val2 = "";

                    int c = dataGridViewX5.Rows.Count;

                    for (n = 0; n <= c - 1; n++)
                    {
                        int cc = 0;
                        db.sql.Close();
                        db.sql.Open();
                        try
                        {
                            val1 = dataGridViewX5.Rows[n].Cells[0].Value.ToString();
                            val2 = dataGridViewX5.Rows[n].Cells[1].Value.ToString();
                        }
                        catch
                        {
                        }


                        SqlCommand cmd = new SqlCommand("select * from ultrasono_pregnency where reg_no='" + richTextBox42.Text + "' and name='" + val1 + "'", db.sql);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            cc++;

                        }


                        if (cc > 0)
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd2 = new SqlCommand("update ultrasono_pregnency set name='" + val1 + "', result='" + val2 + "',comment='" + richTextBox5.Text + "' where reg_no='" + richTextBox42.Text + "'  and name='" + val1 + "'", db.sql);
                            x = cmd2.ExecuteNonQuery();


                        }

                        else
                        {
                            try
                            {
                                string xx = dataGridViewX1.Rows[n].Cells[1].Value.ToString(); ;
                                if (xx == "")
                                {
                                }
                                else
                                {
                                    db.sql.Close();
                                    db.sql.Open();
                                    SqlCommand cmd1 = new SqlCommand("insert into ultrasono_pregnency(reg_no,name,result,comment)values('" + richTextBox42.Text + "','" + val1 + "','" + val2 + "','" + richTextBox5.Text + "')", db.sql);
                                    y = cmd1.ExecuteNonQuery();

                                }
                            }
                            catch
                            {

                            }

                        }


                    }
                    if (x > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                        Ultrasono_Pregnency ultra_pg= new Ultrasono_Pregnency(richTextBox42.Text);
                        ultra_pg.Show();
                    }
                    if (y > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                        Ultrasono_Pregnency ultra_pg = new Ultrasono_Pregnency(richTextBox42.Text);
                        ultra_pg.Show();
                    }
                    db.sql.Close();
                }
            }
            catch
            {

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                int y = 0;
                if (richTextBox42.Text == "")
                {
                    MessageBox.Show("Registration No  and Invoice no must needed");
                }
                else
                {

                    int n = 0;

                    string val1 = "";
                    string val2 = "";

                    int c = dataGridViewX5.Rows.Count;

                    for (n = 0; n <= c - 1; n++)
                    {
                        int cc = 0;
                        db.sql.Close();
                        db.sql.Open();
                        try
                        {
                            val1 = dataGridViewX5.Rows[n].Cells[0].Value.ToString();
                            val2 = dataGridViewX5.Rows[n].Cells[1].Value.ToString();
                        }
                        catch
                        {
                        }


                        SqlCommand cmd = new SqlCommand("select * from ultrasono_pregnency where reg_no='" + richTextBox42.Text + "' and name='" + val1 + "'", db.sql);
                        SqlDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            cc++;

                        }


                        if (cc > 0)
                        {
                            db.sql.Close();
                            db.sql.Open();
                            SqlCommand cmd2 = new SqlCommand("update ultrasono_pregnency set name='" + val1 + "', result='" + val2 + "',comment='" + richTextBox5.Text + "' where reg_no='" + richTextBox42.Text + "'  and name='" + val1 + "'", db.sql);
                            x = cmd2.ExecuteNonQuery();


                        }

                        else
                        {
                            try
                            {
                                string xx = dataGridViewX1.Rows[n].Cells[1].Value.ToString(); ;
                                if (xx == "")
                                {
                                }
                                else
                                {
                                    db.sql.Close();
                                    db.sql.Open();
                                    SqlCommand cmd1 = new SqlCommand("insert into ultrasono_pregnency(reg_no,name,result,comment)values('" + richTextBox42.Text + "','" + val1 + "','" + val2 + "','" + richTextBox5.Text + "')", db.sql);
                                    y = cmd1.ExecuteNonQuery();

                                }
                            }
                            catch
                            {

                            }

                        }


                    }
                    if (x > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                       
                    }
                    if (y > 0)
                    {
                        MessageBox.Show("Saved Sucessfull....");
                      
                    }
                    db.sql.Close();
                }
            }
            catch
            {

            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "Ultrasono 1")
            {
                richTextBox7.Text = "Both breast are normal in bulk and composition.\nEcho texture of parenchyma is homogeneous.\nNo focal lisions are seen.";
                richTextBox6.Text = "NORMAL STUDY";
            }
            if (comboBox11.Text == "Ultrasono 2")
            {
                richTextBox7.Text = "Uterus bulky in size,there is a GS seen on the uterine cavity measuring\n(26mm.) about which corresponds to 07 wks 05 days.";
                richTextBox6.Text = "EARLY PREGNANCY ABOUT 07 WKS 05 DAYS";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from ultrasono_text where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                }

                if (c > 0)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd1 = new SqlCommand("update ultrasono_text set  result='" + richTextBox7.Text + "',comment='" + richTextBox6.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                    int a = cmd1.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Update Sucess Full");
                        Ultrasono_Text ul_text = new Ultrasono_Text(richTextBox42.Text);
                        ul_text.Show();
                    }
                    db.sql.Close();
                }
                else
                {

                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into ultrasono_text(reg_no,result,comment)values('" + richTextBox42.Text + "','" + richTextBox7.Text + "','" + richTextBox6.Text + "')", db.sql);
                    int x = cmd2.ExecuteNonQuery();
                    if (x > 0)
                    {
                        MessageBox.Show("Save Sucessfull");
                        Ultrasono_Text ul_text = new Ultrasono_Text(richTextBox42.Text);
                        ul_text.Show();
                    }
                    db.sql.Close();
                }
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
                int c = 0;
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select * from ultrasono_text where reg_no='" + richTextBox42.Text + "'", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    c++;
                }

                if (c > 0)
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd1 = new SqlCommand("update ultrasono_text set  result='" + richTextBox7.Text + "',comment='" + richTextBox6.Text + "' where reg_no='" + richTextBox42.Text + "'", db.sql);
                    int a = cmd1.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Update Sucess Full");
                        Xray2 x2 = new Xray2(richTextBox42.Text);
                        x2.Show();
                    }
                    db.sql.Close();
                }
                else
                {

                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into ultrasono_text(reg_no,result,comment)values('" + richTextBox42.Text + "','" + richTextBox7.Text + "','" + richTextBox6.Text + "')", db.sql);
                    int x = cmd2.ExecuteNonQuery();
                    if (x > 0)
                    {
                        MessageBox.Show("Save Sucessfull");
                        /*Xray2 x2 = new Xray2(richTextBox42.Text);
                        x2.Show();*/
                    }
                    db.sql.Close();
                }
                db.sql.Close();
            }

            catch
            {

            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = "N";
            textBox2.Text = "N";
            textBox3.Text = "N";
            textBox4.Text = "N/A";
            textBox5.Text = "N/A";

            textBox10.Text = "Alkali";
            textBox9.Text = "N/A";
            textBox8.Text = "+";
            textBox7.Text = "++";
            textBox6.Text = "N/A";
            textBox15.Text = "N/A";
            textBox14.Text = "N/A";
            textBox13.Text = "N/A";
            textBox12.Text = "N/A";

            textBox23.Text = "N/A";
            textBox22.Text = "N/A";
            textBox21.Text = "N/A";
            textBox20.Text = "N/A";
            textBox18.Text = "8-5/hpf";
            textBox17.Text = "N/A";
            textBox16.Text = "10-15/hpf";
            textBox11.Text = "N/A";
            textBox26.Text = "N/A";
            textBox25.Text = "N/A";
            textBox24.Text = "N/A";
            textBox19.Text = "";
        }

    }
}
