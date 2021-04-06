using api_gateway.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.ResponseModels
{
    public class TicketResponseModel
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

        public TicketResponseModel(Guid id, string toDoLocationId, DateTime createdAt, string createdByPCN, double finishedAt, string finishedByPCN, bool isFinished, string nextTicketId, TicketAction ticketAction)
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
    }
}
