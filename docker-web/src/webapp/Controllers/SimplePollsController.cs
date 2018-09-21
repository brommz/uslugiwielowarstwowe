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
    public class SimplePollsController : BaseController
    {
        public SimplePollsController(SimplePollsLogic logic)
            : base(logic)
        {
        }

        [HttpGet("{simplePollId}")]
        public ActionResult Get(Guid? simplePollId)
        {
            if (!simplePollId.HasValue)
            {
                return BadRequest();
            }

            SimplePoll simplePoll = _logic.GetSimplePollById(simplePollId.Value);
            if (simplePoll == null)
            {
                return NotFound();
            }

            string jsonResult = JsonConvert.SerializeObject(simplePoll);
            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        public ActionResult AddSimplePoll([FromBody]SimplePollUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            SimplePoll simplePoll = new SimplePoll()
            {
                Id = ObjectModel.GenerateGuid(),
                Text = model.Text,
                Type = model.Type
            };

            _logic.AddSimplePoll(simplePoll);

            string jsonResult = JsonConvert.SerializeObject(simplePoll);
            return Content(jsonResult, "application/json");
        }
    }
}
