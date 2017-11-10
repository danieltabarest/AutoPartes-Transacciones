using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibRNAutoPartes;
using LibRNAutoPartes.Compra;
using LibRNAutoPartes.Transacciones;


namespace AppWebAutoPartes.Pedido
{
    public partial class wfGestionarPedido : System.Web.UI.Page
    {
        #region Atributos

        clsCabeceraCompra objCabeceraCompra ;
        clsDetalleCompra objDetCompra;
        clsTrnCompra objTrnCompra;
        int intNumCompra;
        int IdProducto;
        decimal decVlrServ;
        int intCant;
        #endregion


        #region Metodos Privados

        private void LlenarDdlCliente()
        {
            objCabeceraCompra  = new clsCabeceraCompra();

            objCabeceraCompra .gsDdlCliente = ddlCliente;

            if (objCabeceraCompra .LlenarCliente())
            {
                ddlCliente = objCabeceraCompra .gsDdlCliente;
            }
            else
            {
                lblMsjCab.Text = objCabeceraCompra .gError;
            }

            objCabeceraCompra  = null;
        }

        private void LlenarDdlEmpleado()
        {
            objCabeceraCompra  = new clsCabeceraCompra();

            objCabeceraCompra .gsDdlEmpleado= ddlEmpleado;

            if (objCabeceraCompra .LlenarEmpleado())
            {
                ddlEmpleado = objCabeceraCompra .gsDdlEmpleado;
            }
            else
            {
                lblMsjCab.Text = objCabeceraCompra .gError;
            }

            objCabeceraCompra  = null;
        }

        private void LlenarDdlProducto()
        {
            objDetCompra = new clsDetalleCompra();

            objDetCompra.gsddlProducto = ddlProducto;

            if (objDetCompra.LlenarProducto())
            {
                ddlProducto = objDetCompra.gsddlProducto;
            }
            else
            {
                lblMsjDet.Text = objDetCompra.gError;
            }

            objDetCompra = null;
        }

        private void LlenarGridDetalle()
        {
            objDetCompra = new clsDetalleCompra();
            int.TryParse(txtNumCompra.Text, out intNumCompra);
            objDetCompra.gsIdCabCompra = intNumCompra; 
            objDetCompra.gsGvDetalleCompra = gvDetalle;

            if (objDetCompra.LlenarDetalleCompra())
            {
                gvDetalle = objDetCompra.gsGvDetalleCompra;
                Session["varDtDetalle"] = gvDetalle.DataSource;
            }
            else
            {
                lblMsjDet.Text = objDetCompra.gError;
            }

            objDetCompra = null;
        }

        private void ObtenerDetalle()
        {
            lblMsjDet.Text = "";

            clsGridDetalle objGridDet = new clsGridDetalle();

            objGridDet.gsNroOrd = (Int32)Session["NumOrd"];
            objGridDet.gsCodProd = Convert.ToInt16 (Session["CodPro"]);

            if (Session["varDtDetalle"] != null)
            {
                objGridDet.gsDtDetalle = (DataTable)Session["varDtDetalle"];
            }

            if (objGridDet.ObtenerDetalle())
            {
                //txtProd.Text = (string)Session["CodPro"];
                ddlProducto.SelectedValue = objGridDet.gsCodProd.ToString();
                txtCant.Text = objGridDet.gsCant.ToString();
                txtVlrServ.Text = objGridDet.gsValor.ToString();
            }
            else
            {
                lblMsjDet.Text = objGridDet.gError;
            }

            objGridDet = null;
        }


