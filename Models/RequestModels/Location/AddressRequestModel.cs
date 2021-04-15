using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api_gateway.Models.ServiceModels.Location;

namespace api_gateway.Models.RequestModels.Location
{
    public class AddressRequestModel
    {
        [Required]
        public City City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        public string Addition { get; set; }
    }
}
