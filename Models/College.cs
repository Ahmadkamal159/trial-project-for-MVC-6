using System.ComponentModel.DataAnnotations;
using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class College : IBasicInfo
    {
        public int Id { get ; set; }
        public string Name { get; set; }
        public List<Department> Departments{get; set;}
        public int UniversityId;
        public University University { get; set; }
       
    }
}
