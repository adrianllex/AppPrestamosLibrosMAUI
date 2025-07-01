using SQLite;

namespace AppPrestamosLibrosMAUI.Models
{
    public class Libro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}

