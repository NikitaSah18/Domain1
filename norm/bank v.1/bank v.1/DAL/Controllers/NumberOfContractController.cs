using Bank.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bank_v._1.DAL.Controllers
{
    [ApiController]
    [Route("/NumberOfContract")]
    public class NumberOfContractController : Controller
    {
        ApplicationContext db;
        public NumberOfContractController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NumberOfContract>>> Get()
        {
            return await db.NumberOfContract.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LinkedList<NumberOfContract>>> GetClient(int id)
        {
            NumberOfContract number = await db.NumberOfContract.FirstOrDefaultAsync(x => x.Id == id);
            if (number == null)
                return NotFound();
            return new ObjectResult(number);
        }



        [HttpPost]
        public async Task<ActionResult<NumberOfContract>> Post(NumberOfContract number)
        {
            if (number == null)
            {
                return BadRequest();
            }

            db.NumberOfContract.Add(number);
            await db.SaveChangesAsync();
            return Ok(number);
        }


        [HttpPut]
        public async Task<ActionResult<NumberOfContract>> Put(NumberOfContract number)
        {
            if (number == null)
            {
                return BadRequest();
            }
            if (!db.NumberOfContract.Any(x => x.Id == number.Id))
            {
                return NotFound();
            }

            db.Update(number);
            await db.SaveChangesAsync();
            return Ok(number);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<NumberOfContract>> Delete(int Id)
        {
            var number = db.NumberOfContract.FirstOrDefault(x => x.Id == Id);
            if (number == null)
            {
                return NotFound();
            }
            db.NumberOfContract.Remove(number);
            await db.SaveChangesAsync();
            return Ok(number);
        }
    }

}

