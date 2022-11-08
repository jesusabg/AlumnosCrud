using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly DataContext _context;
        public AlumnosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetTasks")]
        public async Task<ActionResult<List<Alumnos>>> Get()
        {
           var res = await _context.ALumnosDbSet.ToListAsync();
            return Ok(res);
        }


        [HttpPost]
        [Route("PostTask")]
        public async Task<ActionResult<List<Alumnos>>> Post(Alumnos task)
        {
            await _context.ALumnosDbSet.AddAsync(task);
            await _context.SaveChangesAsync();
            return Ok(await _context.ALumnosDbSet.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Alumnos>>> DeleteTask(int id)
        {
            var task = await _context.ALumnosDbSet.FindAsync(id);
            if (task == null)
            {
                return BadRequest("Task not found");
            }
            _context.ALumnosDbSet.Remove(task);
            await _context.SaveChangesAsync();
            return Ok(await _context.ALumnosDbSet.ToListAsync());
        }
    }
}
