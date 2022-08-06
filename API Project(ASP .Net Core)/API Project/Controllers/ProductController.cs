using API_Project.DTO;
using API_Project.Models;
using API_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository ProductRepo;
        ICategoryRepository CategoryRepo;
        IRatingRepository RatingRepo;
        public ProductController(IProductRepository ProdRepo, ICategoryRepository CatRepo, IRatingRepository RateRepo)
        {
            ProductRepo = ProdRepo;
            CategoryRepo = CatRepo;
            RatingRepo = RateRepo;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> Products = ProductRepo.getAll();
            List<ProductCategoryRateDTO> productCategoryRateDTO = new List<ProductCategoryRateDTO>();
            foreach (Product product in Products)
            {
                productCategoryRateDTO.Add(new ProductCategoryRateDTO()
                {
                    productId = product.PId,
                    productTitle = product.PTitle,
                    productPrice = product.PPrice,
                    productDescription = product.PDescription,
                    productImage = product.PImage,
                    productCategory = product.Category.CatName,
                    productRating = new RateDTO() { rate = product.Rating.rate, count = product.Rating.count }
                });
            }
            return Ok(productCategoryRateDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute]int id)
        {
            Product Product = ProductRepo.getById(id);
            ProductCategoryRateDTO productCategoryRateDTO = new ProductCategoryRateDTO();
            productCategoryRateDTO.productId = Product.PId;
            productCategoryRateDTO.productTitle = Product.PTitle;
            productCategoryRateDTO.productPrice = Product.PPrice;
            productCategoryRateDTO.productDescription = Product.PDescription;
            productCategoryRateDTO.productImage = Product.PImage;
            productCategoryRateDTO.productCategory = Product.Category.CatName;
            productCategoryRateDTO.productCategoryId = Product.CategoryId;
            productCategoryRateDTO.productRating = new RateDTO() { rate = Product.Rating.rate, count = Product.Rating.count };

            return Ok(productCategoryRateDTO);
        }

        [HttpPost]
        public IActionResult PostProduct(PostProductDTO newprod)
        {
            if (ModelState.IsValid)
            {
                ProductRepo.Insert(newprod);
                return Created("http://localhost:5034/Product" + newprod.productTitle, newprod);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct([FromRoute] int id, [FromBody]PostProductDTO prod)
        {
            if(ModelState.IsValid)
            {
                ProductRepo.Update(id, prod);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProduct([FromRoute] int id)
        {

            try
            {
                ProductRepo.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {


                return BadRequest(ex);
            }
        }

    }
}
