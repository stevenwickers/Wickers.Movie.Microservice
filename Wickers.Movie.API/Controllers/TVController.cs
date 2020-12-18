using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Wickers.Movie.Business.Interfaces;
using Wickers.Movie.Models;

namespace Wickers.Movie.API.Controllers
{
    [ApiController]
    [Route("TV")]
    public class TVController : BaseController
    {
        private IServices<TVModel> _services;
        public TVController(IServices<TVModel> Services)
        {
            _services = Services;
        }

        [HttpGet]
        public async Task<IActionResult> GetShows()
        {
            try
            {
                var results = await _services.Select();
                return Ok(results);
            }
            catch (Exception e)
            {
                return base.InteralServer(e);
            }
        }

        // Select TV Show by ID

        //[HttpGet]
        //[Route("{ID}")]
        //public async Task<IActionResult> GetShowsID(int ID)
        //{
        //    try
        //    {
        //        var results = await _services.SelectByID(ID);
        //        return Ok(results);
        //    }
        //    catch (Exception e)
        //    {
        //        return base.InteralServer(e);
        //    }
        //}

        // Insert TV Show

        //[HttpPost]
        //public async Task<IActionResult> InsertShows([FromQuery] TVModel Model)
        //{
        //    try
        //    {
        //        var results = await _services.Insert(Model);
        //        return Ok(results);
        //    }
        //    catch (Exception e)
        //    {
        //        return base.InteralServer(e);
        //    }
        //}
    }
}
