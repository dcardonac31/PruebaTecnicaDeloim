using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ListTo
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
