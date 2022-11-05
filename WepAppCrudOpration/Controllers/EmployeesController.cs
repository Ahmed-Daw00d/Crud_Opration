using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAppCrudOpration.Data;
using WepAppCrudOpration.Models;

namespace WepAppCrudOpration.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _Context;

        public EmployeesController(AppDbContext Context)
        {
            _Context = Context;
        }

        public IActionResult Index()
        {
            var Result = _Context.Employees.Include(s=>s.Department).OrderBy(x=>x.EmployeeName).ToList();
            return View(Result);
        }

        public IActionResult Create()
        {
            ViewBag.Departments=_Context.Departments.OrderBy(x=>x.DepartmentName).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0) {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream=new FileStream(Path.Combine(@"wwwroot/","Images",ImageName),FileMode.Create);
                file[0].CopyTo(fileStream);
                model.ImageUser = ImageName;
            }
            else if(model.ImageUser == null && model.EmployeeId==null) {
                model.ImageUser = "DefultImage.png";
            }
            else
            {
                model.ImageUser = model.ImageUser;
            }
            if (ModelState.IsValid)
            {
             _Context.Employees.Add(model);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _Context.Departments.OrderBy(x => x.DepartmentName).ToList();
            return View();
        }
    }
}
