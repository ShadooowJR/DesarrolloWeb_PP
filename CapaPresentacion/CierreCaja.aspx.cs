using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaLogicadeNegocio;

namespace CapaPresentacion
{
    
    public partial class CierreCaja : System.Web.UI.Page
    {
        ClsNuevaVenta objCierreCaja = new ClsNuevaVenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objCierreCaja.c_Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                Session["CierreCaja"] = objCierreCaja.MostrarTotalCierreCaja().Rows[0][0].ToString();
                if(Session["CierreCaja"].ToString() == "")
                {
                    txtInicioCaja.Text = Session["InicioCaja"].ToString();
                    txtCierreCaja.Text = Session["InicioCaja"].ToString();
                }
                else
                {
                    txtInicioCaja.Text = Session["InicioCaja"].ToString();
                    txtCierreCaja.Text = Convert.ToString(Convert.ToDecimal(Session["CierreCaja"].ToString()) + Convert.ToDecimal(Session["InicioCaja"].ToString()));
                }
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            Session["id"] = "Por Defecto";
            Session["Cajero"] = "Por Defecto";
            Session["Fecha"] = "Por Defecto";
            Session["Hora"] = "Por Defecto";
            Session["InicioCaja"] = "Por Defecto";
            Session["CierreCaja"] = "Por Defecto";
            Response.Redirect("Login.aspx");
        }
    }
}