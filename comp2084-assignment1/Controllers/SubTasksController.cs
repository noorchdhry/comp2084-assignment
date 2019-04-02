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
    public class SubTasksController : Controller
    {
        IMockSubTasks db;

        public SubTasksController()
        {
            this.db = new IDataSubTasks();
        }
        public SubTasksController(IMockSubTasks mockDb)
        {
            this.db = mockDb;
        }

        // GET: SubTasks
        [AllowAnonymous]
        public ActionResult Index()
        {
            var subTasks = db.subtasks.Include(s => s.TaskList);
            return View("Index", subTasks.ToList());
        }

        // GET: SubTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SubTask subTask = db.SubTasks.Find(id);
            SubTask subTask = db.subtasks.SingleOrDefault(s => s.SubID == id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View("Details", subTask);
        }

        // GET: SubTasks/Create
        public ActionResult Create()
        {
            ViewBag.TaskID = new SelectList(db.tasklists, "TaskID", "TaskName");
            return View("Create");
        }

        // POST: SubTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubID,SubName,SubStatus,TaskID")] SubTask subTask)
        {
            if (ModelState.IsValid)
            {
                //db.SubTasks.Add(subTask);
                //db.SaveChanges();
                db.Save(subTask);
                return RedirectToAction("Index");
            }

            ViewBag.TaskID = new SelectList(db.tasklists, "TaskID", "TaskName", subTask.TaskID);
            return View(subTask);
        }

        // GET: SubTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SubTask subTask = db.SubTasks.Find(id);
            SubTask subTask = db.subtasks.SingleOrDefault(s => s.SubID == id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskID = new SelectList(db.tasklists, "TaskID", "TaskName", subTask.TaskID);
            return View("Edit", subTask);
        }

        // POST: SubTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubID,SubName,SubStatus,TaskID")] SubTask subTask)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(subTask).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(subTask);
                return RedirectToAction("Index");
            }
            ViewBag.TaskID = new SelectList(db.tasklists, "TaskID", "TaskName", subTask.TaskID);
            return View(subTask);
        }

        // GET: SubTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SubTask subTask = db.SubTasks.Find(id);
            SubTask subTask = db.subtasks.SingleOrDefault(s => s.SubID == id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View("Index", subTask);
        }

        // POST: SubTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //SubTask subTask = db.SubTasks.Find(id);
            SubTask subTask = db.subtasks.SingleOrDefault(s => s.SubID == id);
            //db.sub.Remove(subTask);
            //db.SaveChanges();
            db.Delete(subTask);
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
