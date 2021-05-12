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
        public string ToDoLocationId { get; set; }
        public double CreatedAt { get; set; }
        public string CreatedByPCN { get; set; }
        public double FinishedAt { get; set; }
        public string FinishedByPCN { get; set; }
        public bool IsFinished { get; set; }
        public string NextTicketId { get; set; }
        public TicketAction TicketAction { get; set; }

        public TicketResponseModel(Guid id, string toDoLocationId, double createdAt, string createdByPCN, double finishedAt, string finishedByPCN, bool isFinished, string nextTicketId, TicketAction ticketAction)
        {
            Id = id;
            ToDoLocationId = toDoLocationId;
            CreatedAt = createdAt;
            CreatedByPCN = createdByPCN;
            FinishedAt = finishedAt;
            FinishedByPCN = finishedByPCN;
            IsFinished = isFinished;
            NextTicketId = nextTicketId;
            TicketAction = ticketAction;
        }

        public TicketResponseModel()
        {

        }
    }
}
