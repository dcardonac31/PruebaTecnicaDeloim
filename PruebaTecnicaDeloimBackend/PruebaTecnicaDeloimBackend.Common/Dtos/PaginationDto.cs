using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.Dtos
{
    [ExcludeFromCodeCoverage]
    public class PaginationDto
    {
        public string OrderBy { get; set; }
        public bool Ascendent { get; set; }
        public int PageNumber { get; set; }
        public int ResultsPerPage { get; set; }
    }
}
