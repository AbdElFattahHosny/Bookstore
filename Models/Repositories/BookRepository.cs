using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                 new Book
                 {
                    Id=1,Title="C#",Description="Power of c#",
                    ImageUrl="download.jpg",
                     Author=new Author(){Id=2}
                 },
                 new Book
                 {
                    Id=2,Title="Asp",Description="Power of ASP",Author=new Author(),ImageUrl="Open_book_nae_02.svg.png"
                 },
                 new Book
                 {
                     Id = 3,
                     Title = "sql",
                     ImageUrl="download.jpg",
                    Description = "Power of sql",Author=new Author()
                 },

            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = find(id);
            books.Remove(book);
             
        }

        public Book find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public List<Book> Search(string term)
        {
            var result = books.Where(a => a.Title.Contains(term) || a.Description.Contains(term)).ToList();
            return result;
        }

        public void Update(int id , Book newBook)
        {
            var book = find(id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            book.ImageUrl = newBook.ImageUrl;
        }
    }
}
