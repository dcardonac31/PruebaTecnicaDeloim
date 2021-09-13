using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PruebaTecnicaDeloimBackend.Domain.Dtos
{
    [ExcludeFromCodeCoverage]
    public class AfiliadoDto
    {
        public int AfiliadoID { get; set; }
        public string AfiliadoNombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public byte[] Foto { get; set; }
        public string FotoBase64 { get; set; }
        public decimal Peso { get; set; }

    }

}
