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
    public partial class ReporteDevoluciones : System.Web.UI.Page
    {
        ClsReportes objReportes = new ClsReportes();   
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            ReporteDevolucionesPDF();
            Response.Redirect("Inicio.aspx");
        }

        public void ReporteDevolucionesPDF()
        {
            FileStream fs = new FileStream("C:\\Users\\bryan\\Desktop\\ReportesFacturas\\ReporteDevoluciones.pdf", FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL.Rotate(), 0, 0, 0, 0);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfPTable Tabla = new PdfPTable(9);

            document.Add(new Paragraph("\n"));

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:\\Users\\bryan\\source\\repos\\DesarrolloWeb_PP\\CapaPresentacion\\Images\\FondoFactura.png");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 795 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            document.Add(imagen);
            document.Add(new Paragraph("\n"));

            Paragraph Encabezado = new Paragraph("REPORTE DE DEVOLUCIONES "+txtFechaInicio.Text+" AL "+txtFechaFinal.Text);
            Encabezado.Alignment = Element.ALIGN_CENTER;
            document.Add(Encabezado);

            document.Add(new Paragraph("\n"));

            Tabla.AddCell(new Paragraph("Factura"));
            Tabla.AddCell(new Paragraph("Cajero"));
            Tabla.AddCell(new Paragraph("NIT Cliente"));
            Tabla.AddCell(new Paragraph("Cliente"));
            Tabla.AddCell(new Paragraph("Producto"));
            Tabla.AddCell(new Paragraph("Motivo Devolucion"));
            Tabla.AddCell(new Paragraph("Cantidad Devuelta"));
            Tabla.AddCell(new Paragraph("Fecha Devolucion"));
            Tabla.AddCell(new Paragraph("Hora Devolucion"));

            objReportes.c_FechaInicio = txtFechaInicio.Text;
            objReportes.c_FechaFinal = txtFechaFinal.Text;

            foreach (DataRow row in objReportes.ReporteDevoluciones().Rows)
            {
                Tabla.AddCell(new Paragraph(row[0].ToString()));
                Tabla.AddCell(new Paragraph(row[1].ToString()));
                Tabla.AddCell(new Paragraph(row[2].ToString()));
                Tabla.AddCell(new Paragraph(row[3].ToString()));
                Tabla.AddCell(new Paragraph(row[4].ToString()));
                Tabla.AddCell(new Paragraph(row[5].ToString()));
                Tabla.AddCell(new Paragraph(row[6].ToString()));
                Tabla.AddCell(new Paragraph(row[7].ToString()));
                Tabla.AddCell(new Paragraph(row[8].ToString()));
            }

            document.Add(Tabla);
            document.Add(new Paragraph("\n"));

            Paragraph Gracias = new Paragraph("- FIN DEL REPORTE -");
            Gracias.Alignment = Element.ALIGN_CENTER;
            document.Add(Gracias);

            document.Close();
        }
    }
}