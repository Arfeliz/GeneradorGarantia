using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Microsoft.Win32; // Necesario para el SaveFileDialog

namespace GeneradorCartasGarantia;

// Aseguramos que la clase esté en el namespace correcto para evitar el error de la foto


public static class PdfService
{
    public static void GenerarPdfTienda(GarantiaData data)
    {
        // 1. Configurar el cuadro de diálogo para guardar
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Archivo PDF (*.pdf)|*.pdf",
            FileName = $"Garantia_{data.Serie}.pdf",
            Title = "Seleccione dónde guardar la carta de garantía"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            string filePath = saveFileDialog.FileName;

            // 2. Crear el documento
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(1, Unit.Inch);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.Verdana));

                    // ENCABEZADO: Logo y Fecha
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col => 
                        {
                            // Cargamos el logo que subiste
                            if (System.IO.File.Exists("logo_jumbo.png"))
                                col.Item().Width(150).Image("logo_jumbo.png");
                            else
                                col.Item().Text("JUMBO").FontSize(24).Bold().FontColor(Colors.Red.Medium);
                            
                        });

                        row.RelativeItem().AlignRight().Column(col => 
                        {
                            col.Item().Text("Santo Domingo, Rep. Dom.");
                            col.Item().Text(DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy"));
                        });
                    });

                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        col.Item().PaddingTop(10).Text("Sres.");
                        col.Item().Text(data.Taller.ToUpper()).Bold();
                        col.Item().PaddingLeft(20).Text("Asunto: CARTA DE GARANTIA");
                        col.Item().PaddingLeft(20).Text("Sus manos:");

                        col.Item().PaddingVertical(15).Text(text => {
                            text.Span("Nos dirigimos a ustedes para dar constancia de que el articulo descrito a continuación pertenecen a la tienda ");
                            text.Span("JUMBO LUPERON.").Bold();
                        });

                        // TABLA DE DATOS ESTILO JUMBO
                        col.Item().Table(table => {
                            table.ColumnsDefinition(columns => {
                                columns.ConstantColumn(120);
                                columns.ConstantColumn(20);
                                columns.RelativeColumn();
                            });

                            AddRow(table, "MATERIAL", data.Material);
                            AddRow(table, "DESCRIPCION", data.Descripcion);
                            AddRow(table, "MODELO", data.Modelo);
                            AddRow(table, "MARCA", data.Marca);
                            AddRow(table, "SERIE", data.Serie);
                        });

                        col.Item().PaddingVertical(15).Text(text => {
                            text.Span("Se emite como constancia para Servicio de Garantía, en el centro de servicios de ");
                            text.Span($"{data.Taller.ToUpper()}.").Bold();
                        });

                        col.Item().Text($"Observación: {data.Observaciones}").Italic();
                        col.Item().PaddingTop(15).Text("Gracias,");

                        // FIRMA (Igual a la imagen)
                        col.Item().PaddingTop(60).Column(f => {
                            f.Item().Width(250).BorderBottom(1).PaddingBottom(5);
                            f.Item().Text(data.Firma).Bold();
                            f.Item().Text("Departamento de Electrodomésticos");
                            f.Item().Text("Jumbo Luperón (806)");
                            f.Item().Text("Tel. 809-333-1111 EXT.3520").FontSize(9);
                        });
                    });
                });
            }).GeneratePdf(filePath);
        }
    }

    
    public static void GenerarPdfCliente(GarantiaData data)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "Archivo PDF (*.pdf)|*.pdf",
            FileName = $"Garantia_{data.NombreCliente.Replace(" ", "_")}.pdf"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(1, Unit.Inch);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.Verdana));

                    // 1. ENCABEZADO
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col => 
                        {
                            // Cargamos el logo que subiste
                            if (System.IO.File.Exists("logo_jumbo.png"))
                                col.Item().Width(150).Image("logo_jumbo.png");
                            else
                                col.Item().Text("JUMBO").FontSize(24).Bold().FontColor(Colors.Red.Medium);
                        });

                        row.RelativeItem().AlignRight().Column(col => 
                        {
                            col.Item().Text("Santo Domingo, Rep. Dom.");
                            col.Item().Text(DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy"));
                        });
                    });

                    // 2. CUERPO
                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        col.Item().PaddingTop(10).Text("Sres.");
                        col.Item().Text(data.Taller.ToUpper()).Bold();
                        col.Item().PaddingLeft(20).Text("Asunto: CARTA-GARANTIA");
                        col.Item().PaddingLeft(20).Text("Sus manos:");

                        col.Item().PaddingVertical(15).Text(text => {
                            text.Span("Nos dirijimos a ustedes para dar constancia de que el Sr, ");
                            text.Span($"{data.NombreCliente} ").Bold();
                            text.Span($"ced. {data.Cedula} ").Bold();
                            text.Span($"compró el {data.FechaCompra} ");
                            text.Span($"{data.TipoArticulo} ").Bold();
                            text.Span("en nuestra tienda Jumbo Luperon, con una Garantía de ");
                            text.Span($"{data.TiempoGarantia}.");
                        });

                        // 3. TABLA DE DATOS TÉCNICOS
                        col.Item().Table(table => {
                            table.ColumnsDefinition(columns => {
                                columns.ConstantColumn(100);
                                columns.ConstantColumn(20);
                                columns.RelativeColumn();
                            });

                            void AddRow(string label, string value) {
                                table.Cell().PaddingVertical(1).Text(label).Bold();
                                table.Cell().PaddingVertical(1).Text(":");
                                table.Cell().PaddingVertical(1).Text(value);
                            }

                            AddRow("MATERIAL", data.Material);
                            AddRow("DESCRIPCION", data.Descripcion);
                            AddRow("MODELO", data.Modelo);
                            AddRow("MARCA", data.Marca);
                            AddRow("PRECIO", data.Precio);
                            AddRow("SERIE", data.Serie);
                            AddRow("TICKET", data.Ticket);
                        });

                        col.Item().PaddingVertical(15).Text(text => {
                            text.Span("Se emite como constancia para Servicio de Garantía, en el centro de servicios ");
                            text.Span($"{data.Taller.ToUpper()}.").Bold();
                        });

                        col.Item().PaddingTop(20).Text("Quedo a su orden,");

                        // 4. FIRMA Y SELLO
                        col.Item().PaddingTop(50).Row(row => {
                            row.RelativeItem().Column(f => {
                                f.Item().Width(180).BorderBottom(1).PaddingBottom(5);
                                f.Item().Text(data.Firma).Bold();
                                f.Item().Text("Electrodomesticos 806");
                                f.Item().Text("Jumbo Luperón");
                                f.Item().Text("Tel. 809-333-2111");
                                f.Item().Text("Ext. 3501 & 3520");
                            });
                            
                        });
                    });
                });
            }).GeneratePdf(saveFileDialog.FileName);
        }
    }
    
    private static void AddRow(TableDescriptor table, string label, string value)
    {
        table.Cell().PaddingVertical(2).Text(label).Bold();
        table.Cell().PaddingVertical(2).Text(":");
        table.Cell().PaddingVertical(2).Text(value);
    }
}