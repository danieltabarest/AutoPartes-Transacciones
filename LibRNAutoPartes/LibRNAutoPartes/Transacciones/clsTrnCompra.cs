using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibRNAutoPartes.Compra;
using System.Data;
using System.Transactions;
using LibRNAutoPartes.Maestro;

namespace LibRNAutoPartes.Transacciones
{
    public class clsTrnCompra
    {
        #region Atributos

        //Atributos Cabecera Orden
        private Int32 idCabCompra;
        private DateTime dtmFechaCabCompra;
        private string stridCliente;
        private string stridEmpleado;
        private decimal decVlr;
        private decimal decIva;
        private double dbPorComEmpleado;
        private double dbVlrComEmpleado;



        private int IdProducto;



        //Atributo Detalle Orden;
        private DataTable dtDetalle;

        private string strError;

        #endregion



        #region Propiedades

        public int gsIdProducto
        {
            get { return IdProducto; }
            set { IdProducto = value; }
        }

        public Int32 gsIdCabCompra
        {
            get { return idCabCompra; }
            set { idCabCompra = value; }
        }

        public DateTime gsFechaCabCompra
        {
            get { return dtmFechaCabCompra; }
            set { dtmFechaCabCompra = value; }
        }

        public string gsidClient
        {
            get { return stridCliente; }
            set { stridCliente = value; }
        }

        public string gsidEmpleado
        {
            get { return stridEmpleado; }
            set { stridEmpleado = value; }
        }

        public decimal gsVlr
        {
            get { return decVlr; }
            set { decVlr = value; }
        }

        public decimal gsIva
        {
            get { return decIva; }
            set { decIva = value; }
        }

        public DataTable gsDtDetalle
        {
            get { return dtDetalle; }
            set { dtDetalle = value; }
        }

        public string gError
        {
            get { return strError; }
        }

        public double gsDbPorComEmpleado
        {
            get { return dbPorComEmpleado; }
            set { dbPorComEmpleado = value; }
        }
        public double gsDbVlrComEmpleado
        {
            get { return dbVlrComEmpleado; }
            set { dbVlrComEmpleado = value; }
        }

        #endregion


        #region Metodos Privados

        private bool GrabarCabecera()
        {
            clsCabeceraCompra objCabOrd = new clsCabeceraCompra();

            objCabOrd.gsNroOrd = idCabCompra;
            objCabOrd.gsFechaCabCompra = dtmFechaCabCompra;
            objCabOrd.gsCodCli = stridCliente;
            objCabOrd.gsCodTec = stridEmpleado;
            objCabOrd.gsVlr = decVlr;
            objCabOrd.gsIva = decIva;

            if (!objCabOrd.GrabarCabCompra())
            {
                strError = objCabOrd.gError;
                objCabOrd = null;
                return false;
            }

            objCabOrd = null;
            return true;
        }


        private bool GrabarDetalle()
        {
            if (dtDetalle == null)
            {
                strError = "NO se asignaron los productos de la compra";
                return false;
            }

            clsDetalleCompra objDetalleCompra = new clsDetalleCompra();

            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                objDetalleCompra.gsIdCabCompra = Convert.ToInt32(dtDetalle.Rows[i][0]);
                objDetalleCompra.gsIdProducto = Convert.ToInt32(dtDetalle.Rows[i][1]);
                objDetalleCompra.gsUnidadesCompradas = Convert.ToInt32(dtDetalle.Rows[i][2]);
                objDetalleCompra.gsValor = Convert.ToDecimal(dtDetalle.Rows[i][3]);


                if (!objDetalleCompra.GrabarDetalleCompra())
                {
                    strError = objDetalleCompra.gError;
                    objDetalleCompra = null;
                    return false;
                }
            }

            objDetalleCompra = null;
            return true;
        }


