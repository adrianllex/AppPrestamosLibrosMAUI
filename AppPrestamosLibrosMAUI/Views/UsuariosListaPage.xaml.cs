using AppPrestamosLibrosMAUI.Models;
using AppPrestamosLibrosMAUI.Services;

namespace AppPrestamosLibrosMAUI.Views;

public partial class UsuariosListaPage : ContentPage
{
    private readonly DatabaseService _db;

    public UsuariosListaPage(DatabaseService dbService)
    {
        InitializeComponent();
        _db = dbService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var usuarios = await _db.GetUsuariosAsync();
        usuariosCollectionView.ItemsSource = usuarios;
    }
}
