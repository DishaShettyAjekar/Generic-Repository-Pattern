using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Repository_pattern.Models
{
    public interface IAllRepository<T> where T : class
    {
        IEnumerable<T> GetModel();
        T GetByModel(int modelId);

        void insertModel(T model);
        void deleteModel(int modelId);
        void updateModel(T model);

        void save();
    }
}
