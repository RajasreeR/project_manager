using ProjectManagerApi.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApi.Models
{
    public class ProjectUpdateResponse
    {
        public ProjectModel Project { get; set; }
        public Status Status { get; set; }
    }
}