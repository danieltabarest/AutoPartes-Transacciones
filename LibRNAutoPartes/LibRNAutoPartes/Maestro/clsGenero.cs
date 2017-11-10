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
    public class clsGenero
    {

        #region Atributos

        //Atributos Ciudaad
        private string IdGenero;
        private string strDescripcionGenero;


        private GridView gvGenero;



        private string strError;


        private clsGrid objGrid;
        private clsCombo objCombo;
        private clsConexBd objConBd;
        #endregion



        #region Propiedades
        public GridView gsGvGenero
        {
            get { return gvGenero; }
            set { gvGenero = value; }
        }
        public string gError
        {
            get { return strError; }
            set { strError = value; }
        }
        public string gsIdGenero
        {
            get { return IdGenero; }
            set { IdGenero = value; }
        }


        public string gsDescripcionGenero
        {
            get { return strDescripcionGenero; }
            set { strDescripcionGenero = value; }
        }

        #endregion

        #region Metodos Privados

        private bool ExisteGenero()
        {
            if (string.IsNullOrEmpty(IdGenero))
            {
                strError = "No asigno numero de identificación del Genero";
                return false;
            }
            objConBd.gsSql = "sp_ExisteGenero";
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdGenero", SqlDbType.BigInt, 10, IdGenero))
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
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
                strError = "No existe genero con el numero ingresado";
                objConBd.gCommand.Parameters.Clear();
                return false;
            }
            objConBd.gCommand.Parameters.Clear();
            return true;
        }


        private bool ValDatosGenero()
        {
            if (string.IsNullOrEmpty(IdGenero))
            {
                strError = "No se signó numero de identificación del Genero o no es valido";
                return false;
            }
            
            if (string.IsNullOrEmpty(strDescripcionGenero))
            {
                strError = "No se asignò la descripcion del genero";
            }
            return true;
        }

        private bool InsertarGenero()
        {
            if (!ValDatosGenero())
            {
                return false;
            }
            objConBd.gsSql = "sp_InsertarGenero";
            if (!AdicionarParamsGenero())
            {
                return false;
            }
            if (!objConBd.ExecSql(true))
            {
                strError = objConBd.gError;
                objConBd.gCommand.Parameters.Clear();
                return false;
            }
            objConBd.gCommand.Parameters.Clear();
            return true;
        }
        private bool ActualizarGenero()
        {
            if (!ValDatosGenero())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarGenero";

            if (!AdicionarParamsGenero())
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

        private bool AdicionarParamsGenero()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdGenero", SqlDbType.VarChar, 10, IdGenero))
            {
                strError = objConBd.gError;
                return false;
            }

            

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@DescripcionGenero", SqlDbType.VarChar, 50, strDescripcionGenero))
            {
                strError = objConBd.gError;
                return false;
            }

            return true;
        }
        #endregion

        #region Metodos Publicos

        public bool GrabarGenero()
        {
            objConBd = new clsConexBd();

            if (ExisteGenero()) //Existe, por lo tanto Modifico
            {
                if (!ActualizarGenero())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarGenero())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
        }

        public bool LlenarGridCliente()
        {
            if (gvGenero == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Genero";
            objGrid.gsNomTabla = "Genero";
            objGrid.gsGvGen = gvGenero;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvGenero = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool LlenarGenero()
        {
            if (gvGenero == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Genero";
            objGrid.gsNomTabla = "Genero";
            objGrid.gsGvGen = gvGenero;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvGenero = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool ObtenerGenero()
        {

            objConBd = new clsConexBd();

            if (!ExisteGenero())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ExisteGenero";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdGenero", SqlDbType.BigInt, 10, IdGenero))
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
                strError = "NO Existe genero";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {
                strDescripcionGenero = (string)objConBd.gDataReader[1];

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
