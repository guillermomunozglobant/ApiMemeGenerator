namespace ApiMemeGenerator.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Permisos TipoUsuario { get; set; }
    }
}
