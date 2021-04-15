using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_gateway.Models.ServiceModels.Location;

namespace api_gateway.Models.RequestModels.Location
{
    public class RoomRequestModel
    {
        public string Name { get; set; }
        public Building Building { get; set; }
    }
}
