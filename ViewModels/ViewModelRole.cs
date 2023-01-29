using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trial_project_for_MVC_Core.ViewModels
{
    public class ViewModelRole
    {
        [Required,Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
