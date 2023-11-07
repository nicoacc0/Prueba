using System.ComponentModel.DataAnnotations;

namespace Prueba.Model
{
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }

    public class UsuarioDTO
    {
        [Key]
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }

        public int asdas { get; set; }

    }


    
}
