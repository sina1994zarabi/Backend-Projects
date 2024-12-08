using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Entity
{
    public enum status
    {
        Todo,
        InProgress,
        Done
    }

    public class UserTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public status Status { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Updatedat { get; set; }
    }
}
