using Assesment.Data;
using Assesment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
       private readonly ApplicationDbContext _dbContext;
        public DepartmentController(ApplicationDbContext dbContext)
        {
            _dbContext  = dbContext;
        }

        [HttpPost]
        public IActionResult AddDepartment([FromForm] Department department)
        {
            _dbContext.Add(department);
            _dbContext.SaveChanges();
            return Ok(department);
        }
        [HttpPut]
        public IActionResult EditDepartment([FromForm] Department department)
        {
            _dbContext.Update(department);
            _dbContext.SaveChanges();
            return Ok(department);
        }

    }
}
