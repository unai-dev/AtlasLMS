namespace AtlasLMS.Shared.DTOs.Common;

public abstract class BaseDto
{
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
