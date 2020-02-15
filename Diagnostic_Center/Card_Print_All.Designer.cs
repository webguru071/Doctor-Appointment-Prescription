namespace Diagnostic_Center
{
    partial class Card_Print_All
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet55 = new Diagnostic_Center.DataSet55();
            this.card_detailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.card_detailsTableAdapter = new Diagnostic_Center.DataSet55TableAdapters.card_detailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_detailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet55";
            reportDataSource2.Value = this.card_detailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report67.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet55
            // 
            this.DataSet55.DataSetName = "DataSet55";
            this.DataSet55.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // card_detailsBindingSource
            // 
            this.card_detailsBindingSource.DataMember = "card_details";
            this.card_detailsBindingSource.DataSource = this.DataSet55;
            // 
            // card_detailsTableAdapter
            // 
            this.card_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // Card_Print_All
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Card_Print_All";
            this.Text = "Card_Print_All";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Card_Print_All_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_detailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource card_detailsBindingSource;
        private DataSet55 DataSet55;
        private DataSet55TableAdapters.card_detailsTableAdapter card_detailsTableAdapter;
    }
}