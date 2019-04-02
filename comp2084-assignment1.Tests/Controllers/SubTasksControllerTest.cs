using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using comp2084_assignment1;
using comp2084_assignment1.Controllers;
using Moq;
using comp2084_assignment1.Models;


namespace comp2084_assignment1.Tests.Controllers
{
    [TestClass]
    public class SubTasksControllerTest
    {
        //Moq Data
        SubTasksController controller;
        List<SubTask> subtasks;

        [TestInitialize]
        public void TestInitialize()
        {
            subtasks = new List<SubTask>
        {
            new SubTask { SubID = 01, SubName = "Finsh part 1", SubStatus = true, TaskID = 01},
            new SubTask { SubID = 02, SubName = "Finsh part 2", SubStatus = false, TaskID = 01},
            new SubTask { SubID = 03, SubName = "Finsh part 3", SubStatus = false, TaskID = 01}
        };

        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            SubTasksController controller = new SubTasksController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
