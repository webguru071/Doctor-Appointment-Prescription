namespace Diagnostic_Center
{
    partial class Commission_Pay_Print
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet66 = new Diagnostic_Center.DataSet66();
            this.commission_printBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commission_printTableAdapter = new Diagnostic_Center.DataSet66TableAdapters.commission_printTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commission_printBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet66";
            reportDataSource1.Value = this.commission_printBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report79.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(689, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet66
            // 
            this.DataSet66.DataSetName = "DataSet66";
            this.DataSet66.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // commission_printBindingSource
            // 
            this.commission_printBindingSource.DataMember = "commission_print";
            this.commission_printBindingSource.DataSource = this.DataSet66;
            // 
            // commission_printTableAdapter
            // 
            this.commission_printTableAdapter.ClearBeforeFill = true;
            // 
            // Commission_Pay_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 425);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Commission_Pay_Print";
            this.Text = "Commission_Pay_Print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Commission_Pay_Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commission_printBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource commission_printBindingSource;
        private DataSet66 DataSet66;
        private DataSet66TableAdapters.commission_printTableAdapter commission_printTableAdapter;
    }
}