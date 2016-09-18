using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MoreLess.Models
{
    public class AuctionDbInitializer : DropCreateDatabaseAlways<AuctionContext>
    {
        protected override void Seed(AuctionContext db)
        {
            db.Lots.Add(new Lot { Title = "Book1", Category = "Books", StartPrice = 100});
            db.Lots.Add(new Lot { Title = "Book2", Category = "Books", StartPrice = 200});
            db.Lots.Add(new Lot { Title = "Book3", Category = "Books", StartPrice = 200 });

            base.Seed(db);
        }
    }
}