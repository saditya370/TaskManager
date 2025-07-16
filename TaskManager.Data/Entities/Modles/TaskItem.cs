using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Entities.Modles
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Guid ListId { get; set; }
        public TaskList List { get; set; } = null!;

        public Guid? AssignedToId { get; set; }
        public User? AssignedTo { get; set; }

    }

}
