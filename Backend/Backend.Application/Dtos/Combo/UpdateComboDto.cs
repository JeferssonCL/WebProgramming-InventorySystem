namespace Backend.Application.Dtos.Combo;

public class UpdateComboDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? DiscountPercent { get; set; }
    public List<Guid>? ProductsIds { get; set; }
    public bool? IsActive { get; set; }
}
