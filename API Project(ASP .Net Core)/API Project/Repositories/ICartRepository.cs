using API_Project.Models;

namespace API_Project.Repositories
{
    public interface ICartRepository
    {
        public List<Cart> getAll();
        public Cart getById(int id);
        public void Insert(Cart cart);
        public void Delete(int id);
    }
}
