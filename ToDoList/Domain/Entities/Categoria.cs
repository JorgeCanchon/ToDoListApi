using Domain.Common;

namespace Domain.Entities
{
    public class Categoria : AuditableBaseEntity
    {
        public string Nombre { get; set; }
        public virtual Tarea Tarea { get; set; }
        public bool Activo { get; set; }
    }
}