        private bool EliminarCabecera()
        {
            clsCabeceraCompra objCabOrd = new clsCabeceraCompra();

            objCabOrd.gsNroOrd = idCabCompra;

            if (!objCabOrd.EliminarCabCompra())
            {
                strError = objCabOrd.gError;
                objCabOrd = null;
                return false;
            }

            objCabOrd = null;
            return true;
        }

        private bool EliminarDetalle()
        {
            if (dtDetalle == null)
            {
                strError = "NO se asignaron los productos de la compra";
                return false;
            }

            clsDetalleCompra objDetalleCompra = new clsDetalleCompra();

            for (int i = 0; i < dtDetalle.Rows.Count; i++)
            {
                objDetalleCompra.gsIdCabCompra = Convert.ToInt32(dtDetalle.Rows[0][0]);
                if (!objDetalleCompra.EliminarDetalleCompra())
                {
                    strError = objDetalleCompra.gError;
                    objDetalleCompra = null;
                    return false;
                }
            }


            objDetalleCompra = null;
            return true;
        }

        private bool GrabarComisionEmpleado()
        {
            dbVlrComEmpleado = (dbPorComEmpleado * Convert.ToDouble(decVlr)) / 100;

            clsEmpleado objEmpleado = new clsEmpleado();

            objEmpleado.gsIdEmpleado = stridEmpleado;
            objEmpleado.gsVlrComision = dbVlrComEmpleado;

            if (!objEmpleado.GrabarComisionEmpleado())
            {
                strError = objEmpleado.gError;
                objEmpleado = null;
                return false;
            }

            objEmpleado = null;
            return true;
        }

        private bool ConsultarPorcentajeComisionEmpleado()
        {
            clsEmpleado objEmpleado = new clsEmpleado();

            objEmpleado.gsIdEmpleado = stridEmpleado;


            if (!objEmpleado.ObtenerPorcentajeComisionEmpleado())
            {
                strError = objEmpleado.gError;
                objEmpleado = null;
                return false;
            }

            dbPorComEmpleado = objEmpleado.gsVlrPorcentajeComision;
            objEmpleado = null;
            return true;
        }

        #endregion


        #region Metodos Publicos

        public bool GrabarTrnCompra()
        {
            try
            {
                using (TransactionScope objTrnScp = new TransactionScope())
                {
                    if (GrabarCabecera())
                    {
                        if (GrabarDetalle())
                        {
                            objTrnScp.Complete();
                            return true;
                        }
                        else
                        {
                            objTrnScp.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        objTrnScp.Dispose();
                        return false;
                    }

                }
            }
            catch (TransactionException tex)
            {
                strError = tex.Message;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool EliminarTrnCompra()
        {
            try
            {
                using (TransactionScope objTrnScp = new TransactionScope())
                {

                    if (EliminarDetalle())
                    {
                        if (EliminarCabecera())
                        {
                            objTrnScp.Complete();
                            return true;
                        }
                        else
                        {
                            objTrnScp.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        objTrnScp.Dispose();
                        return false;
                    }

                }

            }
            catch (TransactionException tex)
            {
                strError = tex.Message;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        
        public bool GrabarTrnCompraComisionEmpleado()
        {
            try
            {
                using (TransactionScope objTrnScp = new TransactionScope())
                {
                    if (GrabarCabecera())
                    {
                        if (GrabarDetalle())
                        {
                            if (ConsultarPorcentajeComisionEmpleado())
                            {
                                if (GrabarComisionEmpleado())
                                {
                                    objTrnScp.Complete();
                                    return true;
                                }
                                else
                                {
                                    objTrnScp.Dispose();
                                    return false;
                                }
                            }
                            else
                            {
                                objTrnScp.Dispose();
                                return false;
                            }
                        }
                        else
                        {
                            objTrnScp.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        objTrnScp.Dispose();
                        return false;
                    }

                }
            }
            catch (TransactionException tex)
            {
                strError = tex.Message;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        #endregion
    }
}
