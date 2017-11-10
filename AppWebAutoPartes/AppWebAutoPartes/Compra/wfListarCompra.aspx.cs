using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibRNAutoPartes;
using LibRNAutoPartes.Compra;

namespace AppWebAutoPartes.Pedido
{
    public partial class wfListarPedido : System.Web.UI.Page
    {
        #region Atributos
        //Int32 intNroOrd;
        clsCabeceraCompra objCabeceraCompra ;
        clsDetalleCompra objDetalleCompra;
        #endregion


        #region Metodos Privados

        private void LlenarGridCabOrd()
        {
            objCabeceraCompra = new clsCabeceraCompra();

            objCabeceraCompra.gsGvCabCompra = gvCabOrd;

            if (objCabeceraCompra.LlenarCabeceraCompra())
            {
                gvCabOrd = objCabeceraCompra.gsGvCabCompra;
            }
            else
            {
                lblMsj.Text = objCabeceraCompra .gError;
            }

            objCabeceraCompra  = null;
        }

        private void LlenarGridDetOrd()
        {
            objDetalleCompra = new clsDetalleCompra();

            objDetalleCompra.gsIdCabCompra = (int)Session["NumOrd"];
            objDetalleCompra.gsGvDetalleCompra= gvDetOrd;

            if (objDetalleCompra.LlenarDetalleCompra())
            {
                gvDetOrd = objDetalleCompra.gsGvDetalleCompra;
            }
            else
            {
                lblMsj.Text = objDetalleCompra.gError;
            }

            objDetalleCompra = null;
        }

        #endregion



        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            LlenarGridCabOrd();
        }

        protected void gvCabOrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCabOrd.PageIndex = e.NewPageIndex;
            LlenarGridCabOrd();
        }

        protected void gvCabOrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["NumOrd"] = Convert.ToInt32(gvCabOrd.SelectedRow.Cells[1].Text);
            gvDetOrd.PageIndex = 0;
            LlenarGridDetOrd();
        }

        protected void gvDetOrd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDetOrd.PageIndex = e.NewPageIndex;
            LlenarGridDetOrd();
        }

        #endregion

    }
}