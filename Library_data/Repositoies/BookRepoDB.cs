using Library_data.IRepositories;
using Library_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_data.Repositories
{
    public class BookRepoDB : IBookRepo
    {
        LibraryContext db = new LibraryContext();
        public List<Book> GetAllBook()
        {
            return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public string GetAuthorByBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id).Author;
        }

        

        public List<Book> GetBooksByAuthor(string authorname)
        {
            return db.Books.Where(x => x.Author.Contains(authorname)).ToList();
        }

        public List<Book> GetBooksByAuthorAndYear(string authorname, int year)
        {
            return db.Books.Where(x => x.Author.Contains(authorname) && x.PublicationYear == year).ToList();
        }
        public Book AddNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }
        public bool RemoveBook(int id)
        {
            Book book = this.GetBook(id);
            if( book == null)
            {
                return false;
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return true;
        }

        public Book UpdateBook(int id, Book book)
        {
            if( this.RemoveBook(id))
            {
                this.AddNewBook(book);
            }
            return book;
        }
        public Book AddCost(int bookId, Cost cost)
        {
            Book book = this.GetBook(bookId);
            if( book == null)
            {
                return null;
            } 
            book.cost = cost;
            db.SaveChanges();
            return book;
        }
    }
}
