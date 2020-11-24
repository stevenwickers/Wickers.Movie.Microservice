using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wickers.Movie.Business.Interfaces
{
    public interface IServices<T>
    {
        Task<IEnumerable<T>> Select();
        Task<T> SelectByID(int ID);
        Task<T> Insert(T Model);
    }
}
