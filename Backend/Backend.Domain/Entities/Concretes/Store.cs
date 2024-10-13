using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Store : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public int PhoneNumber { get; set; }
    public ICollection<Product> Products { get; set; }
    public User User { get; set; }
}