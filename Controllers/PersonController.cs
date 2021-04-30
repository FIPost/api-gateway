﻿using api_gateway.Helper;
using api_gateway.Models.ServiceModels;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        /// <summary>
        /// Gets a list of all persons
        /// </summary>
        /// <returns>List of rooms</returns>
        /// <response code="200">returns the list of persons</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("persons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<PersonServiceModel>>> GetPersons()
        {
            IFlurlResponse response = await $"{Constants.PersonApiUrl}/api/persons".GetAsync();

            if (response.StatusCode >= 500)
            {
                return StatusCode(500);
            }
            else if (response.StatusCode >= 400)
            {
                return StatusCode(400);
            }
            else
            {
                ICollection<PersonServiceModel> responseModels = await response.GetJsonAsync<ICollection<PersonServiceModel>>();
                return Ok(responseModels);
            }
        }

        /// <summary>
        /// Gets a specific person by id
        /// </summary>
        /// <param name="id">the id of the person</param>
        /// <returns>person with matching id</returns>
        /// <response code="200">Returns the person with the specified id</response>
        /// <response code="404">No person found with the matching id</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("persons/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PersonServiceModel>> GetPersonById(string id)
        {
            IFlurlResponse response = await $"{Constants.PersonApiUrl}/api/persons/{id}".GetAsync();

            if (response.StatusCode == 404)
            {
                return NotFound();
            }
            else if (response.StatusCode >= 400)
            {
                return StatusCode(400);
            }
            else if (response.StatusCode >= 500)
            {
                return StatusCode(500);
            }
            else
            {
                PersonServiceModel responseModel = await response.GetJsonAsync<PersonServiceModel>();
                return Ok(responseModel);
            }
        }
    }
}