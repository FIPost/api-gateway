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
using System.Net;

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
            IFlurlResponse flurlResponse = await $"{Constants.LocationApiUrl}/api/Room".GetAsync();
            var response = flurlResponse.GetResponse("Er kunnen geen ruimtes gevonden worden");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            ICollection<Room> responseModels = await flurlResponse.GetJsonAsync<ICollection<Room>>();
            return Ok(responseModels);
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
            IFlurlResponse flurlResponse = await $"{Constants.LocationApiUrl}/api/City".GetAsync();
            var response = flurlResponse.GetResponse("Er kunnen geen steden gevonden worden");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            ICollection<City> responseModels = await flurlResponse.GetJsonAsync<ICollection<City>>();
            return Ok(responseModels);
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
            IFlurlResponse flurlResponse = await $"{Constants.LocationApiUrl}/api/Building".GetAsync();
            var response = flurlResponse.GetResponse("Er kunnen geen gebouwen gevonden worden");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            ICollection<Building> responseModels = await flurlResponse.GetJsonAsync<ICollection<Building>>();
            return Ok(responseModels);
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
            IFlurlResponse flurlResponse = await $"{Constants.LocationApiUrl}/api/Room/{id}".GetAsync();
            var response = flurlResponse.GetResponse("Deze ruimte kan niet gevonden worden");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            Room responseModel = await flurlResponse.GetJsonAsync<Room>();
            return Ok(responseModel);
            
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
            IFlurlResponse flurlResponse = await $"{Constants.LocationApiUrl}/api/City/{id}".GetAsync();
            var response = flurlResponse.GetResponse("Deze stad kan niet gevonden worden");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            City responseModel = await flurlResponse.GetJsonAsync<City>();
            return Ok(responseModel);
            
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
            IFlurlResponse flurlResponse = await $"{Constants.LocationApiUrl}/api/Building/{id}".GetAsync();
            var response = flurlResponse.GetResponse("Dit gebouw kan niet gevonden worden");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            Building responseModel = await flurlResponse.GetJsonAsync<Building>();
            return Ok(responseModel);
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
            ObjectResult buildingResponse = await BuildingExists(request.BuildingId.ToString());
            if (buildingResponse.StatusCode != 200)
            {
                return buildingResponse;
            }

            //post room
            IFlurlResponse flurlResponse = await $"{ Constants.LocationApiUrl }/api/Room".PostJsonAsync(request);
            var response = flurlResponse.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            Room responseModel = await flurlResponse.GetJsonAsync<Room>();
            return CreatedAtAction("PostRoom", responseModel);
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
            IFlurlResponse flurlResponse = await $"{ Constants.LocationApiUrl }/api/City".PostJsonAsync(request);
            var response = flurlResponse.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            City responseModel = await flurlResponse.GetJsonAsync<City>();
            return CreatedAtAction("PostCity", responseModel);
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
            ObjectResult cityResponse = await CityExists(request.Address.CityId.ToString());
            if (cityResponse.StatusCode != 200)
            {
                return cityResponse;
            }

            //post building
            IFlurlResponse flurlResponse = await $"{ Constants.LocationApiUrl }/api/Building".PostJsonAsync(request);
            var response = flurlResponse.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            Building responseModel = await flurlResponse.GetJsonAsync<Building>();
            return CreatedAtAction("PostBuilding", responseModel);
        }


        #region Put methods.

        [HttpPut("buildings")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Building>> PutBuilding(BuildingRequestModel request, Guid id)
        {
            ObjectResult cityResponse = await CityExists(request.Address.CityId.ToString());
            if (cityResponse.StatusCode != 200)
            {
                return cityResponse;
            }

            //put building
            IFlurlResponse flurlResponse = await $"{ Constants.LocationApiUrl }/api/building/{id}".PutJsonAsync(request);
            var response = flurlResponse.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            Building responseModel = await flurlResponse.GetJsonAsync<Building>();
            return CreatedAtAction("PutBuilding", responseModel);
            
        }

        [HttpPut("cities")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<City>> PutCity(CityRequestModel request, Guid id)
        {
            IFlurlResponse flurlResponse = await $"{ Constants.LocationApiUrl }/api/City/{id}".PutJsonAsync(request);
            var response = flurlResponse.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            City responseModel = await flurlResponse.GetJsonAsync<City>();
            return CreatedAtAction("PutCity", responseModel);
            
        }

        [HttpPut("rooms")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Room>> PutRoom(RoomRequestModel request, Guid id)
        {
            ObjectResult buildingResponse = await BuildingExists(request.BuildingId.ToString());
            if (buildingResponse.StatusCode != 200)
            {
                return buildingResponse;
            }

            //put room
            IFlurlResponse flurlResponse = await $"{ Constants.LocationApiUrl }/api/Room/{id}".PutJsonAsync(request);
            var response = flurlResponse.GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(response.Message) { StatusCode = (int)response.StatusCode };
            }

            Room responseModel = await flurlResponse.GetJsonAsync<Room>();
            return CreatedAtAction("PutRoom", responseModel);

        }
        #endregion

        private async Task<ObjectResult> CityExists(string id)
        {
            IFlurlResponse flurlCityResponse = await $"{ Constants.LocationApiUrl }/api/City/{id}".GetAsync();
            var cityResponse = flurlCityResponse.GetResponse("De meegegeven stad bestaat niet");

            if (cityResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(cityResponse.Message) { StatusCode = (int)cityResponse.StatusCode };
            }

            return new ObjectResult(cityResponse.Message) { StatusCode = (int)cityResponse.StatusCode };
        }

        private async Task<ObjectResult> BuildingExists(string id)
        {
            IFlurlResponse flurlBuildingResponse = await $"{ Constants.LocationApiUrl }/api/Building/{id}".GetAsync();
            var buildingResponse = flurlBuildingResponse.GetResponse("Het meegegeven gebouw bestaat niet");

            if (buildingResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(buildingResponse.Message) { StatusCode = (int)buildingResponse.StatusCode };
            }

            return new ObjectResult(buildingResponse.Message) { StatusCode = (int)buildingResponse.StatusCode };
        }
    }
}
