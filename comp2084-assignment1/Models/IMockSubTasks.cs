using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp2084_assignment1.Models
{
    public interface IMockSubTasks
    {
        IQueryable<SubTask> subtasks { get; }
        IQueryable<TaskList> tasklists { get; }

        SubTask Save(SubTask subtasks);

        void Delete(SubTask subtasks);

        void Dispose();
    }
}
