using API_Project.Models;

namespace API_Project.Repositories
{
    public class CartRepository : ICartRepository
    {
        ShoppingDB context;
        public CartRepository(ShoppingDB shoppingdb)
        {
            context = shoppingdb;
        }
        public void Delete(int id)
        {
            Cart cart = getById(id);
            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        public List<Cart> getAll()
        {
            List<Cart> carts = context.Carts.ToList();
            return carts;
        }

        public Cart getById(int id)
        {
            Cart cart = context.Carts.SingleOrDefault(c => c.CartId == id);
            return cart;
        }

        public void Insert(Cart cart)
        {
            Cart newcart = new Cart();
            newcart.CartId = cart.CartId;
            context.Carts.Add(newcart);
            context.SaveChanges();
        }
    }
}
