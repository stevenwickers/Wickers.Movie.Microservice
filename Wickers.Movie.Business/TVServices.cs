using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wickers.Movie.Business.Interfaces;
using Wickers.Movie.Models;

namespace Wickers.Movie.Business
{
    public class TVServices : IServices<TVModel>
    {
        private const string _sprocPrefix = "TV";
        private ISQLServices _dataService;

        public TVServices(ISQLServices SqlService)
        {
            _dataService = SqlService;
        }

        public Task<TVModel> Insert(TVModel Model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TVModel>> Select()
        {
            return await _dataService.GetAll<TVModel>($"{_sprocPrefix}_Select");
        }

        public Task<TVModel> SelectByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
