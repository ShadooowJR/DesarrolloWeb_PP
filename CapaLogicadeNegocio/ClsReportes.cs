using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaLogicadeNegocio
{
    public class ClsReportes
    {
        public String c_FechaInicio { get; set; }
        public String c_FechaFinal { get; set; }

        ClsManejador m = new ClsManejador();

        public DataTable ReporteClientes()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return m.Listado("reporteClientes", lst);
        }
        public DataTable ReporteDevoluciones()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@FechaInicio", c_FechaInicio));
            lst.Add(new ClsParametros("@FechaFinal", c_FechaFinal));
            return m.Listado("reporteDevoluciones", lst);
        }

        public DataTable ReporteVentas()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@FechaInicio", c_FechaInicio));
            lst.Add(new ClsParametros("@FechaFinal", c_FechaFinal));
            return m.Listado("reporteVentas", lst);
        }

        public DataTable GananciasTotales()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@FechaInicio", c_FechaInicio));
            lst.Add(new ClsParametros("@FechaFinal", c_FechaFinal));
            return m.Listado("totalVentas", lst);
        }
    }
}
