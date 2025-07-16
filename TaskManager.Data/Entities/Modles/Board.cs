using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Data.Entities.Modles
{
    public class Board
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid OwnerId { get; set; }

        public User Owner { get; set; } = null!;
    }

}
