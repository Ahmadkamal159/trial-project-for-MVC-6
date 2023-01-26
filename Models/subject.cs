using trial_project_for_MVC_Core.Interfaces;

namespace trial_project_for_MVC_Core.Models
{
    public class subject : IBasicInfo
    {
        public int Id { get; set;}
        public string Name { get; set;}
        //public double? Grade { get; set; }
        //readonly double SubjectGrade;
        //readonly double Percentage;
        public List<AppUser> Students { get; set; }
        public List<AppUser> Teachers { get; set; }

    }
}
