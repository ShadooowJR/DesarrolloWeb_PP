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
    public partial class ReporteClientes : System.Web.UI.Page
    {
        ClsReportes objReportes = new ClsReportes();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            ReporteClientesPDF();
            Response.Redirect("Inicio.aspx");
        }

        public void ReporteClientesPDF()
        {
            FileStream fs = new FileStream("C:\\Users\\bryan\\Desktop\\ReportesFacturas\\ReporteClientes.pdf", FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL.Rotate(), 0, 0, 0, 0);
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfPTable Tabla = new PdfPTable(10);

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

            Paragraph Encabezado = new Paragraph("- REPORTE DE CLIENTES -");
            Encabezado.Alignment = Element.ALIGN_CENTER;
            document.Add(Encabezado);

            document.Add(new Paragraph("\n"));

            Tabla.AddCell(new Paragraph("ID Cliente"));
            Tabla.AddCell(new Paragraph("NIT"));
            Tabla.AddCell(new Paragraph("Nombre"));
            Tabla.AddCell(new Paragraph("DPI"));
            Tabla.AddCell(new Paragraph("Email"));
            Tabla.AddCell(new Paragraph("Teléfono"));            
            Tabla.AddCell(new Paragraph("Dirección"));
            Tabla.AddCell(new Paragraph("Municipio"));
            Tabla.AddCell(new Paragraph("Departamento"));
            Tabla.AddCell(new Paragraph("País"));

            foreach (DataRow row in objReportes.ReporteClientes().Rows)
            {
                Tabla.AddCell(new Paragraph(row[0].ToString()));
                Tabla.AddCell(new Paragraph(row[1].ToString()));
                Tabla.AddCell(new Paragraph(row[2].ToString()));
                Tabla.AddCell(new Paragraph(row[3].ToString()));
                Tabla.AddCell(new Paragraph(row[6].ToString()));
                Tabla.AddCell(new Paragraph(row[5].ToString()));
                Tabla.AddCell(new Paragraph(row[4].ToString()));
                Tabla.AddCell(new Paragraph(row[7].ToString()));
                Tabla.AddCell(new Paragraph(row[8].ToString()));
                Tabla.AddCell(new Paragraph(row[9].ToString()));
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