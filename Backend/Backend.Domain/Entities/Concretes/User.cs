using Backend.Domain.Entities.Bases;
using Backend.Domain.Entities.Enums;

namespace Backend.Domain.Entities.Concretes;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; }
    public UserAddress Address { get; set; }
    public ICollection<Order> Orders { get; set; }
}