using System.Collections.Generic;
using System.Linq;
using DAL.Entities;

namespace DAL.Repo
{
    public class ProductRepo
    {
        private readonly Prn212block3WContext _context;

        public ProductRepo()
        {
            _context = new Prn212block3WContext();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = GetById(id);
            if (p != null)
            {
                _context.Products.Remove(p);
                _context.SaveChanges();
            }
        }
    }
}
