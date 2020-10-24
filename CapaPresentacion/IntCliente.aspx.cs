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
    public partial class Cliente : System.Web.UI.Page
    {

        
        ClsCliente objCliente = new ClsCliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGridClientes();

            if (!IsPostBack)
            {
                LlenarDDL();
                LlenarGridClientes();
            }
        }
                
        protected void Button1_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            try
            {

                objCliente.c_NIT = txtNIT.Text;
                objCliente.c_Nombre = txtNombre.Text;
                objCliente.c_DPI = Convert.ToDecimal(txtDPI.Text);
                objCliente.c_Direccion = txtDireccion.Text;
                objCliente.c_Telefono = Convert.ToDecimal(txtTelefono.Text);
                objCliente.c_Email = txtEmail.Text;
                objCliente.c_Municipio = Convert.ToInt32(ddlMunicipio.SelectedValue.ToString());
                objCliente.c_Depa = Convert.ToInt32(ddlDepa.SelectedValue.ToString());
                objCliente.c_Pais = Convert.ToInt32(ddlPais.SelectedValue.ToString());

                Mensaje = objCliente.IngresarClientes();

                Response.Redirect("IntCliente.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }

        private void LlenarGridClientes(){
            DataTable dt = objCliente.ListadoClientes();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void LlenarDDL()
        {
            try
            {
                ddlPais.DataSource = objCliente.ListadoPaises();
                ddlPais.DataTextField = "Nombre";
                ddlPais.DataValueField = "id_Pais";
                ddlPais.DataBind();
                ddlPais.Items.Insert(0, new ListItem("[-Seleccionar-]", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {            
            try
            {
                objCliente.c_Pais = Convert.ToInt32(ddlPais.SelectedValue.ToString());
                ddlDepa.DataSource = objCliente.ListadoDepartamentos();
                ddlDepa.DataTextField = "Nombre";
                ddlDepa.DataValueField = "id_Departamento";
                ddlDepa.DataBind();
                ddlDepa.Items.Insert(0, new ListItem("[-Seleccionar-]", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }

        }

        protected void ddlDepa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objCliente.c_Depa = Convert.ToInt32(ddlDepa.SelectedValue.ToString());
                ddlMunicipio.DataSource = objCliente.ListadoMunicipios();
                ddlMunicipio.DataTextField = "Nombre";
                ddlMunicipio.DataValueField = "id_Municipio";
                ddlMunicipio.DataBind();
                ddlMunicipio.Items.Insert(0, new ListItem("[-Seleccionar-]", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("IntCliente.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String Mensaje = "";
            try
            {
                objCliente.c_idCliente = Convert.ToInt32(txtNIT.Text);
                objCliente.c_NIT = txtNIT.Text;
                objCliente.c_Nombre = txtNombre.Text;
                objCliente.c_DPI = Convert.ToDecimal(txtDPI.Text);
                objCliente.c_Direccion = txtDireccion.Text;
                objCliente.c_Telefono = Convert.ToDecimal(txtTelefono.Text);
                objCliente.c_Email = txtEmail.Text;
                objCliente.c_Municipio = Convert.ToInt32(ddlMunicipio.SelectedItem.ToString());
                objCliente.c_Depa = Convert.ToInt32(ddlDepa.SelectedItem.ToString());
                objCliente.c_Pais = Convert.ToInt32(ddlPais.SelectedItem.ToString());

                Mensaje = objCliente.ModificarCliente();

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
            try {
                objCliente.c_idCliente = Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);
                Mensaje = objCliente.EliminarCliente();
                Response.Redirect("IntCliente.aspx");
            }
            catch (Exception ex) { }
        }
    }
}