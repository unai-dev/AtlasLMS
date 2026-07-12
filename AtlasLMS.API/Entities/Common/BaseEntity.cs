namespace AtlasLMS.API.Entities.Common;

public abstract class BaseEntity
{
    public int ID { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Default constructor for the Base class. 
    /// </summary>
    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }
}