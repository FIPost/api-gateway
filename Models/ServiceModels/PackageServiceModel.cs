using api_gateway.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.ServiceModels
{
    public class PackageServiceModel
    {
        public Guid Id { get; }
        public string ReceiverId { get; }
        public string TrackAndTraceId { get; }
        public string CollectionPointId { get; }
        public string Sender { get; }
        public string Name { get; }
        public Status Status { get; }
        public bool RouteFinished { get; }
        public virtual ICollection<TicketServiceModel> Tickets { get; }

    }
}
