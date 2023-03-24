using Assesment.Data;
using Assesment.DTO;
using Assesment.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeController(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
            var employees = _dbContext.employee.Where(e => e.Isactive).ToList();
            if (employees == null)
            {
                return NoContent();
            }
            return Ok(employees);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employeeId = _dbContext.employee.Find(id);
            if (employeeId == null)
            {
                return NoContent();
            }
            return Ok(employeeId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateEmployee([FromBody] EmployeeDto employeedto)
        {
            var result = _dbContext.employee.AsQueryable().Where(x => x.EmployeeName.ToLower().Trim() == employeedto.EmployeeName.ToLower().Trim())
            .Where(x => x.DepartmentId == employeedto.DepartmentId).Any();
            if (result)
            {
                return Conflict("Employee Already Exist!!!");
            }
            var employee = _mapper.Map<Employee>(employeedto);
            _dbContext.employee.Add(employee);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetEmployeeById", new { id = employee.EmployeeID }, employee);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployee employeedto)
        {
            if (employeedto == null || id != employeedto.EmpId)
            {
                return BadRequest();
            }
            var employees = _dbContext.employee.Find(id);
            if (employees == null)
            {
                return NotFound();
            }
            employees.EmployeeName = employeedto.EmpName;
            employees.Salary = employeedto.Salary;
            employees.DepartmentId = employeedto.DepartmentId;
            employees.Isactive = employeedto.IsActive;
            var employee = _mapper.Map<Employee>(employeedto);
            _dbContext.employee.Update(employees);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var employee = _dbContext.employee.Find(id); if (employee != null)
            {
                employee.Isactive = false;
                _dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
            /* _db.employees.Remove(employee);
             _db.SaveChanges();
             return Ok("Deleted");*/
        }
    }
    
}
