using API_Project.DTO;
using API_Project.Models;
using API_Project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IProductRepository ProductRepo;
        ICategoryRepository CategoryRepo;
        IRatingRepository RatingRepo;
        ICartItemRepository CartItemRepo;
        public CategoryController(IProductRepository ProdRepo, ICategoryRepository CatRepo, IRatingRepository RateRepo, ICartItemRepository cartItemRepo)
        {
            ProductRepo = ProdRepo;
            CategoryRepo = CatRepo;
            RatingRepo = RateRepo;
            CartItemRepo = cartItemRepo;
        }

        [HttpGet]
        public IActionResult GetCategoriesProducts()
        {
            List <CategoryProductsDTO> categoriesDTO = new List<CategoryProductsDTO> ();
            List<Category> categories = CategoryRepo.getCategoriesWithProducts();


            foreach (Category category in categories) 
            {           
                List<ProductCategoryRateDTO> products = new List<ProductCategoryRateDTO> ();

                foreach (Product product in category.Products)
                {
                    if(product.CategoryId == category.CatId)
                    {
                        products.Add(new ProductCategoryRateDTO()
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
                    
                }
                categoriesDTO.Add(new CategoryProductsDTO()
                {
                    categoryId = category.CatId,
                    categoryName = category.CatName,
                    products = products
                });
            }
           
            return Ok(categoriesDTO);
        }
    }
}
