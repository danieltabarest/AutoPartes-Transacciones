using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LibBasica;
using System.Web.UI.WebControls;

namespace LibRNAutoPartes.Compra
{
    public class clsCabeceraCompra
    {
        #region Atributos

        //Atributos Cabecera CabCompra
        private int idCabCompra;
        private DateTime dtmFechaCabCompra;
        private string stridCliente;
        private string stridEmpleado;
        private string strNitProveedor;

        private decimal decVlr;
        private decimal decIva;



        private GridView gvCabCompra;
        private DropDownList ddlCliente;
        private DropDownList ddlEmpleado;


        private string strError;

        private clsGrid objGrid;
        private clsCombo objCombo;

        private clsConexBd objConBd;



        #endregion


        #region Propiedades

        public int gsNroOrd
        {
            get { return idCabCompra; }
            set { idCabCompra = value; }
        }

        public DateTime gsFechaCabCompra
        {
            get { return dtmFechaCabCompra; }
            set { dtmFechaCabCompra = value; }
        }

        public string gsCodCli
        {
            get { return stridCliente; }
            set { stridCliente = value; }
        }

        public string gsCodTec
        {
            get { return stridEmpleado; }
            set { stridEmpleado = value; }
        }

        public string gsNitProveedor
        {
            get { return strNitProveedor; }
            set { strNitProveedor = value; }
        }
        public decimal gsVlr
        {
            get { return decVlr; }
            set { decVlr = value; }
        }

        public decimal gsIva
        {
            get { return decIva; }
            set { decIva = value; }
        }

        public GridView gsGvCabCompra
        {
            get { return gvCabCompra; }
            set { gvCabCompra = value; }
        }

        public DropDownList gsDdlCliente
        {
            get { return ddlCliente; }
            set { ddlCliente = value; }
        }

        public DropDownList gsDdlEmpleado
        {
            get { return ddlEmpleado; }
            set { ddlEmpleado = value; }
        }


        public string gError    
        {
            get { return strError; }
        }

        #endregion


        #region Metodos Privados

        private bool ExisteCompra()
        {
            if (idCabCompra < 1)
            {
                strError = "NO se asigno numero de orden o es un numero invalido";
                return false;
            }

            objConBd.gsSql = "sp_ExisteCabeceraCompra";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.Int, 10, idCabCompra))
            {
                strError = objConBd.gError;
                //objConBd = null;
                return false;
            }

