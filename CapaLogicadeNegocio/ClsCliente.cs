using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogicadeNegocio
{
    public class ClsCliente
    {
        //ATRIBUTOS
        public Int32 c_idCliente { get; set; }
        public String c_NIT { get; set; }
        public String c_Nombre { get; set; }
        public decimal c_DPI { get; set; }
        public String c_Direccion { get; set; }
        public decimal c_Telefono { get; set; }
        public String c_Email { get; set; }
        public Int32 c_Pais { get; set; }
        public Int32 c_Depa { get; set; }
        public Int32 c_Municipio { get; set; }


        ClsManejador m = new ClsManejador();

        //INGRESAR CLIENTES  
        public String IngresarClientes() {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try {

                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@nit_Cliente", c_NIT));
                lst.Add(new ClsParametros("@Nombre", c_Nombre));
                lst.Add(new ClsParametros("@DPI", c_DPI));
                lst.Add(new ClsParametros("@Direccion", c_Direccion));
                lst.Add(new ClsParametros("@Telefono", c_Telefono));
                lst.Add(new ClsParametros("@Email", c_Email));
                lst.Add(new ClsParametros("@id_Municipio", c_Municipio));
                lst.Add(new ClsParametros("@id_Departamento", c_Depa));
                lst.Add(new ClsParametros("@id_Pais", c_Pais));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("nuevoCliente", lst);
                Mensaje = lst[9].Valor.ToString();

            } catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public String ModificarCliente()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {

                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@id_Cliente", c_idCliente));
                lst.Add(new ClsParametros("@nit_Cliente", c_NIT));
                lst.Add(new ClsParametros("@Nombre", c_Nombre));
                lst.Add(new ClsParametros("@DPI", c_DPI));
                lst.Add(new ClsParametros("@Direccion", c_Direccion));
                lst.Add(new ClsParametros("@Telefono", c_Telefono));
                lst.Add(new ClsParametros("@Email", c_Email));
                lst.Add(new ClsParametros("@id_Municipio", c_Municipio));
                lst.Add(new ClsParametros("@id_Departamento", c_Depa));
                lst.Add(new ClsParametros("@id_Pais", c_Pais));
                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("modCliente", lst);
                Mensaje = lst[10].Valor.ToString();

            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public String EliminarCliente()
        {

            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@id_Cliente", c_idCliente));
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("eliminarCliente", lst);
                Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        //LISTAR CLIENTES
        public DataTable ListadoClientes() {

            return m.Listado("mostrarClientes", null);
        }

        public DataTable ListadoPaises()
        {
            return m.Listado("mostrarPaises", null);
        }

        public DataTable ListadoDepartamentos()
        {
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@id_Pais", c_Pais));
                return m.Listado("mostrarDepartamentos", lst);
            }
            catch (Exception ex) { throw ex; }                       
        }

        public DataTable ListadoMunicipios()
        {
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@id_Departamento", c_Depa));
                return m.Listado("mostrarMunicipios", lst);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
