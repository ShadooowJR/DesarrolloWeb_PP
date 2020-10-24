using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaLogicadeNegocio;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaPresentacion
{
    public partial class NuevoPedido : System.Web.UI.Page
    {
        ClsPedido objPedido = new ClsPedido();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                LlenarDDLProveedor();
                LlenarGridPedidos();
            }
        }

        protected void LlenarDDLProveedor()
        {
            try
            {
                ddlProveedor.DataSource = objPedido.MostrarProveedores();
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

        private void LlenarGridProductosProveedor()
        {
            objPedido.c_idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue.ToString());
            DataTable dt = objPedido.MostrarProductoProveedor();
            gvProductos.DataSource = dt;
            gvProductos.DataBind();
        }

        private void LlenarGridPedidos()
        {
            DataTable dt = objPedido.MostrarPedidos();
            gvPedidos.DataSource = dt;
            gvPedidos.DataBind();
        }

        private void LlenarTxtAuditoria()
        {
            txtAuditoria.Text += "-MONITOR DE OPERACIONES-\r\n";
            foreach (DataRow row in objPedido.MostrarAuditoria().Rows)
            {
                txtAuditoria.Text += row[1].ToString() + " " + row[2].ToString() + "\r\n";
            }
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {                
                Label2.Visible = true;
                Label3.Visible = true;
                Label7.Visible = true;
                Label8.Visible = true;
                txtFechaPedido.Visible = true;
                txtFechaEntrega.Visible = true;
                txtCantidad.Visible = true;
                txtCajero.Visible = true;
                btnAceptar.Visible = true;
                gvProductos.Visible = true;
                txtAuditoria.Visible = true;
                ddlProveedor.Enabled = false;

                txtFechaPedido.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtCajero.Text = Session["Cajero"].ToString();
                LlenarGridProductosProveedor();
                LlenarTxtAuditoria();

            } catch (Exception ex) { }            
        }

        

        protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnPedidoRecibido_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            objPedido.c_idPedido = Convert.ToInt32(gvPedidos.SelectedRow.Cells[1].Text);
            objPedido.c_idProducto = Convert.ToInt32(gvPedidos.SelectedRow.Cells[2].Text);
            objPedido.c_Cantidad = Convert.ToDecimal(gvPedidos.SelectedRow.Cells[6].Text);
            Mensaje = objPedido.EntregarPedido();
            LlenarGridPedidos();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            String Mensaje = "";

            try
            {
                objPedido.c_idProducto = Convert.ToInt32(gvProductos.SelectedRow.Cells[1].Text);
                objPedido.c_idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue.ToString());
                objPedido.c_idCajero = Convert.ToInt32(Session["id"]);
                objPedido.c_PrecioCompra = Convert.ToDecimal(gvProductos.SelectedRow.Cells[3].Text);
                objPedido.c_Cantidad = Convert.ToInt32(txtCantidad.Text);
                objPedido.c_FechaPedido = txtFechaPedido.Text;
                objPedido.c_FechaEntrega = txtFechaEntrega.Text;

                Mensaje = objPedido.NuevoPedido();
                LlenarGridPedidos();
                
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("shadooowjr@gmail.com");
                mail.To.Add("bryan.alejo06@gmail.com");
                mail.Subject = "NUEVO PEDIDO - RINCON GUATEMALTECO";
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "Hola, Rincón Guatemalteco necesita "+txtCantidad.Text+" unidades de "+gvProductos.SelectedRow.Cells[2].Text+" para el "+ txtFechaEntrega.Text+". Gracias, saludos.";
                mail.Body = htmlBody;                              
                sc.Port = 587;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential("shadooowjr@gmail.com","alejandro06");
                sc.EnableSsl = true;
                try {
                    Thread email = new Thread(delegate ()
                    {
                        sc.Send(mail);
                    });
                    email.IsBackground = true;
                    email.Start();

                } catch (Exception) { }
                txtAuditoria.Text = "";
                txtCantidad.Text = "";
                txtFechaEntrega.Text = "";
                LlenarTxtAuditoria();
            }
            catch (Exception ex) { }
        }
    }
}