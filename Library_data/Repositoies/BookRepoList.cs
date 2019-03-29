using Library_data.IRepositories;
using Library_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_data.Repositoies
{
    public class BookRepoList : IBookRepo
    {
        List<Book> books = new List<Book>()
        {
            new Book{Id=1, Title="One Day", Author="David Nicholls", Isavailable=true, PublicationYear=2010},
            new Book{Id=2, Title="How to Be a Woman", Author="Caitlin Moran", Isavailable=true, PublicationYear=2011},
            new Book{Id=3, Title="Nonai", Author="Humayun shadu", Isavailable=false, PublicationYear=2019}
        };

        public List<Book> GetAllBook()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

        public string GetAuthorByBook(int id)
        {
            return books.FirstOrDefault(x => x.Id == id).Author;
        }    

        public List<Book> GetBooksByAuthor(string authorname)
        {
            return books.Where(x => x.Author.Contains(authorname)).ToList();
        }

        public List<Book> GetBooksByAuthorAndYear(string authorname, int year)
        {
            return books.Where(x => x.Author.Contains(authorname) && x.PublicationYear == year).ToList();
        }

        public Book AddNewBook(Book book)
        {
            books.Add(book);
            return book;
        }

        public bool RemoveBook(int id)
        {
            Book book = this.GetBook(id);
            if(book == null)
            {
                return false;
            }
            books.Remove(book);
            return true;
            
        }

        public Book UpdateBook(int id, Book book)
        {
            if (this.RemoveBook(id))
            {
                this.AddNewBook(book);
            }
            return book;
        }

        public Book AddCost(int bookId, Cost cost)
        {
            Book book = this.GetBook(bookId);
            book.cost = cost;
            return book;

        }        
    }
}
