using System;
using System.Windows;
using GeneradorCartasGarantia; // Asegura que este namespace coincida con tu proyecto

namespace GeneradorCartasGarantia
{
    /// <summary>
    /// Lógica de interacción para FormularioCliente.xaml
    /// </summary>
    public partial class FormularioCliente : Window
    {
        public FormularioCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón de generar
        /// </summary>
        private void BtnGenerar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validación de campos obligatorios (Clean Code)
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtSerie.Text))
            {
                MessageBox.Show("Por favor, rellene al menos el nombre del cliente y la serie del producto.", 
                                "Campos Faltantes", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // 2. Mapeo de datos desde la UI al Modelo Único
                GarantiaData datos = new GarantiaData
                {
                    Taller = txtTaller.Text,
                    NombreCliente = txtNombre.Text,
                    Cedula = txtCedula.Text,
                    // Si usas DatePicker se usa SelectedDate, si es TextBox se usa .Text
                    FechaCompra = txtFechaCompra.Text, 
                    TipoArticulo = txtTipoArticulo.Text,
                    TiempoGarantia = txtTiempoGarantia.Text,
                    Material = txtMaterial.Text,
                    Descripcion = txtDescripcion.Text,
                    Modelo = txtModelo.Text,
                    Marca = txtMarca.Text,
                    Precio = txtPrecio.Text,
                    Serie = txtSerie.Text,
                    Ticket = txtTicket.Text,
                    Firma = txtFirma.Text,
                    Observaciones = "Generado desde Formulario de Cliente"
                };

                // 3. Invocación del servicio de generación de PDF
                // Nota: Usamos GenerarPdfCliente que es el que tiene el formato de cliente
                PdfService.GenerarPdfCliente(datos);

                // 4. Feedback al usuario y cierre
                MessageBox.Show($"Documento para {datos.NombreCliente} procesado correctamente.", 
                                "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF: {ex.Message}", 
                                "Error Crítico", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Opcional: Botón para cancelar y cerrar la ventana
        /// </summary>
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}