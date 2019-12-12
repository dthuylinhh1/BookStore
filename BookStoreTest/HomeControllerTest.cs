using BookStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTest
{
    [TestClass]
    public class HomeControllerTest
    {
        //declare the HomeController globally
        HomeController homeController;

        [TestInitialize]
        public void Initialize()
        {
            //this method runs automatically before every test method
            //initialize the Controller so we can test it
            homeController = new HomeController();

        }
        [TestMethod]
        public void IndexLoadsCorrectView()
        {
            //act - > call method we want to test
            var result = homeController.Index();
            //cast the result as a ViewResult object    
            var viewResult = (ViewResult)result;
            //assert -> evaluate the result to see if we got what we expected
            Assert.AreEqual("Index", viewResult.ViewName);
        }
        [TestMethod]
        public void AboutLoadsCorrectView()
        {
            //act - > call method we want to test
            var result = homeController.About();
            //cast the result as a ViewResult object    
            var viewResult = (ViewResult)result;
            //assert -> evaluate the result to see if we got what we expected
            Assert.AreEqual("About", viewResult.ViewName);
        }
        [TestMethod]
        public void ContactLoadsCorrectView()
        {
            //act - > call method we want to test
            var result = homeController.Contact();
            //cast the result as a ViewResult object    
            var viewResult = (ViewResult)result;
            //assert -> evaluate the result to see if we got what we expected
            Assert.AreEqual("Contact", viewResult.ViewName);
        }
        [TestMethod]
        public void PrivacyLoadsCorrectView()
        {
            //act - > call method we want to test
            var result = homeController.Privacy();
            //cast the result as a ViewResult object    
            var viewResult = (ViewResult)result;
            //assert -> evaluate the result to see if we got what we expected
            Assert.AreEqual("Privacy", viewResult.ViewName);
        }
    }
}
