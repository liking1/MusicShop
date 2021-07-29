
using DAL;
using DAL.Enties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Collections.EF
{
    public class Initializer : CreateDatabaseIfNotExists<MusicCollectionDb>
    {
        protected override void Seed(MusicCollectionDb context)
        {
            base.Seed(context);
            // Country
            Country urk = context.Countries.Add(new Country() { Name = "Ukraine" });
            context.SaveChanges();

            // Artish
            Artish artish1 = context.Artishes.Add(new Artish() { Name = "dww", Surname = "daadwd" });
            context.SaveChanges();
            
            // Category
            Category category1 = context.Categories.Add(new Category() { Name = "fee" });
            context.SaveChanges();

            // Ganre
            Ganre ganre = context.Ganres.Add(new Ganre() { Name = "grrgrgr" });
            context.SaveChanges();

            // Album
            DateTime date = new DateTime(year: 2020,11,11);
            Album album = context.Albums.Add(new Album() { Name = "grgrgr",Year=date });
            context.SaveChanges();

            // Track
            Track track = context.Tracks.Add(new Track() { Duration = new TimeSpan(200) });
            context.SaveChanges();

            // Playlist
            Playlist playlist = context.Playlists.Add(new Playlist() { Name = "fesfaws" });
            context.SaveChanges();
        }
    }
}
