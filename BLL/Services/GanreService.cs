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
    public interface IGanreService
    {
        IEnumerable<string> GetAll();
        void Add(Ganre ganre);
        void Remove(int id);
        IEnumerable<int> GetAllGanreId();
        
    }

    public class GanreService : IGanreService
    {
        IUnitOfWork unitOfWork;
        IRepository<Ganre> ganres;
        IMapper mapper;
        MusicCollectionDb context = new MusicCollectionDb();

        public GanreService()
        {
            unitOfWork = new UnitOfWork(context);
            ganres = unitOfWork.GanreRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GanreDTO, Ganre>();
            });

            mapper = new Mapper(config);
        }
        public void Add(Ganre ganre)
        {
            try
            {
                unitOfWork.GanreRepository.Insert(ganre);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
        }

        public IEnumerable<string> GetAll()
        {
            return unitOfWork.GanreRepository.Get().Select(c => c.Name);
        }

        public IEnumerable<int> GetAllGanreId()
        {
            return unitOfWork.GanreRepository.Get().Select(c => c.Id);
        }

        public void Remove(int id)
        {
            unitOfWork.GanreRepository.Delete(id);
        }
    }
}
