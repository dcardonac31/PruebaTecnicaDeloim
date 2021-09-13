using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
