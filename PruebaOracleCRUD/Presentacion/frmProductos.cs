using PruebaOracleCRUD.Datos;
using PruebaOracleCRUD.Entidades;
using PruebaOracleCRUD.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaOracleCRUD.Presentacion
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        #region "Mis Variables"
        int nCodigo_pr = 0;
        int nEstadoguarda = 0;
        #endregion

        #region "Mis Metodos"
        private void LimpiaTexto()
        {
            txtDescripcion_pr.Clear();
            txtMarca_pr.Clear();
            txtMedida_pr.Clear();
            txtStock.Clear();
            cmbCategorias.Text = "";
        }

        private void EstadoTexto(bool lEstado)
        {
            txtDescripcion_pr.Enabled= lEstado;
            txtMarca_pr.Enabled = lEstado;
            txtMedida_pr.Enabled =lEstado;
            txtStock.Enabled = lEstado;
            cmbCategorias.Enabled = lEstado;
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            btnCancelar.Visible = lEstado;
            btnGuardar.Visible = lEstado;
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;  
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;
        }

        private void Listado_ca()
        {
            D_Productos Datos = new D_Productos();
            cmbCategorias.DataSource = Datos.listado_ca();
            cmbCategorias.ValueMember = "codigo_ca";
            cmbCategorias.DisplayMember = "description_ca";
        }
        private void Formato_pr()
        {
            dgvListado.Columns[0].Width = 100;
            dgvListado.Columns[0].HeaderText = "CODIGO_PR";
            dgvListado.Columns[1].Width = 180;
            dgvListado.Columns[1].HeaderText = "PRODUCTO";
            dgvListado.Columns[2].Width = 130;
            dgvListado.Columns[2].HeaderText = "MARCA";
            dgvListado.Columns[3].Width = 100;
            dgvListado.Columns[3].HeaderText = "MEDIDA";
            dgvListado.Columns[4].Width = 150;
            dgvListado.Columns[4].HeaderText = "CATEGORIA";
            dgvListado.Columns[5].Width = 120;
            dgvListado.Columns[5].HeaderText = "STOCK ACTUAL";
            dgvListado.Columns[6].Visible = false;

        }

        private void Listado_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            dgvListado.DataSource = Datos.listado_pr(cTexto);
            this.Formato_pr();
        }

        private void Selecciona_item()
        {
            if ( string.IsNullOrEmpty (dgvListado.CurrentRow.Cells["codigo_pr"].Value.ToString()))
            {
                MessageBox.Show("Seleccione un registro",
                                "Aviso del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                nCodigo_pr = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_pr"].Value);
                txtDescripcion_pr.Text = Convert.ToString(dgvListado.CurrentRow.Cells["description_pr"].Value);
                txtMarca_pr.Text = Convert.ToString(dgvListado.CurrentRow.Cells["marca_pro"].Value);
                txtMedida_pr.Text = Convert.ToString(dgvListado.CurrentRow.Cells["medida_pr"].Value);
                cmbCategorias.Text = Convert.ToString(dgvListado.CurrentRow.Cells["description_ca"].Value);
                txtStock.Text = Convert.ToString(dgvListado.CurrentRow.Cells["stock_actual"].Value);
            }
        }

        #endregion

        private void frmProductos_Load(object sender, EventArgs e)
        {
            this.Listado_ca();
            this.Listado_pr("%"); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 1; //Nuevo registro
            this.LimpiaTexto();
            this.EstadoTexto(true);
            this.Estado_Botonesprocesos(true);
            this.Estado_Botonesprincipales(false);
            txtDescripcion_pr.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 0;
            this.LimpiaTexto();
            this.EstadoTexto(false);
            this.Estado_Botonesprocesos(false);
            this.Estado_Botonesprincipales(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion_pr.Text == string.Empty ||
                txtMarca_pr.Text == string.Empty ||
                txtMedida_pr.Text == string.Empty ||
                cmbCategorias.Text == string.Empty ||
                txtStock.Text == string.Empty)
            {
                MessageBox.Show("Ingrese datos requeridos (*)",
                    "Aviso del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else //guarda informacion
            {
                E_Productos oPro = new E_Productos();
                string Res = "";
                oPro.Codigo_pr = nCodigo_pr;
                oPro.Description_pr = txtDescripcion_pr.Text;
                oPro.Marca_pr = txtMarca_pr.Text;
                oPro.Medida_pr = txtMedida_pr.Text;
                oPro.Codigo_ca = Convert.ToInt32(cmbCategorias.SelectedValue);
                oPro.Stock_actual = float.Parse(txtStock.Text.Trim());
                
                D_Productos Datos = new D_Productos();
                Res = Datos.Guardar_pr(nEstadoguarda, oPro);

                if(Res.Equals("OK"))
                {
                    nCodigo_pr = 0;
                    this.LimpiaTexto();
                    this.EstadoTexto(false);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_Botonesprincipales(true);
                    this.Listado_pr("%");
                    MessageBox.Show("Los datos han sido guardados correctamente",
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Res,
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_pr(txtBuscar.Text.Trim());
        }

        private void dgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 2; //Actualizar registro
            this.EstadoTexto(true);
            this.Estado_Botonesprocesos(true);
            this.Estado_Botonesprincipales(false);
            txtDescripcion_pr.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvListado.Rows.Count > 0)
            {
                string Res = "";
                D_Productos Datos = new D_Productos();
                Res = Datos.Eliminar_pr(Convert.ToInt32( dgvListado.CurrentRow.Cells["codigo_pr"].Value));
                if (Res.Equals("OK"))
                {
                    this.Listado_pr("%");
                    this.LimpiaTexto();
                    MessageBox.Show("El registro ha sido eliminado",
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(Res,
                                   "Aviso del sistema",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmrpt_producto oRpt = new frmrpt_producto();
            oRpt.txt_p01.Text = txtBuscar.Text;
            oRpt.ShowDialog();
        }
    }
}
