using Library_data.IRepositories;
using Library_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Library_webservice.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BooksController : ApiController
    {
        IBookRepo books;
        public BooksController( IBookRepo _books)
        {
            this.books = _books;
        }
        [HttpGet]
        public List<Book> Get()
        {
            return books.GetAllBook();
        }
        [HttpGet]
        [Route("api/books/{id}")]
        public IHttpActionResult Get(int id)
        {
            Book book = books.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);

        }
        [HttpGet]
        [Route("api/books/authorname/{id}")] //bookId
        public IHttpActionResult GetAuthorByBook(int id)
        {
            string author = books.GetAuthorByBook(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpGet]
        [Route("api/books/author/{author}")]
        public IHttpActionResult GetBooksByAuthor(string author)
        {
            List<Book> bks = books.GetBooksByAuthor(author);
            if( bks == null)
            {
                return NotFound();
            }
            return Ok(bks);
        }
        [HttpGet]
        [Route("api/books/author/{author}/year/{year}")]
        public IHttpActionResult GetBooksByAuthorAndYear(string author, int year)
        {
            List<Book> bks = books.GetBooksByAuthorAndYear(author, year);
            if (bks == null)
            {
                return NotFound();
            }
            return Ok(bks);
        }
        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            Book bk = books.AddNewBook(book);
            if (bk == null)
            {
                return NotFound();
            }
            return Ok(bk);
        }
        [HttpDelete]
        [Route("api/books/{id}")]
        public IHttpActionResult Delete(int id)
        {
            bool res = books.RemoveBook(id);
            if (!res)
            {
                return NotFound();
            }
            return Ok(true);
        }
        [HttpPut]
        [Route("api/books/{id}")]
        public IHttpActionResult Put(int id, Book book)
        {
            Book bk = books.UpdateBook(id, book);
            if (bk == null)
            {
                return NotFound();
            }
            return Ok(bk);
        }
        [HttpPut]
        [Route("api/books/addcost/{bookId}")]
        public IHttpActionResult AddCostToBook(int bookId, Cost cost)
        {
            Book book = books.AddCost(bookId, cost);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
