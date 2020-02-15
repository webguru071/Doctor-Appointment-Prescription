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
    public partial class Doctor_Commission : Form
    {
        connection db = new connection();
        public Doctor_Commission()
        {
            InitializeComponent();
            load_Commission();
            load_doctor();
        }

        void load_Commission()
        {
            try
            {
             string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                string date2 = dateTimePicker2.Text;
                DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd2 = d2.ToString("yyyy/MM/dd");
            db.sql.Close();
            db.sql.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select type,count(test_id),sum(net_price) from diagnostic_list,diagnostic_person,diagnostic_bill,paid_and_due where diagnostic_list.id=diagnostic_bill.test_id and diagnostic_bill.invoice_id=diagnostic_person.id and diagnostic_person.id=paid_and_due.invoice_no and diaggnostic_person.referdoctor='"+comboBox1.Text+"' and date2 between '"+dd+"' and '"+dd2+"'  group by type", db.sql);
            DataTable dt = new DataTable();
            dataGridView1.Rows.Clear();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = 0;
                dataGridView1.Rows[n].Cells[4].Value = 0;            
            }
            db.sql.Close();
        
            }
            catch
            {
            
            }
        }


        void load_doctor()
        {
            try
            {
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd = new SqlCommand("select name from doctors", db.sql);
                SqlDataReader read = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (read.Read())
                {
                    String name = read[0].ToString();
                    comboBox1.Items.Add(name);
                }

                db.sql.Close();

            }
            catch
            {

            }


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int n = dataGridView1.Rows.Count;
                int i = 0;
                double sub_total = 0;
                double total = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                double commission = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                double net_amount = 0;
                net_amount = (total * (commission / 100));

                dataGridView1.SelectedRows[0].Cells[4].Value = net_amount.ToString();
                for (i = 0; i < n - 1; i++)
                {
                    sub_total += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                label3.Text = sub_total.ToString();

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                string date = dateTimePicker1.Text;
                DateTime d = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd = d.ToString("yyyy/MM/dd");
                string date2 = dateTimePicker2.Text;
                DateTime d2 = DateTime.ParseExact(date2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dd2 = d2.ToString("yyyy/MM/dd");
                db.sql.Close();
                db.sql.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select type,count(test_id),sum(net_price),max(commission) from diagnostic_list,test_category,diagnostic_person,diagnostic_bill,paid_and_due,referance where diagnostic_list.id=diagnostic_bill.test_id and test_category.Category=diagnostic_list.type and diagnostic_bill.invoice_id=diagnostic_person.id and diagnostic_person.id=paid_and_due.invoice_no and diagnostic_person.id=referance.patient_id and referance.name='" + comboBox1.Text + "' and referance.date2 between '" + dd + "' and '" + dd2 + "'  group by type", db.sql);
                DataTable dt = new DataTable();
                dataGridView1.Rows.Clear();
                sda.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    double x =Convert.ToDouble ( dataGridView1.Rows[n].Cells[2].Value.ToString());
                    double y = Convert.ToDouble(dataGridView1.Rows[n].Cells[3].Value.ToString());
                    double commission = x * (y / 100);
                    dataGridView1.Rows[n].Cells[4].Value = commission.ToString();
                }
                dataGridView1.Rows.Add();
                db.sql.Close();

            }
            catch
            {

            }

            try
            {
                double tk = 0;
                int a = dataGridView1.Rows.Count;
                int i=0;
                for (i = 0; i < a - 1; i++)
                {
                    tk += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                label3.Text = tk.ToString();
            }

            catch
            { 
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int aa = 0;
                int i = 0;
                string category = "";
                string total_test = "";
                string total_amount = "";
                string commission = "";
                string net_commission = "";
                db.sql.Close();
                db.sql.Open();
                SqlCommand cmd_del = new SqlCommand("delete from commission_print", db.sql);
                int a = cmd_del.ExecuteNonQuery();
                int n = dataGridView1.Rows.Count;
                for (i = 0; i <n-1; i++)
                {
                    category = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    total_test = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    total_amount = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    commission = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    net_commission = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("insert into commission_print(test_category,total_test,total_amount,commission,net_amount)values('" + category + "','" + total_test + "','" + total_amount + "','" + commission + "','" + net_commission + "')", db.sql);
                    aa=cmd.ExecuteNonQuery();
                    db.sql.Close();
                }
                if (aa > 0)
                {
                    Commission_Pay_Print cpp = new Commission_Pay_Print(comboBox1.Text,dateTimePicker1.Text,dateTimePicker2.Text,richTextBox1.Text);
                    cpp.Show();
                    cpp.Show();
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
