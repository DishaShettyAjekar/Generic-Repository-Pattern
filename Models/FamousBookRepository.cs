using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Generic_Repository_pattern.Models
{
    public class FamousBookRepository : AllRepository<Book>, IFamousBook
    {
        private SampleMVCEntities _context;
        private IDbSet<Book> dbEntity;

        public FamousBookRepository()
        {
            _context = new SampleMVCEntities();
            dbEntity = _context.Set<Book>(); //to load model
        }
        public IEnumerable<Book> GetBooksByAuthor(string name)
        {
            return dbEntity.Where(m => m.author == name.Trim()).ToList();
        }
        
    }
}