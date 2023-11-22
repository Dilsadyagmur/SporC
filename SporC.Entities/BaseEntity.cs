using System.ComponentModel.DataAnnotations;

namespace SporC.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}