using API_Project.DTO;
using API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Repositories
{
    public class CartItemRepository: ICartItemRepository
    {
        ShoppingDB context;
        public CartItemRepository(ShoppingDB shoppingdb)
        {
            context = shoppingdb;
        }

        public void Delete(int id)
        {
           CartItem cartItem = getById(id);
           context.Remove(cartItem);
           context.SaveChanges();
        }

        public List<CartItem> getAll()
        {
            List<CartItem> cartItems = context.cartItems.Include(p=>p.Product).ToList();
            return cartItems;
        }

        public CartItem getById(int id)
        {
            CartItem cartitem = context.cartItems.SingleOrDefault(c => c.CartItemId == id);
            return cartitem;
        }

        public void Insert(CartDTO cartitem)
        {
            CartItem newcartitem = new CartItem();
            newcartitem.CartItemId= cartitem.ItemId;
            newcartitem.Quantity = cartitem.ItemQuantity;
            newcartitem.ProductId = cartitem.ProductId;
            newcartitem.TotalCost = cartitem.ItemTotalCost;
            newcartitem.Product = context.Products.FirstOrDefault(p => p.PId == cartitem.ProductId);
            context.cartItems.Add(newcartitem);
            context.SaveChanges();
        }

        public void Update(int id, CartDTO updatedcartitem)
        {
            CartItem editedcartItem= getById(id);
            editedcartItem.Quantity = updatedcartitem.ItemQuantity;
            editedcartItem.TotalCost = updatedcartitem.ItemTotalCost;
            context.SaveChanges();
        }
    }
}
