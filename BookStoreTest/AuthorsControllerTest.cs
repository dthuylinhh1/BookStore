using BookStore.Controllers;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreTest
{
    //make this class public so the unit test can be run
    [TestClass]
    public class AuthorsControllerTest
    {
        //create global AuthorsController instance
        AuthorsController authorsController;

        //create global Author list for use in all unit tests
        List<Author> authors;
        //mock db object
        private cp2084bookstoreContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            //use in-memory database instead of connecting to SQL Server 
            //similar to HTML local storage
            var options = new DbContextOptionsBuilder<cp2084bookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new cp2084bookstoreContext(options);
            authors = new List<Author>();
            //create mock data and add to in-memory database
            authors.Add(new Author
            {
                AuthorId = 50,
                FirstName = "SomeName",
                LastName="SomeOtherName"
            });

            authors.Add(new Author
            {
                AuthorId = 60,
                FirstName = "SecondName",
                LastName = "SecondOtherName"
            });
            //add each author to the list
            authors.Add(new Author
            {
                AuthorId = 70,
                FirstName = "ThirdName",
                LastName = "ThirdOtherName"
            });

            foreach(var p in authors)
            {
                _context.Author.Add(p); // add each author to in-memory db
            }
            _context.SaveChanges();

            //this is the last step
            authorsController = new AuthorsController(_context);
        }

        [TestMethod]
        public void IndexLoadsCorrectView()
        {
            var result = authorsController.Index().Result;

            var viewResult = (ViewResult)result;

            Assert.AreEqual("Index", viewResult.ViewName);
        }

        [TestMethod]
        public void IndexReturnsAuthors()
        {
            //act
            var result = authorsController.Index().Result;

            //get the model(data)
            var viewResult = (ViewResult)result;

            //assert - convert result to list of author and compare to mock author list
            CollectionAssert.AreEqual(authors, (List<Author>)viewResult.Model);
        }

        [TestMethod]
        public void DetaisMissingId()
        {
            //act
            var result = authorsController.Details(null).Result;

            //assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            //act
            var result = authorsController.Details(9999).Result;

            //assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DetailsValidIdLoadAuthor()
        {
            //act
            var result = authorsController.Details(60).Result;
            var viewResult = (ViewResult)result;

            //assert
            Assert.AreEqual(authors[1], viewResult.Model);
        }

        [TestMethod]
        public void CreatePostInvalidData()
        {
            //arrange
            var author = new Author
            {
                //create author object with missing firstname which is required
                AuthorId = 99,
                LastName = "TestOnee"
            };

            authorsController.ModelState.AddModelError("Error", "Fake model error");
            /*var result = _context.Author.Add(author);
            _context.SaveChanges();*/

            //act
            var result = authorsController.Create(author).Result;
            var viewResult = (ViewResult)result;
            //assert
            Assert.AreEqual("Create", viewResult.ViewName);
        }

        [TestMethod]
        public void CreatePostAddsAuthor()
        {
            //arrange
            var author = new Author
            {
                //create author object with missing firstname which is required
                AuthorId = 99,
                FirstName = "TestOne",
                LastName = "TestOnee"
            };

            //act
            var result = authorsController.Create(author);

            //assert
            Assert.AreEqual(_context.Author.LastOrDefault(), author);
        }

        [TestMethod]
        public void CreatePostRedirectsToIndex()
        {
            //arrange
            var author = new Author
            {
                //create author object with missing firstname which is required
                AuthorId = 99,
                FirstName = "TestOne",
                LastName = "TestOnee"
            };

            //act
            var result = authorsController.Create(author);
            var redirectResult = (RedirectToActionResult)result.Result;
            //assert
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        


        

    }
}
