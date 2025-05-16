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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> DeleteAuthor(int id)
        {
            var author = await _authorRepository.GetById(id);
            await _authorRepository.Delete(author);
            return author;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAll();
            return authors;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetById(id);
            return author;
        }

        public async Task<Author> InsertAuthor(Author author)
        {
            var result = await _authorRepository.Insert(author);
            return result;
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            var result = await _authorRepository.Update(author);
            return result;
        }
    }
}
