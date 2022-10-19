using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_autores.Entitys
{
    public class Autor
    {
        //Definimos la llave primaria
        [Key]
        public int codigoautor { get; set; }
        //definimos valores no nulos
        [Required]
        //definimos el tamaño del campo
        [StringLength(maximumLength:100, ErrorMessage ="Se tiene que ingresar un nombre")]
        public string nombre { get; set; }
        [Required]
        public bool estado { get; set; }
        public List<Libro> libro { get; set; }
    }
}
