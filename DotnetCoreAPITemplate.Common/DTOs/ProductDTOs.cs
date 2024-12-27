namespace DotnetCoreAPITemplate.Common.DTOs
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
