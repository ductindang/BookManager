using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAllAuthors();
        public Task<Author> GetAuthorById(int id);
        public Task<Author> InsertAuthor(Author author);
        public Task<Author> UpdateAuthor(Author author);
        public Task<Author> DeleteAuthor(int id);
    }
}
