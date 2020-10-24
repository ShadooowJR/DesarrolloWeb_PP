using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaLogicadeNegocio;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ListItem = System.Web.UI.WebControls.ListItem;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing;
using System.Drawing.Imaging;

namespace CapaPresentacion
{
    public partial class NuevaVenta : System.Web.UI.Page
    {
        ClsNuevaVenta objNuevaVenta = new ClsNuevaVenta();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                LlenarDDLTipoPago();
                txtAuditoria.Text = "";
                LlenarTxtAuditoria();
            }
        }

        protected void txtNIT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objNuevaVenta.c_NIT = txtNIT.Text;
                txtNombreCliente.Text = " " + objNuevaVenta.PropietarioNIT().Rows[0]["Nombre"].ToString();
                lblErrorNIT.Text = "";
            }
            catch (Exception ex) {
                txtNombreCliente.Text = " ";
                lblErrorNIT.Text = "NIT INVÁLIDO";
            }
            
        }

        protected void btnCrearFactura_Click(object sender, EventArgs e)
        {
            txtNIT.Enabled = false;
            ddlTipoPago.Enabled = false;
            btnCrearFactura.Enabled = false;
            btnCrearFactura.Text = "Factura Creada";

            String Mensaje = "";
            try
            {
                objNuevaVenta.c_NIT = txtNIT.Text;
                objNuevaVenta.c_NombreCliente = txtNombreCliente.Text;
                objNuevaVenta.c_idCajero = Convert.ToInt32(Session["id"]);
                objNuevaVenta.c_idTipoPago = Convert.ToInt32(ddlTipoPago.SelectedValue.ToString());
                objNuevaVenta.c_Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                objNuevaVenta.c_Hora = DateTime.Now.ToString("HH:mm:ss");

                Mensaje = objNuevaVenta.NuevaVenta();
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
                        
            lblSeleccioneProductos.Visible = true;
            lblBuscar.Visible = true;
            txtBuscar.Visible = true;
            gvProductos.Visible = true;
            lblCuanto.Visible = true;
            txtCantidad.Visible = true;
            btnAgregarCarrito.Visible = true;
            btnCancelarVenta.Visible = true;
            lblMensaje.Visible = true;
            Label4.Visible = true;
            txtTotal.Visible = true;
            txtTotal.Text = "0,00";
            
            LlenarGridProductos();

            if(ddlTipoPago.SelectedValue.ToString() == "1")
            {
                lblEfectivo.Visible = true;
                txtEfectivo.Visible = true;
                lblCambio.Visible = true;
                txtCambio.Visible = true;
            }
            txtAuditoria.Text = "";
            LlenarTxtAuditoria();
        }

        protected void LlenarDDLTipoPago()
        {
            try
            {
                ddlTipoPago.DataSource = objNuevaVenta.ListadoTipoPago();
                ddlTipoPago.DataTextField = "Descripcion";
                ddlTipoPago.DataValueField = "id_TipoPago";
                ddlTipoPago.DataBind();
                ddlTipoPago.Items.Insert(0, new ListItem("[-Seleccionar-]", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
        }

        private void LlenarTxtAuditoria()
        {
            txtAuditoria.Text += "-MONITOR DE OPERACIONES-\r\n";
            foreach (DataRow row in objNuevaVenta.MostrarAuditoria().Rows)
            {
                txtAuditoria.Text += row[1].ToString() + " " + row[2].ToString() + "\r\n";
            }
        }

        private void LlenarGridProductos()
        {
            DataTable dt = objNuevaVenta.ListadoProductos();
            gvProductos.DataSource = dt;
            gvProductos.DataBind();
        }

        private void LlenarGridCarrito()
        {
            DataTable dt = objNuevaVenta.MostrarDetalleVenta();
            gvCarrito.DataSource = dt;
            gvCarrito.DataBind();
        }

        protected void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            String Mensaje2 = "";
            String Mensaje3 = "";
            try
            {
                foreach (GridViewRow row in gvCarrito.Rows)
                {
                    objNuevaVenta.c_idProducto = Convert.ToInt32(row.Cells[0].Text);
                    objNuevaVenta.c_Cantidad = Convert.ToInt32(row.Cells[3].Text);
                    Mensaje2 = objNuevaVenta.DevolverStock();
                }
                Mensaje = objNuevaVenta.CancelarVenta();
                Mensaje3 = objNuevaVenta.TriggerCancelarVenta();
                Response.Redirect("NuevaVenta.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {

            lblComprado.Visible = true;
            lblTerminoCompra.Visible = true;
            btnFacturar.Visible = true;
            gvCarrito.Visible = true;

            String Mensaje = "";
            try
            {
                objNuevaVenta.c_idProducto = Convert.ToInt32(gvProductos.SelectedRow.Cells[1].Text);
                objNuevaVenta.c_PrecioVenta = Convert.ToDecimal(gvProductos.SelectedRow.Cells[6].Text);
                objNuevaVenta.c_Cantidad = Convert.ToDecimal(txtCantidad.Text);

                Mensaje = objNuevaVenta.NuevoDetalleVenta();
                lblMensaje.Text = Mensaje;
                LlenarGridCarrito();
                LlenarGridProductos();
                txtCantidad.Text = "";
                Mensaje = objNuevaVenta.actualizarTotal();
                txtTotal.Text = objNuevaVenta.MostrarTotalFactura().Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }

            txtAuditoria.Text = "";
            LlenarTxtAuditoria();
        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            String Mensaje2 = ""; 
            try
            {
                if (Convert.ToInt32(ddlTipoPago.SelectedValue.ToString()) == 1)
                {
                    if (Convert.ToDecimal(txtEfectivo.Text) < Convert.ToDecimal(txtTotal.Text))
                    {
                        lblDineroInsuficiente.Text = "Efectivo Insuficiente";
                    }
                    else
                    {                        
                        lblDineroInsuficiente.Text = "";
                        Mensaje = objNuevaVenta.actualizarTotal();
                        GenerarCodigoQR();
                        FacturaPDF();
                        Mensaje2 = objNuevaVenta.TriggerNuevaVenta();
                        Response.Redirect("NuevaVenta.aspx");
                    }
                }
                else
                {
                    Session["CierreCaja"] = Convert.ToString(Convert.ToDecimal(Session["CierreCaja"]) + Convert.ToDecimal(txtTotal.Text));
                    lblDineroInsuficiente.Text = "";
                    Mensaje = objNuevaVenta.actualizarTotal();
                    GenerarCodigoQR();
                    FacturaPDF();
                    Mensaje2 = objNuevaVenta.TriggerNuevaVenta();
                    Response.Redirect("NuevaVenta.aspx");
                }
                                   
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "") {
                LlenarGridProductos();
            }
            else
            {
                objNuevaVenta.c_Descripcion = txtBuscar.Text;
                DataTable dt = objNuevaVenta.buscarProducto();
                gvProductos.DataSource = dt;
                gvProductos.DataBind();
            }
            
        }

        public void GenerarCodigoQR()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(0, 5);
            objNuevaVenta.c_idPromocion = value;

            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            objNuevaVenta.c_idPromocion = value;
            qrEncoder.TryEncode(objNuevaVenta.MostrarPromocion().Rows[0][0].ToString(), out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400,QuietZoneModules.Zero),Brushes.Black,Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));

            imagen.Save("C:\\Users\\bryan\\Desktop\\ReportesFacturas\\Imagen.png", ImageFormat.Png);

        }

        public void FacturaPDF()
        {
            FileStream fs = new FileStream("C:\\Users\\bryan\\Desktop\\ReportesFacturas\\Factura.pdf",FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL,0,0,0,0);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfPTable Tabla = new PdfPTable(4);

            document.Add(new Paragraph("\n"));

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:\\Users\\bryan\\source\\repos\\DesarrolloWeb_PP\\CapaPresentacion\\Images\\FondoFactura.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 488 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            
            // Insertamos la imagen en el documento
            document.Add(imagen);
            document.Add(new Paragraph("\n"));

            Paragraph Factura = new Paragraph("Factura No. " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][0].ToString());
            Factura.Alignment = Element.ALIGN_CENTER;
            document.Add(Factura);
            Paragraph Direccion = new Paragraph("Dirección: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][1].ToString());
            Direccion.Alignment = Element.ALIGN_CENTER;
            document.Add(Direccion);
            Paragraph NIT = new Paragraph("NIT: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][2].ToString());
            NIT.Alignment = Element.ALIGN_CENTER;
            document.Add(NIT);
            Paragraph Cliente = new Paragraph("Cliente: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][3].ToString());
            Cliente.Alignment = Element.ALIGN_CENTER;
            document.Add(Cliente);
            Paragraph Cajero = new Paragraph("Cajero: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][4].ToString());
            Cajero.Alignment = Element.ALIGN_CENTER;
            document.Add(Cajero);
            Paragraph TipoPago = new Paragraph("Tipo de Pago: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][5].ToString());
            TipoPago.Alignment = Element.ALIGN_CENTER;
            document.Add(TipoPago);
            Paragraph Fecha = new Paragraph("Fecha: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][6].ToString());
            Fecha.Alignment = Element.ALIGN_CENTER;
            document.Add(Fecha);
            Paragraph Hora = new Paragraph("Hora: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][7].ToString());
            Hora.Alignment = Element.ALIGN_CENTER;
            document.Add(Hora);
            document.Add(new Paragraph("\n"));

            Tabla.AddCell(new Paragraph("Producto"));
            Tabla.AddCell(new Paragraph("Precio"));
            Tabla.AddCell(new Paragraph("Cantidad"));
            Tabla.AddCell(new Paragraph("Subtotal"));

            foreach (DataRow row in objNuevaVenta.MostrarDetalleVentaPDF().Rows)
            {
                Tabla.AddCell(new Paragraph(row[0].ToString()));
                Tabla.AddCell(new Paragraph(row[1].ToString()));
                Tabla.AddCell(new Paragraph(row[2].ToString()));
                Tabla.AddCell(new Paragraph(row[3].ToString()));
            }
            PdfPCell pcell = (new PdfPCell(new Phrase("Total: " + objNuevaVenta.MostrarEncabezadoVenta().Rows[0][8].ToString())) { Colspan = 4 });
            pcell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            Tabla.AddCell(pcell);

            if(ddlTipoPago.SelectedValue.ToString() == "1")
            {
                PdfPCell pcell2 = (new PdfPCell(new Phrase("Efectivo: " + txtEfectivo.Text)) { Colspan = 4 });
                pcell2.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                Tabla.AddCell(pcell2);

                PdfPCell pcell3 = (new PdfPCell(new Phrase("Cambio: " + txtCambio.Text)) { Colspan = 4 });
                pcell3.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                Tabla.AddCell(pcell3);
            }
            document.Add(Tabla);
            document.Add(new Paragraph("\n"));

            iTextSharp.text.Image imagenQR = iTextSharp.text.Image.GetInstance("C:\\Users\\bryan\\Desktop\\ReportesFacturas\\Imagen.png");
            imagenQR.BorderWidth = 0;
            imagenQR.Alignment = Element.ALIGN_CENTER;
            float percentageQR = 0.0f;
            percentage = 400 / imagen.Width;
            imagen.ScalePercent(percentageQR * 100);

            // Insertamos la imagen en el documento
            document.Add(imagenQR);
            document.Add(new Paragraph("\n"));

            Paragraph Gracias = new Paragraph("¡GRACIAS POR SU COMPRA!");
            Gracias.Alignment = Element.ALIGN_CENTER;
            document.Add(Gracias);

            document.Close();
        }

        protected void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            txtCambio.Text = "0.00";
            try
            {
                if(Convert.ToInt32(ddlTipoPago.SelectedValue.ToString()) == 1){
                    if (Convert.ToDecimal(txtEfectivo.Text) < Convert.ToDecimal(txtTotal.Text))
                    {
                        lblDineroInsuficiente.Text = "Efectivo Insuficiente";
                    }
                    else
                    {
                        txtCambio.Text = Convert.ToString(Convert.ToDecimal(txtEfectivo.Text) - Convert.ToDecimal(txtTotal.Text));
                        lblDineroInsuficiente.Text = "";
                    }
                }
                
            }
            catch (Exception ex)
            {

                Response.Write("Error: " + ex);
            }
        }
    }
}