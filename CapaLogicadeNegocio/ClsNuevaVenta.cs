using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogicadeNegocio
{
    public class ClsNuevaVenta
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
        public Int32 c_idPromocion { get; set; }

        ClsManejador m = new ClsManejador();

        public String NuevaVenta()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {

                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@nit_Cliente", c_NIT));
                lst.Add(new ClsParametros("@Nombre_Cliente", c_NombreCliente));
                lst.Add(new ClsParametros("@id_Cajero", c_idCajero));
                lst.Add(new ClsParametros("@id_TipoPago", c_idTipoPago));
                lst.Add(new ClsParametros("@Fecha", c_Fecha));
                lst.Add(new ClsParametros("@HoraVenta", c_Hora));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("encFactura", lst);
                Mensaje = lst[6].Valor.ToString();
            }catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public String NuevoDetalleVenta()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@id_Producto", c_idProducto));
                lst.Add(new ClsParametros("@PrecioVenta", c_PrecioVenta));
                lst.Add(new ClsParametros("@Cantidad", c_Cantidad));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("detFactura", lst);
                Mensaje = lst[3].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public DataTable MostrarAuditoria()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarAuditoria", lst);
        }

        public String TriggerNuevaVenta()
        {
            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("insertarVentaAuditoria", lst);
                Mensaje = lst[0].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public String TriggerCancelarVenta()
        {
            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("cancelarVenntaAuditoria", lst);
                Mensaje = lst[0].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public DataTable MostrarEncabezadoVenta()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarEncabezado", lst);
        }

        public DataTable MostrarDetalleVenta()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarDetalle", lst);
        }

        public DataTable MostrarTotalFactura()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarTotal", lst);
        }

        public DataTable MostrarDetalleVentaPDF()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarDetallePDF", lst);
        }

        public DataTable MostrarTotalCierreCaja()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Fecha", c_Fecha));
            return m.Listado("totalCierreCaja", lst);
        }

        public String actualizarTotal()
        {
            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("totalFactura", lst);
                Mensaje = lst[0].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public DataTable PropietarioNIT()
        {            
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@nit_Cliente", c_NIT));
            return m.Listado("mostrarCliente", lst);
        }

        public DataTable ListadoTipoPago()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarTipoPago", lst);
        }

        public DataTable ListadoProductos()
        {

            return m.Listado("mostrarProductos", null);
        }

        public String DevolverStock()
        {
            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@id_Producto", c_idProducto));
                lst.Add(new ClsParametros("@Cantidad", c_Cantidad));
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("devolverStock", lst);
                Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public String CancelarVenta()
        {
            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("cancelarFactura", lst);
                Mensaje = lst[0].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public DataTable buscarProducto()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Descripcion", c_Descripcion));
            return m.Listado("buscarProducto", lst);
        }

        public DataTable MostrarPromocion()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@id_Promocion", c_idPromocion));
            return m.Listado("mostrarPromocion", lst);
        }
    }
}
