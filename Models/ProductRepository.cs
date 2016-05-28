using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleStockAssessment.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;
        
        public ProductRepository()
        {
            Add(new Product { Name = "Lee Cooper", catID=1, Category = "Pants", Price = 150000 });
            Add(new Product { Name = "Uniqlo", catID=2, Category = "Clothes", Price = 250000 });
            Add(new Product { Name = "Cardinal", catID = 1, Category = "Pants", Price = 175000 });
            Add(new Product { Name = "Fossil", catID = 3, Category = "Watches", Price = 1750000 });           
           
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
           
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);

            if (index == -1)
            {
                return false;
            }

            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}