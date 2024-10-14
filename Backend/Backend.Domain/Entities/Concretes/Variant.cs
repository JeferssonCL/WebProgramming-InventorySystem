using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Variant : BaseEntity
{
    public Guid ProductAttributeId { get; set; }
    public string Name { get; set; }
    public ProductAttribute ProductAttribute { get; set; }
}