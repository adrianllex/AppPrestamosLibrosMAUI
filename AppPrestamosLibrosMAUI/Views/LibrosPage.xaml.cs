using AppPrestamosLibrosMAUI.Models;
using AppPrestamosLibrosMAUI.Services;

namespace AppPrestamosLibrosMAUI.Views;

public partial class LibrosPage : ContentPage
{
    private readonly DatabaseService _db;

    // ? Constructor con inyección de dependencia
    public LibrosPage(DatabaseService dbService)
    {
        InitializeComponent();
        _db = dbService;
    }

    // ? Evento del botón para guardar el libro
    private async void OnGuardarLibroClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tituloEntry.Text) ||
            string.IsNullOrWhiteSpace(autorEntry.Text) ||
            string.IsNullOrWhiteSpace(stockEntry.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            return;
        }

        var libro = new Libro
        {
            Titulo = tituloEntry.Text,
            Autor = autorEntry.Text,
            Stock = int.Parse(stockEntry.Text)
        };

        await _db.SaveLibroAsync(libro);
        await DisplayAlert("Éxito", "Libro guardado", "OK");

        // Limpiar campos
        tituloEntry.Text = "";
        autorEntry.Text = "";
        stockEntry.Text = "";
    }
}
