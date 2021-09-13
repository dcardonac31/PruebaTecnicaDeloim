using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.Dtos
{
    [ExcludeFromCodeCoverage]
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
