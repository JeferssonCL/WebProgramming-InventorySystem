using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Image : BaseEntity
{
    public Guid ProdcutId { get; set; }
    public string AltText { get; set; }
    public string Url { get; set; }
    public Product Product { get; set; }
    public ProductAttribute ProductAttribute { get; set; }
}