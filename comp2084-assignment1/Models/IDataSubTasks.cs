using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comp2084_assignment1.Models
{
    public class IDataSubTasks : IMockSubTasks
    {
        private DbModel db = new DbModel();

        public IQueryable<SubTask> subtasks { get { return db.SubTasks; } }

        public IQueryable<TaskList> tasklists { get { return db.TaskLists; } }

        public void Delete(SubTask subtasks)
        {
            db.SubTasks.Remove(subtasks);
            db.SaveChanges();
        }

        public SubTask Save(SubTask subtasks)
        {
            if (subtasks.SubID == 0)
            {
                db.SubTasks.Add(subtasks);
            }
            else
            {
                db.Entry(subtasks).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return subtasks;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}