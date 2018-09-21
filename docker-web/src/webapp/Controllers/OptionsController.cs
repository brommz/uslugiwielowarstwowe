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
    public class OptionsController : BaseController
    {
        public OptionsController(SimplePollsLogic logic)
            : base(logic)
        {
        }

        [HttpPost]
        public ActionResult AddOption([FromBody]SimplePollOptionUpdateModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            SimplePoll simplePoll = _logic.GetSimplePollById(model.SimplePollId);
            SimplePollOption option = new SimplePollOption()
            {
                Id = ObjectModel.GenerateGuid(),
                Text = model.Text
            };
            _logic.AddOptionToSimplePoll(simplePoll, option);

            return Ok();
        }

    }
}
