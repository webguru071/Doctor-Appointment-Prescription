namespace Diagnostic_Center
{
    partial class Diagnostic_xl_print
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.user_cash_collectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Diagnostic_Center.DataSet1();
            this.lab_copyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diagnostic_billBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.due_collectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.diagnostic_billTableAdapter = new Diagnostic_Center.DataSet1TableAdapters.diagnostic_billTableAdapter();
            this.user_cash_collectionTableAdapter = new Diagnostic_Center.DataSet1TableAdapters.user_cash_collectionTableAdapter();
            this.lab_copy = new Diagnostic_Center.DataSet1TableAdapters.lab_copy();
            this.due_collectionTableAdapter = new Diagnostic_Center.DataSet1TableAdapters.due_collectionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab_copyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_billBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.due_collectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1a";
            reportDataSource1.Value = this.user_cash_collectionBindingSource;
            reportDataSource2.Name = "DataSet1b";
            reportDataSource2.Value = this.lab_copyBindingSource;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.diagnostic_billBindingSource;
            reportDataSource4.Name = "DataSet1c";
            reportDataSource4.Value = this.due_collectionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report39.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(823, 460);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Xerox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(624, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Lab Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // user_cash_collectionBindingSource
            // 
            this.user_cash_collectionBindingSource.DataMember = "user_cash_collection";
            this.user_cash_collectionBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lab_copyBindingSource
            // 
            this.lab_copyBindingSource.DataMember = "lab_copy";
            this.lab_copyBindingSource.DataSource = this.DataSet1;
            // 
            // diagnostic_billBindingSource
            // 
            this.diagnostic_billBindingSource.DataMember = "diagnostic_bill";
            this.diagnostic_billBindingSource.DataSource = this.DataSet1;
            // 
            // due_collectionBindingSource
            // 
            this.due_collectionBindingSource.DataMember = "due_collection";
            this.due_collectionBindingSource.DataSource = this.DataSet1;
            // 
            // diagnostic_billTableAdapter
            // 
            this.diagnostic_billTableAdapter.ClearBeforeFill = true;
            // 
            // user_cash_collectionTableAdapter
            // 
            this.user_cash_collectionTableAdapter.ClearBeforeFill = true;
            // 
            // lab_copy
            // 
            this.lab_copy.ClearBeforeFill = true;
            // 
            // due_collectionTableAdapter
            // 
            this.due_collectionTableAdapter.ClearBeforeFill = true;
            // 
            // Diagnostic_xl_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 511);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Diagnostic_xl_print";
            this.Text = "Diagnostic_xl_print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Diagnostic_xl_print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lab_copyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_billBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.due_collectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource diagnostic_billBindingSource;
        private DataSet1 DataSet1;
        private System.Windows.Forms.BindingSource user_cash_collectionBindingSource;
        private DataSet1TableAdapters.diagnostic_billTableAdapter diagnostic_billTableAdapter;
        private DataSet1TableAdapters.user_cash_collectionTableAdapter user_cash_collectionTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource lab_copyBindingSource;
        private DataSet1TableAdapters.lab_copy lab_copy;
        private System.Windows.Forms.BindingSource due_collectionBindingSource;
        private DataSet1TableAdapters.due_collectionTableAdapter due_collectionTableAdapter;
        private System.Windows.Forms.Button button2;
    }
}