namespace Diagnostic_Center
{
    partial class card_prints
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
            this.card_detailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet48 = new Diagnostic_Center.DataSet48();
            this.card_serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.card_detailsTableAdapter = new Diagnostic_Center.DataSet48TableAdapters.card_detailsTableAdapter();
            this.card_serviceTableAdapter = new Diagnostic_Center.DataSet48TableAdapters.card_serviceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.card_detailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_serviceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // card_detailsBindingSource
            // 
            this.card_detailsBindingSource.DataMember = "card_details";
            this.card_detailsBindingSource.DataSource = this.DataSet48;
            // 
            // DataSet48
            // 
            this.DataSet48.DataSetName = "DataSet48";
            this.DataSet48.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // card_serviceBindingSource
            // 
            this.card_serviceBindingSource.DataMember = "card_service";
            this.card_serviceBindingSource.DataSource = this.DataSet48;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "card_details";
            reportDataSource1.Value = this.card_detailsBindingSource;
            reportDataSource2.Name = "card_service";
            reportDataSource2.Value = this.card_serviceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report61.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(816, 485);
            this.reportViewer1.TabIndex = 0;
            // 
            // card_detailsTableAdapter
            // 
            this.card_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // card_serviceTableAdapter
            // 
            this.card_serviceTableAdapter.ClearBeforeFill = true;
            // 
            // card_prints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 485);
            this.Controls.Add(this.reportViewer1);
            this.Name = "card_prints";
            this.Text = "card_prints";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.card_prints_Load);
            ((System.ComponentModel.ISupportInitialize)(this.card_detailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_serviceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource card_detailsBindingSource;
        private DataSet48 DataSet48;
        private System.Windows.Forms.BindingSource card_serviceBindingSource;
        private DataSet48TableAdapters.card_detailsTableAdapter card_detailsTableAdapter;
        private DataSet48TableAdapters.card_serviceTableAdapter card_serviceTableAdapter;
    }
}