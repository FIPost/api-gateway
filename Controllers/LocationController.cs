using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_gateway.Models.ServiceModels.Location;
using Microsoft.AspNetCore.Mvc;
using Flurl.Http;
using api_gateway.Models.RequestModels.Location;
using Microsoft.AspNetCore.Http;
using api_gateway.Helper;

namespace api_gateway.Controllers
{
    /// <summary>
    /// The location controller handles all of the web-friendly endpoints that consume the location microservice
    /// Controller documentation should be handled automatically via swagger.
    /// For more information visit the generated swagger documentation.
    /// </summary>
    [Produces("application/json")]
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        /// <summary>
        /// Gets a list of all the available rooms from the location service
        /// </summary>
        /// <returns>List of rooms</returns>
        /// <response code="200">returns the list of rooms</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("rooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<Room>>> GetRooms()
        {
            IFlurlResponse response = await $"{Constants.LocationApiUrl}/api/Room".GetAsync();

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
                ICollection<Room> responseModels = await response.GetJsonAsync<ICollection<Room>>();
                return Ok(responseModels);
            }
        }

        /// <summary>
        /// Gets a list of all the available cities from the location service
        /// </summary>
        /// <returns>List of cities</returns>
        /// <response code="200">returns the list of cities</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("cities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<City>>> GetCities()
        {
            IFlurlResponse response = await $"{Constants.LocationApiUrl}/api/City".GetAsync();
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
                ICollection<City> responseModels = await response.GetJsonAsync<ICollection<City>>();
                return Ok(responseModels);
            }
        }

        /// <summary>
        /// Gets a list of all the available buildings from the location service
        /// </summary>
        /// <returns>List of buildings</returns>
        /// <response code="200">returns the list of buildings</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("buildings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<Building>>> GetBuildings()
        {
            IFlurlResponse response = await $"{Constants.LocationApiUrl}/api/Building".GetAsync();

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
                ICollection<Building> responseModels = await response.GetJsonAsync<ICollection<Building>>();
                return Ok(responseModels);
            }
        }

        /// <summary>
        /// Gets a specific room by id
        /// </summary>
        /// <param name="id">the id of the room</param>
        /// <returns>room with matching id</returns>
        /// <response code="200">Returns the room with the specified id</response>
        /// <response code="404">No room found with the matching id</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("rooms/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Room>> GetRoomById(Guid id)
        {
            IFlurlResponse response = await $"{Constants.LocationApiUrl}/api/Room/{id}".GetAsync();

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
                Room responseModel = await response.GetJsonAsync<Room>();
                return Ok(responseModel);
            }
        }

        /// <summary>
        /// Gets a specific city by id
        /// </summary>
        /// <param name="id">the id of the city</param>
        /// <returns>city with matching id</returns>
        /// <response code="200">Returns the city with the specified id</response>
        /// <response code="404">No city found with the matching id</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("cities/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<City>> GetCityById(Guid id)
        {
            IFlurlResponse response = await $"{Constants.LocationApiUrl}/api/City/{id}".GetAsync();

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
                City responseModel = await response.GetJsonAsync<City>();
                return Ok(responseModel);
            }
        }

        /// <summary>
        /// Gets a specific building by id
        /// </summary>
        /// <param name="id">the id of the building</param>
        /// <returns>building with matching id</returns>
        /// <response code="200">Returns the building with the specified id</response>
        /// <response code="404">No building found with the matching id</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("buildings/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Building>> GetBuildingById(Guid id)
        {
            IFlurlResponse response = await $"{Constants.LocationApiUrl}/api/Building/{id}".GetAsync();

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
                Building responseModel = await response.GetJsonAsync<Building>();
                return Ok(responseModel);
            }
        }

        /// <summary>
        /// Creates a new room
        /// </summary>
        /// <param name="request">Room request model</param>
        /// <returns>the newly created room</returns>
        /// <response code="201">A new room has been created</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpPost("rooms")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Room>> PostRoom(RoomRequestModel request)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/Room".PostJsonAsync(request);

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
                Room responseModel = await response.GetJsonAsync<Room>();
                return CreatedAtAction("PostRoom", responseModel);
            }
        }

        /// <summary>
        /// Creates a new city
        /// </summary>
        /// <param name="request">City request model</param>
        /// <returns>the newly created city</returns>
        /// <response code="201">A new city has been created</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpPost("cities")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<City>> PostCity(CityRequestModel request)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/City".PostJsonAsync(request);

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
                City responseModel = await response.GetJsonAsync<City>();
                return CreatedAtAction("PostCity", responseModel);
            }
        }

        /// <summary>
        /// Creates a new building
        /// </summary>
        /// <param name="request">Buildiung request model</param>
        /// <returns>the newly created building</returns>
        /// <response code="201">A new building has been created</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpPost("buildings")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Building>> PostBuilding(BuildingRequestModel request)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/Building".PostJsonAsync(request);

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
                Building responseModel = await response.GetJsonAsync<Building>();
                return CreatedAtAction("PostBuilding", responseModel);
            }
        }


        #region Put methods.

        [HttpPut("buildings")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Building>> PutBuilding(BuildingRequestModel request, Guid id)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/building/{id}".PutJsonAsync(request);

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
                Building responseModel = await response.GetJsonAsync<Building>();
                return CreatedAtAction("PutBuilding", responseModel);
            }
        }

        [HttpPut("cities")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<City>> PutCity(CityRequestModel request, Guid id)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/City/{id}".PutJsonAsync(request);

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
                City responseModel = await response.GetJsonAsync<City>();
                return CreatedAtAction("PutCity", responseModel);
            }
        }

        [HttpPut("rooms")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Room>> PutRoom(RoomRequestModel request, Guid id)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/Room/{id}".PutJsonAsync(request);

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
                Room responseModel = await response.GetJsonAsync<Room>();
                return CreatedAtAction("PutRoom", responseModel);
            }
        }
        #endregion

        #region Delete methods.
        [HttpDelete("buildings")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBuilding(Guid id)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/building/{id}".DeleteAsync();

            if (response.StatusCode == 204)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, response.ResponseMessage);
            }
        }


        [HttpDelete("cities")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCity(Guid id)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/city/{id}".DeleteAsync();

            if (response.StatusCode == 204)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, response.ResponseMessage);
            }
        }

        [HttpDelete("rooms")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteRoom(Guid id)
        {
            IFlurlResponse response = await $"{ Constants.LocationApiUrl }/api/room/{id}".DeleteAsync();

            if (response.StatusCode == 204)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, response.ResponseMessage);
            }
        }
        #endregion
    }
}
