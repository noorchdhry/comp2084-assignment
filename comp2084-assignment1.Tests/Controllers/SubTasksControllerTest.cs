using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using comp2084_assignment1;
using comp2084_assignment1.Controllers;

namespace comp2084_assignment1.Tests.Controllers
{
    [TestClass]
    public class SubTasksControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            SubTasksController controller = new SubTasksController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
