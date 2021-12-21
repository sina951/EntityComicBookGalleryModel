using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        public int SeriesId { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        // adding ? like decimal? makes this property nullable, this means we can add it to database
        // even if it does't have an average rating value - https://entityframework.net/one-to-many-relationship
        public decimal? AverageRating { get; set; }

        // public Series Series { get; set; } defines a Many-to-One relationship between ComicBook and series entities
        // so each ComicBook instance can be associated with exactly one series instance. but there is no restriction on 
        // how many ComicBook instances a Series instance can be associated with.
        // So the Series entity is the PRINCIPAL and ComicBook entity is the DEPENDENT (ComicBook is dependent on a series)
        // ES refers to Series as a NAVIGATION PROPERTY it navigates the relationship between them ComicBook and Series
        public Series Series { get; set; }

        // You can achieve one-to-many relationship by adding the collection navigation property
        public virtual ICollection<ComicBookArtist> Artists { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }
    }
}
