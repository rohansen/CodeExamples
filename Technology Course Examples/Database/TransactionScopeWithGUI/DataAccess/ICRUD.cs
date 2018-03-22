using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ICRUD<T>
    {
        
        void Create(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Delete(int id);
        void Update(T entity);


    }
}
