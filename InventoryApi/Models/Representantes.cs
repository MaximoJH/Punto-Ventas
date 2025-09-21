using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Representantes
    {
        [Key]
        public int RepresentanteId { get; set; }
        public string Nombre { get; set; }
        public string PremirApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
    }
}