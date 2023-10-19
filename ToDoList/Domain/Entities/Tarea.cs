using Domain.Common;

namespace Domain.Entities
{
    public class Tarea : AuditableBaseEntity
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set;}
        public DateTime FechaLimite { get; set;}
        public int CategoriaId { get; set;}
        public virtual Categoria Categoria { get; set;}
        public string Estado { get; set;}
        public bool Activo { get; set; }
    }
}
