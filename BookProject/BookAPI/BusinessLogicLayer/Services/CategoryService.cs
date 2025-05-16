using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var cate = await _categoryRepository.GetById(id);
            await _categoryRepository.Delete(cate);
            return cate;
        }

        public async Task<IEnumerable<Category>> GetAllCategorys()
        {
            var cates = await _categoryRepository.GetAll();
            return cates;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var cate = await _categoryRepository.GetById(id);
            return cate;
        }

        public async Task<Category> InsertCategory(Category category)
        {
            var result = await _categoryRepository.Insert(category);
            return result;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var result = await _categoryRepository.Update(category);
            return result;
        }
    }
}
