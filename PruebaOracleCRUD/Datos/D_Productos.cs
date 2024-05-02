using Oracle.ManagedDataAccess.Client;
using PruebaOracleCRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaOracleCRUD.Datos
{
    internal class D_Productos
    {

        public DataTable listado_ca()
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon =Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select DESCRIPTION_CA, codigo_ca from tb_categorias", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) 
                {
                SqlCon.Close();
                }
            }
        }

        public DataTable listado_pr( string cTexto)
        {
            OracleDataReader Resultado;
            DataTable Tabla = new DataTable();
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                cTexto = "%" + cTexto + "%";
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("select * from VISTA_PRODUCTOS where description_pr like '"+cTexto+"' order by codigo_pr", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string Guardar_pr(int nOpcion, E_Productos oPro)
        {
            string Res = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon=Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_GUARDAR_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("pOpcion", OracleDbType.Int32).Value = nOpcion;
                Comando.Parameters.Add("pCodigo_pr", OracleDbType.Int32).Value = oPro.Codigo_pr;
                Comando.Parameters.Add("pDescription_pr", OracleDbType.Varchar2).Value = oPro.Description_pr;
                Comando.Parameters.Add("pMarca_pr", OracleDbType.Varchar2).Value = oPro.Marca_pr;
                Comando.Parameters.Add("pMedida_pr", OracleDbType.Varchar2).Value = oPro.Medida_pr;
                Comando.Parameters.Add("pStock_actual", OracleDbType.Decimal).Value = oPro.Stock_actual;
                Comando.Parameters.Add("pCodigo_ca", OracleDbType.Int32).Value = oPro.Codigo_ca;
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Res = "OK";
            }
            catch (Exception ex)
            {

                Res = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }

            return Res;
        }

        public string Eliminar_pr(int nCodigo_pr)
        {
            string Res = "";
            OracleConnection SqlCon = new OracleConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                OracleCommand Comando = new OracleCommand("USP_ELIMINAR_PR", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("nCodigo_pr", OracleDbType.Int32).Value = nCodigo_pr;
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Res = "OK";
            }
            catch (Exception ex)
            {

                Res = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }

            return Res;
        }
    }
}
