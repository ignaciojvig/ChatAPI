using Chat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Interfaces.Repository_Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Remove(T entity);
        void Dispose();
    }
}