        private void BuscarCabeceraCompra()
        {
            
            lblMsjCab.Text = "";
            objCabeceraCompra  = new clsCabeceraCompra();
            int.TryParse(this.txtNumCompra.Text, out intNumCompra);
            objCabeceraCompra.gsNroOrd = intNumCompra;
            
            if (objCabeceraCompra.ObtenerCabCompra())
            {
                calFecOrd.SelectedDate = objCabeceraCompra .gsFechaCabCompra;
                calFecOrd.VisibleDate = objCabeceraCompra .gsFechaCabCompra;
                ddlCliente.SelectedValue = objCabeceraCompra .gsCodCli;
                ddlEmpleado.SelectedValue = objCabeceraCompra .gsCodTec;
                txtValor.Text = objCabeceraCompra .gsVlr.ToString();
                txtIva.Text = objCabeceraCompra .gsIva.ToString();
                LlenarGridDetalle();
                BloquearCamposGral(true);
            }
            else
            {
                lblMsjCab.Text = objCabeceraCompra .gError;
                LimpiarCabOrdComp();
            }

            objCabeceraCompra  = null;

        }

        private void GrabarCompra()
        {
            lblMsjCab.Text = "";
            objTrnCompra = new clsTrnCompra();
       
            decimal fltVlr;
            decimal decIva;
            int.TryParse(txtNumCompra.Text, out intNumCompra);
            decimal.TryParse(txtValor.Text, out fltVlr);
            decimal.TryParse(txtIva.Text, out decIva);

            objTrnCompra.gsIdCabCompra = intNumCompra;
            objTrnCompra.gsFechaCabCompra= calFecOrd.SelectedDate;
            objTrnCompra.gsidClient= ddlCliente.SelectedValue;
            objTrnCompra.gsidEmpleado= ddlEmpleado.SelectedValue;
            objTrnCompra.gsVlr = decIva;
            objTrnCompra.gsIva = fltVlr;

            objTrnCompra.gsDtDetalle = (DataTable)Session["varDtDetalle"];

            if (objTrnCompra.GrabarTrnCompra())
            {
                lblMsjCab.Text = "Compra # " + objTrnCompra.gsIdCabCompra.ToString() + " Grabada Exitosamente";
                BloquearCamposGral(false);
                LimpiarCampDet();
                LimpiarCabOrdComp();
            }
            else
            {
                lblMsjCab.Text = objTrnCompra.gError;
            }
            objTrnCompra = null;
    
        }

        private void GrabarCompraConComision()
        {
            lblMsjCab.Text = "";
            objTrnCompra = new clsTrnCompra();

            decimal fltVlr;
            decimal decIva;
            int.TryParse(txtNumCompra.Text, out intNumCompra);
            decimal.TryParse(txtValor.Text, out fltVlr);
            decimal.TryParse(txtIva.Text, out decIva);

            objTrnCompra.gsIdCabCompra = intNumCompra;
            /*objTrnCompra.gsFechaCabCompra = calFecOrd.SelectedDate;*/
            objTrnCompra.gsFechaCabCompra  = Convert.ToDateTime("2013/09/28 12:00:01");
            objTrnCompra.gsidClient = ddlCliente.SelectedValue;
            objTrnCompra.gsidEmpleado = ddlEmpleado.SelectedValue;
            objTrnCompra.gsVlr = decIva;
            objTrnCompra.gsIva = fltVlr;

            objTrnCompra.gsDtDetalle = (DataTable)Session["varDtDetalle"];

            if (objTrnCompra.GrabarTrnCompraComisionEmpleado())
            {
                lblMsjCab.Text = "Compra # " + objTrnCompra.gsIdCabCompra.ToString() + " Grabada Exitosamente con Comisión";
                BloquearCamposGral(false);
                LimpiarCampDet();
                LimpiarCabOrdComp();
            }
            else
            {
                lblMsjCab.Text = objTrnCompra.gError;
            }
            objTrnCompra = null;

        }

