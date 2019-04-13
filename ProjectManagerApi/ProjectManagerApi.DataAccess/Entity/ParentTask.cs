using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.DataAccess.Entity
{
    public class ParentTask
    {
        public long ParentTaskID { get; set; }

        [Column("ParentTask")]
        [StringLength(250)]
        public string ParentTask1 { get; set; }
    }
}
