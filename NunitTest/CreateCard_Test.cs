using System;
using System.Web.Mvc;
using NUnit.Framework;
using umbraco.Controllers;

namespace NunitTest
{
    [TestFixture]
    public class CreateCard_Test
    {

        HomeController controller;
        [SetUp]
        public void Setup()
        {

            controller = new HomeController();
        }

        [Test]
        public void createCard_work()
        {

        }


    }
}
