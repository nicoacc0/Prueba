using System.ComponentModel.DataAnnotations;

namespace Prueba.Model
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //Propiedad de Navegacion

        public List<Producto> Productos{ get; set; }
    }
}
