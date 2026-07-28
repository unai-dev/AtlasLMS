namespace AtlasLMS.Domain.Entities.Common;

public abstract class BaseEntity
{
    public int ID { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}