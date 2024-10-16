namespace Backend.Application.Dtos;
public class ReducedStoreDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public int PhoneNumber { get; set; }
}
