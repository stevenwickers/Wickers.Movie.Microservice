using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wickers.Movie.Data.Model;

namespace Wickers.Movie.Business.Interfaces
{
    public interface ISQLServices
    {
        Task<IEnumerable<T>> GetAll<T>(string ProcedureName);
        Task<T> GetItem<T>(string ProcedureName, List<ParameterModel> ParameterList);
        Task<int> InsertUpdateData(string ProcedureName, List<ParameterModel> ParameterList);
    }
}
