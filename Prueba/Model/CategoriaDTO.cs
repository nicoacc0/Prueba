using System.ComponentModel.DataAnnotations;

namespace Prueba.Model
{
    public class CategoriaDTO
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
