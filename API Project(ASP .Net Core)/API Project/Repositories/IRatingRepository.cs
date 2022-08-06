using API_Project.Models;

namespace API_Project.Repositories
{
    public interface IRatingRepository
    {
        public List<Rating> getAll();
        public Rating getById(int id);
        public void Insert(Rating rate);
        public void Update(int id, Rating updatedRate);
        public void Delete(int id);
    }
}
