using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CapaPresentacion
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["App"] = "Para Todos";
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["id"] = "Por Defecto";
            Session["Cajero"] = "Por Defecto";
            Session["Fecha"] = "Por Defecto";
            Session["Hora"] = "Por Defecto";
            Session["InicioCaja"] = "Por Defecto";
            Session["CierreCaja"] = "Por Defecto";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}