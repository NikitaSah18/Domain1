using Bank.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bank_v._1.DAL.Controllers
{
    [ApiController]
    [Route("/Post")]
    public class PostController : Controller
    {
        ApplicationContext db;
        public PostController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return await db.Post.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LinkedList<Post>>> GetClient(int id)
        {
            Post post = await db.Post.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
                return NotFound();
            return new ObjectResult(post);
        }



        [HttpPost]
        public async Task<ActionResult<Post>> Post(Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }

            db.Post.Add(post);
            await db.SaveChangesAsync();
            return Ok(post);
        }


        [HttpPut]
        public async Task<ActionResult<Post>> Put(Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            if (!db.Post.Any(x => x.Id == post.Id))
            {
                return NotFound();
            }

            db.Update(post);
            await db.SaveChangesAsync();
            return Ok(post);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Post>> Delete(int Id)
        {
            var post = db.Post.FirstOrDefault(x => x.Id == Id);
            if (post == null)
            {
                return NotFound();
            }
            db.Post.Remove(post);
            await db.SaveChangesAsync();
            return Ok(post);
        }
    }
}

