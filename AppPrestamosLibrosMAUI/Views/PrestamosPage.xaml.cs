using AppPrestamosLibrosMAUI.Models;
using AppPrestamosLibrosMAUI.Services;

namespace AppPrestamosLibrosMAUI.Views;

public partial class PrestamosPage : ContentPage
{
    private readonly DatabaseService _db;

    public PrestamosPage(DatabaseService dbService)
    {
        InitializeComponent();
        _db = dbService;
    }

    private async void OnGuardarPrestamoClicked(object sender, EventArgs e)
    {
        // Validar selecci�n
        if (libroPicker.SelectedIndex == -1 || usuarioPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Selecciona un libro y un usuario", "OK");
            return;
        }

        // Crear pr�stamo
        var prestamo = new Prestamo
        {
            LibroId = ((Libro)libroPicker.SelectedItem!).Id,
            UsuarioId = ((Usuario)usuarioPicker.SelectedItem!).Id,
            FechaPrestamo = fechaPicker.Date
        };

        // Guardar en BD
        await _db.SavePrestamoAsync(prestamo);
        await DisplayAlert("�xito", "Pr�stamo guardado", "OK");

        // Limpiar selecci�n
        libroPicker.SelectedIndex = -1;
        usuarioPicker.SelectedIndex = -1;
        fechaPicker.Date = DateTime.Today;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        libroPicker.ItemsSource = await _db.GetLibrosAsync();
        usuarioPicker.ItemsSource = await _db.GetUsuariosAsync();
    }
}
