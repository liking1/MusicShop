using DAL.Enties;
using Music_Collections.EF;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class MusicCollectionDb : DbContext
    {
        public MusicCollectionDb()
            : base("name=MusicCollectionDb")
        {
            Database.SetInitializer(new Initializer());
        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Artish> Artishes { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ganre> Ganres { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}