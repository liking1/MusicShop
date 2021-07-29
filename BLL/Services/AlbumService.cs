using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAlbumService
    {
        void Add(Album album);
        IEnumerable<string> GetAll();
        void AddCountry(string name);
        IEnumerable<Album> GetFullAlbum();
        IEnumerable<string> GetCountries();
        IEnumerable<int> GetAllCountryId();
        void RemoveSelectedItem(Album album);
        void Update(Album album);
    }
    public class AlbumService : IAlbumService
    {
        IUnitOfWork unitOfWork;
        IRepository<Album> albums;
        IMapper mapper;
        MusicCollectionDb context = new MusicCollectionDb();

        public AlbumService()
        {
            unitOfWork = new UnitOfWork(context);
            albums = unitOfWork.AlbumRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AlbumDTO, Album>();
            });

            mapper = new Mapper(config);
        }

        public void Add(Album album)
        {
            try
            {
                unitOfWork.AlbumRepository.Insert(album);
                unitOfWork.Save();
            }
            catch (Exception EX)
            {
                throw new Exception($"{EX}");
            }
        }

        public IEnumerable<string> GetAll()
        {
            return unitOfWork.AlbumRepository.Get().Select(c => c.Name);
        }
        public IEnumerable<Album> GetFullAlbum()
        {
            foreach (var item in albums.Get())
            {
                yield return new Album()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ArtishId = item.ArtishId,
                    Year = item.Year,
                    GanreId = item.GanreId,
                    CategoryId = item.CategoryId
                };
            }
        }

        public void AddCountry(string name)
        {
            unitOfWork.CountryRepository.Insert(new Country { Name = name });
            unitOfWork.Save();
        }

        public IEnumerable<string> GetCountries()
        {
            return unitOfWork.CountryRepository.Get().Select(c => c.Name);
        }

        public IEnumerable<int> GetAllCountryId()
        {
            return unitOfWork.CountryRepository.Get().Select(c => c.Id);
        }

        public void RemoveSelectedItem(Album album)
        {
            unitOfWork.AlbumRepository.Delete(album);
            unitOfWork.Save();
        }

        public void Update(Album album)
        {
            unitOfWork.AlbumRepository.Update(album);
            unitOfWork.Save();
        }
    }
}
