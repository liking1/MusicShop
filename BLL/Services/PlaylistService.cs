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
    public interface IPlaylistService
    {
        void Add(Playlist playlist);
        void RemoveById(int id);
        IEnumerable<string> GetAll();
    }

    public class PlaylistService : IPlaylistService
    {
        IUnitOfWork unitOfWork;
        IRepository<Playlist> playlists;
        IMapper mapper;
        MusicCollectionDb context = new MusicCollectionDb();

        public PlaylistService()
        {
            unitOfWork = new UnitOfWork(context);
            playlists = unitOfWork.PlaylistRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlaylistDTO, Playlist>();
            });

            mapper = new Mapper(config);
        }
        public void Add(Playlist playlist)
        {
            try
            {
                unitOfWork.PlaylistRepository.Insert(playlist);
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

        public void RemoveById(int id)
        {
            try
            {
                unitOfWork.PlaylistRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }
    }
}