        private void AgregarDetalle()
        {
            lblMsjDet.Text = "";
            clsGridDetalle objGridDet = new clsGridDetalle();
            int.TryParse(txtNumCompra.Text, out intNumCompra);
            int.TryParse(txtCant.Text, out intCant);
            decimal.TryParse(txtVlrServ.Text, out decVlrServ);
            objGridDet.gsNroOrd = intNumCompra;
            objGridDet.gsCodProd = Convert.ToInt16(ddlProducto.SelectedValue);
            objGridDet.gsCant = intCant;
            objGridDet.gsValor = decVlrServ;
            

            if (Session["varDtDetalle"] != null)
            {
                objGridDet.gsDtDetalle = (DataTable)Session["varDtDetalle"];
            }

            if (objGridDet.AgregarDetalle())
            {
                Session["varDtDetalle"] = objGridDet.gsDtDetalle;
                gvDetalle.DataSource = (DataTable)Session["varDtDetalle"];
                gvDetalle.DataBind();
                txtValor.Text = objGridDet.gTot.ToString("#,#");
                txtIva.Text = objGridDet.gIva.ToString("#,#");
            }
            else
            {
                lblMsjDet.Text = objGridDet.gError;
            }

            objGridDet = null;
            LimpiarCampDet();
        }

        private void BorrarDetalle()
        {
            if (gvDetalle.SelectedRow.Cells[2] != null)
            {
                lblMsjDet.Text = "";
                clsGridDetalle objGridDet = new clsGridDetalle();
                clsDetalleCompra objDetCompra = new clsDetalleCompra();
                int.TryParse(txtNumCompra.Text, out intNumCompra);
                int.TryParse(txtCant.Text, out intCant);
                decimal.TryParse(txtVlrServ.Text, out decVlrServ);
                int.TryParse(gvDetalle.SelectedRow.Cells[2].Text, out IdProducto);
                objGridDet.gsNroOrd = intNumCompra;
                objGridDet.gsCodProd = IdProducto;
                objGridDet.gsValor = Convert.ToInt32(gvDetalle.SelectedRow.Cells[4].Text);
                objGridDet.gsCant = Convert.ToInt32(gvDetalle.SelectedRow.Cells[3].Text);
                objDetCompra.gsIdProducto = IdProducto;
                objDetCompra.gsIdCabCompra = intNumCompra;
                objDetCompra.gsValor = Convert.ToInt32(gvDetalle.SelectedRow.Cells[4].Text);
                objDetCompra.gsUnidadesCompradas = Convert.ToInt32(gvDetalle.SelectedRow.Cells[3].Text);


                if (Session["varDtDetalle"] != null)
                {
                    objGridDet.gsDtDetalle = (DataTable)Session["varDtDetalle"];
                }

                if (objGridDet.BorrarDetalle())
                {
                    Session["varExisteMEM"] = "1";
                    if (objDetCompra.EliminarDetalleCompra())
                    {
                        lblMsjDet.Text = "Detalle eliminada exitosamente";
                        Session["varDtDetalle"] = objGridDet.gsDtDetalle;
                        gvDetalle.DataSource = (DataTable)Session["varDtDetalle"];
                        gvDetalle.DataBind();
                        txtValor.Text = objGridDet.gTot.ToString("#,#");
                        txtIva.Text = objGridDet.gIva.ToString("#,#");
                    }
                    else
                    {
                        if (Session["varExisteMEM"] != null & objDetCompra.gError.Contains("NO Existe"))
                        {
                            lblMsjDet.Text = "Detalle eliminada exitosamente";
                            Session["varDtDetalle"] = objGridDet.gsDtDetalle;
                            gvDetalle.DataSource = (DataTable)Session["varDtDetalle"];
                            gvDetalle.DataBind();
                            txtValor.Text = objGridDet.gTot.ToString("#,#");
                            txtIva.Text = objGridDet.gIva.ToString("#,#");
                        }
                        else
                            lblMsjDet.Text = objDetCompra.gError;

                    }
                }
                else
                {
                    lblMsjDet.Text = objGridDet.gError;
                }

                objGridDet = null;
                LimpiarCampDet();
            }
            else
            {
                lblMsjDet.Text = "Debe Seleccionar un detalle para eliminar";
            }

        }


