using System;
using System.Collections.Generic;
using DAL.Entities;
using DAL.Repo;

namespace BLL.Service
{
    public class ProductService
    {
        private readonly ProductRepo _repo;

        public ProductService()
        {
            _repo = new ProductRepo();
        }

        public List<Product> GetAllProducts() => _repo.GetAll();

        public Product? GetProductById(int id) => _repo.GetById(id);

        public void AddProduct(Product p)
        {
            if (string.IsNullOrWhiteSpace(p.Name))
                throw new ArgumentException("Tên sản phẩm không được để trống");

            if (p.Price <= 0)
                throw new ArgumentException("Giá sản phẩm phải lớn hơn 0");

            if (p.QuantityInStorage < 0)
                throw new ArgumentException("Số lượng không được âm");

            if (string.IsNullOrWhiteSpace(p.Status))
                p.Status = "Available";

            _repo.Add(p);
        }

        public void UpdateProduct(Product p)
        {
            if (p.Id <= 0)
                throw new ArgumentException("ID sản phẩm không hợp lệ");

            if (string.IsNullOrWhiteSpace(p.Name))
                throw new ArgumentException("Tên sản phẩm không được để trống");

            if (p.Price <= 0)
                throw new ArgumentException("Giá sản phẩm phải lớn hơn 0");

            _repo.Update(p);
        }

        public void DeleteProduct(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID không hợp lệ");

            _repo.Delete(id);
        }
    }
}
