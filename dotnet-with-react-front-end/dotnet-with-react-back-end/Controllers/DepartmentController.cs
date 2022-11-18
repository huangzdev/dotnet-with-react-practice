using dotnet_with_react_back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace dotnet_with_react_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly DotnetReactPracticeContext _context;

        //dependency injection
        public DepartmentController(DotnetReactPracticeContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var departments = _context.Departments.ToList();

            return new JsonResult(departments);
        }

        [HttpPost]
        public JsonResult Post(Department department)
        {
            _context.Add(department);
            _context.SaveChanges();

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Department department)
        {
            _context.Update(department);
            _context.SaveChanges();

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(dep => dep.DepartmentId == id);

            if (department != null)
            {
                _context.Remove(department);
                _context.SaveChanges();
            }

            return new JsonResult("Deleted Successfully");
        }

        [Route("GetAllDepartmentNames")]
        public JsonResult GetAllDepartmentNames()
        {
            return new JsonResult(_context.Departments.Select(dep => dep.DepartmentName).ToList());
        }
    }
}
