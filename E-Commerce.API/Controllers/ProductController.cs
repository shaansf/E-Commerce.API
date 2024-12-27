using E_Commerce.API.Data;
using E_Commerce.API.Model.Domain;
using E_Commerce.API.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
    private readonly ECommerceDbContext dbContext;
        public ProductController(ECommerceDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = dbContext.Products.ToList();
            var productDto = new List<ProductDTO>();
            foreach (var product in products)
            {
                productDto.Add(new ProductDTO
                {
                    Id = product.Id,
                    product_name = product.product_name,
                    product_description = product.product_description,
                    product_type = product.product_type,
                    product_image_url = product.product_image_url,
                    price = product.price,
                    brand = product.brand,
                    quantity = product.quantity,

                });
            }
            return Ok(products);
        }
    [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetProductById([FromRoute] Guid id)
        {
            var product = dbContext.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            var productDto = new ProductDTO
            {
                Id = product.Id,
                product_name = product.product_name,
                product_description = product.product_description,
                product_type = product.product_type,
                product_image_url = product.product_image_url,
                price = product.price,
                brand = product.brand,
                quantity = product.quantity

            };
            return Ok(productDto);
        }
        [HttpPost] 
        public IActionResult CreateProduct([FromBody] AddProductRequestDto addProductRequestDto)
        {
            var productDomainModel = new Product
            {
                product_name = addProductRequestDto.product_name,
                product_description = addProductRequestDto.product_description,
                product_type = addProductRequestDto.product_type,
                product_image_url = addProductRequestDto.product_image_url,
                price = addProductRequestDto.price,
                brand = addProductRequestDto.brand,
                quantity = addProductRequestDto.quantity,
            };
            dbContext.Products.Add(productDomainModel);
            dbContext.SaveChanges();
            var productdto = new ProductDTO
            {
                Id = productDomainModel.Id,
                product_name = productDomainModel.product_name,
                product_description = productDomainModel.product_description,
                product_image_url = productDomainModel.product_image_url,
                price = productDomainModel.price,
                brand = productDomainModel.brand,
                quantity = productDomainModel.quantity,
            };
            return CreatedAtAction(nameof(GetProductById), new { id = productDomainModel.Id }, productDomainModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody])
    }
    

    }