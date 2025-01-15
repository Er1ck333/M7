using iText.Layout.Element;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Event;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace UF2_PAC1F
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Obtener los datos
            var productos = Producto.ObtenerDatosSimulados();

            // Filtrar los productos con precio > 10
            var productosFiltrados = productos.Where(p => p.Precio > 10).ToList();

            // Asignar los datos al DataGridView
            dataGridView1.DataSource = productosFiltrados;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta donde se guardar� el archivo PDF
                string rutaArchivo = @"E:\InformeProductos.pdf";

                // Crear un documento PDF
                using (var writer = new PdfWriter(rutaArchivo))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        // T�tulo del informe
                        document.Add(new Paragraph("Informe de productos").SetFontSize(16));

                        // Fecha del informe
                        document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy")));

                        // Tabla
                        var tabla = new Table(3);
                        tabla.AddHeaderCell("Nombre");
                        tabla.AddHeaderCell("Categor�a");
                        tabla.AddHeaderCell("Precio");

                        // Agregar los datos
                        var productos = dataGridView1.DataSource as List<Producto>;
                        foreach (var producto in productos)
                        {
                            tabla.AddCell(producto.Nombre);
                            tabla.AddCell(producto.Categoria);
                            tabla.AddCell(producto.Precio.ToString("C"));
                        }

                        document.Add(tabla);

                        // Agregar el pie de p�gina
                        AgregarPieDePagina(pdf);
                    }
                }

                MessageBox.Show("Informe exportado correctamente en: " + rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar PDF: " + ex.Message);
            }

        }
        private void AgregarPieDePagina(PdfDocument pdf)
        {
            // Crear una fuente
            var fuente = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                PdfPage page = pdf.GetPage(i);
                PdfCanvas canvas = new PdfCanvas(page);

                // Texto del pie de p�gina
                string textoPie = "Generado autom�ticamente";
                string numeroPagina = "P�gina " + i;

                // Establecer posici�n del pie de p�gina
                float x = page.GetPageSize().GetWidth() / 2;
                float y = 20;

                // Dibujar el texto del pie de p�gina
                canvas.BeginText()
                      .SetFontAndSize(fuente, 10)  // Usa la fuente creada
                      .MoveText(x - 90, y)         // Ajusta la posici�n del texto
                      .ShowText(textoPie)
                      .MoveText(140, 0)            // Mueve para mostrar el n�mero de p�gina
                      .ShowText(numeroPagina)
                      .EndText();

                canvas.Release();
            }
        }

    }
}
