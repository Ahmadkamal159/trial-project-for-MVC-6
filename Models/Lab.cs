using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class Lab : IBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set ; }
        public List<AppUser> Students { get; set; }
        public List<AppUser> Teachers { get; set; }
        public List<Department> Departments { get; set; }
    }
}
