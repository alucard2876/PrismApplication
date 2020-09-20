using Domain.Entities;
using DomainAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainAccess.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository()
        {
            _context = new Context();
        }
        public  Result<IEnumerable<Product>> AddProduct(Product product)
        {
            var result = new Result<IEnumerable<Product>>();
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));
                _context.Products.Add(product);
                _context.SaveProducts();
                result.Data = _context.Products;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }

        public  Result<IEnumerable<Product>> DeleteProduct(int id)
        {
            var result = new Result<IEnumerable<Product>>();
            try
            {
                var data = _context.Products.First(p => p.Id == id);
                if (data ==null)
                    throw new ArgumentNullException("Is no product");
                _context.Products.Remove(data);
                _context.SaveProducts();
                result.Data = _context.Products;
                result.IsCompleted = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }

        public Result<IEnumerable<Product>> GetAllProduct()
        {
            var result = new Result<IEnumerable<Product>>();
            try
            {
                result.Data = _context.Products;
                result.IsCompleted = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }

        public  Result<Product> GetProductById(int id)
        {
            var result = new Result<Product>();
            try
            {
                var data =  _context.Products.First(p => p.Id == id);
                if (data == null)
                    throw new ArgumentNullException("Is no product");
                
                result.Data = data;
                result.IsCompleted = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }
    }
}
