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
        public string Location { get; set; }
        public double FinishedAt { get; set; }
        public string CompletedByPerson { get; set; }
        public string ReceivedByPerson { get; set; }

        public TicketResponseModel(Guid id, string location, double finishedAt, string completedBy, string receivedBy)
        {
            Id = id;
            Location = location;
            FinishedAt = finishedAt;
            CompletedByPerson = completedBy;
            ReceivedByPerson = receivedBy;
        }

        public TicketResponseModel()
        {

        }
    }
}
