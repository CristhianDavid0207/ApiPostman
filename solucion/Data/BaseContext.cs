using Microsoft.EntityFrameworkCore;
using solucion.Models;

namespace solucion.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){

        }

        public DbSet<User> users { get; set;}
    }
}