using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        public string NombreEmpresa { get; set; }
        public string RNC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string PaginaWeb { get; set; }
        public string Estado { get; set; }
    }
}