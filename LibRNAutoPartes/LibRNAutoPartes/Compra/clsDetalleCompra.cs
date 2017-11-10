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
    public class clsDetalleCompra
    {
        #region Atributos
        private int IdProducto;
        private int IdDetCompra;


        private int IdCabCompra;

    
        private int intUnidadesCompradas;
        private decimal decVlrComprado;
        private GridView gvDetalleCompra;
        private DropDownList ddlProducto;
        private string strError;
        private clsConexBd objConBd;
        private clsCombo objCombo;
        #endregion


        #region Propiedades

        public int gsIdCabCompra
        {
            get { return IdCabCompra; }
            set { IdCabCompra = value; }
        }
        
        public int gsIdProducto
        {
            get { return IdProducto; }
            set { IdProducto = value; }
        }
        public int gsUnidadesCompradas
        {
            get { return intUnidadesCompradas; }
            set { intUnidadesCompradas = value; }
        }
        public decimal gsValor
        {
            get { return decVlrComprado; }
            set { decVlrComprado = value; }
        }
  

        public GridView gsGvDetalleCompra
        {
            get { return gvDetalleCompra; }
            set { gvDetalleCompra = value; }
        }
        public DropDownList gsddlProducto
        {
            get { return ddlProducto; }
            set { ddlProducto = value; }
        }


        public string gError
        {
            get { return strError; }
        }

        #endregion


        #region Metodos Privados

        private bool ValDatosDetalleCompra()
        {
            if (IdCabCompra < 1 || IdCabCompra == null)
            {
                strError = "NO se asigno numero de orden o es un numero invalido";
                return false;
            }

            if (IdProducto < 1 || IdProducto == null)
            {
                strError = "NO se asigno Codigo de Producto";
                return false;
            }

            if (intUnidadesCompradas < 1 || intUnidadesCompradas == null)
            {
                strError = "NO se asigno cantidad o es una cantidad invalida";
                return false;
            }

            if (decVlrComprado < 1 || decVlrComprado == null)
            {
                strError = "Valor Item menor a Cero o Invalido";
                return false;
            }

          

            return true;
        }

        private bool AdicionarParamsDetalleCompra()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.BigInt, 10, IdCabCompra))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdProducto", SqlDbType.BigInt, 10, IdProducto))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@UnidadesCompradas", SqlDbType.Int, 10, intUnidadesCompradas))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@VlrComprado", SqlDbType.Decimal, 12, decVlrComprado))
            {
                strError = objConBd.gError;
                return false;
            }

       

            return true;
        }

        private bool InsertarDetalleCompra()
        {
            if (!ValDatosDetalleCompra())
            {
                return false;
                
            }

            objConBd.gsSql = "sp_InsertarDetalleCompra";

            if (!AdicionarParamsDetalleCompra())
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
         
        

        private bool EliminarDetalle()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.BigInt, 10, IdCabCompra))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdProducto", SqlDbType.BigInt, 10, IdProducto))
            {
                strError = objConBd.gError;
                return false;
            }

            objConBd.gsSql = "sp_EliminarDetalleCompra";

            if (!objConBd.ExecSql(true)) //Metodo que Ejecuta Instrucciones Insert, Update  y Delete en la BD
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }


        private bool ModificarDetalleCompra()
        {
            if (!ValDatosDetalleCompra())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarDetalleCompra";

            if (!AdicionarParamsDetalleCompra())
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

        private bool ExisteDetalle()
        {
            if (IdCabCompra < 1 )
            {
                strError = "NO se asigno numero de orden o es un numero invalido";
                return false;
            }

       

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.Int, 10, IdCabCompra))
            {
                strError = objConBd.gError;
                
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdProducto", SqlDbType.BigInt, 10, IdProducto))
            {
                strError = objConBd.gError;
                
                return false;
            }
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@UnidadesCompradas", SqlDbType.BigInt, 10, intUnidadesCompradas))
            {
                strError = objConBd.gError;

                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@VlrComprado", SqlDbType.Float, 12, decVlrComprado))
            {
                strError = objConBd.gError;

                return false;
            }


            objConBd.gsSql = "sp_ExisteDetalleCompra";

       

            if (!objConBd.GetScalar(true))
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
              
                return false;
            }

            if (objConBd.gScalar == null)
            {
                strError = "NO Existe detalle ";
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }


        #endregion


        #region Metodos Publicos

        public bool GrabarDetalleCompra()
        {
            objConBd = new clsConexBd();

            if (ExisteDetalle()) //Existe, por lo tanto Modifico
            {
                if (!ModificarDetalleCompra())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarDetalleCompra())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
        }


        public bool EliminarDetalleCompra()
        {
            objConBd = new clsConexBd();

            if (ExisteDetalle()) //Existe, por lo tanto elimino
            {
                if (!EliminarDetalle())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            objConBd = null;
            return false;
        }

        public bool LlenarDetalleCompra()
        {
            if (IdCabCompra < 1 )
            {
                strError = "NO se asigno numero de orden o es un numero invalido";
                return false;
            }

            if (gvDetalleCompra == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objConBd = new clsConexBd();

            objConBd.gsSql = "sp_LlenarDetalleCompra";
            objConBd.gsNomTabla = "Detalle";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCabCompra", SqlDbType.BigInt, 10, IdCabCompra))
            {
                strError = objConBd.gError;
                objConBd = null;
                return false;
            }

            if (!objConBd.GetDataSet(true))
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            if (objConBd.gDataSet.Tables[objConBd.gsNomTabla].Rows.Count < 1)
            {
                strError = "No hay registros de Detalle de Orden";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            gvDetalleCompra.DataSource = objConBd.gDataSet.Tables[objConBd.gsNomTabla];
            gvDetalleCompra.DataBind();

            objConBd.gCommand.Parameters.Clear();
            objConBd = null;
            return true;
        }


        public bool LlenarProducto()
        {
            if (ddlProducto == null)
            {
                strError = "NO se asignó Lista Despegable de productos";
                return false;
            }

            objCombo = new clsCombo();

            objCombo.gsSql = "sp_Producto";
            objCombo.gsNomTabla = "Productos";
            objCombo.gsColValor = "IdProducto";
            objCombo.gsColTexto = "NombreProducto";

            objCombo.gsDdlGen = ddlProducto;

            if (!objCombo.LlenarDdl())
            {
                strError = objCombo.gError;
                objCombo = null;
                return false;
            }

            ddlProducto = objCombo.gsDdlGen;

            objCombo = null;
            return true;
        }

        #endregion

    }
}
