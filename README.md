# 📄 Generador de Cartas de Garantía - Jumbo

¡Bienvenido! Este es un software de escritorio ligero y profesional diseñado para la gestión y generación automatizada de cartas de garantía en formato PDF. Ideal para centros de servicios y tiendas de electrodomésticos.

**Realizado por: Arlinton Feliz** 🚀

## 🌟 Características Principales

- **Doble Modalidad de Proceso**: 
  - 📦 **Garantía Cliente**: Formulario detallado (14 campos) que incluye datos personales, información de compra y ticket para un documento formal.
  - 🏢 **Garantía Tienda**: Formulario optimizado para procesos internos de stock y destinatarios de taller.
- **Motor de PDF Moderno**: Utiliza **QuestPDF** para generar documentos con un layout profesional, incluyendo logotipos, tablas alineadas y firmas.
- **Interfaz Intuitiva**: Desarrollada en **WPF** con una experiencia de usuario limpia, validaciones de campos y placeholders.
- **Portable**: Capacidad de generar un único archivo ejecutable (`.exe`) sin dependencias externas.
- **Guardado Personalizado**: Ventana de diálogo para elegir la ruta y nombre del archivo PDF generado.

## 🛠️ Tecnologías Utilizadas

- **Lenguaje**: C#
- **Framework**: .NET 8.0 / 9.0 (WPF)
- **Librería PDF**: [QuestPDF](https://www.questpdf.com/) (Community License)
- **IDE**: VS Code / Visual Studio

## 🚀 Instalación y Ejecución (Desarrollo)

Si deseas clonar y ejecutar este proyecto localmente:

1. **Clonar el repositorio**:
   ```bash
   git clone [https://github.com/Arfeliz/GeneradorCartasGarantia.git](https://github.com/Arfeliz/GeneradorCartasGarantia.git)


2.Restaurar dependencias:
    dotnet restore

3.Ejecutar la aplicación:
    dotnet run
