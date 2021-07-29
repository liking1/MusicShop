using DAL.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<Album> AlbumRepository { get; }
        GenericRepository<Artish> ArtishRepository { get; }
        GenericRepository<Category> CategoryRepository { get; }
        GenericRepository<Country> CountryRepository { get; }
        GenericRepository<Ganre> GanreRepository { get; }
        GenericRepository<Playlist> PlaylistRepository { get; }
        GenericRepository<Track> TrackRepository { get; }
        GenericRepository<User> UserRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MusicCollectionDb context;// = new MusciCollectionModel();

        private GenericRepository<Album> albumRepository;
        private GenericRepository<Artish> artishRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Ganre> ganreRepository;
        private GenericRepository<Country> countryRepository;
        private GenericRepository<Playlist> playlistRepository;
        private GenericRepository<Track> trackRepository;
        private GenericRepository<User> userRepository;

        public UnitOfWork(MusicCollectionDb context)
        {
            this.context = context;
        }

        public GenericRepository<Album> AlbumRepository
        {
            get
            {
                // lazy loading
                if (this.albumRepository == null)
                {
                    this.albumRepository = new GenericRepository<Album>(context);
                }
                return albumRepository;
            }
        }
        public GenericRepository<Artish> ArtishRepository
        {
            get
            {
                // lazy loading
                if (this.artishRepository == null)
                {
                    this.artishRepository = new GenericRepository<Artish>(context);
                }
                return artishRepository;
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                // lazy loading
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }
        public GenericRepository<Country> CountryRepository
        {
            get
            {
                // lazy loading
                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<Country>(context);
                }
                return countryRepository;
            }
        }
        public GenericRepository<Ganre> GanreRepository
        {
            get
            {
                // lazy loading
                if (this.ganreRepository == null)
                {
                    this.ganreRepository = new GenericRepository<Ganre>(context);
                }
                return ganreRepository;
            }
        }
        public GenericRepository<Playlist> PlaylistRepository
        {
            get
            {
                // lazy loading
                if (this.playlistRepository == null)
                {
                    this.playlistRepository = new GenericRepository<Playlist>(context);
                }
                return playlistRepository;
            }
        }
        public GenericRepository<Track> TrackRepository
        {
            get
            {
                // lazy loading
                if (this.trackRepository == null)
                {
                    this.trackRepository = new GenericRepository<Track>(context);
                }
                return trackRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }


        public GenericRepository<Artish> ClientRepository => throw new NotImplementedException();

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
