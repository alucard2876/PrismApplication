using Domain.Entities;
using DomainAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace DomainAccess.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository()
        {
            _context = new Context();
            
        }
        public  Result<IEnumerable<Category>> AddCategory(Category category)
        {
            var result = new Result<IEnumerable<Category>>();
            try
            {
                if (category == null)
                    throw new ArgumentNullException(nameof(category));
                _context.Categories.Add(category);
                _context.SaveCategories();
                result.Data = _context.Categories;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = true;
            }
            return result;
        }

        public Result<IEnumerable<Category>> GetCategories()
        {
            var result = new Result<IEnumerable<Category>>();
            try
            {
                var data = _context.Categories;
                result.Data = data;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                result.IsCompleted = false;
            }
            return result;
        }
    }
}
