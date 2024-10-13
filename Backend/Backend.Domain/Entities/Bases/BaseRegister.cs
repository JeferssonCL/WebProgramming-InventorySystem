using Backend.Domain.Entities.Interfaces;

namespace Backend.Domain.Entities.Bases;

public abstract class BaseRegister : IRegister
{
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}