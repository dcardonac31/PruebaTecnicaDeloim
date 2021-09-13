using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.Dtos
{
    [ExcludeFromCodeCoverage]
    public class Body
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Token")]
        public string Token { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("Footer")]
        public string Footer { get; set; }
    }
}
