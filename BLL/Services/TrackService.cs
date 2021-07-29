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
    public interface ITrackService
    {
        void Add(Track track);
        void Remove(int id);
        IEnumerable<string> GetAll();
    }
    public class TrackService : ITrackService
    {
        IUnitOfWork unitOfWork;
        IRepository<Track> traks;
        IMapper mapper;
        MusicCollectionDb context = new MusicCollectionDb();

        public TrackService()
        {
            unitOfWork = new UnitOfWork(context);
            traks = unitOfWork.TrackRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TrackDTO, Track>();
            });

            mapper = new Mapper(config);
        }
        public void Add(Track track)
        {
            try
            {
                unitOfWork.TrackRepository.Insert(track);
                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public IEnumerable<string> GetAll()
        {
            return unitOfWork.PlaylistRepository.Get().Select(c => c.Name);
        }

        public void Remove(int id)
        {
            try
            {
                unitOfWork.TrackRepository.Delete(id);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}
