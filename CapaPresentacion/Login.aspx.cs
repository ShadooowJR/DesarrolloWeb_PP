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
    public partial class Login : System.Web.UI.Page
    {
        ClsLogin objLogin = new ClsLogin();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            try
            {

                objLogin.c_Username = txtUsuario.Text;
                objLogin.c_Pass = txtPass.Text;

                Mensaje = objLogin.ValidarUsuario();

                if(Mensaje == "null")
                {
                    lblMensaje.Text = "Usuario y/o Contraseña Incorrectos";
                }
                else
                {
                    Session["id"] = objLogin.DatosCajero().Rows[0]["id_Usuario"].ToString();
                    Session["Cajero"] = objLogin.DatosCajero().Rows[0]["Nombre"].ToString();
                    Response.Redirect("InicioCaja.aspx");
                }
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }
    }
}