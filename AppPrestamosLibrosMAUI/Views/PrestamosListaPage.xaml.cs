using AppPrestamosLibrosMAUI.Models;
using AppPrestamosLibrosMAUI.Services;
using System.Linq;

namespace AppPrestamosLibrosMAUI.Views;

public partial class PrestamosListaPage : ContentPage
{
    private readonly DatabaseService _db;

    public PrestamosListaPage(DatabaseService dbService)
    {
        InitializeComponent();
        _db = dbService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Cargar solo los pr�stamos que no han sido devueltos
        var prestamos = await _db.GetPrestamosAsync();
        var prestamosNoDevueltos = prestamos.Where(p => p.FechaDevolucion == null).ToList();

        prestamosCollectionView.ItemsSource = prestamosNoDevueltos;
    }

    private async void OnMarcarComoDevueltoClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Prestamo prestamo)
        {
            if (prestamo.FechaDevolucion != null)
            {
                await DisplayAlert("Aviso", "Este pr�stamo ya fue devuelto.", "OK");
                return;
            }

            prestamo.FechaDevolucion = DateTime.Now;
            await _db.SavePrestamoAsync(prestamo);

            await DisplayAlert("�xito", "Pr�stamo marcado como devuelto.", "OK");

            // Recargar solo los pr�stamos no devueltos
            var prestamosActualizados = await _db.GetPrestamosAsync();
            var prestamosNoDevueltos = prestamosActualizados.Where(p => p.FechaDevolucion == null).ToList();

            prestamosCollectionView.ItemsSource = prestamosNoDevueltos; // Actualizar lista
        }
    }

    // Evento para alternar entre ver todos los pr�stamos y los no devueltos
    private async void OnFiltrarTodosClicked(object sender, EventArgs e)
    {
        var prestamos = await _db.GetPrestamosAsync();

        // Alternar entre todos los pr�stamos y los no devueltos
        var prestamosNoDevueltos = prestamos.Where(p => p.FechaDevolucion == null).ToList();

        // Verificar si ya se est� mostrando solo los no devueltos, si no, mostrar todos
        if (prestamosCollectionView.ItemsSource == prestamosNoDevueltos)
        {
            prestamosCollectionView.ItemsSource = prestamos; // Mostrar todos los pr�stamos
            ((Button)sender).Text = "Ver Solo No Devueltos"; // Cambiar texto del bot�n
        }
        else
        {
            prestamosCollectionView.ItemsSource = prestamosNoDevueltos; // Mostrar solo los no devueltos
            ((Button)sender).Text = "Ver Todos los Pr�stamos"; // Cambiar texto del bot�n
        }
    }
}

