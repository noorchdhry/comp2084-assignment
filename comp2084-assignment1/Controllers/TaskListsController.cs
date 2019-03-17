using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comp2084_assignment1.Models;

namespace comp2084_assignment1.Controllers
{
    [Authorize]
    public class TaskListsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: TaskLists
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.TaskLists.ToList());
        }

        // GET: TaskLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // GET: TaskLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,TaskName,TaskStatus,Description")] TaskList taskList)
        {
            if (ModelState.IsValid)
            {
                db.TaskLists.Add(taskList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskList);
        }

        // GET: TaskLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // POST: TaskLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,TaskName,TaskStatus,Description")] TaskList taskList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskList);
        }

        // GET: TaskLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // POST: TaskLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskList taskList = db.TaskLists.Find(id);
            db.TaskLists.Remove(taskList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
