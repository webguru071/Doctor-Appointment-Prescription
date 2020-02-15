namespace Diagnostic_Center
{
    partial class All_Purchase_histry_print
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
            this.DataSet63 = new Diagnostic_Center.DataSet63();
            this.purchase_product_paidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchase_product_paidTableAdapter = new Diagnostic_Center.DataSet63TableAdapters.purchase_product_paidTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchase_product_paidBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.purchase_product_paidBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report76.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(530, 297);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet63
            // 
            this.DataSet63.DataSetName = "DataSet63";
            this.DataSet63.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // purchase_product_paidBindingSource
            // 
            this.purchase_product_paidBindingSource.DataMember = "purchase_product_paid";
            this.purchase_product_paidBindingSource.DataSource = this.DataSet63;
            // 
            // purchase_product_paidTableAdapter
            // 
            this.purchase_product_paidTableAdapter.ClearBeforeFill = true;
            // 
            // All_Purchase_histry_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 297);
            this.Controls.Add(this.reportViewer1);
            this.Name = "All_Purchase_histry_print";
            this.Text = "All_Purchase_histry_print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.All_Purchase_histry_print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchase_product_paidBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource purchase_product_paidBindingSource;
        private DataSet63 DataSet63;
        private DataSet63TableAdapters.purchase_product_paidTableAdapter purchase_product_paidTableAdapter;
    }
}