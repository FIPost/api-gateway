using api_gateway.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.ServiceModels
{
    public class TicketServiceModel
    {
        public Guid Id { get; }
        public string ToDoLocationId { get; }
        public DateTime CreatedAt { get; }
        public string CreatedByPCN { get; }
        public double FinishedAt { get; }
        public string FinishedByPCN { get; }
        public bool IsFinished { get; }
        public string NextTicketId { get; }
        public TicketAction TicketAction { get; }

    }
}
