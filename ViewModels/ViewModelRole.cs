using System.ComponentModel.DataAnnotations;

namespace trial_project_for_MVC_Core.ViewModels
{
    public class ViewModelRole
    {
        [Required,Display(Name ="Role Name")]
        public string RoleName { get; set; }

        public string Id { get; set; }

    }
}
