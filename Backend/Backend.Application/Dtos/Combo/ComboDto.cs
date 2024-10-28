namespace Backend.Application.Dtos.Combo;

public class ComboDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int? DiscountPercent { get; set; }
    public List<ProductComboDto> Products { get; set; }
    public ComboImageDto ComboImageDto { get; set; }
    public bool? IsActive { get; set; }
}
