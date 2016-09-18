using MoreLess.Models;
using System.Data.Entity;

namespace MoreLess.Models
{
    public class AuctionContext:DbContext
    {
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Lot> Lots { get; set; }
        /*static AuctionContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AuctionContext>());
        }*/
    }
}