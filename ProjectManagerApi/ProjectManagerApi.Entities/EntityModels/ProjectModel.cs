using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.Entities.EntityModels
{
    public class ProjectModel
    {
        public long ProjectID { get; set; }

        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? Priority { get; set; }
        public string Status { get; set; }
        public int? TaskCount { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
