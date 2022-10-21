using BackendInnovationAPI.DTO;
using BackendInnovationAPI.Models;
using BackendInnovationAPI.Services.IdeaServices;
using Microsoft.AspNetCore.Mvc;

namespace BackendInnovationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeasController : ControllerBase
    {

        //Create an object for IServicesIdea Interface
        private readonly IServiceIdeas _ideaServices;

        public IdeasController(IServiceIdeas ideaServices)
        {
            this._ideaServices = ideaServices;
        }


        //// GET: api/<IdeasController>/Ideascollections
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Idea>> Get()
        {
            var ideas = await _ideaServices.GetIdeaCollections();
            return Ok(ideas);

        }


        //api/<IdeasController>/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post([FromBody] Idea idea)
        {
            if (idea == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ideaServices.CreateIdeaCollection(idea);
           

            return CreatedAtAction(nameof(Get), new { id = idea.IdeaId }, idea);


        }

        // PUT api/<IdeasController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status205ResetContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Idea>> Put(string id, [FromBody] Idea idea)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingIdea = await _ideaServices.GetIdea(id);
            await _ideaServices.Update(id, idea);

            //return NoContent();
            return Ok($"Idea with Id = {id} Updated");
            if (existingIdea == null)
            {
                return NotFound($"Idea with Id = {id} not found");
            }

        }


        // Get api/<IdeasController>/5
        [HttpGet("{MUId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Idea>> Get(string MUId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingIdea = await _ideaServices.GetIdeasByIdeatorMUID(MUId);

            if (existingIdea == null)
            {
                return NotFound($"Idea with Id = {MUId} not found");
            }

            return Ok(existingIdea);
        }

        [HttpGet("IdeasWithMuId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Idea>> GetMapped()
        {

            var ideas = await _ideaServices.FetchAndMapIdeas();
            return Ok(ideas);
        }

    }
}
