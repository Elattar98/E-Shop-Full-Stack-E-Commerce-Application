using API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        ShoppingDB context;
        public CategoryRepository(ShoppingDB shoppingdb)
        {
            context = shoppingdb;
        }
        public List<Category> getAll()
        {
            List<Category> categories = context.Categories.ToList();
            return categories;
        }
        public List<Category> getCategoriesWithProducts()
        {
            List<Category> categories = context.Categories.Include(p => p.Products).ToList();
            return categories;
        }
        public Category getById(int id)
        {
            Category category = context.Categories.SingleOrDefault(c => c.CatId == id);
            return category;
        }
        public void Insert(Category cat)
        {
            Category newcategory = new Category();
            newcategory.CatId = cat.CatId;
            newcategory.CatName = cat.CatName;
            context.Categories.Add(newcategory);
            context.SaveChanges();
        }
        public void Update(int id, Category updatedcategory)
        {
            Category editedcategory = getById(id);
            editedcategory.CatName = updatedcategory.CatName;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Category category = getById(id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
