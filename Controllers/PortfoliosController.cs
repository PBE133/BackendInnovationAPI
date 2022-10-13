﻿using BackendInnovationAPI.Models;
using BackendInnovationAPI.Services.PortfolioServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendInnovationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {

        private readonly IPortfolioService _portfolioService;

        public PortfoliosController(IPortfolioService portfolio)
        {

            this._portfolioService = portfolio;
        }

       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Portfolio>> Get()
        {
           var portfolioList = await _portfolioService.GetPortfolio(); 
            return Ok(portfolioList);   
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Portfolio>> Get(string id)
        {

            var existingPortfolio = await _portfolioService.GetPortfolio(id);


            if (existingPortfolio == null)
            {
                return NotFound($"Portfolio with Id = {id} not found");
            }

            return Ok(existingPortfolio);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Portfolio>>Post(Portfolio portfolio)
        {
           await _portfolioService.PostPortfolio(portfolio);
            return portfolio;
        }
    }
}