            if (!objConBd.GetScalar(true))
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                //objConBd = null;
                return false;
            }

            if (objConBd.gScalar == null)
            {
                strError = "NO Existe Compra con numero de orden asignado";
                objConBd.gCommand.Parameters.Clear();
                //objConBd = null;
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            //objConBd = null;
            return true;
        }

        private bool ValDatosCabCompra()
        {
            if (idCabCompra < 1 || idCabCompra == null)
            {
                strError = "NO se asigno numero de orden o es un numero invalido";
                return false;
            }

            if (dtmFechaCabCompra == null)
            {
                strError = "NO se asigno fecha de orden";
                return false;
            }

            if (String.IsNullOrEmpty(stridCliente))
            {
                strError = "NO se asigno Codigo de Cliente";
                return false;
            }

            if (String.IsNullOrEmpty(stridEmpleado))
            {
                strError = "NO se asigno Codigo de Empleado";
                return false;
            }

            if (decVlr < 1)
            {
                strError = "Valor Orden menor a Cero o Invalido";
                return false;
            }

            if (decIva < 1)
            {
                strError = "Iva menor a Cero o Invalido";
                return false;
            }

            return true;


        }

        private bool InsertarCabCompra()
        {
            if (!ValDatosCabCompra())
            {
                return false;
            }

            objConBd.gsSql = "sp_InsertarCabeceraCompra";

            if (!AdicionarParamsCabCompra())
            {
                return false;
            }

            if (!objConBd.ExecSql(true)) //Metodo que Ejecuta Instrucciones Insert, Update  y Delete en la BD
            {
                strError = objConBd.gError;
                    objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }

        private bool ModificarCabCompra()
        {
            if (!ValDatosCabCompra())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarCabeceraCompra";

            if (!AdicionarParamsCabCompra())
            {
                return false;
            }

            if (!objConBd.ExecSql(true)) //Metodo que Ejecuta Instrucciones Insert, Update  y Delete en la BD
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }

        private bool AdicionarParamsCabCompra()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.Int, 12, idCabCompra))
            {
                strError = objConBd.gError;
                objConBd = null;
                return false;
            }


            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@FechaCompra", SqlDbType.SmallDateTime, 10, dtmFechaCabCompra))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@VlrCompra", SqlDbType.Decimal, 18, decVlr))
            {
                strError = objConBd.gError;
                return false;
            }
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCliente", SqlDbType.VarChar, 10, stridCliente))
            {
                strError = objConBd.gError;
                return false;
            }
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdEmpleado", SqlDbType.VarChar, 10, stridEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }


            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IvaCompra", SqlDbType.Decimal, 18, decIva))
            {
                strError = objConBd.gError;
                return false;
            }

            return true;
        }

        #endregion


        #region Metodos Publicos

        public bool GrabarCabCompra()
        {
            objConBd = new clsConexBd();

            if (ExisteCompra()) //Existe, por lo tanto Modifico
            {
                if (!ModificarCabCompra())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarCabCompra())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
        }

        public bool EliminarCabCompra()
        {
            objConBd = new clsConexBd();

            if (idCabCompra < 1 )
            {
                strError = "NO se asignó numero de la compra";
                return false;
            }

            objConBd.gsSql = "sp_EliminarCabaceraCompra";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.Int, 10, idCabCompra))
            {
                strError = objConBd.gError;
                //objConBd = null;
                return false;
            }
            

            if (!objConBd.ExecSql(true)) //Metodo que Ejecuta Instrucciones Insert, Update  y Delete en la BD
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }

        public bool LlenarCabeceraCompra()
        {
            if (gvCabCompra == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_LlenarCabeceraCompra";
            objGrid.gsNomTabla = "Cabecera";
            objGrid.gsGvGen = gvCabCompra;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvCabCompra = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool ObtenerCabCompra()
        {

            objConBd = new clsConexBd();
                
            if (!ExisteCompra())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ExisteCabeceraCompra";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.Int, 12, idCabCompra))
            {
                strError = objConBd.gError;
                objConBd = null;
                return false;
            }

            if (!objConBd.GetDataReader(true))
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

         

            if (!objConBd.gDataReader.Read())
            {
                strError = "NO Existe Orden en Cabecera";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {

                dtmFechaCabCompra = (DateTime)objConBd.gDataReader["FechaCompra"];
                stridCliente = (string)objConBd.gDataReader[3];
                stridEmpleado = (string)objConBd.gDataReader[4];
                decVlr = (decimal)objConBd.gDataReader[2];
                decIva = (decimal)objConBd.gDataReader[5];

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
            }

        }

        public bool LlenarCliente()
        {
            if (ddlCliente == null)
            {
                strError = "NO se asignó Lista Despegable de Cliente";
                return false;
            }

            objCombo = new clsCombo();

            objCombo.gsSql = "sp_Cliente";
            objCombo.gsNomTabla = "Cliente";
            objCombo.gsColValor = "IdCliente";
            objCombo.gsColTexto = "NombreCliente";

            objCombo.gsDdlGen = ddlCliente;

            if (!objCombo.LlenarDdl())
            {
                strError = objCombo.gError;
                objCombo = null;
                return false;
            }

            ddlCliente = objCombo.gsDdlGen;

            objCombo = null;
            return true;
        }

        public bool LlenarEmpleado()
        {
            if (ddlEmpleado == null)
            {
                strError = "NO se asignó Lista Despegable de Empleado";
                return false;
            }

            objCombo = new clsCombo();

            objCombo.gsSql = "sp_Empleado";
            objCombo.gsNomTabla = "Empleado";
            objCombo.gsColValor = "IdEmpleado";
            objCombo.gsColTexto = "NombreEmpleado";

            objCombo.gsDdlGen = ddlEmpleado;

            if (!objCombo.LlenarDdl())
            {
                strError = objCombo.gError;
                objCombo = null;
                return false;
            }

            ddlEmpleado = objCombo.gsDdlGen;

            objCombo = null;
            return true;
        }

        #endregion
    }
}
