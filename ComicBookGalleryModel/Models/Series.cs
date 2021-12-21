using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    // From series point of view, a series contains one or more, or many comics. (One-to-Many)
    // From comicBook's point of view a comicbook belongs to a single or one series. (Many-to-One)
    public class Series
    {
        // Default constructor to initialize the collection
        // this ensures that the ComicBooks property is ready to be used immediately after
        // instantiating a series entity object
        public Series()
        {
            ComicBooks = new List<ComicBook>();
        }
        // Series is the PRINCIPAL ENTITY and NAVIGATION PROPERTY, so setting a Id property is very important
        // Why is Id imp? so EF will know that we intend the data for the series entity to be stored in its own table.
        // EF would tread Series class as an complex type. Thus adding its Title and Description to ComicBook's database Table!
        // example https://entityframework.net/one-to-many-relationship
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        // Below defines a navigation property but it's optional. Series can be associated with more than one ComicBook,
        // thus we can define as a colletion
        public ICollection<ComicBook> ComicBooks { get; set; }
    }
}
