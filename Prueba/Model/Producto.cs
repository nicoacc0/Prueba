using System.ComponentModel.DataAnnotations;

namespace Prueba.Model
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public int Imagen { get; set; }

        //FK

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
