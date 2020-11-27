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
        public async Task<IActionResult> GetMovies()
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
    }
}
