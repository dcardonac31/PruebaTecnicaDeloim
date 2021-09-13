using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.Dtos
{
    [ExcludeFromCodeCoverage]
    public class QueryMultipleResponse<T>
    {
        public IEnumerable<T> Results { get; set; }
        public long TotalRecords { get; set; }
    }
}