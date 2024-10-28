namespace Backend.Application.Dtos.Combo;

public class CreateComboDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DiscountPercent { get; set; }
    public List<Guid> ProductIds { get; set; }
}
