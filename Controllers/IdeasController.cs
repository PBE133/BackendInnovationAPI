using BackendInnovationAPI.Models;
using BackendInnovationAPI.Services;
using Microsoft.AspNetCore.Http;
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
        // GET: api/<IdeasController>/Ideascollections
        [HttpGet]
        public ActionResult<List<Idea>> Get()
        {
             return _ideaServices.GetIdeaCollections();
            
        }


        // PUT api/<IdeasController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var existingIdea = _ideaServices.GetIdea(id);

            if (existingIdea == null)
            {
                return NotFound($"Idea with Id = {id} not found");
            }

          return Ok(existingIdea);
        }

        //api/<IdeasController>/
        [HttpPost]
        public ActionResult<Idea> Post([FromBody] Idea idea)
        {
            _ideaServices.CreateIdeaCollection(idea);

            return CreatedAtAction(nameof(Get), new { id = idea.Id }, idea);

        }

        // PUT api/<IdeasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Idea idea)
        {
            var existingIdea = _ideaServices.GetIdea(id);

            if (existingIdea == null)
            {
                return NotFound($"Idea with Id = {id} not found");
            }

            _ideaServices.Update(id, idea);

            //return NoContent();
            return Ok($"Idea with Id = {id} Updated");




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


        }

    }
}
