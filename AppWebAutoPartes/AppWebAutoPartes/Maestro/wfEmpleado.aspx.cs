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
    public partial class wfEmpleado : System.Web.UI.Page
    {
        #region Atributos


        clsEmpleado objEmpleado;


        #endregion


        #region Metodos Privados

        private void LlenarDdlGenero()
        {
            objEmpleado = new clsEmpleado();

            objEmpleado.DdlGenero = ddlGenero;

            if (objEmpleado.LlenarGenero())
            {
                ddlGenero = objEmpleado.DdlGenero;
            }
            else
            {
                lblMsj.Text = objEmpleado.gError;
            }

            objEmpleado = null;
        }

        private void LlenarDdlCiudad()
        {
            objEmpleado = new clsEmpleado();

            objEmpleado.DdlCiudad = ddlCiudad;

            if (objEmpleado.LlenarCiudad())
            {
                ddlCiudad = objEmpleado.DdlCiudad;
            }
            else
            {
                lblMsj.Text = objEmpleado.gError;
            }

            objEmpleado = null;
        }



        private void LlenarGridEmpleado()
        {
            objEmpleado = new clsEmpleado();

            objEmpleado.gsIdEmpleado = (txtIdEmpleado.Text);
            objEmpleado.gsGvEmpleado = gvEmpleado;

            if (objEmpleado.LlenarGridEmpleado())
            {
                gvEmpleado = objEmpleado.gsGvEmpleado;
            }
            else
            {
                lblMsj.Text = objEmpleado.gError;
            }

            objEmpleado = null;
        }

        private void AgregarEmpleado()
        {
            lblMsj.Text = "";

            objEmpleado = new clsEmpleado();
            objEmpleado.gsIdEmpleado = txtIdEmpleado.Text;
            objEmpleado.gsApellidoEmpleado = txtApellidos.Text;
            objEmpleado.gsEmailEmpleado = txtEmail.Text;
            objEmpleado.gsIdCiudadEmpleado = Convert.ToInt16(ddlCiudad.SelectedValue);
            objEmpleado.gsNombreEmpleado = txtNombres.Text;
            objEmpleado.gsTelefonoEmpleado = txtTelefono.Text;
            objEmpleado.gsFechaNacEmpleado = dtmFechaNac.SelectedDate;
            objEmpleado.gsIdGeneroEmpleado = Convert.ToInt16(ddlGenero.SelectedValue);
            int ptjComision;
            int.TryParse(txtPtjComisión.Text,out ptjComision);
            objEmpleado.gsVlrPorcentajeComision = ptjComision;
            if (objEmpleado.GrabarEmpleado())
            {

                gvEmpleado.DataSource = (DataTable)Session["varDtDetalle"];
                gvEmpleado.DataBind();
                lblMsj.Text = "Se agrego el registro exitosamente";
            }
            else
            {
                lblMsj.Text = objEmpleado.gError;
            }
            gvEmpleado = null;
            LimpiarEmpleado();
        }



        private void BuscarEmpleado()
        {
            lblMsj.Text = "";
            objEmpleado = new clsEmpleado();
            objEmpleado.gsIdEmpleado = txtIdEmpleado.Text;

            if (objEmpleado.ObtenerEmpleado())
            {
                aupCabOrd.Visible = true;
                dtmFechaNac.SelectedDate = objEmpleado.gsFechaNacEmpleado;
                dtmFechaNac.VisibleDate = objEmpleado.gsFechaNacEmpleado;
                ddlGenero.SelectedValue = objEmpleado.gsIdGeneroEmpleado.ToString();
                ddlCiudad.SelectedValue = objEmpleado.gsIdCiudadEmpleado.ToString();
                txtEmail.Text = objEmpleado.gsEmailEmpleado.ToString();
                txtNombres.Text = objEmpleado.gsNombreEmpleado.ToString();
                txtTelefono.Text = objEmpleado.gsTelefonoEmpleado.ToString();
                txtApellidos.Text = objEmpleado.gsApellidoEmpleado.ToString();
                txtPtjComisión.Text = objEmpleado.gsVlrPorcentajeComision.ToString();
                BloquearCamposEmpleado(false);
            }
            else
            {
                lblMsj.Text = objEmpleado.gError;

            }

            objEmpleado = null;

        }


        private void LimpiarEmpleado()
        {
            txtIdEmpleado.Text = "";
            txtApellidos.Text = "";
            txtEmail.Text = "";
            txtNombres.Text = "";
            txtTelefono.Text = "";
            dtmFechaNac.SelectedDate = DateTime.Now;
            dtmFechaNac.VisibleDate = DateTime.Now;
            ddlGenero.SelectedIndex = -1;
            ddlCiudad.SelectedIndex = -1;
            txtIdEmpleado.Focus();
            
        }

        private void BloquearCamposEmpleado(bool pBolBloq)
        {

            txtIdEmpleado.Focus();
            txtApellidos.Enabled = pBolBloq;
            txtEmail.Enabled = pBolBloq;
            txtNombres.Enabled = pBolBloq;
            txtTelefono.Enabled = pBolBloq;
            ddlGenero.Enabled = pBolBloq;
            ddlCiudad.Enabled = pBolBloq;
            btnAgregar.Enabled = pBolBloq;
            txtPtjComisión.Enabled = pBolBloq;

        }


        #endregion


        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) //Es la primera vez que se cargo la pagina
            {
                LlenarDdlCiudad();
                LlenarDdlGenero();
                BloquearCamposEmpleado(false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            BuscarEmpleado();

        }

        protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvEmpleado.PageIndex = e.NewPageIndex;
            LlenarGridEmpleado();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarEmpleado();
            aupCabOrd.Visible = true;
            BloquearCamposEmpleado(true);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            AgregarEmpleado();
            aupCabOrd.Visible = true;
        }



        protected void btnBuscar1_Click(object sender, EventArgs e)
        {
            LimpiarEmpleado();
            btnBuscar.Visible = true;
            aupCabOrd.Visible = false;
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
        #endregion
       
    }
}