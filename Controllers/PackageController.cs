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
    [Route("api/packages")]
    [ApiController]
    public class PackageController : ControllerBase
    {

        // GET: api/packages
        [HttpGet]
        public async Task<ActionResult<ICollection<PackageResponseModel>>> Get()
        {
            IFlurlResponse response = await $"http://localhost/api/packages".GetAsync();

            if(response.StatusCode != 200)
            {
                return BadRequest();
            }
            else
            {
                ICollection<PackageServiceModel> serviceModels = await response.GetJsonAsync<ICollection<PackageServiceModel>>();
                ICollection<PackageResponseModel> responseModels = ServiceToResponseModelConverter.ConvertPackages(serviceModels);
                return Ok(responseModels);
            }
        }

        // GET api/packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageResponseModel>> GetById(Guid id)
        {
            IFlurlResponse response = await $"http://localhost/api/packages/{id}".GetAsync();

            if(response.StatusCode == 404)
            {
                return NotFound();
            }
            else if(response.StatusCode != 200)
            {
                return BadRequest();
            }
            else
            {
                PackageServiceModel model = await response.GetJsonAsync();
                PackageResponseModel responseModel = ServiceToResponseModelConverter.ConvertPackage(model);
                return Ok(responseModel);
            }
        }

        // POST api/packages
        [HttpPost]
        public async Task<ActionResult<PackageResponseModel>> Post(PackageRequestModel request)
        {
            IFlurlResponse response = await $"http://localhost:5001/api/packages".PostJsonAsync(request);

            if(response.StatusCode != 201)
            {
                return BadRequest();
            }
            else
            {
                PackageServiceModel model = await response.GetJsonAsync<PackageServiceModel>();
                PackageResponseModel responseModel = ServiceToResponseModelConverter.ConvertPackage(model);
                return CreatedAtAction("GetPackage", new { id = model.Id }, responseModel);
            }
        }

        // PUT api/packages/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PackageResponseModel>> Put(Guid id, PackageRequestModel request)
        {
            IFlurlResponse response = await $"http://localhost:5001/api/packages/{id}".PutJsonAsync(request);

            if(response.StatusCode == 404)
            {
                return NotFound();
            }
            else
            {
                PackageServiceModel model = await response.GetJsonAsync<PackageServiceModel>();
                return ServiceToResponseModelConverter.ConvertPackage(model);
            }
        }

        // DELETE api/packages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            IFlurlResponse response = await $"http://localhost:5001/api/packages/{id}".DeleteAsync();
            if(response.StatusCode == 404)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
