using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class CollegeDTO : IBasicInfo
    {
        public int Id { get ; set; }
        [Display(Name = "College Name")]
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
    }
}
