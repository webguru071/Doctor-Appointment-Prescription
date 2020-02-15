namespace Diagnostic_Center
{
    partial class Ultrasno_Male
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
            this.ultrasono_maleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet58 = new Diagnostic_Center.DataSet58();
            this.diagnostic_personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultrasono_maleTableAdapter = new Diagnostic_Center.DataSet58TableAdapters.ultrasono_maleTableAdapter();
            this.diagnostic_personTableAdapter = new Diagnostic_Center.DataSet58TableAdapters.diagnostic_personTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ultrasono_maleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.DocumentMapWidth = 24;
            reportDataSource1.Name = "DataSet58";
            reportDataSource1.Value = this.ultrasono_maleBindingSource;
            reportDataSource2.Name = "DataSet58a";
            reportDataSource2.Value = this.diagnostic_personBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report70.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 43);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(740, 405);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pathologist";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(265, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ultrasono_maleBindingSource
            // 
            this.ultrasono_maleBindingSource.DataMember = "ultrasono_male";
            this.ultrasono_maleBindingSource.DataSource = this.DataSet58;
            // 
            // DataSet58
            // 
            this.DataSet58.DataSetName = "DataSet58";
            this.DataSet58.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diagnostic_personBindingSource
            // 
            this.diagnostic_personBindingSource.DataMember = "diagnostic_person";
            this.diagnostic_personBindingSource.DataSource = this.DataSet58;
            // 
            // ultrasono_maleTableAdapter
            // 
            this.ultrasono_maleTableAdapter.ClearBeforeFill = true;
            // 
            // diagnostic_personTableAdapter
            // 
            this.diagnostic_personTableAdapter.ClearBeforeFill = true;
            // 
            // Ultrasno_Male
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 457);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Ultrasno_Male";
            this.Text = "Ultrasno_Male";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ultrasno_Male_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultrasono_maleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ultrasono_maleBindingSource;
        private DataSet58 DataSet58;
        private System.Windows.Forms.BindingSource diagnostic_personBindingSource;
        private DataSet58TableAdapters.ultrasono_maleTableAdapter ultrasono_maleTableAdapter;
        private DataSet58TableAdapters.diagnostic_personTableAdapter diagnostic_personTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}