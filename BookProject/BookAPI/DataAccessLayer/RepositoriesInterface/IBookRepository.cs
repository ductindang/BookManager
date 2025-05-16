using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Task<Book> GetBookByAuthor(int authorId);
        public Task<Book> GetBookByCategory(int cateId);
    }
}
