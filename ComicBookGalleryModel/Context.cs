using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        // Our contect class needs to contain a collection of Db set properties
        // one property for each entity(class) we need to write a query for
        // Ass constructor We will be dropping and creating our database every time our model changes using SetInitializer() it has to be called before Context class is used
        // that is why we do public Context() again
        public Context()
        {
            // seed the database
            Database.SetInitializer(new DatabaseInitializer());
        }
        // set properties
        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // We change the avrage rateing column data type! 2 ways to do it
            // 1
            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(5, 2));
            // 2 - Using the fluent API
            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.AverageRating) // targert the property we want to update
                .HasPrecision(5, 2);              // set the new precision
        }
    }
}