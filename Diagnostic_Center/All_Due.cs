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
    public partial class All_Due : Form
    {
        connection db = new connection();
        public All_Due()
        {
            InitializeComponent();
            
        }

        void due()
        {
           // try
            {
               
                //*************************************************************
                double diagnostic = 0;
                double indoor = 0;
                double outdoor = 0;
                double pharmecy = 0; 

                try
                {
                    db.sql.Close();
                    db.sql.Open();
                    SqlCommand cmd = new SqlCommand("select sum(due-(due_paid+discount2)) from due_collection", db.sql);
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        diagnostic = Convert.ToDouble(read[0]);
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
                    SqlCommand cmd1 = new SqlCommand("select sum(due-due_paid) from user_cash_collection_hospital where due_paid<due", db.sql);
                    SqlDataReader read1 = cmd1.ExecuteReader();
                    while (read1.Read())
                    {
                        indoor = Convert.ToDouble(read1[0]);
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
                  SqlCommand cmd1 = new SqlCommand("select sum(due-due_paid) from user_cash_collection_OPD where due_paid<due", db.sql);
                  SqlDataReader read1 = cmd1.ExecuteReader();
                  while (read1.Read())
                  {
                      outdoor = Convert.ToDouble(read1[0]);
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
                  SqlCommand cmd1 = new SqlCommand("select sum(due) from  medicine_selling_history", db.sql);
                  SqlDataReader read1 = cmd1.ExecuteReader();
                  while (read1.Read())
                  {
                      pharmecy = Convert.ToDouble(read1[0]);
                  }
                  db.sql.Close();
              }
              catch
              {
                 
              }
                //*************************************************************
                label2.Text = diagnostic.ToString();
                label3.Text = indoor.ToString();
                label5.Text = outdoor.ToString();
                label7.Text = pharmecy.ToString();
            
                label9.Text = (diagnostic + indoor + outdoor + pharmecy).ToString();
            }
           /* catch
            { 
            
            }*/
            
        }

        private void All_Due_Load(object sender, EventArgs e)
        {
            due();
        }

    }
}
