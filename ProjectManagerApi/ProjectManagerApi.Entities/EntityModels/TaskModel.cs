using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.Entities.EntityModels
{
    public class TaskModel
    {
        public long TaskId { get; set; }

        public long? ParentId { get; set; }

        public string ParentName { get; set; }

        public long? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public short? Priority { get; set; }

        public bool? Status { get; set; }

        public long? UserID { get; set; }
        public string UserName { get; set; }
    }
}
