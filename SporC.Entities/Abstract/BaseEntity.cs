namespace SporC.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}