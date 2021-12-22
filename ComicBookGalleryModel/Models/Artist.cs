using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class Artist
    {
        // Default consturctor to initialize the comicbooks collection property
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        [Required, StringLength(100)] // makes sure that we dont allow nulls
        public string Name { get; set; }
        // add a collection of comicbooks to our artist class
        public ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}
