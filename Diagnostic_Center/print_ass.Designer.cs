namespace Diagnostic_Center
{
    partial class print_ass
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
            this.print_asset = new Diagnostic_Center.print_asset();
            this.fixed_assetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fixed_assetTableAdapter = new Diagnostic_Center.print_assetTableAdapters.fixed_assetTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.print_asset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixed_assetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.fixed_assetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Diagnostic_Center.Report62.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(664, 303);
            this.reportViewer1.TabIndex = 0;
            // 
            // print_asset
            // 
            this.print_asset.DataSetName = "print_asset";
            this.print_asset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fixed_assetBindingSource
            // 
            this.fixed_assetBindingSource.DataMember = "fixed_asset";
            this.fixed_assetBindingSource.DataSource = this.print_asset;
            // 
            // fixed_assetTableAdapter
            // 
            this.fixed_assetTableAdapter.ClearBeforeFill = true;
            // 
            // print_ass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 303);
            this.Controls.Add(this.reportViewer1);
            this.Name = "print_ass";
            this.Text = "print_ass";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.print_ass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.print_asset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixed_assetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource fixed_assetBindingSource;
        private print_asset print_asset;
        private print_assetTableAdapters.fixed_assetTableAdapter fixed_assetTableAdapter;
    }
}