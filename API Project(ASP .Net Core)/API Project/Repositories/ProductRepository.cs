﻿using API_Project.DTO;
using API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Repositories
{
    public class ProductRepository: IProductRepository
    {
        ShoppingDB context;
        public ProductRepository(ShoppingDB shoppingdb)
        {
            context = shoppingdb;
        }
        public List<Product> getAll()
        {
            List<Product> products = context.Products.Include(c=>c.Category).Include(r=>r.Rating).ToList();
            return products;
        }
        public Product getById(int id)
        {
            Product product = context.Products.Include(c => c.Category).Include(r => r.Rating).SingleOrDefault(p=>p.PId == id);
            return product;
        }
        public void Insert(PostProductDTO prod)
        {
            Product newproduct = new Product();
            newproduct.PPrice = prod.productPrice;
            newproduct.PTitle = prod.productTitle;
            newproduct.CategoryId = prod.productCategoryId;
            newproduct.PDescription = prod.productDescription;
            newproduct.PImage = prod.productImage;
            context.Products.Add(newproduct);
            context.SaveChanges();
        }
        public void Update(int id, PostProductDTO updatedproduct)
        {
            Product editedproduct = getById(id);
            editedproduct.PPrice = updatedproduct.productPrice;
            editedproduct.PTitle = updatedproduct.productTitle;
            editedproduct.PDescription = updatedproduct.productDescription;
            editedproduct.PImage = updatedproduct.productImage;
            editedproduct.CategoryId = updatedproduct.productCategoryId;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Product product = getById(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
