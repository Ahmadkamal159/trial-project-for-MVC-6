using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trial_project_for_MVC_Core.EntityDB;
using trial_project_for_MVC_Core.Models;

namespace trial_project_for_MVC_Core.Controllers
{
    public class CollegeController : Controller
    {
        UniversityEntity Context;
        public CollegeController(UniversityEntity _Context)
        {
            Context= _Context;
        }

        public IActionResult Index()
        {
            List<College> Colleges = Context.Colleges.Include(x=>x.University).ToList();
            List<CollegeDTO> collegeDTOs = new();
            foreach(var item in Colleges)
            {
                CollegeDTO collegeDTO = new();
                collegeDTO.Id=item.Id;
                collegeDTO.Name = item.Name;
                collegeDTO.UniversityId = item.University.Id;
                collegeDTO.UniversityName = item.University.Name;
                collegeDTOs.Add(collegeDTO);
            }
            
            return View(collegeDTOs);
        }
        public ActionResult Add()
        {
            ViewData["universities"] = Context.Universities.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind(include:"Id,Name,UniversityId")]CollegeDTO collegeDTO)
        {
            ModelState.Remove("UniversityName");
            if (ModelState.IsValid)
            {
                College col = new();
                
                col.Name=collegeDTO.Name;
                ////col.University = new University();
                //col.UniversityId = collegeDTO.UniversityId;
                ////col.University.Id = collegeDTO.UniversityId;
                col.University = Context.Universities.FirstOrDefault(x => x.Id == collegeDTO.UniversityId);

                Context.Colleges.Add(col);
                Context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(collegeDTO);
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return Content("No Colleges to Edit");
            }
            ViewData["universities"] = Context.Universities.ToList();
            College col = Context.Colleges.Include(x=>x.University).SingleOrDefault(x => x.Id == Id);
            CollegeDTO collegeDTO = new() { Id=col.Id,Name=col.Name,UniversityId=col.University.Id};

            return View(collegeDTO);
        }
        [HttpPost]
        public IActionResult Edit(CollegeDTO collegeDTO)
        {
            
            ModelState.Remove("UniversityName");
            if (ModelState.IsValid)
            {
                College col = new() { Id = collegeDTO.Id, Name = collegeDTO.Name };
                col.University = Context.Universities.SingleOrDefault(x => x.Id == collegeDTO.UniversityId);
                Context.Colleges.Update(col);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collegeDTO);

        }
    }

}
