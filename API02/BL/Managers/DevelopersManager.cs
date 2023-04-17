using CoursesTikects.BL.Managers.Inertfaces;
using CoursesTikects.DAL.Data.Context;
using CoursesTikects.DAL.Data.Models;
using CoursesTikects.DAL.Repos.Inertfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTikects.BL.Managers
{
    public class DevelopersManager : IDeveloperManager
    {
        private readonly IDeveloperRepository _repo;

        public DevelopersManager(IDeveloperRepository repo)
        {
            _repo = repo;
        }
        public async Task Add(Developer entity)
        {
            await _repo.Add(entity);
        }

        public async Task<Developer> GetByID(int id)
        {
            return await _repo.GetById(id);
        }

        public void Delete(Developer entity)
        {
            _repo.Delete(entity);
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Task<IEnumerable<Developer>> GetRange(IEnumerable<int> Ids)
        {
            return _repo.GetRange(Ids);
        }

        public async Task SaveChanges()
        {
            await _repo.SaveCahnges();
        }

        public void Update(Developer entity)
        {
            _repo.Update(entity);
        }
    }
}
