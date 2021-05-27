using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_gateway.Models.ResponseModels;
using api_gateway.Models.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using Flurl.Http;
using api_gateway.Models.Converters;
using api_gateway.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using api_gateway.Helper;
using Newtonsoft.Json;
using System.Net;
using api_gateway.Models.ServiceModels.Location;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_gateway.Controllers
{
    /// TODO: error handling, HTTP code responses for created, not found, failed etc.
    /// 
    /// <summary>
    /// The package controller handles all of the web-friendly endpoints that consume the package resource.
    /// Controller documentation should be handled automatically via swagger.
    /// For more information visit the generated swagger documentation.
    /// </summary>
    [Produces("application/json")]
    [Route("api/packages")]
    [ApiController]
    public class PackageController : ControllerBase
    {

        /// <summary>
        /// Gets a list of all the available packages from the package service
        /// </summary>
        /// <returns>List of packages</returns>
        /// <response code="200">returns the list of packages</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ICollection<PackageResponseModel>>> Get()
        {
            IFlurlResponse packageResponse = await $"{Constants.PackageApiUrl}/api/packages".GetAsync();
            var errPackageResponse = packageResponse.GetResponse("Er zijn nog geen pakketten");

            if (errPackageResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(errPackageResponse.Message) { StatusCode = (int)errPackageResponse.StatusCode };
            }

            IFlurlResponse locationResponse = await $"{Constants.LocationApiUrl}/api/room".GetAsync();
            var errLocationResponse = locationResponse.GetResponse();
            ICollection<Room> allRooms = null;

            if (errLocationResponse.StatusCode == HttpStatusCode.OK)
            {
                allRooms = await locationResponse.GetJsonAsync<ICollection<Room>>();
            }

            IFlurlResponse personResponse = await $"{Constants.PersonApiUrl}/api/persons".GetAsync();
            var errPersonResponse = personResponse.GetResponse();
            ICollection<PersonServiceModel> allPersonServiceModels = null;

            if (errPersonResponse.StatusCode == HttpStatusCode.OK)
            {
                allPersonServiceModels = await personResponse.GetJsonAsync<ICollection<PersonServiceModel>>();
            }

            ICollection<PackageServiceModel> allPackageServiceModels = await packageResponse.GetJsonAsync<ICollection<PackageServiceModel>>();
            ICollection<PackageResponseModel> allPackages = ServiceToResponseModelConverter.ConvertPackages(allPackageServiceModels, allPersonServiceModels, allRooms);

            return Ok(allPackages);

        }


        /// <summary>
        /// Gets a specific package by id
        /// </summary>
        /// <param name="id">the id of the package</param>
        /// <returns>package with matching id</returns>
        /// <response code="200">Returns the package with the specified id</response>
        /// <response code="404">No package found with the matching id</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PackageResponseModel>> GetById(Guid id)
        {
            IFlurlResponse packageResponse = await $"{ Constants.PackageApiUrl }/api/packages/{id}".GetAsync();

            var errPackageResponse = packageResponse.GetResponse();

            if (errPackageResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(errPackageResponse.Message) { StatusCode = (int)errPackageResponse.StatusCode };
            }
            PackageServiceModel packageModel = await packageResponse.GetJsonAsync<PackageServiceModel>();

            IFlurlResponse locationResponse = await $"{Constants.LocationApiUrl}/api/room".GetAsync();
            var errLocationResponse = locationResponse.GetResponse();
            ICollection<Room> allRooms = null;

            if (errLocationResponse.StatusCode == HttpStatusCode.OK)
            {
                allRooms = await locationResponse.GetJsonAsync<ICollection<Room>>();
            }

            IFlurlResponse personResponse = await $"{Constants.PersonApiUrl}/api/persons".GetAsync();
            var errPersonResponse = personResponse.GetResponse();
            ICollection<PersonServiceModel> allPersonServiceModels = null;

            if (errPersonResponse.StatusCode == HttpStatusCode.OK)
            {
                allPersonServiceModels = await personResponse.GetJsonAsync<ICollection<PersonServiceModel>>();
            }

            PackageResponseModel responseModel = ServiceToResponseModelConverter.ConvertPackage(packageModel, allPersonServiceModels, allRooms);
            return Ok(responseModel);

        }

        /// <summary>
        /// Creates a new package
        /// </summary>
        /// <param name="request">Package request model</param>
        /// <returns>the newly created package</returns>
        /// <response code="201">A new package has been created</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PackageResponseModel>> Post(PackageRequestModel request)
        {
            ObjectResult personResponse = await PersonExists(request.ReceiverId); 
            if (personResponse.StatusCode != 200)
            {
                return personResponse;
            }

            ObjectResult collectionPointResponse = await CollectionPointExists(request.CollectionPointId);
            if (collectionPointResponse.StatusCode != 200)
            {
                return collectionPointResponse;
            }

            //Post package
            IFlurlResponse flurlPostResponse = await $"{ Constants.PackageApiUrl }/api/packages".PostJsonAsync(request);
            var postResponse = flurlPostResponse.GetResponse();

            if (postResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(postResponse.Message) { StatusCode = (int)postResponse.StatusCode };
            }

            PackageServiceModel model = await flurlPostResponse.GetJsonAsync<PackageServiceModel>();
            PackageResponseModel responseModel = ServiceToResponseModelConverter.ConvertPackage(model);
            return CreatedAtAction("Post", responseModel);
        }

        /// <summary>
        /// Update a package with a specified id
        /// </summary>
        /// <param name="id">the id of the package to be updated</param>
        /// <param name="request">the data that the package should be updated with</param>
        /// <returns>Status code of update request</returns>
        /// <response code="204">The update is successful (no content)</response>
        /// <response code="404">No package found with the matching id</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        // PUT api/packages/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(Guid id, PackageRequestModel request)
        {
            ObjectResult personResponse = await PersonExists(request.ReceiverId);
            if (personResponse.StatusCode != 200)
            {
                return personResponse;
            }

            ObjectResult collectionPointResponse = await CollectionPointExists(request.CollectionPointId);
            if (collectionPointResponse.StatusCode != 200)
            {
                return collectionPointResponse;
            }

            IFlurlResponse flurlPutResponse = await $"{ Constants.PackageApiUrl }/api/packages/{id}".PutJsonAsync(request);
            var putResponse = flurlPutResponse.GetResponse();

            if (putResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(putResponse.Message) { StatusCode = (int)putResponse.StatusCode };
            }

            PackageServiceModel model = await flurlPutResponse.GetJsonAsync<PackageServiceModel>();
            PackageResponseModel responseModel = ServiceToResponseModelConverter.ConvertPackage(model);
            return StatusCode(204);
        }

        /// <summary>
        /// deletes a package with a specific id
        /// </summary>
        /// <param name="id">the id of the package to be deleted</param>
        /// <returns>Status code of delete request</returns>
        /// <response code="200">The package is successfully deleted</response>
        /// <response code="404">No package found with the matching id</response>
        /// <response code="400">bad request, something went wrong on the client-side</response>
        /// <response code="500">processing error, something went wrong on the server-side</response>
        // DELETE api/packages/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            IFlurlResponse response = await $"{ Constants.PackageApiUrl }/api/packages/{id}".DeleteAsync();

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
                return Ok();
            }
        }

        [HttpPost("tickets")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TicketResponseModel>> PostTicket(TicketRequestModel request)
        {
            ObjectResult personResponse = await PersonExists(request.CompletedByPersonId);
            if (personResponse.StatusCode != 200)
            {
                return personResponse;
            }

            ObjectResult collectionPointResponse = await CollectionPointExists(request.LocationId);
            if (collectionPointResponse.StatusCode != 200)
            {
                return collectionPointResponse;
            }

            //Post ticket
            IFlurlResponse flurlPostResponse = await $"{ Constants.PackageApiUrl }/api/tickets".PostJsonAsync(request);
            var postResponse = flurlPostResponse.GetResponse();

            if (postResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(postResponse.Message) { StatusCode = (int)postResponse.StatusCode };
            }

            TicketServiceModel model = await flurlPostResponse.GetJsonAsync<TicketServiceModel>();
            TicketResponseModel responseModel = ServiceToResponseModelConverter.ConvertTicket(model);
            return CreatedAtAction("PostTicket", responseModel);
        }

        private async Task<ObjectResult> PersonExists(string id)
        {
            IFlurlResponse flurlPersonResponse = await $"{ Constants.PersonApiUrl }/api/persons/{id}".GetAsync();
            var personResponse = flurlPersonResponse.GetResponse("De meegegeven ontvanger bestaat niet");

            if (personResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(personResponse.Message) { StatusCode = (int)personResponse.StatusCode };
            }

            return new ObjectResult(personResponse.Message) { StatusCode = (int)personResponse.StatusCode };
        }

        private async Task<ObjectResult> CollectionPointExists(Guid id)
        {
            IFlurlResponse flurlCollectionPointResponse = await $"{ Constants.LocationApiUrl }/api/Room/{id}".GetAsync();
            var collectionPointResponse = flurlCollectionPointResponse.GetResponse("De meegegeven ruimte bestaat niet");

            if (collectionPointResponse.StatusCode != HttpStatusCode.OK)
            {
                return new ObjectResult(collectionPointResponse.Message) { StatusCode = (int)collectionPointResponse.StatusCode };
            }

            return new ObjectResult(collectionPointResponse.Message) { StatusCode = (int)collectionPointResponse.StatusCode };
        }
    }
}
