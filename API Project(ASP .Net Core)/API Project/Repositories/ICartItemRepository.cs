using API_Project.DTO;
using API_Project.Models;

namespace API_Project.Repositories
{
    public interface ICartItemRepository
    {
        public List<CartItem> getAll();
        public CartItem getById(int id);
        public void Insert(CartDTO cartitem);
        public void Update(int id, CartDTO updatedcartitem);
        public void Delete(int id);
    }
}
