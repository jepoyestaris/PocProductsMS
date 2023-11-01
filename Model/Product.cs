using Microsoft.Extensions.Hosting;

namespace PocProductsMS.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string price { get; set; }
        public ICollection<Company> Companies { get; } = new List<Company>();
    }
}
