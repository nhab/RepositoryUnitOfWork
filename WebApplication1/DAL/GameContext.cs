using GameApplication.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace GameApplication.DAL
{
    public class GameContext : DbContext
    {
        public GameContext() : base("GameContext")
        {
        }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}