namespace Diagnostic_Center
{
    partial class Print_Hospital_Patient
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
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DataSet54 = new Diagnostic_Center.DataSet54();
            this.patient_histroyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patient_histroyTableAdapter = new Diagnostic_Center.DataSet54TableAdapters.patient_histroyTableAdapter();
            this.user_cash_collection_hospitalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_cash_collection_hospitalTableAdapter = new Diagnostic_Center.DataSet54TableAdapters.user_cash_collection_hospitalTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patient_histroyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collection_hospitalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet54";
            reportDataSource1.Value = this.patient_histroyBindingSource;
            reportDataSource2.Name = "DataSet54a";
            reportDataSource2.Value = this.user_cash_collection_hospitalBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report66.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 32);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(894, 409);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(176, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "To";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(51, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // DataSet54
            // 
            this.DataSet54.DataSetName = "DataSet54";
            this.DataSet54.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patient_histroyBindingSource
            // 
            this.patient_histroyBindingSource.DataMember = "patient_histroy";
            this.patient_histroyBindingSource.DataSource = this.DataSet54;
            // 
            // patient_histroyTableAdapter
            // 
            this.patient_histroyTableAdapter.ClearBeforeFill = true;
            // 
            // user_cash_collection_hospitalBindingSource
            // 
            this.user_cash_collection_hospitalBindingSource.DataMember = "user_cash_collection_hospital";
            this.user_cash_collection_hospitalBindingSource.DataSource = this.DataSet54;
            // 
            // user_cash_collection_hospitalTableAdapter
            // 
            this.user_cash_collection_hospitalTableAdapter.ClearBeforeFill = true;
            // 
            // Print_Hospital_Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Print_Hospital_Patient";
            this.Text = "Print_Hospital_Patient";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Print_Hospital_Patient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patient_histroyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_cash_collection_hospitalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.BindingSource patient_histroyBindingSource;
        private DataSet54 DataSet54;
        private System.Windows.Forms.BindingSource user_cash_collection_hospitalBindingSource;
        private DataSet54TableAdapters.patient_histroyTableAdapter patient_histroyTableAdapter;
        private DataSet54TableAdapters.user_cash_collection_hospitalTableAdapter user_cash_collection_hospitalTableAdapter;
    }
}