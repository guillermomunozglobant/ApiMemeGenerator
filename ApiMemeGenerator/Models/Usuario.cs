using ApiMemeGenerator.Enum;

namespace ApiMemeGenerator.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public Permisos TipoUsuario { get; set; }
    }
}
