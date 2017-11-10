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
    public class clsCliente
    {
        #region Atributos

        //Atributos Cliente
        private string IdCliente;
        private int IdCiudadCliente;
        private int IdGenero;
        private DateTime dtmFechaNacCliente;
        private string strNombreCliente;
        private string strApellidoCliente;
        private string strTelefonoCliente;
        private string strEmailCliente;


        private GridView gvCliente;
        private DropDownList ddlCiudad;
        private DropDownList ddlGenero;



        private string strError;

      
        private clsGrid objGrid;
        private clsCombo objCombo;
        private clsConexBd objConBd;
        #endregion


        #region Propiedades
        public GridView gsGvCliente
        {
            get { return gvCliente; }
            set { gvCliente = value; }
        }
        public string gError
        {
            get { return strError; }
            set { strError = value; }
        }
        public string gsIdCliente
        {
            get { return IdCliente; }
            set { IdCliente = value; }
        }
        public DropDownList DdlCiudad
        {
            get { return ddlCiudad; }
            set { ddlCiudad = value; }
        }
        public DropDownList DdlGenero
        {
            get { return ddlGenero; }
            set { ddlGenero = value; }
        }

        public int gsIdCiudadCliente
        {
            get { return IdCiudadCliente; }
            set { IdCiudadCliente = value; }
        }


        public DateTime gsFechaNacCliente
        {
            get { return dtmFechaNacCliente; }
            set { dtmFechaNacCliente = value; }
        }
        public int gsIdGenero
        {
            get { return IdGenero; }
            set { IdGenero = value; }
        }


        public string gsNombreCliente
        {
            get { return strNombreCliente; }
            set { strNombreCliente = value; }
        }


        public string gsApellidoCliente
        {
            get { return strApellidoCliente; }
            set { strApellidoCliente = value; }
        }


        public string gsTelefonoCliente
        {
            get { return strTelefonoCliente; }
            set { strTelefonoCliente = value; }
        }


        public string gsEmailCliente
        {
            get { return strEmailCliente; }
            set { strEmailCliente = value; }
        }

        #endregion


        #region Metodos Privados

        private bool ExisteCliente()
        {
            if (string.IsNullOrEmpty(IdCliente))
            {
                strError = "NO se asigno numero de identificación del Cliente o es un numero invalido";
                return false;
            }

            objConBd.gsSql = "sp_ExisteCliente";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCliente", SqlDbType.BigInt, 10, IdCliente))
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
                strError = "NO Existe Pedido con numero de orden asignado";
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }

        private bool ValDatosCliente()
        {
            if (string.IsNullOrEmpty(IdCliente))
            {
                strError = "NO se asigno numero de idenficación del Cliente o es un numero invalido";
                return false;
            }
            if (IdCiudadCliente < 0)
            {
                strError = "NO se asigno la ciudad del Cliente";
                return false;
            }
            if (IdGenero < 0)
            {
                strError = "NO se asigno el genero del Cliente";
                return false;
            }

            if (string.IsNullOrEmpty(strNombreCliente))
            {
                strError = "NO se asigno nombre del Cliente";
                return false;
            }

            if (string.IsNullOrEmpty(strTelefonoCliente))
            {
                strError = "NO se asigno telefono del Cliente";
                return false;
            }

            if (string.IsNullOrEmpty(strApellidoCliente))
            {
                strError = "NO se asigno apellido del Cliente";
                return false;
            }
            if (string.IsNullOrEmpty(strEmailCliente))
            {
                strError = "NO se asigno email del Cliente";
                return false;
            }

            return true;


        }

        private bool InsertarCliente()
        {
            if (!ValDatosCliente())
            {
                return false;
            }

            objConBd.gsSql = "sp_InsertarCliente";

            if (!AdicionarParamsCliente())
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

        private bool ActualizarCliente()
        {
            if (!ValDatosCliente())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarCliente";

            if (!AdicionarParamsCliente())
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



        private bool AdicionarParamsCliente()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCliente", SqlDbType.VarChar, 10, IdCliente))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCiudadCliente", SqlDbType.BigInt, 10, IdCiudadCliente))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@FechaNacCliente", SqlDbType.SmallDateTime, 10, dtmFechaNacCliente))
            {
                strError = objConBd.gError;
                return false;
            }


            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NombreCliente", SqlDbType.VarChar, 10, strNombreCliente))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@ApellidoCliente", SqlDbType.VarChar, 12, strApellidoCliente))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@TelefonoCliente", SqlDbType.VarChar, 12, strTelefonoCliente))
            {
                strError = objConBd.gError;
                return false;
            }
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@EmailCliente", SqlDbType.VarChar, 12, strEmailCliente))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdGenero", SqlDbType.BigInt, 10, IdGenero))
            {
                strError = objConBd.gError;
                return false;
            }
            return true;
        }



        #endregion


        #region Metodos Publicos

        public bool GrabarCliente()
        {
            objConBd = new clsConexBd();

            if (ExisteCliente()) //Existe, por lo tanto Modifico
            {
                if (!ActualizarCliente())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarCliente())
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
            if (gvCliente == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Empleado";
            objGrid.gsNomTabla = "Clientes";
            objGrid.gsGvGen = gvCliente;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvCliente = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool LlenarCliente()
        {
            if (gvCliente == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "CABPEDIDOS_S";
            objGrid.gsNomTabla = "Cabecera";
            objGrid.gsGvGen = gvCliente;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvCliente = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool ObtenerCliente()
        {

            objConBd = new clsConexBd();

            if (!ExisteCliente())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ExisteCliente";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCliente", SqlDbType.BigInt, 10, IdCliente))
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
                strError = "NO Existe cliente";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {
                dtmFechaNacCliente = (DateTime)objConBd.gDataReader["FechaNacCliente"];
                IdGenero = (int)objConBd.gDataReader[7];
                IdCiudadCliente = (int)objConBd.gDataReader[1];
                strNombreCliente = (string)objConBd.gDataReader[3];
                strApellidoCliente = (string)objConBd.gDataReader[4];
                strTelefonoCliente = (string)objConBd.gDataReader[5];
                strEmailCliente = (string)objConBd.gDataReader[6];

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

        public bool LlenarGenero()
        {
            if (ddlGenero == null)
            {
                strError = "NO se asignó Lista Despegable de Genero";
                return false;
            }

            objCombo = new clsCombo();

            objCombo.gsSql = "sp_Genero";
            objCombo.gsNomTabla = "Genero";
            objCombo.gsColValor = "IdGenero";
            objCombo.gsColTexto = "DescripcionGenero";

            objCombo.gsDdlGen = ddlGenero;

            if (!objCombo.LlenarDdl())
            {
                strError = objCombo.gError;
                objCombo = null;
                return false;
            }

            ddlGenero = objCombo.gsDdlGen;

            objCombo = null;
            return true;
        }

        public bool LlenarCiudad()
        {
            if (ddlCiudad == null)
            {
                strError = "NO se asignó Lista Despegable de Ciudad";
                return false;
            }

            objCombo = new clsCombo();

            objCombo.gsSql = "sp_Ciudad";
            objCombo.gsNomTabla = "Ciudad";
            objCombo.gsColValor = "IdCiudad";
            objCombo.gsColTexto = "NombreCiudad";
            objCombo.gsDdlGen = ddlCiudad;

            if (!objCombo.LlenarDdl())
            {
                strError = objCombo.gError;
                objCombo = null;
                return false;
            }

            ddlCiudad = objCombo.gsDdlGen;

            objCombo = null;
            return true;
        }

        #endregion
    }
}
