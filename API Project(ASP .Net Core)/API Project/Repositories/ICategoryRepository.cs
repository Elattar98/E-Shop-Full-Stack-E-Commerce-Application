using API_Project.Models;

namespace API_Project.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> getAll();
        public List<Category> getCategoriesWithProducts();
        public Category getById(int id);
        public void Insert(Category cat);
        public void Update(int id, Category updatedcategory);
        public void Delete(int id);
    }
}
