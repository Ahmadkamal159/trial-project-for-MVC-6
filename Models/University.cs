using System.ComponentModel.DataAnnotations;
using System.Reflection;
using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class University:IBasicInfo
    {
        public int Id { get; set; }
        [StringLength(30,ErrorMessage = "Max Length of the name is 30)")]
        [Display(Name ="University Name")]
        [Required(ErrorMessage = "Please enter university name")]
        public string Name { get; set; }
        [StringLength(40)]
        [Display(Name ="university Location")]
        public string Location { get; set; }
        public List<College> colleges { get; set; }
    }
}
