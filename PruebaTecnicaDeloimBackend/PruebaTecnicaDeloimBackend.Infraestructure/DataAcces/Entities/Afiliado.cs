using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Entities
{
    public class Afiliado
    {
        [Key]
        public int AfiliadoID { get; set; }
        [Required]
        public string AfiliadoNombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public string LugarNacimiento { get; set; }
        public byte[] Foto { get; set; }
        [Required]
        public decimal Peso { get; set; }
    }

}
