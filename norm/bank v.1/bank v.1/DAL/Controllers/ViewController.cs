using Bank.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace bank_v._1.DAL.Controllers
{
   
       [ApiController]
        [Route("/View")]
        public class ViewController : ControllerBase
        {
            ApplicationContext db;
            public ViewController(ApplicationContext context)
            {
                db = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Bank.Models.View>>> Get()
            {
                return await db.View.ToListAsync();
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<LinkedList<Bank.Models.View>>> GetClient(int id)
            {
                var view = await db.View.FirstOrDefaultAsync(x => x.Id == id);
                if (view == null)
                    return NotFound();
                return new ObjectResult(view);
            }



            [HttpPost]
            public async Task<ActionResult<Bank.Models.View>> Post(Bank.Models.View view)
        {
                if (view == null)
                {
                    return BadRequest();
                }

                db.View.Add(view);
                await db.SaveChangesAsync();
                return Ok(view );
            }


            [HttpPut]
            public async Task<ActionResult<Bank.Models.View>> Put(Bank.Models.View view)
        {
                if (view == null)
                {
                    return BadRequest();
                }
                if (!db.View.Any(x => x.Id == view.Id))
                {
                    return NotFound();
                }

                db.Update(view);
                await db.SaveChangesAsync();
                return Ok(view);
        }
        [HttpDelete("{Id}")]
            public async Task<ActionResult<Bank.Models.View>> Delete(int Id)
            {
            Bank.Models.View view = db.View.FirstOrDefault(x => x.Id == Id);
                if (view == null)
                {
                    return NotFound();
                }
                db.View.Remove(view);
                await db.SaveChangesAsync();
                return Ok(view);
            }
        }
}
