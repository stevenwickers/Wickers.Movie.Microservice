using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Wickers.Movie.Business.Interfaces;
using Wickers.Movie.Models;
using Wickers.Movie.Data.Model;

namespace Wickers.Movie.Business.Services
{
    public class MovieServices : IServices<MovieModel>
    {
        private const string _sprocPrefix = "Movie";
        private ISQLServices _dataService;
        public MovieServices(ISQLServices SqlService) 
        {
            _dataService = SqlService;
        }

        public async Task<IEnumerable<MovieModel>> Select()
        {
            return await _dataService.GetAll<MovieModel>($"{_sprocPrefix}_Select");
        }

        public async Task<MovieModel> SelectByID(int ID)
        {
            List<ParameterModel> _params = new List<ParameterModel>();
            _params.Add(new ParameterModel() { Name = "@MovieID", DataType = DbType.Int32, Value = ID });

            return await _dataService.GetItem<MovieModel>($"{_sprocPrefix}_Select", _params);
        }

        public async Task<MovieModel> Insert(MovieModel Model)
        {
            List<ParameterModel> _params = CreateMovieParameters(Model, false);
            
            var id = await _dataService.InsertUpdateData($"{_sprocPrefix}_Insert", _params);
            Model.MovieID = id;
            return Model;

        }

        public async Task<MovieModel> Update(MovieModel Model)
        {
            List<ParameterModel> _params = CreateMovieParameters(Model, true);

            var id = await _dataService.InsertUpdateData($"{_sprocPrefix}_Update", _params);
            Model.MovieID = id;
            return Model;

        }
       
        private List<ParameterModel> CreateMovieParameters(MovieModel Model, bool IsUpdating)
        {
            List<ParameterModel> _params = new List<ParameterModel>();

            if (IsUpdating)
            {
                _params.Add(new ParameterModel() { Name = "@MovieID", DataType = DbType.Int32, Value = Model.MovieID });
            }

            _params.Add(new ParameterModel() { Name = "@MovieName", DataType = DbType.String, Value = Model.MovieName });
            _params.Add(new ParameterModel() { Name = "@ReleaseDate", DataType = DbType.String, Value = Model.ReleaseDate });
            _params.Add(new ParameterModel() { Name = "@WorldwideGross", DataType = DbType.String, Value = Model.WorldwideGross });
            _params.Add(new ParameterModel() { Name = "@ProductionBudget", DataType = DbType.String, Value = Model.ProductionBudget });
            _params.Add(new ParameterModel() { Name = "@DomesticGross", DataType = DbType.String, Value = Model.DomesticGross });
            _params.Add(new ParameterModel() { Name = "@MovieLink", DataType = DbType.String, Value = Model.MovieLink });

            return _params;
        }


    }
}
