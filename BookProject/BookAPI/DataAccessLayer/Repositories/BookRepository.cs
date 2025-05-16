using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByAuthor(int authorId)
        {
            var book = await _context.Book.FirstOrDefaultAsync(b => b.AuthorId == authorId);
            return book;
        }

        public async Task<Book> GetBookByCategory(int cateId)
        {
            var book = await _context.Book.FirstOrDefaultAsync(b => b.CategoryId == cateId);
            return book;
        }
    }
}
