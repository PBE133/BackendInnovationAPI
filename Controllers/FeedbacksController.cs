using BackendInnovationAPI.Models;
using BackendInnovationAPI.Services.FeedbackServices;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using NPOI.XSSF.Streaming.Values;

namespace BackendInnovationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;

        public FeedbacksController(IFeedbackServices feedback)
        {
            this._feedbackServices = feedback;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Feedback>> Get()
        {
            var feedback = await _feedbackServices.GetFeedback();
            return Ok(feedback);    

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Feedback>> Post([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (feedback == null)
                {
                    return BadRequest();
                }   
            
         await _feedbackServices.CreateFeedbacks(feedback);
         return CreatedAtAction(nameof(Get), new { id = feedback.FeedbackId }, feedback);
                            
        }

        // get feedback by idea id
       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< ActionResult<Feedback>> Get(string id)
        {
          var existingIdea = await _feedbackServices.GetFeedbackById(id);

                if (existingIdea == null)
                {
                    return NotFound($"Idea with Id = {id} not found");
                }

                return Ok(existingIdea);       
        }



        // PUT api/<FeedbacksController>/id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Feedback>> Put(string id, [FromBody] Feedback feedback)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        var existingIdea = await _feedbackServices.GetFeedbackById(id);

            if (existingIdea == null)
            {
                return NotFound($"Idea with Id = {id} not found");
            }

         await _feedbackServices.Update(id, feedback);

         //return NoContent();
         return Ok($"Idea with Id = {id} Updated");


        }

        /*
         // get feedback by idea id

       [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       public  ActionResult<Feedback> Get(string id)
       {
          var existingIdea = _feedbackServices.GetFeedbacksByIdeaID(id);

          if (existingIdea == null)
          {
              return NotFound($"Idea with Id = {id} not found");
          }

        return Ok(existingIdea);
       }
       */




    }
}
