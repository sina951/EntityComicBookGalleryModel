using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    // Here we use the context class to add a comic book, retrieve a list of comic books, and
    // write the comic book series title to the console
    // Step 1. Instantiate an instance of your context class
    // Step 2. Use context to add a comicbook to database.
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate an instance of your context class
            // the using statement will close connection and dump cache when done
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                // Details queries
                var comicBookId = 1;
                // Details queries
                //var comicBook1 = context.ComicBooks.Find(comicBookId);
                //var comicBook2 = context.ComicBooks.Find(comicBookId);

                // Lazy Loading
                // The SingleOrDefault() method will return a single entity or null depending on
                // whether or not a comicbook is found that matches the provided filter criteria.
                // if more that one entity is found, the method will throw a exception.
                // FirstOrDefault() - Returns the first entity if more than one is found
                var comicBook1 = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .SingleOrDefault(cb => cb.Id == comicBookId);

                Debug.WriteLine("Changing the Description property value.");
                comicBook1.Description = "New value!";

                var comicBook2 = context.ComicBooks
                    .SingleOrDefault(cb => cb.Id == comicBookId);

                // Eager Loading - To get Series data we use Include() method - Using Include() means we use Eager Loading
                //var comicBooks = context.ComicBooks
                //    //.Include(cb => cb.Series)
                //    //.Include(cb => cb.Artists.Select(a => a.Artist))
                //    //.Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                // Explicit Loading
                //foreach (var comicBook in comicBooks)
                //{
                //    if (comicBook.Series == null)
                //    {
                //        context.Entry(comicBook)
                //            .Reference(cb => cb.Series)
                //            .Load();
                //    }

                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistRolesDisplayText = string.Join(", ", artistRoleNames);

                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistRolesDisplayText);
                //}

                Console.ReadLine();
            }
        }
    }
}
