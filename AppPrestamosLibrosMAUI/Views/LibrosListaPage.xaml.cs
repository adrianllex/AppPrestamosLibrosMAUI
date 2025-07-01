using AppPrestamosLibrosMAUI.Models;
using AppPrestamosLibrosMAUI.Services;

namespace AppPrestamosLibrosMAUI.Views;

public partial class LibrosListaPage : ContentPage
{
    private readonly DatabaseService _db;

    public LibrosListaPage(DatabaseService dbService)
    {
        InitializeComponent();
        _db = dbService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var libros = await _db.GetLibrosAsync();
        librosCollectionView.ItemsSource = libros;
    }
}
