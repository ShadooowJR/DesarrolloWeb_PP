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

namespace CapaPresentacion
{
    public partial class Devoluciones : System.Web.UI.Page
    {
        ClsDevolucion objDevolucion = new ClsDevolucion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtAuditoria.Text = "";
                LlenarTxtAuditoria();
            }
        }

        protected void txt_idFactura_TextChanged(object sender, EventArgs e)
        {
            txtNit.Text = " ";
            txtNombreCliente.Text = " ";
            txtCajero.Text = " ";
            txtTipoPago.Text = " ";
            txtFecha.Text = " ";
            txtHora.Text = " ";
            txtTotal.Text = " ";
            txtCantidad.Enabled = false;
            txtDescripcion.Enabled = false;
            btnDevolver.Enabled = false;
            LlenarEncabezado();
            LlenarGridDetalle();
            LlenarGridDevoluciones();
        }

        private void LlenarGridDetalle()
        {
            try {
                objDevolucion.c_idFactura = Convert.ToInt32(txt_idFactura.Text);
                DataTable dt = objDevolucion.MostrarDetalleFactura();
                gvDetalleFactura.DataSource = dt;
                gvDetalleFactura.DataBind();
            } catch (Exception ex) {}                                   
        }

        private void LlenarGridDevoluciones()
        {
            try
            {
                objDevolucion.c_idFactura = Convert.ToInt32(txt_idFactura.Text);
                DataTable dt = objDevolucion.MostrarDetalleDevoluciones();
                gvDevoluciones.DataSource = dt;
                gvDevoluciones.DataBind();
            }
            catch (Exception ex) { }
        }

        private void LlenarTxtAuditoria()
        {
            txtAuditoria.Text += "-MONITOR DE OPERACIONES-\r\n";
            foreach (DataRow row in objDevolucion.MostrarAuditoria().Rows)
            {
                txtAuditoria.Text += row[1].ToString() + " " + row[2].ToString() + "\r\n";
            }
        }

        private void LlenarEncabezado()
        {
            try {
                objDevolucion.c_idFactura = Convert.ToInt32(txt_idFactura.Text);
                txtNit.Text = " " + objDevolucion.MostrarEncabezado().Rows[0][2].ToString();
                txtNombreCliente.Text = " " + objDevolucion.MostrarEncabezado().Rows[0][3].ToString();
                txtCajero.Text = " " + objDevolucion.MostrarEncabezado().Rows[0][4].ToString();
                txtTipoPago.Text = " " + objDevolucion.MostrarEncabezado().Rows[0][5].ToString();
                txtFecha.Text = " " + objDevolucion.MostrarEncabezado().Rows[0][6].ToString();
                txtHora.Text = " " + objDevolucion.MostrarEncabezado().Rows[0][7].ToString();
                txtTotal.Text = " " + objDevolucion.MostrarEncabezado().Rows[0][8].ToString();

                txtCantidad.Enabled = true;
                txtDescripcion.Enabled = true;
                btnDevolver.Enabled = true;

            } catch (Exception ex) { }            
        }
                
        protected void btnDevolver_Click(object sender, EventArgs e)
        {
            String Mensaje = "";
            lblCantidadDevolver.Text = " ";
            txt_idFactura.Enabled = false;
            try
            {
                if (Convert.ToDecimal(txtCantidad.Text) > Convert.ToDecimal(gvDetalleFactura.SelectedRow.Cells[5].Text))
                {
                    lblCantidadDevolver.Text = "VERIFIQUE LA CANTIDAD";
                }
                else
                {
                    objDevolucion.c_NIT = txtNit.Text;
                    objDevolucion.c_Descripcion = txtDescripcion.Text;
                    objDevolucion.c_Cantidad = Convert.ToDecimal(txtCantidad.Text);
                    objDevolucion.c_Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    objDevolucion.c_Hora = DateTime.Now.ToString("HH:mm:ss");
                    objDevolucion.c_idDFactura = Convert.ToInt32(gvDetalleFactura.SelectedRow.Cells[1].Text);
                    objDevolucion.c_idFactura = Convert.ToInt32(txt_idFactura.Text);
                    objDevolucion.c_idProducto = Convert.ToInt32(gvDetalleFactura.SelectedRow.Cells[2].Text);
                    objDevolucion.c_idCajero = Convert.ToInt32(Session["id"]);

                    Mensaje = objDevolucion.NuevaDevolucion();

                    LlenarGridDevoluciones();
                    LlenarEncabezado();
                    LlenarGridDetalle();
                    btnFacturar.Enabled = true;
                }

            }
            catch (Exception ex) { }

            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            txtAuditoria.Text = "";
            LlenarTxtAuditoria();
        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            FacturaPDF();
            Response.Redirect("Inicio.aspx");
        }

        public void FacturaPDF()
        {
            FileStream fs = new FileStream("C:\\Users\\bryan\\Desktop\\ReportesFacturas\\Factura.pdf", FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL, 0, 0, 0, 0);
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

            objDevolucion.c_idFactura = Convert.ToInt32(txt_idFactura.Text);

            Paragraph Factura = new Paragraph("Factura No. " + objDevolucion.MostrarEncabezado().Rows[0][0].ToString());
            Factura.Alignment = Element.ALIGN_CENTER;
            document.Add(Factura);
            Paragraph Direccion = new Paragraph("Dirección: " + objDevolucion.MostrarEncabezado().Rows[0][1].ToString());
            Direccion.Alignment = Element.ALIGN_CENTER;
            document.Add(Direccion);
            Paragraph NIT = new Paragraph("NIT: " + objDevolucion.MostrarEncabezado().Rows[0][2].ToString());
            NIT.Alignment = Element.ALIGN_CENTER;
            document.Add(NIT);
            Paragraph Cliente = new Paragraph("Cliente: " + objDevolucion.MostrarEncabezado().Rows[0][3].ToString());
            Cliente.Alignment = Element.ALIGN_CENTER;
            document.Add(Cliente);
            Paragraph Cajero = new Paragraph("Cajero: " + objDevolucion.MostrarEncabezado().Rows[0][4].ToString());
            Cajero.Alignment = Element.ALIGN_CENTER;
            document.Add(Cajero);
            Paragraph TipoPago = new Paragraph("Tipo de Pago: " + objDevolucion.MostrarEncabezado().Rows[0][5].ToString());
            TipoPago.Alignment = Element.ALIGN_CENTER;
            document.Add(TipoPago);
            Paragraph Fecha = new Paragraph("Fecha: " + objDevolucion.MostrarEncabezado().Rows[0][6].ToString());
            Fecha.Alignment = Element.ALIGN_CENTER;
            document.Add(Fecha);
            Paragraph Hora = new Paragraph("Hora: " + objDevolucion.MostrarEncabezado().Rows[0][7].ToString());
            Hora.Alignment = Element.ALIGN_CENTER;
            document.Add(Hora);
            document.Add(new Paragraph("\n"));

            Tabla.AddCell(new Paragraph("Producto"));
            Tabla.AddCell(new Paragraph("Precio"));
            Tabla.AddCell(new Paragraph("Cantidad"));
            Tabla.AddCell(new Paragraph("Subtotal"));

            foreach (DataRow row in objDevolucion.MostrarDetalleFacturaPDF().Rows)
            {
                Tabla.AddCell(new Paragraph(row[0].ToString()));
                Tabla.AddCell(new Paragraph(row[1].ToString()));
                Tabla.AddCell(new Paragraph(row[2].ToString()));
                Tabla.AddCell(new Paragraph(row[3].ToString()));
            }
            PdfPCell pcell = (new PdfPCell(new Phrase("Total: " + objDevolucion.MostrarEncabezado().Rows[0][8].ToString())) { Colspan = 4 });
            pcell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            Tabla.AddCell(pcell);
            document.Add(Tabla);
            
            document.Add(new Paragraph("\n"));

            Paragraph Gracias = new Paragraph("¡GRACIAS POR SU COMPRA!");
            Gracias.Alignment = Element.ALIGN_CENTER;
            document.Add(Gracias);

            document.Close();
        }
    }
}