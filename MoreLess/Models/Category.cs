using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MoreLess.Models
{
    public class Category
    {
        [Required]
        public long Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 5)]
        public string Title { get; set; }

        public virtual Collection<Category> Subcategories { get; set; }
        public int SubcategoriesCount
        {
            get { return Subcategories.Count; }
        }

        public Category()
        {
            Subcategories = new Collection<Category>();
        }
    }
}