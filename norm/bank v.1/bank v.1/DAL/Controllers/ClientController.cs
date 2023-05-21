
using Bank.Models;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace bank_v._1.DAL.Controllers
{

    [ApiController]
    [Route("/Client")]
    public class ClientController : ControllerBase
    {
        ApplicationContext db;
        public ClientController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await db.Client.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LinkedList<Client>>> GetClient(int id)
        {
            Client client = await db.Client.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }



        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            db.Client.Add(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }


        [HttpPut]
        public async Task<ActionResult<Client>> Put(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            if (!db.Client.Any(x => x.Id == client.Id))
            {
                return NotFound();
            }

            db.Update(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Client>> Delete(int Id)
        {
            var client = db.Client.FirstOrDefault(x => x.Id == Id);
            if (client == null)
            {
                return NotFound();
            }
            db.Client.Remove(client);
            await db.SaveChangesAsync();
            return Ok(client);
        }
    }
}