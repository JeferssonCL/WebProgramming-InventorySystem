using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Variant : BaseEntity
{ 
    public string Name { get; set; }
    public ICollection<ProductAttribute> ProductAttributes { get; set; }
}