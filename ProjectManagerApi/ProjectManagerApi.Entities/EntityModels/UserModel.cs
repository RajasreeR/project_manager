using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.Entities.EntityModels
{
    public class UserModel
    {
        public long ID { get; set; }

        [Required] 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public long? ProjectId { get; set; }
        public long? TaskId { get; set; }
    }
}
