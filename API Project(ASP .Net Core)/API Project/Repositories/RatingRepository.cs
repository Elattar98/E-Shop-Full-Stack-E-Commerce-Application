﻿using API_Project.Models;

namespace API_Project.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        ShoppingDB context;
        public RatingRepository(ShoppingDB shoppingdb)
        {
            context = shoppingdb;
        }
        public void Delete(int id)
        {
            Rating rate = getById(id);
            context.Ratings.Remove(rate);
            context.SaveChanges();
        }

        public List<Rating> getAll()
        {
            List<Rating> rates = context.Ratings.ToList();
            return rates;
        }

        public Rating getById(int id)
        {
            Rating rate = context.Ratings.SingleOrDefault(c => c.RId == id);
            return rate;
        }

        public void Insert(Rating rate)
        {
            Rating newrate = new Rating();
            newrate.RId = rate.RId;
            newrate.rate = rate.rate;
            context.Ratings.Add(newrate);
            context.SaveChanges();
        }

        public void Update(int id, Rating updatedRate)
        {
            Rating editedrate = getById(id);
            editedrate.rate = updatedRate.rate;
            context.SaveChanges();
        }
    }
}
