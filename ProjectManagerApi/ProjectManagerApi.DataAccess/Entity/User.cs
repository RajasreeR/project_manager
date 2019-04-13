using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.DataAccess.Entity
{
    public class User
    {
       
        public long UserID { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public long? ProjectID { get; set; }
        public long? TaskID { get; set; }
        public virtual Project Project { get; set; }
        //public virtual Task Tasks { get; set; }

    }
}
