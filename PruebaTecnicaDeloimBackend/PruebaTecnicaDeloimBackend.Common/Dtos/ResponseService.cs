using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace PruebaTecnicaDeloimBackend.Common.Dtos
{
    [ExcludeFromCodeCoverage]
    public class ResponseService<T>
    {
        public bool Status { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ResponseService()
        {
            Status = false;
            Message = string.Empty;
        }
    }
}
