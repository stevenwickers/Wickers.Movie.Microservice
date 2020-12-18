using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Wickers.Movie.Business.Interfaces;
using Wickers.Movie.Data.Model;
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

        public async Task<TVModel> Insert(TVModel Model)
        {
            List<ParameterModel> _params = CreateMovieParameters(Model, false);

            var id = await _dataService.InsertUpdateData($"{_sprocPrefix}_Insert", _params);
            Model.TVID = id;
            return Model;
        }

        public async Task<IEnumerable<TVModel>> Select()
        {
            return await _dataService.GetAll<TVModel>($"{_sprocPrefix}_Select");
        }

        public async Task<TVModel> SelectByID(int ID)
        {
            List<ParameterModel> _params = new List<ParameterModel>();
            _params.Add(new ParameterModel() { Name = "@TVID", DataType = DbType.Int32, Value = ID });

            return await _dataService.GetItem<TVModel>($"{_sprocPrefix}_Select", _params);
        }

        private List<ParameterModel> CreateMovieParameters(TVModel Model, bool IsUpdating)
        {
            List<ParameterModel> _params = new List<ParameterModel>();

            if (IsUpdating)
            {
                _params.Add(new ParameterModel() { Name = "@TVID", DataType = DbType.Int32, Value = Model.TVID });
            }

            _params.Add(new ParameterModel() { Name = "@Name", DataType = DbType.String, Value = Model.Name });
            _params.Add(new ParameterModel() { Name = "@YearStart", DataType = DbType.String, Value = Model.YearStart });
            _params.Add(new ParameterModel() { Name = "@YearEnd", DataType = DbType.String, Value = Model.YearEnd });
            _params.Add(new ParameterModel() { Name = "@Description", DataType = DbType.String, Value = Model.Description });

            return _params;
        }
    }
}
