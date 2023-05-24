using CRUD_API_with_Database.Data;
using CRUD_API_with_Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace CRUD_API_with_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //    private static List<Users> callUsers = new List<Users>
        //{   new Users
        //    {
        //        Id = 1,
        //        Name = "salam adil",
        //        Password =07512562442,
        //        Email="salamadilsaidan@gmail.com"

        //    } 
        //};

        private Datacontext _context;
        public UsersController(Datacontext context)
        {

            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> get()
        {
            return Ok(await _context.UsersTable.ToListAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Users>>> get(int id)
        {
            var getusers = await _context.UsersTable.FindAsync(id);
            if (getusers == null)
            {
                return BadRequest("NOT FOUND");
            }
            return Ok(getusers);

        }
        [HttpPost]
        public async Task<ActionResult<List<Users>>> post(Users users)
        {
            _context.UsersTable.Add(users);
            await _context.SaveChangesAsync();
            return Ok(await _context.UsersTable.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Users>>> put(Users users)
        {
            var edituser = await _context.UsersTable.FindAsync(users.Id)
            ; if (edituser == null)
            {
                return BadRequest("NOT FOUND ");

            }
            edituser.Id = users.Id;
            edituser.Name = users.Name;
            edituser.Password = users.Password;
            edituser.Email = users.Email;
            await _context.SaveChangesAsync();
            return Ok(await _context.UsersTable.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Users>>> delete(int id)
        {
            var deleteUsers = await _context.UsersTable.FindAsync(id);
            if (deleteUsers == null) { return BadRequest("NOT FOUND"); }
            _context.UsersTable.Remove(deleteUsers);
            await _context.SaveChangesAsync();
            return Ok(await _context .UsersTable.ToListAsync());

        }
    }
}
