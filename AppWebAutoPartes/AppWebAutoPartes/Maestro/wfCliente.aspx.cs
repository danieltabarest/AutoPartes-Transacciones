using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibRNAutoPartes.Maestro;
using LibRNAutoPartes.Compra;
using System.Data;

namespace AppWebAutoPartes.Maestro
{
    public partial class wfCliente : System.Web.UI.Page
    {
        #region Atributos


        clsCliente objCliente;
        

        #endregion


        #region Metodos Privados

        private void LlenarDdlGenero()
        {
            objCliente = new clsCliente();

            objCliente.DdlGenero = ddlGenero;

            if (objCliente.LlenarGenero())
            {
                ddlGenero = objCliente.DdlGenero;
            }
            else
            {
                lblMsj.Text = objCliente.gError;
            }
            
            objCliente = null;
        }

        private void LlenarDdlCiudad()
        {
           objCliente = new clsCliente();
            
            objCliente.DdlCiudad= ddlCiudad;

            if (objCliente.LlenarCiudad())
            {
                ddlCiudad = objCliente.DdlCiudad;
            }
            else
            {
                lblMsj.Text = objCliente.gError;
            }

            objCliente = null;
        }



        private void LlenarGridCliente()
        {
            objCliente = new clsCliente();

            objCliente.gsIdCliente = (txtIdCliente.Text);
            objCliente.gsGvCliente = gvCliente;

            if (objCliente.LlenarGridCliente())
            {
                gvCliente = objCliente.gsGvCliente;
            }
            else
            {
                lblMsj.Text = objCliente.gError;
            }

            objCliente = null;
        }

        private void AgregarCliente()
        {
            lblMsj.Text = "";

            objCliente = new clsCliente();
            objCliente.gsIdCliente= txtIdCliente.Text;
            objCliente.gsApellidoCliente= txtApellidos.Text;
            objCliente.gsEmailCliente= txtEmail.Text;
            objCliente.gsIdCiudadCliente = Convert.ToInt16(ddlCiudad.SelectedValue);
            objCliente.gsNombreCliente = txtNombres.Text;
            objCliente.gsTelefonoCliente = txtTelefono.Text;
            objCliente.gsFechaNacCliente = dtmFechaNac.SelectedDate;
            objCliente.gsIdGenero = Convert.ToInt16(ddlGenero.SelectedValue);

            if (objCliente.GrabarCliente())
            {
             
             gvCliente.DataSource = (DataTable)Session["varDtDetalle"];
             gvCliente.DataBind();
             lblMsj.Text = "Se agrego el registro exitosamente";
            }
            else
            {
                lblMsj.Text = objCliente.gError;
            }
            gvCliente = null;
            LimpiarCliente();
        }



        private void BuscarCliente()
        {
            lblMsj.Text = "";
            objCliente = new clsCliente();
            objCliente.gsIdCliente = txtIdCliente.Text.ToString();

            if (objCliente.ObtenerCliente())
            {
                aupCabOrd.Visible = true;
                dtmFechaNac.SelectedDate = objCliente.gsFechaNacCliente;
                dtmFechaNac.VisibleDate = objCliente.gsFechaNacCliente;
                ddlGenero.SelectedValue = objCliente.gsIdGenero.ToString();
                ddlCiudad.SelectedValue = objCliente.gsIdCliente.ToString();
                txtEmail.Text = objCliente.gsApellidoCliente.ToString();
                txtNombres.Text = objCliente.gsApellidoCliente.ToString();
                txtTelefono.Text = objCliente.gsApellidoCliente.ToString();
                txtApellidos.Text = objCliente.gsApellidoCliente.ToString();
                LlenarGridCliente();
            }
            else
            {
                lblMsj.Text = objCliente.gError;

            }

            objCliente = null;

        }

        
        private void LimpiarCliente()
        {
            txtIdCliente.Text = "";
            txtApellidos.Text = "";
            txtEmail.Text = "";
            txtNombres.Text = "";
            txtTelefono.Text = "";
            dtmFechaNac.SelectedDate = DateTime.Now;
            dtmFechaNac.VisibleDate = DateTime.Now;
            ddlGenero.SelectedIndex = -1;
            ddlCiudad.SelectedIndex = -1;
            txtIdCliente.Focus();
            lblMsj.Text = "";
        }


        #endregion


        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack) //Es la primera vez que se cargo la pagina
            {
                LlenarDdlCiudad();
                LlenarDdlGenero();
                
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           
            LimpiarCliente();
            BuscarCliente();
        }

        protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            gvCliente.PageIndex = e.NewPageIndex;
            LlenarGridCliente();
           
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCliente();
            aupCabOrd.Visible = true;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            AgregarCliente();
            aupCabOrd.Visible = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar1_Click(object sender, EventArgs e)
        {
            LimpiarCliente();
            btnBuscar.Visible = true;
            aupCabOrd.Visible = false;
        }
        #endregion

    }
}