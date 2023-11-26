using Microsoft.EntityFrameworkCore;
using Humano.Models;
namespace Api.Data
{

    
    public class _DbContext: DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options) { 
        
        }
        public DbSet<Humanos> Humanos { get; set; }

    }
}
