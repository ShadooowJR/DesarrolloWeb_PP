using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class InicioCaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                Session["InicioCaja"] = Convert.ToString(Convert.ToDecimal(txtInicioCaja.Text));
                Session["CierreCaja"] = Convert.ToString(Convert.ToDecimal(txtInicioCaja.Text));
                Response.Redirect("Inicio.aspx");
            } catch(Exception ex) {
                lblMensaje.Text = "Cantidad Inválida";
            }
            
        }
    }
}