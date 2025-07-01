using SQLite;
using SQLite;
using System;

namespace AppPrestamosLibrosMAUI.Models
{
    public class Prestamo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int LibroId { get; set; }

        public DateTime FechaPrestamo { get; set; }  // Fecha en que se hace el préstamo

        public DateTime? FechaDevolucion { get; set; } // Puede ser nula si aún no se devuelve
    }
}
