using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MoreLess.Models
{
    public class Lot
    {
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public virtual Category Category { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 5)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartedTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [DataType(DataType.Currency)]
        public decimal StartPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal? CurrentPrice { get; set; }

        public virtual Collection<Bid> Bids { get; private set; }
        public int BidCount
        {
            get { return Bids.Count; }
        }

        public Lot()
        {
            Bids = new Collection<Bid>();
        }
    }
}