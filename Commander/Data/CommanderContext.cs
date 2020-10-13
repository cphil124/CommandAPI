using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    // DbContext: Object representing connection to database. Can be used to write and execute queries, materialize query results as entity objects, 
    //            track changes to those objects, persist object changes back to the database, and bind objects in memory to UI controls. 
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }

        // DbSet: Representation of collections of the specified entities in the context. 
        public DbSet<Command> Commands { get; set; }

    }
}