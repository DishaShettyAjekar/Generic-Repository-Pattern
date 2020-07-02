using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Generic_Repository_pattern.Models
{
    public class AllRepository<T> : IAllRepository<T> where T : class
    {
        private SampleMVCEntities _context;
        private IDbSet<T> dbEntity;

        public AllRepository()
        {
            _context = new SampleMVCEntities();
            dbEntity = _context.Set<T>(); //to load model
        }

        public void deleteModel(int modelId)
        {
           T model = dbEntity.Find(modelId);
            dbEntity.Remove(model);
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();
        }

        public T GetByModel(int modelId)
        {
            return dbEntity.Find(modelId);
        }

        public void insertModel(T model)
        {
            dbEntity.Add(model);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public void updateModel(T model)
        {
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
    }
}