using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogicadeNegocio
{
    public class ClsProveedor
    {
        public Int32 c_idProveedor { get; set; }
        public String c_Descripcion { get; set; }
        public String c_Email { get; set; }

        ClsManejador m = new ClsManejador();
        public String IngresarProveedor()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {

                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@Descripcion", c_Descripcion));
                lst.Add(new ClsParametros("@Email", c_Email));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("nuevoProveedor", lst);
                Mensaje = lst[2].Valor.ToString();

            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public String EliminarProveedor()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {

                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@id_Proveedor", c_idProveedor));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("eliminarProveedor", lst);
                Mensaje = lst[1].Valor.ToString();

            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public DataTable ListadoProveedores()
        {

            return m.Listado("mostrarProveedor", null);
        }
    }
}
