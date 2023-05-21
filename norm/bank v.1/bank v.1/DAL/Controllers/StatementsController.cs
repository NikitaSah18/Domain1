using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Bank.Models;

namespace bank_v._1.DAL.Controllers
{
    [ApiController]
    [Route("/Statement")]
    public class StatementController : ControllerBase
    {
        ApplicationContext db;
        public StatementController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statement>>> Get()
        {
            return await db.Statement.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LinkedList<Statement>>> GetClient(int id)
        {
            Statement statement = await db.Statement.FirstOrDefaultAsync(x => x.Id == id);
            if (statement == null)
                return NotFound();
            return new ObjectResult(statement);
        }



        [HttpPost]
        public async Task<ActionResult<Statement>> Post(Statement statement)
        {
            if (statement == null)
            {
                return BadRequest();
            }

            db.Statement.Add(statement);
            await db.SaveChangesAsync();
            return Ok(statement);
        }


        [HttpPut]
        public async Task<ActionResult<Statement>> Put(Statement statement)
        {
            if (statement == null)
            {
                return BadRequest();
            }
            if (!db.Client.Any(x => x.Id == statement.Id))
            {
                return NotFound();
            }

            db.Update(statement);
            await db.SaveChangesAsync();
            return Ok(statement);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Statement>> Delete(int Id)
        {
            Statement statement = db.Statement.FirstOrDefault(x => x.Id == Id);
            if (statement == null)
            {
                return NotFound();
            }
            db.Statement.Remove(statement);
            await db.SaveChangesAsync();
            return Ok(statement);
        }
    }
}
