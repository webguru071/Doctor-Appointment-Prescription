namespace Diagnostic_Center
{
    partial class Stool_Report
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet47 = new Diagnostic_Center.DataSet47();
            this.stoolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stoolTableAdapter = new Diagnostic_Center.DataSet47TableAdapters.stoolTableAdapter();
            this.diagnostic_personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diagnostic_personTableAdapter = new Diagnostic_Center.DataSet47TableAdapters.diagnostic_personTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stoolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Pathologist";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(90, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet36";
            reportDataSource1.Value = this.stoolBindingSource;
            reportDataSource2.Name = "DataSet25a";
            reportDataSource2.Value = this.diagnostic_personBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report60.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 36);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(529, 310);
            this.reportViewer1.TabIndex = 15;
            // 
            // DataSet47
            // 
            this.DataSet47.DataSetName = "DataSet47";
            this.DataSet47.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stoolBindingSource
            // 
            this.stoolBindingSource.DataMember = "stool";
            this.stoolBindingSource.DataSource = this.DataSet47;
            // 
            // stoolTableAdapter
            // 
            this.stoolTableAdapter.ClearBeforeFill = true;
            // 
            // diagnostic_personBindingSource
            // 
            this.diagnostic_personBindingSource.DataMember = "diagnostic_person";
            this.diagnostic_personBindingSource.DataSource = this.DataSet47;
            // 
            // diagnostic_personTableAdapter
            // 
            this.diagnostic_personTableAdapter.ClearBeforeFill = true;
            // 
            // Stool_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 358);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Stool_Report";
            this.Text = "Stool_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Stool_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stoolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource stoolBindingSource;
        private DataSet47 DataSet47;
        private System.Windows.Forms.BindingSource diagnostic_personBindingSource;
        private DataSet47TableAdapters.stoolTableAdapter stoolTableAdapter;
        private DataSet47TableAdapters.diagnostic_personTableAdapter diagnostic_personTableAdapter;
    }
}