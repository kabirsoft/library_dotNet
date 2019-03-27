using Library_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_data.IRepositories
{
    public interface IBookRepo
    {
        List<Book> GetAllBook();
        Book GetBook(int id);
        string GetAuthorByBook(int id);
        List<Book> GetBooksByAuthor(string authorname);        
        List<Book> GetBooksByAuthorAndYear(string authorname, int year);
        Book AddNewBook(Book book);
        bool RemoveBook(int id);
        Book UpdateBook(int id, Book book);
        Book AddCost(int bookId, Cost cost);
    }
}
