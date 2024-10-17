namespace Backend.Application.Dtos
{
    public class ImageDto
    {
        public Guid ProductId { get; set; }
        public string AltText { get; set; }
        public string Url { get; set; }
        public Guid ProductVariantId { get; set; }
    }
}