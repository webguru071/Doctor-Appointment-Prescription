﻿namespace Diagnostic_Center
{
    partial class Pharmacy_Due_Print
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
            this.DataSet15 = new Diagnostic_Center.DataSet15();
            this.medicine_selling_historyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicine_selling_historyTableAdapter = new Diagnostic_Center.DataSet15TableAdapters.medicine_selling_historyTableAdapter();
            this.user_cash_collection_pharmacyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_cash_collection_pharmacyTableAdapter = new Diagnostic_Center.DataSet15TableAdapters.user_cash_collection_pharmacyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicine_selling_historyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collection_pharmacyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet15";
            reportDataSource1.Value = this.medicine_selling_historyBindingSource;
            reportDataSource2.Name = "DataSet15a";
            reportDataSource2.Value = this.user_cash_collection_pharmacyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report54.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(476, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet15
            // 
            this.DataSet15.DataSetName = "DataSet15";
            this.DataSet15.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // medicine_selling_historyBindingSource
            // 
            this.medicine_selling_historyBindingSource.DataMember = "medicine_selling_history";
            this.medicine_selling_historyBindingSource.DataSource = this.DataSet15;
            // 
            // medicine_selling_historyTableAdapter
            // 
            this.medicine_selling_historyTableAdapter.ClearBeforeFill = true;
            // 
            // user_cash_collection_pharmacyBindingSource
            // 
            this.user_cash_collection_pharmacyBindingSource.DataMember = "user_cash_collection_pharmacy";
            this.user_cash_collection_pharmacyBindingSource.DataSource = this.DataSet15;
            // 
            // user_cash_collection_pharmacyTableAdapter
            // 
            this.user_cash_collection_pharmacyTableAdapter.ClearBeforeFill = true;
            // 
            // Pharmacy_Due_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Pharmacy_Due_Print";
            this.Text = "Pharmacy_Due_Print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pharmacy_Due_Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicine_selling_historyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collection_pharmacyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource medicine_selling_historyBindingSource;
        private DataSet15 DataSet15;
        private System.Windows.Forms.BindingSource user_cash_collection_pharmacyBindingSource;
        private DataSet15TableAdapters.medicine_selling_historyTableAdapter medicine_selling_historyTableAdapter;
        private DataSet15TableAdapters.user_cash_collection_pharmacyTableAdapter user_cash_collection_pharmacyTableAdapter;
    }
}