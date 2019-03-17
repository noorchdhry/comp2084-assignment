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
        private DbModel db = new DbModel();

        // GET: SubTasks
        [AllowAnonymous]
        public ActionResult Index()
        {
            var subTasks = db.SubTasks.Include(s => s.TaskList);
            return View(subTasks.ToList());
        }

        // GET: SubTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View(subTask);
        }

        // GET: SubTasks/Create
        public ActionResult Create()
        {
            ViewBag.TaskID = new SelectList(db.TaskLists, "TaskID", "TaskName");
            return View();
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
                db.SubTasks.Add(subTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskID = new SelectList(db.TaskLists, "TaskID", "TaskName", subTask.TaskID);
            return View(subTask);
        }

        // GET: SubTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskID = new SelectList(db.TaskLists, "TaskID", "TaskName", subTask.TaskID);
            return View(subTask);
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
                db.Entry(subTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskID = new SelectList(db.TaskLists, "TaskID", "TaskName", subTask.TaskID);
            return View(subTask);
        }

        // GET: SubTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return HttpNotFound();
            }
            return View(subTask);
        }

        // POST: SubTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTask subTask = db.SubTasks.Find(id);
            db.SubTasks.Remove(subTask);
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
