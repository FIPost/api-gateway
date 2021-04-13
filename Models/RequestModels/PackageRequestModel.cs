using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.RequestModels
{
    public class PackageRequestModel
    {
        public int ReceiverId { get; set; }
        public int CollectionPointId { get; set; }
        public int TrackAndTraceId { get; set; }
        public string Sender { get; set; }
        public string Name { get; set; }
    }
}
