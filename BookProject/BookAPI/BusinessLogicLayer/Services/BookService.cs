using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await _bookRepository.GetById(id);
            await _bookRepository.Delete(book);
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _bookRepository.GetAll();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _bookRepository.GetById(id);
            return book;
        }

        public async Task<Book> InsertBook(Book book)
        {
            var result = await _bookRepository.Insert(book);
            return result;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var result = await _bookRepository.Update(book);
            return result;
        }

        public async Task<Book> GetBookByAuthor(int authorId)
        {
            var result = await _bookRepository.GetBookByAuthor(authorId);
            return result;
        }

        public async Task<Book> GetBookByCategory(int cateId)
        {
            var result = await _bookRepository.GetBookByCategory(cateId);
            return result;
        }
    }
}
