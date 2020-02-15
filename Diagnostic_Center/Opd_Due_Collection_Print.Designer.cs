namespace Diagnostic_Center
{
    partial class Opd_Due_Collection_Print
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
            this.admissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet10 = new Diagnostic_Center.DataSet10();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.admissionTableAdapter = new Diagnostic_Center.DataSet10TableAdapters.admissionTableAdapter();
            this.DataSet44 = new Diagnostic_Center.DataSet44();
            this.opdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opdTableAdapter = new Diagnostic_Center.DataSet44TableAdapters.opdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.admissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opdBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // admissionBindingSource
            // 
            this.admissionBindingSource.DataMember = "admission";
            this.admissionBindingSource.DataSource = this.DataSet10;
            // 
            // DataSet10
            // 
            this.DataSet10.DataSetName = "DataSet10";
            this.DataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet10";
            reportDataSource1.Value = this.opdBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report53.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(610, 338);
            this.reportViewer1.TabIndex = 0;
            // 
            // admissionTableAdapter
            // 
            this.admissionTableAdapter.ClearBeforeFill = true;
            // 
            // DataSet44
            // 
            this.DataSet44.DataSetName = "DataSet44";
            this.DataSet44.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opdBindingSource
            // 
            this.opdBindingSource.DataMember = "opd";
            this.opdBindingSource.DataSource = this.DataSet44;
            // 
            // opdTableAdapter
            // 
            this.opdTableAdapter.ClearBeforeFill = true;
            // 
            // Opd_Due_Collection_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 338);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Opd_Due_Collection_Print";
            this.Text = "Opd_Due_Collection_Print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Opd_Due_Collection_Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.admissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opdBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource admissionBindingSource;
        private DataSet10 DataSet10;
        private DataSet10TableAdapters.admissionTableAdapter admissionTableAdapter;
        private System.Windows.Forms.BindingSource opdBindingSource;
        private DataSet44 DataSet44;
        private DataSet44TableAdapters.opdTableAdapter opdTableAdapter;
    }
}