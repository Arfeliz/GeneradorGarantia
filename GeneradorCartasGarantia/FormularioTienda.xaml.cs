using System.Windows;

namespace GeneradorCartasGarantia
{
    // El nombre 'FormularioTienda' debe ser igual al x:Class del XAML
    public partial class FormularioTienda : Window
    {
        public FormularioTienda()
        {
            InitializeComponent();
        }

        private void BtnGenerar_Click(object sender, RoutedEventArgs e)
        {
            // Creamos el objeto con los datos capturados
            var data = new GarantiaData
            {
                Taller = txtTaller.Text,
                Material = txtMaterial.Text,
                Marca = txtMarca.Text,
                Descripcion = txtDescripcion.Text,
                Modelo = txtModelo.Text,
                Serie = txtSerie.Text,
                Observaciones = txtObservaciones.Text,
                Firma = txtFirma.Text
            };

            // Llamamos al método específico para Tienda
            PdfService.GenerarPdfTienda(data);
            
            this.Close();
        }
    }
}