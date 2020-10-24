using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogicadeNegocio
{
    public class ClsLogin
    {
        public String c_Username { get; set; }
        public String c_Pass { get; set; }

        ClsManejador m = new ClsManejador();

        public String ValidarUsuario()
        {
            String Mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {

                //PASAMOS PARAMETROS DE ENTRADA
                lst.Add(new ClsParametros("@Username", c_Username));
                lst.Add(new ClsParametros("@Pass", c_Pass));

                //PASAMOS LOS PARAMETROS DE SALIDA
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                m.EjecutarSP("validarUsuario", lst);
                Mensaje = lst[2].Valor.ToString();

            }
            catch (Exception ex) { throw ex; }

            return Mensaje;
        }

        public DataTable DatosCajero()
        {
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                lst.Add(new ClsParametros("@Username", c_Username));
                return m.Listado("obtenerCajero", lst);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
