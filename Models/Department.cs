using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class Department : IBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set;}
        //public int CollegeId;
        public College College { get; set; }
        public List<StudentDTO> students { get; set; }
        public List<TeacherDTO> teachers { get; set; }
    }
}
