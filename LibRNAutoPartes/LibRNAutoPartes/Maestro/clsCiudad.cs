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
    public class clsCiudad
    {
        #region Atributos

        //Atributos Ciudaad
        private string IdCiudad;
        private int IdDepartamento;
        private string strNombreCiudad;
        

        private GridView gvCiudad;
        private DropDownList ddlDepartamento;



        private string strError;


        private clsGrid objGrid;
        private clsCombo objCombo;
        private clsConexBd objConBd;
        #endregion



        #region Propiedades
        public GridView gsGvCiudad
        {
            get { return gvCiudad; }
            set { gvCiudad = value; }
        }
        public string gError
        {
            get { return strError; }
            set { strError = value; }
        }
        public string gsIdCliente
        {
            get { return IdCiudad; }
            set { IdCiudad = value; }
        }
        
        public DropDownList DdlDepartamento
        {
            get { return ddlDepartamento; }
            set { ddlDepartamento = value; }
        }

        public int gsIdDepartamento
        {
            get { return IdDepartamento; }
            set { IdDepartamento = value; }
        }



        public string gsNombreCiudad
        {
            get { return strNombreCiudad; }
            set { strNombreCiudad= value; }
        }

        #endregion

        #region Metodos Privados

        private bool ExisteCiudad()
        {
            if (string.IsNullOrEmpty(IdCiudad))
            {
                strError = "No asigno numero de identificación de la ciudad";
                return false;
            }
            objConBd.gsSql = "sp_ExisteCiudad";
            if (!objConBd.AdicionarParametro(ParameterDirection.Input,"@IdCiudad",SqlDbType.BigInt,10,IdCiudad))
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
                strError = "No existe ciudad con el numero ingresado";
                objConBd.gCommand.Parameters.Clear();
                return false;
            }
            objConBd.gCommand.Parameters.Clear();
            return true;
        }


        private bool ValDatosCiudad()
        {
            if (string.IsNullOrEmpty(IdCiudad))
            {
                strError = "No se signó numero de identificación de la Ciudad o no es valido";
                return false;
            }
            if (IdDepartamento < 0)
            {
                strError = "No se asignó numero de Dapartamento";
                return false;
            }
            if (string.IsNullOrEmpty(strNombreCiudad))
            {
                strError = "No se el nombre de la ciudad";
            }
            return true;
        }

        private bool InsertarCiudad() 
        {
            if (!ValDatosCiudad())
            {
                return false;
            }
            objConBd.gsSql = "sp_InsertarCiudad";
            if (!AdicionarParamsCiudad())
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
        private bool ActualizarCiudad()
        {
            if (!ValDatosCiudad())
            {
                return false;
            }

            objConBd.gsSql = "sp_ActualizarCiudad";

            if (!AdicionarParamsCiudad())
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

        private bool AdicionarParamsCiudad()
        {
            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCiudad", SqlDbType.VarChar, 10, IdCiudad))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdDepartmento", SqlDbType.BigInt, 10, IdDepartamento))
            {
                strError = objConBd.gError;
                return false;
            }

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@NombreCiudad", SqlDbType.VarChar, 50, strNombreCiudad))
            {
                strError = objConBd.gError;
                return false;
            }

            return true;
        }
        #endregion

        #region Metodos Publicos

        public bool GrabarCiudad()
        {
            objConBd = new clsConexBd();

            if (ExisteCiudad()) //Existe, por lo tanto Modifico
            {
                if (!ActualizarCiudad())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
            else //NO Existe, por lo tanto Inserto
            {
                if (!InsertarCiudad())
                {
                    objConBd = null;
                    return false;
                }

                objConBd = null;
                return true;
            }
        }

        public bool LlenarGridCiudad()
        {
            if (gvCiudad == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Ciudad";
            objGrid.gsNomTabla = "Ciudaad";
            objGrid.gsGvGen = gvCiudad;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvCiudad = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool LlenarCiudad()
        {
            if (gvCiudad == null)
            {
                strError = "NO se asignó GridView a poblar";
                return false;
            }

            objGrid = new clsGrid();

            objGrid.gsSql = "sp_Ciudad";
            objGrid.gsNomTabla = "Ciudad";
            objGrid.gsGvGen = gvCiudad;

            if (!objGrid.LlenarGridWeb())
            {
                strError = objGrid.gError;
                objGrid = null;
                return false;
            }

            gvCiudad = objGrid.gsGvGen;

            objGrid = null;
            return true;
        }

        public bool ObtenerCiudad()
        {

            objConBd = new clsConexBd();

            if (!ExisteCiudad())
            {
                objConBd = null;
                return false;
            }

            objConBd.gsSql = "sp_ExisteCiudad";

            if (!objConBd.AdicionarParametro(ParameterDirection.Input, "@IdCiudad", SqlDbType.BigInt, 10, IdCiudad))
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
                strError = "NO Existe ciudad";
                objConBd.gCommand.Parameters.Clear();
                objConBd = null;
                return false;
            }

            try
            {
                IdDepartamento = (int)objConBd.gDataReader[1];
                strNombreCiudad = (string)objConBd.gDataReader[2];

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

        public bool LlenarDepartamento()
        {
            if (ddlDepartamento == null)
            {
                strError = "NO se asignó Lista Despegable de Departamento";
                return false;
            }

            objCombo = new clsCombo();

            objCombo.gsSql = "sp_Departamento";
            objCombo.gsNomTabla = "Departamento";
            objCombo.gsColValor = "IdDepartamento";
            objCombo.gsColTexto = "DescripcionDeprtamento";

            objCombo.gsDdlGen = ddlDepartamento;

            if (!objCombo.LlenarDdl())
            {
                strError = objCombo.gError;
                objCombo = null;
                return false;
            }

            ddlDepartamento = objCombo.gsDdlGen;

            objCombo = null;
            return true;
        }

        
        #endregion
    }
}
