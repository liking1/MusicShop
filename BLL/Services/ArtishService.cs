using AutoMapper;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IArtishService
    {
        void Add(Artish artish);
        void RemoveArtish(int id);
        IEnumerable<string> GetAll();
        IEnumerable<int> GetAllArtishId();

    }
    public class ArtishService : IArtishService
    {
        IUnitOfWork unitOfWork;
        IRepository<Artish> artishes;
        IMapper mapper;
        MusicCollectionDb context = new MusicCollectionDb();

        public ArtishService()
        {
            unitOfWork = new UnitOfWork(context);
            artishes = unitOfWork.ArtishRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArtishDTO, Artish>();
            });

            mapper = new Mapper(config);
        }
        public void Add(Artish artish)
        {
            try
            {
                unitOfWork.ArtishRepository.Insert(artish);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public IEnumerable<string> GetAll()
        {
            return unitOfWork.ArtishRepository.Get().Select(c => c.Name);
        }
        public IEnumerable<int> GetAllArtishId()
        {
            return unitOfWork.ArtishRepository.Get().Select(c => c.Id);
        }
        public void RemoveArtish(int id)
        {
            unitOfWork.ArtishRepository.Delete(id);
            unitOfWork.Save();
        }
    }
}
