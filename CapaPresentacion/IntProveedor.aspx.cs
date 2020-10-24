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
    public partial class IntProveedor : System.Web.UI.Page
    {
        ClsProveedor objProveedor = new ClsProveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGridProveedores();

            if (!IsPostBack)
            {
                LlenarGridProveedores();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            try
            {

                objProveedor.c_Descripcion = txtDescripcion.Text;
                objProveedor.c_Email = txtEmail.Text;

                Mensaje = objProveedor.IngresarProveedor();

                Response.Redirect("IntProveedor.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }

        private void LlenarGridProveedores()
        {
            DataTable dt = objProveedor.ListadoProveedores();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("IntProveedor.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String Mensaje = "";
            try
            {
                Response.Write(Mensaje);
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            String Mensaje = "";
            try
            {
                objProveedor.c_idProveedor = Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
                Mensaje = objProveedor.EliminarProveedor();
                Response.Redirect("IntProveedor.aspx");
            }
            catch (Exception ex) { }
        }
    }
}