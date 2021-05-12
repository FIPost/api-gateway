using api_gateway.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.ServiceModels
{
    public class TicketServiceModel
    {
        public Guid Id { get; set; }
        public string ToDoLocationId { get; set; }
        public double CreatedAt { get; set; }
        public string CreatedByPCN { get; set; }
        public double FinishedAt { get; set; }
        public string FinishedByPCN { get; set; }
        public bool IsFinished { get; set; }
        public string NextTicketId { get; set; }
        public TicketAction TicketAction { get; set; }

    }
}
