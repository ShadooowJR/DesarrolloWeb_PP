using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogicadeNegocio
{
    public class ClsDevolucion
    {
        public String c_NIT { get; set; }
        public String c_NombreCliente { get; set; }
        public Int32 c_idCajero { get; set; }
        public Int32 c_idTipoPago { get; set; }
        public String c_Fecha { get; set; }
        public String c_Hora { get; set; }
        public decimal c_Total { get; set; }
        public Int32 c_idProducto { get; set; }
        public decimal c_PrecioVenta { get; set; }
        public decimal c_Cantidad { get; set; }
        public String c_Descripcion { get; set; }
        public Int32 c_idFactura { get; set; }
        public Int32 c_idDFactura { get; set; }

        ClsManejador m = new ClsManejador();

        public String NuevaDevolucion()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@nit_Cliente", c_NIT));
                lst.Add(new ClsParametros("@Descripcion", c_Descripcion));
                lst.Add(new ClsParametros("@Cantidad", c_Cantidad));                
                lst.Add(new ClsParametros("@Fecha", c_Fecha));
                lst.Add(new ClsParametros("@HoraDevolucion", c_Hora));
                lst.Add(new ClsParametros("@id_dFactura", c_idDFactura));
                lst.Add(new ClsParametros("@id_Factura", c_idFactura));
                lst.Add(new ClsParametros("@id_Producto", c_idProducto));
                lst.Add(new ClsParametros("@id_Cajero", c_idCajero));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("nuevaDevolucion", lst);
                Mensaje = lst[9].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public DataTable MostrarAuditoria()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarAuditoria", lst);
        }

        public DataTable MostrarDetalleFactura()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@id_Factura", c_idFactura));
            return m.Listado("mostrarDetalleConID", lst);
        }

        public DataTable MostrarDetalleFacturaPDF()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@id_Factura", c_idFactura));
            return m.Listado("mostrarDetallePDFConID", lst);
        }

        public DataTable MostrarDetalleDevoluciones()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@id_Factura", c_idFactura));
            return m.Listado("mostrarDevolucionesConID", lst);
        }
        public DataTable MostrarEncabezado()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@id_Factura", c_idFactura));
            return m.Listado("mostrarEncabezadoConID", lst);
        }
    }
}
