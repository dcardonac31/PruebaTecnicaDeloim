using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.ApplicationInsights.Dtos
{
    [ExcludeFromCodeCoverage]
    public class AppSettingInfo
    {
        public bool Enabled { get; set; }
        public string InstrumentationKey { get; set; }
    }
}
