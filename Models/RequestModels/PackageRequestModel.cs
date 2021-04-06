using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.RequestModels
{
    public class PackageRequestModel
    {
        public int ReceiverId { get; }
        public int CollectionPointId { get; }
        public int TrackAndTraceId { get; }
        public string Sender { get; }
        public string Name { get; }
    }
}
