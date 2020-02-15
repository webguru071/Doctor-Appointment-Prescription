namespace Diagnostic_Center
{
    partial class Immunology_Report
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
            this.immunologyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet46 = new Diagnostic_Center.DataSet46();
            this.diagnostic_personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.immunologyTableAdapter = new Diagnostic_Center.DataSet46TableAdapters.immunologyTableAdapter();
            this.diagnostic_personTableAdapter = new Diagnostic_Center.DataSet46TableAdapters.diagnostic_personTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.immunologyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet35";
            reportDataSource1.Value = this.immunologyBindingSource;
            reportDataSource2.Name = "DataSet25a";
            reportDataSource2.Value = this.diagnostic_personBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report59.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 38);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(577, 336);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pathologist";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // immunologyBindingSource
            // 
            this.immunologyBindingSource.DataMember = "immunology";
            this.immunologyBindingSource.DataSource = this.DataSet46;
            // 
            // DataSet46
            // 
            this.DataSet46.DataSetName = "DataSet46";
            this.DataSet46.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diagnostic_personBindingSource
            // 
            this.diagnostic_personBindingSource.DataMember = "diagnostic_person";
            this.diagnostic_personBindingSource.DataSource = this.DataSet46;
            // 
            // immunologyTableAdapter
            // 
            this.immunologyTableAdapter.ClearBeforeFill = true;
            // 
            // diagnostic_personTableAdapter
            // 
            this.diagnostic_personTableAdapter.ClearBeforeFill = true;
            // 
            // Immunology_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Immunology_Report";
            this.Text = "Immunology_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Immunology_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.immunologyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource immunologyBindingSource;
        private DataSet46 DataSet46;
        private System.Windows.Forms.BindingSource diagnostic_personBindingSource;
        private DataSet46TableAdapters.immunologyTableAdapter immunologyTableAdapter;
        private DataSet46TableAdapters.diagnostic_personTableAdapter diagnostic_personTableAdapter;
    }
}