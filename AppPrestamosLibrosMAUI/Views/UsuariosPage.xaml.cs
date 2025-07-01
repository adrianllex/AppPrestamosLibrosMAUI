using AppPrestamosLibrosMAUI.Models;
using AppPrestamosLibrosMAUI.Services;

namespace AppPrestamosLibrosMAUI.Views;

public partial class UsuariosPage : ContentPage
{
    private readonly DatabaseService _db;

    public UsuariosPage(DatabaseService dbService)
    {
        InitializeComponent();
        _db = dbService;

        // Cargar elementos del Picker desde aquí, sin usar x:Array
        tipoPicker.ItemsSource = new List<string> { "Alumno", "Docente" };
    }

    private async void OnGuardarUsuarioClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nombreEntry.Text) || tipoPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        var usuario = new Usuario
        {
            Nombre = nombreEntry.Text,
            Tipo = tipoPicker.SelectedItem!.ToString()  // El ! evita la advertencia CS8601
        };

        await _db.SaveUsuarioAsync(usuario);
        await DisplayAlert("Éxito", "Usuario guardado correctamente", "OK");

        // Limpiar campos
        nombreEntry.Text = "";
        tipoPicker.SelectedIndex = -1;
    }
}
