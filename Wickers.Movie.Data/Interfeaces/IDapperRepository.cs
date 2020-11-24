using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wickers.Movie.Data.Model;

namespace Wickers.Movie.Data.Interfeaces
{
    public interface IDapperRepository
    {
        Task<T> QuerySingle<T>(string ProcedureName, List<ParameterModel> ParameterList);
        Task<IEnumerable<T>> QueryData<T>(string ProcedureName);
        Task<T> ExecuteProc<T>(string ProcedureName, List<ParameterModel> ParameterList);
    }
}
