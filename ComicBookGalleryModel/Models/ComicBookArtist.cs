using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    // This is our bridge entity class
    public class ComicBookArtist
    {
        // 1. A one-to-many relationship happens when the primary key of one table becomes foreign keys in another table.
        // 2. The foreign key is defined in the table that represents the many end of the relationship. 
        public int Id { get; set; }
        // This is a foreign key prop to the comicbook that we are adding artists to
        public int ComicBookId { get; set; }
        // This is a foreign key prop to the artist that we are adding to the comicbook
        public int ArtistId { get; set; }
        // This is a foreign key prop to the role that the artist had for this comicbook
        public int RoleId { get; set; }

        // Navigation properties
        // Ef will detect and determine this property as a foreign key property
        public virtual ComicBook ComicBook { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Role Role { get; set; }
    }
}
