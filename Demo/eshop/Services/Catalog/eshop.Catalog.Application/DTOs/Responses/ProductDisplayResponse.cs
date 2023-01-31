namespace eshop.Catalog.Application.DTOs.Responses
{
    public class ProductDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
