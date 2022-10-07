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

        public IdeasController( IServiceIdeas ideaServices)
        {
                this._ideaServices = ideaServices;  
        }


        //// GET: api/<IdeasController>/Ideascollections
        [HttpGet]
        public async Task<ActionResult<Idea>> Get()
        {
         var ideas = await _ideaServices.GetIdeaCollections();
         return Ok(ideas);
 
        }



        // Get api/<IdeasController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Idea>> Get(string id)
        //{
        //    var existingIdea = await _ideaServices.GetIdea(id);

        //    if (existingIdea == null)
        //    {
        //        return NotFound($"Idea with Id = {id} not found");
        //    }

        //  return Ok(existingIdea);
        //}


        //api/<IdeasController>/
        [HttpPost]
       
        public async Task< ActionResult<Idea>> Post([FromBody] Idea idea)
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
           
        [HttpGet("DisplayOnlyIdea")]
        public async Task< ActionResult<Idea>> GetMapped()
        {
         
                var ideas = await _ideaServices.FetchAndMapIdeas();
                return Ok(ideas);
        }
          


        /*  // DELETE api/<IdeasController>/5
                  [HttpDelete("{id}")]
                  public ActionResult Delete(string id)
                  {
                      var idea = _ideaServices.GetIdea(id);

                      if (student == null)
                      {
                          return NotFound($"idea with Id = {id} not found");
                      }

                      _ideaServices.Remove(student.Id);

                      return Ok($"Idea with Id = {id} deleted");
      }*/


        // Patch method



    }
}
