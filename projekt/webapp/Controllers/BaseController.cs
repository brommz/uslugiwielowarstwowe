using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using Newtonsoft.Json;

namespace webapp.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly SimplePollsLogic _logic;

        public BaseController(SimplePollsLogic logic)
        {
            _logic = logic;
        }
    }
}
