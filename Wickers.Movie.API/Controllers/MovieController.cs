using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wickers.Movie.Business.Interfaces;
using Wickers.Movie.Models;
using System.Collections.Generic;
using System.Linq;

namespace Wickers.Movie.API.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : BaseController
    {

        private IServices<MovieModel> _services;

        public MovieController(IServices<MovieModel> Services)
        {
            _services = Services;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            try 
            {
                var results = await _services.Select();
                return Ok(results);
            }
            catch(Exception e)
            {
                return base.InteralServer(e);
            }
        }

        [HttpGet]
        [Route("{ID}")]
        public async Task<IActionResult> GetMovieID(int ID)
        {
            try
            {
                var results = await _services.SelectByID(ID);
                return Ok(results);
            }
            catch (Exception e)
            {
                return base.InteralServer(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovide([FromQuery] MovieModel Model)
        {
            try
            {
                var results = await _services.Insert(Model);
                return Ok(results);
            }
            catch (Exception e)
            {
                return base.InteralServer(e);
            }
        }
    }
}
