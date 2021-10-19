using System;

namespace ApiMemeGenerator.Entities
{
    public class Meme
    {
        public string Nombre { get; set; }
        public string URL { get; set; }

        public double Peso { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
