namespace Diagnostic_Center
{
    partial class Ultrasono_Pregnency
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DataSet59 = new Diagnostic_Center.DataSet59();
            this.ultrasono_pregnencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultrasono_pregnencyTableAdapter = new Diagnostic_Center.DataSet59TableAdapters.ultrasono_pregnencyTableAdapter();
            this.diagnostic_personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diagnostic_personTableAdapter = new Diagnostic_Center.DataSet59TableAdapters.diagnostic_personTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultrasono_pregnencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource3.Name = "DataSet59";
            reportDataSource3.Value = this.ultrasono_pregnencyBindingSource;
            reportDataSource4.Name = "DataSet59a";
            reportDataSource4.Value = this.diagnostic_personBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report71.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 42);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(670, 416);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Pathologist";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(100, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(265, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DataSet59
            // 
            this.DataSet59.DataSetName = "DataSet59";
            this.DataSet59.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultrasono_pregnencyBindingSource
            // 
            this.ultrasono_pregnencyBindingSource.DataMember = "ultrasono_pregnency";
            this.ultrasono_pregnencyBindingSource.DataSource = this.DataSet59;
            // 
            // ultrasono_pregnencyTableAdapter
            // 
            this.ultrasono_pregnencyTableAdapter.ClearBeforeFill = true;
            // 
            // diagnostic_personBindingSource
            // 
            this.diagnostic_personBindingSource.DataMember = "diagnostic_person";
            this.diagnostic_personBindingSource.DataSource = this.DataSet59;
            // 
            // diagnostic_personTableAdapter
            // 
            this.diagnostic_personTableAdapter.ClearBeforeFill = true;
            // 
            // Ultrasono_Pregnency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 460);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Ultrasono_Pregnency";
            this.Text = "Ultrasono_Pregnency";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ultrasono_Pregnency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultrasono_pregnencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource ultrasono_pregnencyBindingSource;
        private DataSet59 DataSet59;
        private System.Windows.Forms.BindingSource diagnostic_personBindingSource;
        private DataSet59TableAdapters.ultrasono_pregnencyTableAdapter ultrasono_pregnencyTableAdapter;
        private DataSet59TableAdapters.diagnostic_personTableAdapter diagnostic_personTableAdapter;
    }
}