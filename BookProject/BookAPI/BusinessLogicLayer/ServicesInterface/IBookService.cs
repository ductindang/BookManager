using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetBookById(int id);
        public Task<Book> InsertBook(Book book);
        public Task<Book> UpdateBook(Book book);
        public Task<Book> DeleteBook(int id);
        public Task<Book> GetBookByAuthor(int  authorId);
        public Task<Book> GetBookByCategory(int cateId);
    }
}
