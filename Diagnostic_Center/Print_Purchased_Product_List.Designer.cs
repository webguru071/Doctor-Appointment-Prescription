namespace Diagnostic_Center
{
    partial class Print_Purchased_Product_List
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
            this.DataSet61 = new Diagnostic_Center.DataSet61();
            this.purchase_productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchase_productTableAdapter = new Diagnostic_Center.DataSet61TableAdapters.purchase_productTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchase_productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet61";
            reportDataSource1.Value = this.purchase_productBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report74.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(649, 391);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet61
            // 
            this.DataSet61.DataSetName = "DataSet61";
            this.DataSet61.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // purchase_productBindingSource
            // 
            this.purchase_productBindingSource.DataMember = "purchase_product";
            this.purchase_productBindingSource.DataSource = this.DataSet61;
            // 
            // purchase_productTableAdapter
            // 
            this.purchase_productTableAdapter.ClearBeforeFill = true;
            // 
            // Print_Purchased_Product_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 391);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Print_Purchased_Product_List";
            this.Text = "Print_Purchased_Product_List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Print_Purchased_Product_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchase_productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource purchase_productBindingSource;
        private DataSet61 DataSet61;
        private DataSet61TableAdapters.purchase_productTableAdapter purchase_productTableAdapter;
    }
}