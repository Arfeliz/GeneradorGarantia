using System.Windows;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GeneradorCartasGarantia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Configuración de licencia obligatoria
        QuestPDF.Settings.License = LicenseType.Community;
    }

    private void BtnCliente_Click(object sender, RoutedEventArgs e)
{
    var formulario = new FormularioCliente();
        formulario.Owner = this;
        formulario.ShowDialog();
}

    private void BtnTienda_Click(object sender, RoutedEventArgs e)
    {
        var formulario = new FormularioTienda();
        formulario.Owner = this;
        formulario.ShowDialog();
    }

   
    
}
public class GarantiaData
{
    // Datos de cabecera y cuerpo
    public string Taller { get; set; } = "";
    public string NombreCliente { get; set; } = "";
    public string Cedula { get; set; } = "";
    public string FechaCompra { get; set; } = "";
    public string TipoArticulo { get; set; } = "";
    public string TiempoGarantia { get; set; } = "";
    public string Observaciones { get; set; } = "";
    
    // Datos de la tabla
    public string Material { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public string Modelo { get; set; } = "";
    public string Marca { get; set; } = "";
    public string Precio { get; set; } = "";
    public string Serie { get; set; } = "";
    public string Ticket { get; set; } = "";
    
    // Pie
    public string Firma { get; set; } = "";
}