namespace DomainApi.Common.Models;

public abstract class BaseModelWithoutId
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
