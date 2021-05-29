using System.Data.Entity;

namespace Coursework.Models
{
    public class TentContext : DbContext
    {
        public DbSet<Tent> Tents { get; set; }

        public DbSet<TentSelection> TentSelections { get; set; }
    }
}