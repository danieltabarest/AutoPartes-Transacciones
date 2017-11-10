using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LibRNAutoPartes.Compra
{
   public class clsGridDetalle
    {
        #region Atributos

        private Int32 intNroOrd;
        private int intCodProd;
        private int intCant;
        private decimal decValor;


        private string strError;

        private DataTable dtDetalle;

        private decimal decTot;


        private decimal decIva;


        private const decimal decPctIva = 10;

        #endregion



        #region Propiedades

        public Int32 gsNroOrd
        {
            get { return intNroOrd; }
            set { intNroOrd = value; }
        }
        public int gsCodProd
        {
            get { return intCodProd; }
            set { intCodProd = value; }
        }
        public int gsCant
        {
            get { return intCant; }
            set { intCant = value; }
        }
        public decimal gsValor
        {
            get { return decValor; }
            set { decValor = value; }
        }
     

        public string gError
        {
            get { return strError; }
        }
 
        public DataTable gsDtDetalle
        {
            get { return dtDetalle; }
            set { dtDetalle = value; }
        }


        public decimal gTot
        {
            get { return decTot; }
        }
        public decimal gIva
        {
            get { return decIva; }
        }

        #endregion



        #region Metodos Privados

        private bool ValDatosDetOrd()
        {
            if (intNroOrd < 1 )
            {
                strError = "NO se asigno numero de la compra o es un numero invalido";
                return false;
            }

            if (intCodProd < 1 )
            {
                strError = "NO se asigno codigo de Producto";
                return false;
            }

            if (intCant < 1)
            {
                strError = "NO se asigno cantidad o es una cantidad invalida";
                return false;
            }

            if (decValor < 1)
            {
                strError = "Valor Item menor a Cero o Invalido";
                return false;
            }

            

            return true;
        }

        private bool CrearTabla()
        {
            try
            {
                dtDetalle = new DataTable("Detalle");
                dtDetalle.Columns.Add("IdCabecera", typeof(Decimal));
                dtDetalle.Columns.Add("IdProducto", typeof(String));
                dtDetalle.Columns.Add("Cantidad", typeof(Int32));
                dtDetalle.Columns.Add("Valor", typeof(Decimal));
               

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
       

        private bool CalcularTotalPed()
        {
            try
            {
                decimal objSum = Convert.ToDecimal(dtDetalle.Compute("Sum(Valor)", ""));
                
                decTot = objSum;
                decIva = decTot * (decPctIva / 100);

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        #endregion



        #region Metodos Publicos

        public bool AgregarDetalle()
        {
            if (dtDetalle == null) //Es el primer Detalle a Agregar
            {
                if (!CrearTabla())
                {
                    return false;
                }
            }

            if (!ValDatosDetOrd())
            {
                return false;
            }

            try
            {
                DataRow drFila = dtDetalle.NewRow();



                drFila["IdCabecera"] = intNroOrd;
                drFila["IdProducto"] = intCodProd;
                drFila["Cantidad"] = intCant;
                drFila["Valor"] = decValor;
                


                dtDetalle.Rows.Add(drFila);

                if (!CalcularTotalPed())
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool ObtenerDetalle()
        {
            if (intNroOrd < 1)
            {
                strError = "NO se asigno numero de orden o es un numero invalido";
                return false;
            }

            if (intCodProd < 1)
            {
                strError = "NO se asigno Codigo de Producto";
                return false;
            }

            if (dtDetalle == null) //Es el primer Detalle a Agregar
            {
                strError = "NO se asigno Tabla Detalle";
                return false;
            }

            try
            {
                DataRow[] drFilaRes;

                //string strBus = "nroOrdServ = '10' AND codProd = '70001'";
                string strBus = "IdCabecera = '" + intNroOrd + "' AND IdProducto = '" + intCodProd + "'";

                drFilaRes = dtDetalle.Select(strBus);

                if (drFilaRes.Length > 1)
                {
                    strError = "La busqueda retorno varias filas";
                    return false;
                }

                intCant = Convert.ToInt16(drFilaRes[0]["Cantidad"]);
                decValor = Convert.ToDecimal(drFilaRes[0]["Valor"]);
                //intCodTipSer = Convert.ToInt16(drFilaRes[0]["codTipServ"]);

                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }


        }

        public bool BorrarDetalle()
        {
            if (intNroOrd < 1)
            {
                strError = "NO se asigno numero de orden o es un numero invalido";
                return false;
            }

            if (intCodProd<1)
            {
                strError = "NO se asigno Codigo de Producto";
                return false;
            }

            if (dtDetalle == null) //Es el primer Detalle a Agregar
            {
                strError = "NO se asigno Tabla Detalle";
                return false;
            }

            try
            {
                DataRow[] drFilaRes;

                //string strBus = "nroOrdServ = '10' AND codProd = '70001'";

                string strBus = "[IdCabecera] = '" + intNroOrd + "' AND [IdProducto] = '" + intCodProd + "' AND [Cantidad] = " + intCant + " AND [Valor] = " + decValor + ""; 

                drFilaRes = dtDetalle.Select(strBus);

                foreach (DataRow drFila in drFilaRes)
                {
                    dtDetalle.Rows.Remove(drFila);
                }

                if (dtDetalle.Rows.Count > 0) //Es el primer Detalle a Agregar
                {
                    if (!CalcularTotalPed())
                    {
                        return false;
                    }
                }

                return true;
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
