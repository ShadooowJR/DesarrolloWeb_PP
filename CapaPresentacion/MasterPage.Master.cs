using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("IntCliente.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("IntProducto.aspx");
        }

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("IntVenta.aspx");
        }
    }
}