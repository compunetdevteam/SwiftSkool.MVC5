using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftSkool.Entities;

namespace SwiftSkool.Abstractions
{
    public interface ICommandRepository<T>
    {

        void Update(T entity);
        Task<int> SaveAsync();
        void Add(T entity);
        bool Delete(T entity);
        T FindById(int id);
    }
}
