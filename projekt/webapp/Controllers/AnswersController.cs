using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using System.Net;
using Newtonsoft.Json;

namespace webapp.Controllers
{
    [Route("api/[controller]")]
    public class AnswersController : BaseController
    {
        public AnswersController(SimplePollsLogic logic)
            : base(logic)
        {
        }

        [HttpGet("{simplePollId}")]
        public ActionResult GetAnswersForSimplePoll(Guid? simplePollId)
        {
            if(!simplePollId.HasValue)
            {
                return BadRequest();
            }

            List<SimplePollAnswer> answers = _logic.GetAnswers(simplePollId.Value);
            string jsonResult = JsonConvert.SerializeObject(new { Answers = answers });
            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        public ActionResult AddAnswerToSimplePollOption([FromBody]SimplePollAnswerUpdateModel updateModel)
        {
            if (!updateModel.SimplePollId.HasValue 
                || !updateModel.SimplePollOptionId.HasValue 
                || updateModel.EmployeeName == null)
            {
                return BadRequest();
            }

            bool result = _logic.AddAnswerToSimplePollOption(updateModel);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }
        }
    }
}
