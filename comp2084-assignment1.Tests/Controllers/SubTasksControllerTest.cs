﻿using System;
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
        Mock<IMockSubTasks> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            subtasks = new List<SubTask>
        {
            new SubTask { SubID = 01, SubName = "Finsh part 1", SubStatus = true, TaskID = 01},
            new SubTask { SubID = 02, SubName = "Finsh part 2", SubStatus = false, TaskID = 01},
            new SubTask { SubID = 03, SubName = "Finsh part 3", SubStatus = false, TaskID = 01}
        };

            mock = new Mock<IMockSubTasks>();
            mock.Setup(s => s.subtasks).Returns(subtasks.AsQueryable());

            controller = new SubTasksController(mock.Object);

        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
         
        [TestMethod]
        public void IndexLoadsSubTasks()
        {
            //Act
            var results = (List<SubTask>)((ViewResult)controller.Index()).Model;
            //Assert
            CollectionAssert.AreEqual(subtasks.ToList(), results);
        }

        [TestMethod]
        public void EditPostIndexViewLoads()
        {
            //Act
            ViewResult result = controller.Edit(001) as ViewResult;
            //Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void CreateGetViewLoads()
        {
            //Act
            ViewResult result = controller.Create() as ViewResult;
            //Assert 
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void DetailsViewLoads()
        {
            //Act
            ViewResult result = controller.Details(001) as ViewResult;
            //Assert
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void DeleteViewLoads()
        {
            //Act
            ViewResult result = controller.Delete(001) as ViewResult;
            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void CreatePostViewLoads()
        {
            //Act
            ViewResult result = controller.Create(subtasks[0]) as ViewResult;
            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void EditPostIsNotNull()
        {
            //Act
            ViewResult result = controller.Edit(001) as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditSaves()
        {
            //Act
            var result = (List<SubTask>)((ViewResult)controller.Edit(01)).Model;
            //Assert
            Assert.AreEqual(subtasks.SingleOrDefault(s => s.SubID == 01), result);
        }

        [TestMethod]
        public void ValidDeleteRedirectLoading()
        {
            //Act
            RedirectToRouteResult result = controller.DeleteConfirmed(01) as RedirectToRouteResult;
            var resultlist = result.RouteValues.ToArray();
            //Assert
            Assert.AreEqual("Index", resultlist[0].Value);
        }

        [TestMethod]
        public void InvalidDeleteRedirectLoading()
        {
            //Act
            RedirectToRouteResult result = controller.DeleteConfirmed(04) as RedirectToRouteResult;
            var resultlist = result.RouteValues.ToArray();
            //Assert
            Assert.AreEqual("Index", resultlist[0].Value);
        }

        [TestMethod]
        public void InvalidCreateRedirectLoading()
        {
            //Act
            RedirectToRouteResult result = controller.Create(subtasks[0]) as RedirectToRouteResult;
            var resultlist = result.RouteValues.ToArray();
            //Assert
            Assert.AreEqual("Index", resultlist[0].Value);
        }

        [TestMethod]
        public void DetailsViewSubTask()
        {
            //Act
            var result = (List<SubTask>)((ViewResult)controller.Details(01)).Model;
            //Assert
            Assert.AreEqual(subtasks.SingleOrDefault(s => s.SubID == 01), result);
        }

        [TestMethod]
        public void DetailsView404Error()
        {
            //Act
            HttpNotFoundResult result = controller.Details(04) as HttpNotFoundResult;
            //Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DetailsViewNullId()
        {
            //Act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;
            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }

    }
}
