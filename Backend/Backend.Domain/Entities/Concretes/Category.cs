using Backend.Domain.Entities.Bases;

namespace Backend.Domain.Entities.Concretes;

public class Category : BaseEntity
{
    public Guid? ParentCategoryId { get; set; }
    public string Name { get; set; }
    public Category ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; }
    public ICollection<Product> Products { get; set; }
}