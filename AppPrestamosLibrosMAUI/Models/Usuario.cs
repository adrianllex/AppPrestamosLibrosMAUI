﻿using SQLite;

namespace AppPrestamosLibrosMAUI.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
    }
}
