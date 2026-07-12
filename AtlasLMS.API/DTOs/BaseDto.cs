namespace AtlasLMS.API.DTOs;

public abstract class BaseDto
{
    public int ID { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
