using System;

namespace PruebaTecnicaDeloimBackend.Api.Models
{
    public class AfiliadoModel
    {
        public int AfiliadoID { get; set; }
        public string AfiliadoNombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public byte[] Foto { get; set; }
        public decimal Peso { get; set; }
    }
}
