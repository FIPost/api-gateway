using api_gateway.Models.ServiceModels;
using api_gateway.Models.ServiceModels.Location;
using api_gateway.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.ResponseModels
{
    public class TicketResponseModel
    {
        public Guid Id { get; set; }
        public Room Location { get; set; }
        public double FinishedAt { get; set; }
        public PersonServiceModel CompletedByPerson { get; set; }
        public PersonServiceModel ReceivedByPerson { get; set; }
        public Guid PackageId { get; set; }

        public TicketResponseModel(Guid id, Room location, double finishedAt, PersonServiceModel completedBy, PersonServiceModel receivedBy, Guid packageId)
        {
            Id = id;
            Location = location;
            FinishedAt = finishedAt;
            CompletedByPerson = completedBy;
            ReceivedByPerson = receivedBy;
            PackageId = packageId;
        }

        public TicketResponseModel()
        {

        }
    }
}
