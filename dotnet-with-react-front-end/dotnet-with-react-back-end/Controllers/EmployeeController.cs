using dotnet_with_react_back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_with_react_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DotnetReactPracticeContext _context;
        private readonly IWebHostEnvironment _environment;

        //dependency injection
        public EmployeeController(DotnetReactPracticeContext context, IWebHostEnvironment env)
        {
            this._context = context;
            this._environment = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var employees = _context.Employees.ToList();

            return new JsonResult(employees);
        }

        [HttpPost]
        public JsonResult Post(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(emp => emp.EmployeeId == id);

            if (employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }

            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _environment.ContentRootPath + "/Photos/" + fileName;

                using(var strem = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(strem);
                }

                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
