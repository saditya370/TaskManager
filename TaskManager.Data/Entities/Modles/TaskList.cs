using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Entities.Modles
{
    public class TaskList
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public Guid BoardId { get; set; }

        public Board Board { get; set; } = null!;
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

}
