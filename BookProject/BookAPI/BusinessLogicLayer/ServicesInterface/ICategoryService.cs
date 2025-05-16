using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategorys();
        public Task<Category> GetCategoryById(int id);
        public Task<Category> InsertCategory(Category category);
        public Task<Category> UpdateCategory(Category category);
        public Task<Category> DeleteCategory(int id);
    }
}
