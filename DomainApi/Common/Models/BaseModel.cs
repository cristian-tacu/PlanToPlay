using System.ComponentModel.DataAnnotations;
using KSUID;

namespace DomainApi.Common.Models;

public abstract class BaseModel : BaseModelWithoutId
{
    [Key]
    [StringLength(27, MinimumLength = 27)]
    public Ksuid? Id { get; init; } = Ksuid.Generate();
}
