using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaLogicadeNegocio
{
    public class ClsProducto
    {
        //ATRIBUTOS
        public Int32 c_idProducto { get; set; }
        public String c_Descripcion { get; set; }
        public Int32 c_idTipoProducto { get; set; }
        public String c_MarcaProducto { get; set; }
        public decimal c_PrecioCompra { get; set; }
        public decimal c_PrecioVenta { get; set; }        
        public decimal c_Stock { get; set; }
        public Int32 c_idProveedor { get; set; }

        ClsManejador m = new ClsManejador();

        //INGRESAR CLIENTES  
        public String IngresarProductos()
        {
            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {

                //PASAMOS PARAMETROS DE ENTRADA                
                lst.Add(new ClsParametros("@Descripcion", c_Descripcion));
                lst.Add(new ClsParametros("@id_TipoProducto", c_idTipoProducto));
                lst.Add(new ClsParametros("@MarcaProducto", c_MarcaProducto));
                lst.Add(new ClsParametros("@PrecioCompra", c_PrecioCompra));
                lst.Add(new ClsParametros("@PrecioVenta", c_PrecioVenta));
                lst.Add(new ClsParametros("@Stock", c_Stock));
                lst.Add(new ClsParametros("@id_Proveedor", c_idProveedor));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("nuevoProducto", lst);
                Mensaje = lst[7].Valor.ToString();

            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }
             
        //LISTAR CLIENTES
        public DataTable ListadoProductos()
        {

            return m.Listado("mostrarProductos", null);
        }
        public DataTable ListadoTipoProducto()
        {

            return m.Listado("mostrarTipoProducto", null);
        }

        public DataTable ListadoProveedores()
        {

            return m.Listado("mostrarProveedor", null);
        }

        public String EliminarProducto()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {

                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@id_Producto", c_idProducto));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("eliminarProducto", lst);
                Mensaje = lst[1].Valor.ToString();

            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }
    }
}
