using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftSkool.Abstractions
{
    public interface IUsersCommandRepository<T>
    {
        void Update(T entity);
        Task<int> SaveAsync();
        void Add(T entity);
        bool Delete(T entity);
        T FindById(string id);
    }
}
