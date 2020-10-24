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
    public partial class IntProducto : System.Web.UI.Page
    {
        ClsProducto objProducto = new ClsProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGridProductos();

            if (!IsPostBack)
            {
                LlenarGridProductos();
                LlenarDDLTipoProducto();
                LlenarDDLProveedor();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            try
            {

                objProducto.c_Descripcion = txtDescripcion.Text;
                objProducto.c_idTipoProducto = Convert.ToInt32(ddlTipoProducto.SelectedValue.ToString());
                objProducto.c_MarcaProducto = txtMarca.Text;
                objProducto.c_PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                objProducto.c_PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                objProducto.c_Stock = Convert.ToInt32(txtCantidad.Text);
                objProducto.c_idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue.ToString());

                Mensaje = objProducto.IngresarProductos();

                Response.Redirect("IntProducto.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }
        protected void LlenarDDLTipoProducto()
        {
            try
            {
                ddlTipoProducto.DataSource = objProducto.ListadoTipoProducto();
                ddlTipoProducto.DataTextField = "Descripcion";
                ddlTipoProducto.DataValueField = "id_TipoProducto";
                ddlTipoProducto.DataBind();
                ddlTipoProducto.Items.Insert(0, new ListItem("[-Seleccionar-]", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }

        protected void LlenarDDLProveedor()
        {
            try
            {
                ddlProveedor.DataSource = objProducto.ListadoProveedores();
                ddlProveedor.DataTextField = "Descripcion";
                ddlProveedor.DataValueField = "id_Proveedor";
                ddlProveedor.DataBind();
                ddlProveedor.Items.Insert(0, new ListItem("[-Seleccionar-]", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }

        private void LlenarGridProductos()
        {
            DataTable dt = objProducto.ListadoProductos();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("IntProducto.aspx");
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Mensaje = "";
            try
            {
                objProducto.c_idProducto = Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
                Mensaje = objProducto.EliminarProducto();
                Response.Redirect("IntProducto.aspx");
            }
            catch (Exception ex) { }
        }
    }
}