using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MyBlog.Logic
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All();
        T GetItem(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}