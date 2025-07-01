using System.Collections.Generic;

namespace ApiPrestamosLibros.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación uno a muchos con Préstamos
        public List<Prestamo> Prestamos { get; set; }
    }
}
