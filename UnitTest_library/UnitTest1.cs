using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Library_data.IRepositories;
using Library_data.Models;
using Library_webservice.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest_library
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAllBook()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            List<Book> getBooksObj = new List<Book>()
            {
                new Book{Id=1,  Title="Nonai", Author="Huma", PublicationYear=2011},
                new Book{Id=2, Title="Title2", Author="David Nicholls", PublicationYear=2012}
            };

            BookRepoMockClass.Setup(x => x.GetAllBook()).Returns(getBooksObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            List<Book> result = booksController.Get();

            //Assert
            Assert.AreEqual(result[0].Title, "Nonai");
            Assert.AreEqual(result[1].Author, "David Nicholls");

        }

        [TestMethod]
        public void TestGetBook()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            var getBookObj = new Book { Id = 2, Author = "Huma" };
            BookRepoMockClass.Setup(x => x.GetBook(2)).Returns(getBookObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.Get(2);
            var resultBook = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(2, resultBook.Content.Id);
            Assert.AreEqual(resultBook.Content.Author, "Huma");
        }

        [TestMethod]
        public void TestGetBooksByAuthor()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            List<Book> getBooksObj = new List<Book>()
            {
                new Book{Id=1,  Title="Nonai", Author="Huma", PublicationYear=2011},
                new Book{Id=2, Title="Title2", Author="Huma", PublicationYear=2012}
            };

            BookRepoMockClass.Setup(x => x.GetBooksByAuthor("huma")).Returns(getBooksObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.GetBooksByAuthor("huma");
            var resultBook = result as OkNegotiatedContentResult<List<Book>>;

            //Assert
            Assert.AreEqual(resultBook.Content[0].Title, "Nonai");
            Assert.AreEqual(resultBook.Content[1].Author, "Huma");

        }
        [TestMethod]
        public void TestGetAuthorByBook()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            string expected = "Huma";
            BookRepoMockClass.Setup(x => x.GetAuthorByBook(2)).Returns(expected);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.GetAuthorByBook(2);
            var resultBook = result as OkNegotiatedContentResult<string>;

            //Assert
            Assert.AreEqual(resultBook.Content, expected);

        }
        [TestMethod]
        public void TestGetBooksByAuthorAndYear()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            List<Book> getBooksObj = new List<Book>()
            {
                new Book{Id=1,  Title="Nonai", Author="Huma", PublicationYear=2019},
                new Book{Id=2, Title="Title2", Author="Huma", PublicationYear=2019}
            };

            BookRepoMockClass.Setup(x => x.GetBooksByAuthorAndYear("huma", 2019)).Returns(getBooksObj);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.GetBooksByAuthorAndYear("huma", 2019);
            var resultBook = result as OkNegotiatedContentResult<List<Book>>;

            //Assert
            Assert.AreEqual(resultBook.Content[0].PublicationYear, 2019);
            Assert.AreEqual(resultBook.Content[1].Author, "Huma");
        }

        [TestMethod]
        public void TestPost()
        {
            //Arrange 
            var BookRepoMockClass = new Mock<IBookRepo>();
            var book = new Book { Title = "Nonai", Author = "Huma", PublicationYear = 2019, Isavailable = true };
            BookRepoMockClass.Setup(x => x.AddNewBook(book)).Returns(book);
            var booksController = new BooksController(BookRepoMockClass.Object);
            //Act
            IHttpActionResult result = booksController.Post(book);
            var resultBook = result as OkNegotiatedContentResult<Book>;
            //Assert
            Assert.AreEqual(resultBook.Content.Author, "Huma");
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            var expected = true;
            BookRepoMockClass.Setup(x => x.RemoveBook(2)).Returns(expected);
            var booksController = new BooksController(BookRepoMockClass.Object);
            //Act
            IHttpActionResult result = booksController.Delete(2);
            var resultDel = result as OkNegotiatedContentResult<bool>;
            //Assert
            Assert.AreEqual(resultDel.Content, true);
        }

        [TestMethod]
        public void TestPut()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            int id = 1;
            Book book = new Book { Id = 1, Title = "Nonai", Author = "Huma", PublicationYear = 2019, Isavailable = true };

            BookRepoMockClass.Setup(x => x.UpdateBook(id, book)).Returns(book);
            var booksController = new BooksController(BookRepoMockClass.Object);

            //Act
            IHttpActionResult result = booksController.Put(id, book);
            var resultBooks = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(resultBooks.Content, book);
        }

        [TestMethod]
        public void TestAddCost()
        {
            //Arrange
            var BookRepoMockClass = new Mock<IBookRepo>();
            int id = 2;
            Cost cost = new Cost { Price = 220, Discount = true };
            Book book = new Book { Id = 2, Title = "Nonai", Author = "Huma", PublicationYear = 2019, Isavailable = true };
            book.cost = cost;
            BookRepoMockClass.Setup(x => x.AddCost(id, cost)).Returns(book);
            var booksController = new BooksController(BookRepoMockClass.Object);
            //Act
            IHttpActionResult result = booksController.AddCostToBook(id, cost);
            var resultBooks = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(resultBooks.Content.cost.Price, 220);

        }

    }
}
