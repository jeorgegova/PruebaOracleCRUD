namespace PruebaOracleCRUD.Presentacion.Reportes
{
    partial class frmrpt_producto
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
            this.listadoprBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_REPORTES = new PruebaOracleCRUD.Presentacion.Reportes.DS_REPORTES();
            this.txt_p01 = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.listadoprBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_REPORTES)).BeginInit();
            this.SuspendLayout();
            // 
            // listadoprBindingSource
            // 
            this.listadoprBindingSource.DataMember = "listado_pr";
            this.listadoprBindingSource.DataSource = this.dS_REPORTES;
            // 
            // dS_REPORTES
            // 
            this.dS_REPORTES.DataSetName = "DS_REPORTES";
            this.dS_REPORTES.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txt_p01
            // 
            this.txt_p01.Location = new System.Drawing.Point(35, 66);
            this.txt_p01.Name = "txt_p01";
            this.txt_p01.Size = new System.Drawing.Size(100, 20);
            this.txt_p01.TabIndex = 0;
            this.txt_p01.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.listadoprBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PruebaOracleCRUD.Presentacion.Reportes.Rpt_Productos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1454, 589);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // frmrpt_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 589);
            this.Controls.Add(this.txt_p01);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmrpt_producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmrpt_producto";
            this.Load += new System.EventHandler(this.frmrpt_producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listadoprBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_REPORTES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_p01;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource listadoprBindingSource;
        private DS_REPORTES dS_REPORTES;
    }
}