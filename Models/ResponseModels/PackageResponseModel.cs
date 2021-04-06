using api_gateway.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.ResponseModels
{
    public class PackageResponseModel
    {
        public Guid Id { get; }
        public string ReceiverId { get; }
        public string TrackAndTraceId { get; }
        public string CollectionPointId { get; }
        public string Sender { get; }
        public string Name { get; }
        public Status Status { get; }
        public bool RouteFinished { get; }
        public virtual ICollection<TicketResponseModel> Tickets { get; }

        public PackageResponseModel(Guid id, string receiverId, string trackAndTraceId, string collectionPointId, string sender, string name, Status status, bool routeFinished, ICollection<TicketResponseModel> tickets)
        {
            Id = id;
            ReceiverId = receiverId;
            TrackAndTraceId = trackAndTraceId;
            CollectionPointId = collectionPointId;
            Sender = sender;
            Name = name;
            Status = status;
            RouteFinished = routeFinished;
            Tickets = tickets;
        }
    }
}
