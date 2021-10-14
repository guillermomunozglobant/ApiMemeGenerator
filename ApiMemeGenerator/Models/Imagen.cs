using System;

namespace ApiMemeGenerator.Models
{
    public class Imagen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }
            
        public double Peso { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Usuario UsuarioCreacion { get; set; }
    }
}
