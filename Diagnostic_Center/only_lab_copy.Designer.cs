namespace Diagnostic_Center
{
    partial class only_lab_copy
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
            this.diagnostic_billBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Diagnostic_Center.DataSet1();
            this.user_cash_collectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.diagnostic_billTableAdapter = new Diagnostic_Center.DataSet1TableAdapters.diagnostic_billTableAdapter();
            this.user_cash_collectionTableAdapter = new Diagnostic_Center.DataSet1TableAdapters.user_cash_collectionTableAdapter();
            this.xray_reportTableAdapter1 = new Diagnostic_Center.DataSet23TableAdapters.xray_reportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_billBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // diagnostic_billBindingSource
            // 
            this.diagnostic_billBindingSource.DataMember = "diagnostic_bill";
            this.diagnostic_billBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // user_cash_collectionBindingSource
            // 
            this.user_cash_collectionBindingSource.DataMember = "user_cash_collection";
            this.user_cash_collectionBindingSource.DataSource = this.DataSet1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.diagnostic_billBindingSource;
            reportDataSource2.Name = "DataSet1a";
            reportDataSource2.Value = this.user_cash_collectionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report73.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(676, 413);
            this.reportViewer1.TabIndex = 0;
            // 
            // diagnostic_billTableAdapter
            // 
            this.diagnostic_billTableAdapter.ClearBeforeFill = true;
            // 
            // user_cash_collectionTableAdapter
            // 
            this.user_cash_collectionTableAdapter.ClearBeforeFill = true;
            // 
            // xray_reportTableAdapter1
            // 
            this.xray_reportTableAdapter1.ClearBeforeFill = true;
            // 
            // only_lab_copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 413);
            this.Controls.Add(this.reportViewer1);
            this.Name = "only_lab_copy";
            this.Text = "only_lab_copy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.only_lab_copy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_billBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource diagnostic_billBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.diagnostic_billTableAdapter diagnostic_billTableAdapter;
        private System.Windows.Forms.BindingSource user_cash_collectionBindingSource;
        private DataSet1TableAdapters.user_cash_collectionTableAdapter user_cash_collectionTableAdapter;
        private DataSet23TableAdapters.xray_reportTableAdapter xray_reportTableAdapter1;
    }
}