        private void EliminarCompra()
        {
            
            lblMsjCab.Text = "";
            objTrnCompra = new clsTrnCompra();
            
            int.TryParse(txtNumCompra.Text, out intNumCompra);
            
            objTrnCompra.gsIdCabCompra = Convert.ToInt32(txtNumCompra.Text);
            objTrnCompra.gsIdProducto =  Convert.ToInt32(ddlProducto.SelectedValue);
            
            objTrnCompra.gsDtDetalle = (DataTable)Session["varDtDetalle"];

            if (objTrnCompra.EliminarTrnCompra())
            {
                lblMsjCab.Text = "Compra eliminada exitosamente";
                BloquearCamposGral(false);
                LimpiarCampDet();
                LimpiarCabOrdComp();
            }
            else
            {
                lblMsjCab.Text = objTrnCompra.gError;
            }
            objTrnCompra = null;

        }


        private void LimpiarCabOrdComp()
        {
            txtNumCompra.Text = "";
            calFecOrd.SelectedDate = DateTime.Now;
            calFecOrd.VisibleDate = DateTime.Now;
            ddlCliente.SelectedIndex = -1;
            ddlEmpleado.SelectedIndex = -1;
            txtValor.Text = "";
            txtIva.Text = "";
            txtNumCompra.Focus();
            gvDetalle.DataSource = null;
            gvDetalle.DataBind();


            Session["varDtDetalle"] = null;
        }

        private void LimpiarCampDet()
        {
            
            txtCant.Text = "";
            txtVlrServ.Text = "";
            ddlProducto.SelectedIndex = -1;
            
        }

        private void BloquearCamposGral(bool pBolBloq)
        {

            txtNumCompra.Focus();
            calFecOrd.Enabled = pBolBloq;
            ddlCliente.Enabled = pBolBloq;
            ddlEmpleado.Enabled = pBolBloq;
            btnCancelarCab.Enabled = pBolBloq;
            btnGuardarCab.Enabled = pBolBloq;
            txtCant.Enabled = pBolBloq;
            txtVlrServ.Enabled = pBolBloq;
            ddlProducto.Enabled = pBolBloq;
            btnNuevoDet.Enabled = pBolBloq;
            btnAgregarDet.Enabled = pBolBloq;
            btnEliminarDet.Enabled = pBolBloq;


        }


        #endregion


        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //Es la primera vez que se cargo la pagina
            {
                LlenarDdlCliente();
                LlenarDdlEmpleado();
                LlenarDdlProducto();
                BloquearCamposGral(false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCabeceraCompra();
        }

        protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetalle.PageIndex = e.NewPageIndex;
            LlenarGridDetalle();
        }

        protected void btnAgregarDet_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }


        #endregion

        protected void btnNuevoCab_Click(object sender, EventArgs e)
        {
            lblMsjCab.Text = "";
            lblMsjDet.Text = "";
            LimpiarCampDet();
            LimpiarCabOrdComp();
            BloquearCamposGral(true);
        }

        protected void btnGuardarCab_Click(object sender, EventArgs e)
        {
            GrabarCompra();
        }
        protected void btnCancelarCab_Click(object sender, EventArgs e)
        {

            LimpiarCampDet();
            LimpiarCabOrdComp();
            BloquearCamposGral(false);  

        }
        protected void gvDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["NumOrd"] = Convert.ToInt32(gvDetalle.SelectedRow.Cells[1].Text);
            Session["CodPro"] = Convert.ToInt32(gvDetalle.SelectedRow.Cells[2].Text);
            ObtenerDetalle();
        }

        protected void btnNuevoDet_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarDet_Click(object sender, EventArgs e)
        {
            BorrarDetalle();
        }

        protected void btnEliminarCab_Click(object sender, EventArgs e)
        {
            EliminarCompra();
        }

        protected void gvDetalle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["NumOrd"] = Convert.ToInt32(gvDetalle.SelectedRow.Cells[1].Text);
            Session["CodPro"] = Convert.ToInt32(gvDetalle.SelectedRow.Cells[2].Text);

        }

        protected void btnGuardarComision_Click(object sender, EventArgs e)
        {
            GrabarCompraConComision();
        }

    }
}