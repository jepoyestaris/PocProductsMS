namespace PocProductsMS.Model
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public ICollection<CompanyDto> Companies { get; set; }
    }
}
