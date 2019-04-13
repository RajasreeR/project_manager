using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.DataAccess.Entity
{
    public class Task
    {
        public long TaskID { get; set; }
        public long? ParentTaskID { get; set; }
        public long? ProjectID { get; set; }
        public long? UserID { get; set; }

        [Column("Task")]
        [StringLength(250)]
        public string Task1{ get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? Priority { get; set; }
        public string Status { get; set; }

        public virtual User Users { get; set; }
        public virtual ParentTask ParentTasks { get; set; }
        public virtual Project Projects { get; set; }


    }
}
