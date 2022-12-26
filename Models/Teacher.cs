using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class Teacher : IBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Lab> Labs { get; set; }
        public List<Department> Departments { get; set; }
    }
}
