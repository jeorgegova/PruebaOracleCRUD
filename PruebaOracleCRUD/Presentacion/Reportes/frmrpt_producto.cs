using Microsoft.Reporting.WinForms;
using PruebaOracleCRUD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaOracleCRUD.Presentacion.Reportes
{
    public partial class frmrpt_producto : Form
    {
        public frmrpt_producto()
        {
            InitializeComponent();
        }

        private void frmrpt_producto_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        #region "Mis Metodos"
        
        private void Listado()
        {
            try
            {
                D_Productos Datos = new D_Productos();
                string cTexto = txt_p01.Text;
                DataTable miTabla = new DataTable();
                miTabla = Datos.listado_pr(cTexto);
                ReportDataSource fuente = new ReportDataSource("DataSet1", miTabla);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(fuente);
                reportViewer1.LocalReport.ReportEmbeddedResource = "PruebaOracleCRUD.Presentacion.Reportes.Rpt_Productos.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        #endregion

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.Listado();
        }
    }
}
