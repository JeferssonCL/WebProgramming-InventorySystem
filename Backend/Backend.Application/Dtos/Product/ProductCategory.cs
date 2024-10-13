namespace Backend.Application.Dtos
{
    public class ProductCategory
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Subcategories { get; set; } = [];
    }
}