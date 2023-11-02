using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocProductsMS.Data;
using PocProductsMS.Model;

namespace PocProductsMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EmwDbContext _dbContext;
        public ProductsController(EmwDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            // Retrieve the parent and its children using a DTO to prevent Cyclic error:
            // var query = _dbContext.Products.Include(a => a.Companies).ToList();
            var productDtos = _dbContext.Products
                .Include(p => p.Companies)
                .Select(p => new ProductDto {
                    Id = p.Id,
                    Companies = p.Companies.Select(c => 
                            new CompanyDto() { Id = c.Id, Name = c.Name}).ToList(),
                    Name = p.Name,
                    Price = p.price
                });
            return Ok(productDtos);
        } 
    }
}
