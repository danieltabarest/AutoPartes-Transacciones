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
    public class clsProveedor
    {
        #region Atributos

        //Atributos Cliente
        private string NitProveedor;
        private int IdCiudadProveedor;
        private string strNombreProveedor;
        private string strResponsableProveedor;


        private GridView gvProveedor;
        private DropDownList ddlCiudad;



        private string strError;


        private clsGrid objGrid;
        private clsCombo objCombo;
        private clsConexBd objConBd;
        #endregion


        #region Propiedades
        public GridView gsGvProveedor
        {
            get { return gvProveedor; }
            set { gvProveedor = value; }
        }
        public string gError
        {
            get { return strError; }
            set { strError = value; }
        }
        public string gsNitProveedor
        {
            get { return NitProveedor; }
            set { NitProveedor = value; }
        }
        public DropDownList DdlCiudad
        {
            get { return ddlCiudad; }
            set { ddlCiudad = value; }
        }
        
        public int gsIdCiudadProveedor
        {
            get { return IdCiudadProveedor; }
            set { IdCiudadProveedor = value; }
        }


        public string gsNombreProveedor
        {
            get { return strNombreProveedor; }
            set { strNombreProveedor = value; }
        }

        #endregion


        #region Metodos Privados

        private bool ExisteProveedor()
        {
            if (string.IsNullOrEmpty(NitProveedor))
            {
                strError = "NO se asigno numero de identificación del Proveedor o es un numero invalido";
                return false;
            }

            objConBd.gsSql = "sp_ExisteProveedor";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NitProveedor", SqlDbType.BigInt, 10, NitProveedor))
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
                strError = "NO Existe Proveedor con numero de orden asignado";
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }

        private bool ValDatosProveedor()
        {
            if (string.IsNullOrEmpty(NitProveedor))
            {
                strError = "NO se asigno numero de idenficación del Proveedor o es un numero invalido";
                return false;
            }
            if (IdCiudadProveedor < 0)
            {
                strError = "NO se asigno la ciudad del Proveedor";
                return false;
            }
            
            if (string.IsNullOrEmpty(strNombreProveedor))
            {
                strError = "NO se asigno nombre del Proveedor";
                return false;
            }

            if (string.IsNullOrEmpty(strResponsableProveedor))
            {
                strError = "NO se asigno responsable del Proveedor";
                return false;
            }

            return true;


        }

        private bool InsertarProveedor()
        {
            if (!ValDatosProveedor())
            {
                return false;
            }

            objConBd.gsSql = "sp_InsertarProveedor";

            if (!AdicionarParamsProveedor())
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

        private bool ActualizarProveedor()
        {
            if (!ValDatosProveedor())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarProveedor";

            if (!AdicionarParamsProveedor())
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



        private bool AdicionarParamsProveedor()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NitProveedor", SqlDbType.VarChar, 10, NitProveedor))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCiudadProveedor", SqlDbType.BigInt, 10, IdCiudadProveedor))
            {
                strError = objConBd.gError;
                return false;
            }
            
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NombreProveedor", SqlDbType.VarChar, 50, strNombreProveedor))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@ResponsableProveedor", SqlDbType.VarChar, 50, strResponsableProveedor))
            {
                strError = objConBd.gError;
                return false;
            }

            return true;
        }



        #endregion


        #region Metodos Publicos

        public bool GrabarProveedor()
        {
            objConBd = new clsConexBd();

            if (ExisteProveedor()) //Existe, por lo tanto Modifico
            {
                if (!ActualizarProveedor())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarProveedor())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
        }

        public bool LlenarGridProveedor()
        {
            if (gvProveedor == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Proveedor";
            objGrid.gsNomTabla = "Proveedor";
            objGrid.gsGvGen = gvProveedor;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvProveedor = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool LlenarProveedor()
        {
            if (gvProveedor == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Proveedor";
            objGrid.gsNomTabla = "Proveedor";
            objGrid.gsGvGen = gvProveedor;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvProveedor = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool ObteneProveedor()
        {

            objConBd = new clsConexBd();

            if (!ExisteProveedor())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ExisteProveedor";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NitProveedor", SqlDbType.BigInt, 10, NitProveedor))
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
                strError = "NO Existe proveedor";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {
                IdCiudadProveedor = (int)objConBd.gDataReader[1];
                strNombreProveedor = (string)objConBd.gDataReader[2];
                strResponsableProveedor = (string)objConBd.gDataReader[3];
                
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

        
        #endregion
    }
}
