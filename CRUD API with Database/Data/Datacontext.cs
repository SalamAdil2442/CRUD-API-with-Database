using CRUD_API_with_Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CRUD_API_with_Database.Data
{
    public class Datacontext : DbContext    
    {
        public Datacontext(DbContextOptions<Datacontext> options):base(options) { }
        public DbSet<Users> UsersTable => Set<Users>();
    }
}
