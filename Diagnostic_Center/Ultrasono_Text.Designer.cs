namespace Diagnostic_Center
{
    partial class Ultrasono_Text
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ultrasono_textBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet60 = new Diagnostic_Center.DataSet60();
            this.diagnostic_personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultrasono_textTableAdapter = new Diagnostic_Center.DataSet60TableAdapters.ultrasono_textTableAdapter();
            this.diagnostic_personTableAdapter = new Diagnostic_Center.DataSet60TableAdapters.diagnostic_personTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ultrasono_textBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet60";
            reportDataSource1.Value = this.ultrasono_textBindingSource;
            reportDataSource2.Name = "DataSet60a";
            reportDataSource2.Value = this.diagnostic_personBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report72.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(5, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(690, 410);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Pathologist";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(78, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(265, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ultrasono_textBindingSource
            // 
            this.ultrasono_textBindingSource.DataMember = "ultrasono_text";
            this.ultrasono_textBindingSource.DataSource = this.DataSet60;
            // 
            // DataSet60
            // 
            this.DataSet60.DataSetName = "DataSet60";
            this.DataSet60.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diagnostic_personBindingSource
            // 
            this.diagnostic_personBindingSource.DataMember = "diagnostic_person";
            this.diagnostic_personBindingSource.DataSource = this.DataSet60;
            // 
            // ultrasono_textTableAdapter
            // 
            this.ultrasono_textTableAdapter.ClearBeforeFill = true;
            // 
            // diagnostic_personTableAdapter
            // 
            this.diagnostic_personTableAdapter.ClearBeforeFill = true;
            // 
            // Ultrasono_Text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 459);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Ultrasono_Text";
            this.Text = "Ultrasono_Text";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ultrasono_Text_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultrasono_textBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource ultrasono_textBindingSource;
        private DataSet60 DataSet60;
        private System.Windows.Forms.BindingSource diagnostic_personBindingSource;
        private DataSet60TableAdapters.ultrasono_textTableAdapter ultrasono_textTableAdapter;
        private DataSet60TableAdapters.diagnostic_personTableAdapter diagnostic_personTableAdapter;
    }
}