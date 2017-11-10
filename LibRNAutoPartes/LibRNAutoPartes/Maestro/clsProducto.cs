using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LibBasica;
using System.Web.UI.WebControls;

namespace LibRNAutoPartes.Maestro
{
    public class clsProducto
    {
        #region Atributos
        //Atributos Producto
        private int IdProducto;

        
        private int IdCategoria;
        
        private string strNombreProducto;
        private string strDescripcionProducto;
        private string strCodigoProducto;
        
        private GridView gvProducto;

        private DropDownList ddlCategoria;


        private string strError;

     
        private clsGrid objGrid;
        private clsCombo objCombo;
        private clsConexBd objConBd;
        #endregion


        #region Propiedades
        public DropDownList gsDdlCategoria
        {
            get { return ddlCategoria; }
            set { ddlCategoria = value; }
        }

        public int gsIdProducto
        {
            get { return IdProducto; }
            set { IdProducto = value; }
        }
        public int gsdCategoria
        {
            get { return IdCategoria; }
            set { IdCategoria = value; }
        }
        public string gsNombreProducto
        {
            get { return strNombreProducto; }
            set { strNombreProducto = value; }
        }

        public string gsDescripcionProducto
        {
            get { return strDescripcionProducto; }
            set { strDescripcionProducto = value; }
        }

        public string gsCodigoProducto
        {
            get { return strCodigoProducto; }
            set { strCodigoProducto = value; }
        }

        public GridView gsGvProducto
        {
            get { return gvProducto; }
            set { gvProducto = value; }
        }
        
        public string gError
        {
            get { return strError; }
            set { strError = value; }
        }
   
        #endregion


        #region Metodos Privados

        private bool ExisteProducto()
        {
            if (IdProducto < 1 )
            {
                strError = "NO se asigno numero del producto o es un numero invalido";
                return false;
            }

            objConBd.gsSql = "sp_ExisteProducto";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdProducto", SqlDbType.BigInt, 10, IdProducto))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.GetScalar(true))
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            if (objConBd.gScalar == null)
            {
                strError = "NO Existe producto";
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }

        private bool ValDatosProducto()
        {
            if (IdProducto < 1 || IdProducto == null)
            {
                strError = "NO se asigno numero de producto o es un numero invalido";
                return false;
            }
            if (IdCategoria < 1 || IdCategoria == null)
            {
                strError = "NO se asigno la categoria del producto";
                return false;
            }
           
            if (string.IsNullOrEmpty(strNombreProducto))
            {
                strError = "NO se asigno nombre del Producto";
                return false;
            }

            if (string.IsNullOrEmpty(strDescripcionProducto))
            {
                strError = "NO se asigno Descripción del Producto";
                return false;
            }

            if (string.IsNullOrEmpty(strCodigoProducto))
            {
                strError = "NO se asigno codigo del Producto";
                return false;
            }
          

            return true;


        }

        private bool InsertarProducto()
        {
            if (!ValDatosProducto())
            {
                return false;
            }

            objConBd.gsSql = "sp_InsertarProducto";

            if (!AdicionarParamsProducto())
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

        private bool ActualizarProducto()
        {
            if (!ValDatosProducto())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarProducto";

            if (!AdicionarParamsProducto())
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



        private bool AdicionarParamsProducto()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdProducto", SqlDbType.VarChar, 10, IdProducto))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCategoria", SqlDbType.BigInt, 10, IdCategoria))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NombreProducto", SqlDbType.VarChar, 10, strNombreProducto))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@DescripcionProducto", SqlDbType.VarChar, 12, strDescripcionProducto))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@CodigoProducto", SqlDbType.VarChar, 12, strCodigoProducto))
            {
                strError = objConBd.gError;
                return false;
            }
        

            return true;
        }



        #endregion


        #region Metodos Publicos

        public bool GrabarProducto()
        {
            objConBd = new clsConexBd();

            if (ExisteProducto()) //Existe, por lo tanto Modifico
            {
                if (!ActualizarProducto())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarProducto())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
        }

        public bool LlenarGrIdProducto()
        {
            if (gvProducto == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Producto";
            objGrid.gsNomTabla = "Productos";
            objGrid.gsGvGen = gvProducto;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvProducto = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }
      
        public bool ObtenerProducto()
        {

            objConBd = new clsConexBd();

            if (!ExisteProducto())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ExisteProducto";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdProducto", SqlDbType.BigInt, 10, IdProducto))
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
                strError = "NO Existe Producto";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {
               
                
                IdCategoria = (int)objConBd.gDataReader[0];
                strNombreProducto = (string)objConBd.gDataReader[1];
                strCodigoProducto = (string)objConBd.gDataReader[2];
                strDescripcionProducto = (string)objConBd.gDataReader[3];
           

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


        public bool LlenarCategoria()
        {
            if (ddlCategoria== null)
            {
                strError = "NO se asignó Lista Despegable de Categoria";
                return false;
            }

            objCombo = new clsCombo();

            objCombo.gsSql = "sp_Categoria";
            objCombo.gsNomTabla = "Categoria";
            objCombo.gsColValor = "IdCategoria";
            objCombo.gsColTexto = "DescripcionCategoria";

            objCombo.gsDdlGen = ddlCategoria;

            if (!objCombo.LlenarDdl())
            {
                strError = objCombo.gError;
                objCombo = null;
                return false;
            }

            ddlCategoria = objCombo.gsDdlGen;

            objCombo = null;
            return true;
        }


        #endregion

    }
}
