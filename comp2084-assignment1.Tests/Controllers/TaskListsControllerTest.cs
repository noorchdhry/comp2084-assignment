using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using comp2084_assignment1;
using comp2084_assignment1.Controllers;

namespace comp2084_assignment1.Tests.Controllers
{
    [TestClass]
    class TaskListsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            TaskListsController controller = new TaskListsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
