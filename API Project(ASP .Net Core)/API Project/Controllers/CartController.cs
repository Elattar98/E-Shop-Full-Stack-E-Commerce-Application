using API_Project.DTO;
using API_Project.Models;
using API_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        IProductRepository ProductRepo;
        ICategoryRepository CategoryRepo;
        IRatingRepository RatingRepo;
        ICartItemRepository CartItemRepo;
        public CartController(IProductRepository ProdRepo, ICategoryRepository CatRepo, IRatingRepository RateRepo, ICartItemRepository cartItemRepo)
        {
            ProductRepo = ProdRepo;
            CategoryRepo = CatRepo;
            RatingRepo = RateRepo;
            CartItemRepo = cartItemRepo;
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            List<CartItem> cartItems = CartItemRepo.getAll();
            List<CartDTO> cartDTO = new List<CartDTO>();
            foreach (CartItem item in cartItems)
            {
                cartDTO.Add(new CartDTO()
                {
                    ItemId = item.CartItemId,
                    ItemQuantity = item.Quantity,
                    ItemTotalCost = item.TotalCost,
                    ProductId = item.ProductId,
                    Product = new ProductDTO()
                    {
                        productId = item.ProductId,
                        productPrice = item.Product.PPrice,
                        productTitle = item.Product.PTitle
                    }
                });
            }
            return Ok(cartDTO);
        }

        [HttpPost]
        public IActionResult PostCart(CartDTO newitem)
        {
            if (ModelState.IsValid)
            {
                CartItemRepo.Insert(newitem);
                return Created("http://localhost:5034/Product" + newitem.ItemId, newitem);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult PutCartItem([FromRoute] int id, [FromBody] CartDTO item)
        {
            if (ModelState.IsValid)
            {
                CartItemRepo.Update(id, item);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCartItem([FromRoute] int id)
        {

            try
            {
                CartItemRepo.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {


                return BadRequest(ex);
            }
        }
    }
}
