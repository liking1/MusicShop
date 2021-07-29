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
    public interface ICategoryService
    {
        void Add(Category category);
        void Remove(int id);
        IEnumerable<string> GetAll();
        IEnumerable<int> GetAllId();
    }
    public class CategoryService : ICategoryService
    {
        IUnitOfWork unitOfWork;
        IRepository<Category> categories;
        IMapper mapper;
        MusicCollectionDb context = new MusicCollectionDb();

        public CategoryService()
        {
            unitOfWork = new UnitOfWork(context);
            categories = unitOfWork.CategoryRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, Category>();
            });

            mapper = new Mapper(config);
        }

        public void Add(Category category)
        {
            try
            {
                unitOfWork.CategoryRepository.Insert(category);
                unitOfWork.Save();
            }
            catch (Exception EX)
            {
                throw new Exception($"{EX}");
            }
        }

        public IEnumerable<string> GetAll()
        {
            return unitOfWork.CategoryRepository.Get().Select(c => c.Name);
        }

        public IEnumerable<int> GetAllId()
        {
            return unitOfWork.CountryRepository.Get().Select(c => c.Id);
        }

        public void Remove(int id)
        {
            unitOfWork.CategoryRepository.Delete(id);
            unitOfWork.Save();
        }
    }
}
