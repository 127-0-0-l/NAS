using System.Collections.Generic;

namespace NAS.Logic.Managers.Interfaces
{
    public interface IManager<T>
    {
        List<T> GetAll();

        T GetById(int id);

        int Add(T item);

        bool Remove(int id);

        bool Update(T item);
    }
}
