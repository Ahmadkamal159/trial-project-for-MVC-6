using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class Student : IBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Image { get; set; }
        public List<subjectDTO> Subjects { get; set; }
        public List<TeacherDTO> Teachers { get; set; }
        public Department Department { get; set; }
    }
}
