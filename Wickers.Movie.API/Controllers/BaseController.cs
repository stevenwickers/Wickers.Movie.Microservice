using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wickers.Movie.API.Controllers
{ 
    public class BaseController : Controller
    {
        protected IActionResult InteralServer(Exception Exp)
        {
            return StatusCode(500, Exp.Message);
        }
    }
}

