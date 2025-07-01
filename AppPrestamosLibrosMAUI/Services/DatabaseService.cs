using SQLite;
using AppPrestamosLibrosMAUI.Models;

namespace AppPrestamosLibrosMAUI.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            // Crear tablas si no existen
            _db.CreateTableAsync<Libro>().Wait();
            _db.CreateTableAsync<Usuario>().Wait();
            _db.CreateTableAsync<Prestamo>().Wait();
        }

        // 📚 MÉTODOS PARA LIBROS
        public Task<List<Libro>> GetLibrosAsync() => _db.Table<Libro>().ToListAsync();
        public Task<int> SaveLibroAsync(Libro libro) => _db.InsertOrReplaceAsync(libro);
        public Task<int> DeleteLibroAsync(Libro libro) => _db.DeleteAsync(libro);

        // 👤 MÉTODOS PARA USUARIOS
        public Task<List<Usuario>> GetUsuariosAsync() => _db.Table<Usuario>().ToListAsync();
        public Task<int> SaveUsuarioAsync(Usuario usuario) => _db.InsertOrReplaceAsync(usuario);
        public Task<int> DeleteUsuarioAsync(Usuario usuario) => _db.DeleteAsync(usuario);

        // 🔁 MÉTODOS PARA PRÉSTAMOS
        public Task<List<Prestamo>> GetPrestamosAsync() => _db.Table<Prestamo>().ToListAsync();
        public Task<int> SavePrestamoAsync(Prestamo prestamo) => _db.InsertOrReplaceAsync(prestamo);
        public Task<int> DeletePrestamoAsync(Prestamo prestamo) => _db.DeleteAsync(prestamo);
    }
}
