namespace Diagnostic_Center
{
    partial class test_report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.diagnostic_billBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet52 = new Diagnostic_Center.DataSet52();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.diagnostic_billTableAdapter = new Diagnostic_Center.DataSet52TableAdapters.diagnostic_billTableAdapter();
            this.patient_histroyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet53 = new Diagnostic_Center.DataSet53();
            this.card_detailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patient_histroyTableAdapter = new Diagnostic_Center.DataSet53TableAdapters.patient_histroyTableAdapter();
            this.card_detailsTableAdapter = new Diagnostic_Center.DataSet53TableAdapters.card_detailsTableAdapter();
            this.opdTableAdapter = new Diagnostic_Center.DataSet53TableAdapters.opdTableAdapter();
            this.appointmentTableAdapter = new Diagnostic_Center.DataSet53TableAdapters.appointmentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_billBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patient_histroyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_detailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // diagnostic_billBindingSource
            // 
            this.diagnostic_billBindingSource.DataMember = "diagnostic_bill";
            this.diagnostic_billBindingSource.DataSource = this.DataSet52;
            // 
            // DataSet52
            // 
            this.DataSet52.DataSetName = "DataSet52";
            this.DataSet52.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.diagnostic_billBindingSource;
            reportDataSource2.Name = "DataSet3";
            reportDataSource2.Value = this.patient_histroyBindingSource;
            reportDataSource3.Name = "DataSet5";
            reportDataSource3.Value = this.card_detailsBindingSource;
            reportDataSource4.Name = "DataSet2";
            reportDataSource4.Value = this.opdBindingSource;
            reportDataSource5.Name = "DataSet4";
            reportDataSource5.Value = this.appointmentBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report65.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 47);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(992, 488);
            this.reportViewer1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(300, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 29);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(466, 13);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(128, 29);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonX1.BackColor = System.Drawing.Color.Chocolate;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(598, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(69, 29);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.buttonX1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonX1.SymbolSize = 14F;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Search";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "TO";
            // 
            // diagnostic_billTableAdapter
            // 
            this.diagnostic_billTableAdapter.ClearBeforeFill = true;
            // 
            // patient_histroyBindingSource
            // 
            this.patient_histroyBindingSource.DataMember = "patient_histroy";
            this.patient_histroyBindingSource.DataSource = this.DataSet53;
            // 
            // DataSet53
            // 
            this.DataSet53.DataSetName = "DataSet53";
            this.DataSet53.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // card_detailsBindingSource
            // 
            this.card_detailsBindingSource.DataMember = "card_details";
            this.card_detailsBindingSource.DataSource = this.DataSet53;
            // 
            // opdBindingSource
            // 
            this.opdBindingSource.DataMember = "opd";
            this.opdBindingSource.DataSource = this.DataSet53;
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataMember = "appointment";
            this.appointmentBindingSource.DataSource = this.DataSet53;
            // 
            // patient_histroyTableAdapter
            // 
            this.patient_histroyTableAdapter.ClearBeforeFill = true;
            // 
            // card_detailsTableAdapter
            // 
            this.card_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // opdTableAdapter
            // 
            this.opdTableAdapter.ClearBeforeFill = true;
            // 
            // appointmentTableAdapter
            // 
            this.appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // test_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 541);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Name = "test_report";
            this.Text = "Test report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.test_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.diagnostic_billBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patient_histroyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card_detailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource diagnostic_billBindingSource;
        private DataSet52 DataSet52;
        private System.Windows.Forms.BindingSource patient_histroyBindingSource;
        private DataSet53 DataSet53;
        private System.Windows.Forms.BindingSource card_detailsBindingSource;
        private System.Windows.Forms.BindingSource opdBindingSource;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private DataSet52TableAdapters.diagnostic_billTableAdapter diagnostic_billTableAdapter;
        private DataSet53TableAdapters.patient_histroyTableAdapter patient_histroyTableAdapter;
        private DataSet53TableAdapters.card_detailsTableAdapter card_detailsTableAdapter;
        private DataSet53TableAdapters.opdTableAdapter opdTableAdapter;
        private DataSet53TableAdapters.appointmentTableAdapter appointmentTableAdapter;
    }
}