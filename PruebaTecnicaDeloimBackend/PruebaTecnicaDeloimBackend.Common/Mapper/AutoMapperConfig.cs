using System.Diagnostics.CodeAnalysis;

namespace PruebaTecnicaDeloimBackend.Common.Mapper
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperConfig
    {
        public static void CreateMaps()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.ValidateInlineMaps = false;
            });
        }
    }
}
