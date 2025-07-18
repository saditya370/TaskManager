﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Entities.Modles
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = "#ffffff";

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

}
