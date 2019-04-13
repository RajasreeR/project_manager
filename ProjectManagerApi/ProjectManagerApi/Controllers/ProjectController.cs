using ProjectManagerApi.Business;
using ProjectManagerApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagerApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        ProjectBo projBusiness = new ProjectBo();

        [HttpGet]
        [Route("api/projects/get")]
        public IEnumerable<Entities.EntityModels.ProjectModel> GetAllProjects()
        {
            return projBusiness.GetAllProjects();
        }

        [HttpPost]
        [Route("api/projects/update")]
        public ProjectUpdateResponse CreateUpdateProject([FromBody]Entities.EntityModels.ProjectModel projectData)
        {
            ProjectUpdateResponse response = new ProjectUpdateResponse();
            response.Project = projBusiness.AddUpdateProject(projectData);
            response.Status = new Status() { Message = "Successfully created/update project", Result = true };
            return response;
        }
    }
}
