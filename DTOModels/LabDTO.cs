using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class LabDTO : IBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set ; }

    }
}
