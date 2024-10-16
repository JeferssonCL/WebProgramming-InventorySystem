using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class UserAddress : BaseEntity
{
    public Guid UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public User User { get; set; }
}