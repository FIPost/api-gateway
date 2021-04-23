using api_gateway.Models.ServiceModels;
using api_gateway.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.ResponseModels
{
    public class PackageResponseModel
    {
        public Guid Id { get; set; }
        public PersonServiceModel Receiver { get; set; }
        public string TrackAndTraceId { get; set; }
        public string CollectionPointId { get; set; }
        public string Sender { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public bool RouteFinished { get; set; }
        public virtual ICollection<TicketResponseModel> Tickets { get; set; }

        public PackageResponseModel(Guid id, string sender, string trackAndTraceId, string collectionPointId, PersonServiceModel receiver, string name,
            Status status, bool routeFinished, ICollection<TicketResponseModel> tickets)
        {
            Id = id;
            Receiver = receiver;
            TrackAndTraceId = trackAndTraceId;
            CollectionPointId = collectionPointId;
            Sender = sender;
            Name = name;
            Status = status;
            RouteFinished = routeFinished;
            Tickets = tickets;
        }

        public PackageResponseModel()
        {

        }
    }
}
