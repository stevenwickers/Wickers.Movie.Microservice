using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wickers.Movie.Business.Interfaces;
using Wickers.Movie.Data;
using Wickers.Movie.Data.Interfeaces;
using Wickers.Movie.Data.Model;

namespace Wickers.Movie.Business
{
    public class SQLServices : ISQLServices
    {
        protected const string _schema = "dbo.";
        private IDapperRepository _repo;

        public SQLServices(string ConnectionString, int SqlTimeout)
        {
            _repo = new DapperRepository(ConnectionString, SqlTimeout);
        }

        public async Task<IEnumerable<T>> GetAll<T>(string ProcedureName)
        {
            return await _repo.QueryData<T>($"{_schema}{ProcedureName}");
        }

        public async Task<T> GetItem<T>(string ProcedureName, List<ParameterModel> ParameterList)
        {
            return await _repo.QuerySingle<T>($"{_schema}{ProcedureName}", ParameterList);
        }

        public async Task<int> InsertUpdateData(string ProcedureName, List<ParameterModel> ParameterList)
        {
            var result = await _repo.ExecuteProc<int>($"{_schema}{ProcedureName}", ParameterList);
            return result;
        }
    }
}
