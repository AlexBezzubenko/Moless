using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MoreLess.Models
{
    public class Bid
    {
        public long Id { get; internal set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public virtual ApplicationUser user { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        public Bid()
        {
            Timestamp = DateTime.Now;
        }
    }
}