using Domain.Entities;
using System.Collections.Generic;

namespace DomainAccess.Interfaces
{
    public interface ICategoryRepository
    {
        Result<IEnumerable<Category>> GetCategories();
        Result<IEnumerable<Category>> AddCategory(Category category);
    }
}
