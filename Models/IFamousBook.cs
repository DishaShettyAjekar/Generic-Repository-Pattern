using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Repository_pattern.Models
{
    public interface IFamousBook
    {
        IEnumerable<Book> GetBooksByAuthor(string name);
    }
}
