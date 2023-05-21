using Bank.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bank_v._1.DAL.Controllers
{
    [ApiController]
    [Route("/Employee")]
    public class EmployeeController : Controller
    {
        ApplicationContext db;
        public EmployeeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await db.Employee.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LinkedList<Employee>>> GetClient(int id)
        {
            Employee employee = await db.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
                return NotFound();
            return new ObjectResult(employee);
        }



        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            db.Employee.Add(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }


        [HttpPut]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            if (!db.Employee.Any(x => x.Id == employee.Id))
            {
                return NotFound();
            }

            db.Update(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Employee>> Delete(int Id)
        {
            var employee = db.Employee.FirstOrDefault(x => x.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            db.Employee.Remove(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
