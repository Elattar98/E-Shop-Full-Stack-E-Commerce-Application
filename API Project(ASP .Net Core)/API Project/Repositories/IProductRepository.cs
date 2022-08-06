using API_Project.DTO;
using API_Project.Models;

namespace API_Project.Repositories
{
    public interface IProductRepository
    {
        public List<Product> getAll();
        public Product getById(int id);
        public void Insert(PostProductDTO prod);
        public void Update(int id, PostProductDTO updatedproduct);
        public void Delete(int id);
    }
}
