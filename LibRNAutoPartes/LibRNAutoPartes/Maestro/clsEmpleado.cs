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
    public class clsEmpleado
    {
        #region Atributos

        //Atributos Empleado
        private string IdEmpleado;
        private int IdCiudadEmpleado;
        private int IdGeneroEmpleado;
        private DateTime dtmFechaNacEmpleado;
        private string strNombreEmpleado;
        private string strApellidoEmpleado;
        private string strTelefonoEmpleado;
        private string strEmailEmpleado;
        private double VlrComision;
        private double VlrPorcentajeComision;


        private GridView gvEmpleado;


        private DropDownList ddlCiudad;


        private DropDownList ddlGenero;


        private string strError;

        private clsGrid objGrid;
        private clsCombo objCombo;
        private clsConexBd objConBd;
        #endregion


        #region Propiedades
        public GridView gsGvEmpleado
        {
            get { return gvEmpleado; }
            set { gvEmpleado = value; }
        }
        public string gsIdEmpleado
        {
            get { return IdEmpleado; }
            set { IdEmpleado = value; }
        }
        public string gError
        {
            get { return strError; }
            set { strError = value; }
        }
        public DropDownList DdlCiudad
        {
            get { return ddlCiudad; }
            set { ddlCiudad = value; }
        }
        public int gsIdCiudadEmpleado
        {
            get { return IdCiudadEmpleado; }
            set { IdCiudadEmpleado = value; }
        }

        public DropDownList DdlGenero
        {
            get { return ddlGenero; }
            set { ddlGenero = value; }
        }
        public DateTime gsFechaNacEmpleado
        {
            get { return dtmFechaNacEmpleado; }
            set { dtmFechaNacEmpleado = value; }
        }
        public int gsIdGeneroEmpleado
        {
            get { return IdGeneroEmpleado; }
            set { IdGeneroEmpleado = value; }
        }


        public string gsNombreEmpleado
        {
            get { return strNombreEmpleado; }
            set { strNombreEmpleado = value; }
        }


        public string gsApellidoEmpleado
        {
            get { return strApellidoEmpleado; }
            set { strApellidoEmpleado = value; }
        }


        public string gsTelefonoEmpleado
        {
            get { return strTelefonoEmpleado; }
            set { strTelefonoEmpleado = value; }
        }


        public string gsEmailEmpleado
        {
            get { return strEmailEmpleado; }
            set { strEmailEmpleado = value; }
        }

        public double gsVlrComision
        {
            get { return VlrComision; }
            set { VlrComision = value; }
        }

        public double gsVlrPorcentajeComision
        {
            get { return VlrPorcentajeComision; }
            set { VlrPorcentajeComision = value; }
        }

        #endregion


        #region Metodos Privados

        private bool ExisteEmpleado()
        {
            if (string.IsNullOrEmpty(IdEmpleado))
            {
                strError = "NO se asigno numero de identificación del empleado o es un numero invalido";
                return false;
            }

            objConBd.gsSql = "sp_ExisteEmpleado";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdEmpleado", SqlDbType.BigInt, 10, IdEmpleado))
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
                strError = "NO Existe Empleado ";
                objConBd.gCommand.Parameters.Clear();
                return false;
            }

            objConBd.gCommand.Parameters.Clear();
            return true;
        }

        private bool ValDatosEmpleado()
        {
            if (string.IsNullOrEmpty(IdEmpleado))
            {
                strError = "NO se asigno numero de idenficación del empleado o es un numero invalido";
                return false;
            }
            if (IdCiudadEmpleado < 0)
            {
                strError = "NO se asigno la ciudad del empleado";
                return false;
            }
            if (IdGeneroEmpleado < 0)
            {
                strError = "NO se asigno el genero del empleado";
                return false;
            }

            if (string.IsNullOrEmpty(strNombreEmpleado))
            {
                strError = "NO se asigno nombre del empleado";
                return false;
            }

            if (string.IsNullOrEmpty(strTelefonoEmpleado))
            {
                strError = "NO se asigno telefono del empleado";
                return false;
            }

            if (string.IsNullOrEmpty(strApellidoEmpleado))
            {
                strError = "NO se asigno apellido del empleado";
                return false;
            }
            if (string.IsNullOrEmpty(strEmailEmpleado))
            {
                strError = "NO se asigno email del empleado";
                return false;
            }

            return true;


        }

        private bool InsertarEmpleado()
        {
            if (!ValDatosEmpleado())
            {
                return false;
            }

            objConBd.gsSql = "sp_InsertarEmpleado";

            if (!AdicionarParamsEmpleado())
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

        private bool ActualizarEmpleado()
        {
            if (!ValDatosEmpleado())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarEmpleado";

            if (!AdicionarParamsEmpleado())
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

        private bool AdicionarComisionEmpleado()
        {
            if (string.IsNullOrEmpty(IdEmpleado))
             {
                 strError = "NO se asigno numero de idenficación del empleado o es un numero invalido";
                 return false;
             }

             if (!ExisteEmpleado())
             {
                 strError = "El empleado no existe";
                 return false;                
             }

            objConBd.gsSql = "sp_AgregarComisionEmpleado";
            
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IDEMPLEADO", SqlDbType.BigInt, 10, IdEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@VALCOM", SqlDbType.Decimal, 12, VlrComision))
            {
                strError = objConBd.gError;
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

        private bool ConsultarPorcentajeComisionEmpleado()
        {
            if (string.IsNullOrEmpty(IdEmpleado))
            {
                strError = "NO se asigno numero de idenficación del empleado o es un numero invalido";
                return false;
            }

            objConBd = new clsConexBd();

            if (!ExisteEmpleado())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ConsultarComisionEmpleado";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IDEMPLEADO", SqlDbType.BigInt, 10, IdEmpleado))
            {
                strError = objConBd.gError;
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
                strError = "NO Existe comisiòn";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {
                VlrPorcentajeComision = Convert.ToDouble(objConBd.gDataReader[0]);
         
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

        private bool AdicionarParamsEmpleado()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdEmpleado", SqlDbType.VarChar, 10, IdEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCiudadEmpleado", SqlDbType.BigInt, 10, IdCiudadEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@FechaNacEmpleado", SqlDbType.SmallDateTime, 10, dtmFechaNacEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }


            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NombreEmpleado", SqlDbType.VarChar, 10, strNombreEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@ApellidoEmpleado", SqlDbType.VarChar, 12, strApellidoEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@TelefonoEmpleado", SqlDbType.VarChar, 12, strTelefonoEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@EmailEmpleado", SqlDbType.VarChar, 12, strEmailEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdGeneroEmpleado", SqlDbType.BigInt, 10, IdGeneroEmpleado))
            {
                strError = objConBd.gError;
                return false;
            }
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@PorcentajeComisionEmpleado", SqlDbType.Float, 10, VlrPorcentajeComision))
            {
                strError = objConBd.gError;
                return false;
            }

            return true;
        }



        #endregion


        #region Metodos Publicos

        public bool GrabarEmpleado()
        {
            objConBd = new clsConexBd();

            if (ExisteEmpleado()) //Existe, por lo tanto Modifico
            {
                if (!ActualizarEmpleado())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarEmpleado())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
        }

        public bool LlenarGridEmpleado()
        {
            if (gvEmpleado == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Empleado";
            objGrid.gsNomTabla = "Empleados";
            objGrid.gsGvGen = gvEmpleado;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvEmpleado = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool ObtenerEmpleado()
        {

            objConBd = new clsConexBd();

            if (!ExisteEmpleado())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ExisteEmpleado";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdEmpleado", SqlDbType.BigInt, 10, IdEmpleado))
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
                strError = "NO Existe Empleado";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {
                dtmFechaNacEmpleado = (DateTime)objConBd.gDataReader["FechaNacEmpleado"];
                IdGeneroEmpleado = Convert.ToInt32(objConBd.gDataReader[2]);
                IdCiudadEmpleado = Convert.ToInt32(objConBd.gDataReader[1]);
                dtmFechaNacEmpleado = (DateTime)objConBd.gDataReader[3];
                strNombreEmpleado = (string)objConBd.gDataReader[4];
                strApellidoEmpleado = (string)objConBd.gDataReader[5];
                strTelefonoEmpleado = (string)objConBd.gDataReader[6];
                strEmailEmpleado = (string)objConBd.gDataReader[7];
                if (string.IsNullOrEmpty(objConBd.gDataReader[8].ToString()))
                {
                    VlrPorcentajeComision = 0;
                }
                else
                {
                    VlrPorcentajeComision = Convert.ToDouble(objConBd.gDataReader[8]);                   
                }
                
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

            ddlCiudad = objCombo.gsDdlGen;

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


        public bool GrabarComisionEmpleado()
        {
            objConBd = new clsConexBd();

            if (ExisteEmpleado())
            {
                if (!AdicionarComisionEmpleado())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else
            {
                strError = "No fue posible grabar la comision porque el empleado no existe";
                objConBd = null;
                return false;
            }
        }

        public bool ObtenerPorcentajeComisionEmpleado()
        {
            objConBd = new clsConexBd();

            if (ExisteEmpleado())
            {
                if (!ConsultarPorcentajeComisionEmpleado())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else
            {
                strError = "No fue posible grabar la comision porque el empleado no existe";
                objConBd = null;
                return false;
            }
        }


        #endregion

    }
}
