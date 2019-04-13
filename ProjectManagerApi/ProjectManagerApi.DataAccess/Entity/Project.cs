using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerApi.DataAccess.Entity
{
    public class Project
    {
        public long ProjectID { get; set; }

        [Column("Project")]
        [StringLength(250)]
        public string ProjectName{ get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? Priority { get; set; }

        [DefaultValue("Active")]
        public string Status { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<User> Users { get; set; }


    }
}
