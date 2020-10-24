using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogicadeNegocio
{
    public class ClsPedido
    {
        public Int32 c_idProveedor { get; set; }
        public Int32 c_idPedido { get; set; }
        public Int32 c_idProducto { get; set; }
        public Int32 c_idCajero { get; set; }
        public decimal c_PrecioCompra { get; set; }
        public decimal c_Cantidad { get; set; }
        public String c_FechaPedido { get; set; }
        public String c_FechaEntrega { get; set; }

        ClsManejador m = new ClsManejador();

        public String NuevoPedido()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@id_Producto", c_idProducto));
                lst.Add(new ClsParametros("@id_Proveedor", c_idProveedor));
                lst.Add(new ClsParametros("@id_Cajero", c_idCajero));
                lst.Add(new ClsParametros("@PrecioCompra", c_PrecioCompra));
                lst.Add(new ClsParametros("@Cantidad", c_Cantidad));
                lst.Add(new ClsParametros("@Fecha_Pedido", c_FechaPedido));
                lst.Add(new ClsParametros("@Fecha_Entrega", c_FechaEntrega));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("nuevoPedido", lst);
                Mensaje = lst[7].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public String EntregarPedido()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@id_Pedido", c_idPedido));
                lst.Add(new ClsParametros("@id_Producto", c_idProducto));
                lst.Add(new ClsParametros("@Cantidad", c_Cantidad));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("entregarPedido", lst);
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

        public DataTable MostrarProveedores()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarProveedores", lst);
        }

        public DataTable MostrarProductoProveedor()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@id_Proveedor", c_idProveedor));
            return m.Listado("mostrarProductosProveedor", lst);
        }

        public DataTable MostrarPedidos()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("mostrarPedidos", lst);
        }
    }
}
