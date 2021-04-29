using api_gateway.Models.ResponseModels;
using api_gateway.Models.ServiceModels;
using api_gateway.Models.ServiceModels.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_gateway.Models.Converters
{
    /// <summary>
    /// Transfers incoming objects from microservices into response objects for API endpoints
    /// </summary>
    public static class ServiceToResponseModelConverter
    {
        public static PackageResponseModel ConvertPackage(PackageServiceModel serviceModel)
        {
            return new PackageResponseModel(
                serviceModel.Id,
                serviceModel.Sender,
                serviceModel.TrackAndTraceId,
                null,
                null,
                serviceModel.Name,
                serviceModel.Status,
                serviceModel.RouteFinished,
                ConvertTickets(serviceModel.Tickets)
                );
        }

        public static PackageResponseModel ConvertPackage(PackageServiceModel serviceModel, PersonServiceModel personServiceModel, Room room)
        {
            return new PackageResponseModel(
                serviceModel.Id,
                serviceModel.Sender,
                serviceModel.TrackAndTraceId,
                room,
                personServiceModel,
                serviceModel.Name,
                serviceModel.Status,
                serviceModel.RouteFinished,
                ConvertTickets(serviceModel.Tickets)
                );
        }

        public static TicketResponseModel ConvertTicket(TicketServiceModel serviceModel)
        {
            return new TicketResponseModel(
                serviceModel.Id,
                serviceModel.ToDoLocationId,
                serviceModel.CreatedAt,
                serviceModel.CreatedByPCN,
                serviceModel.FinishedAt,
                serviceModel.FinishedByPCN,
                serviceModel.IsFinished,
                serviceModel.NextTicketId,
                serviceModel.TicketAction
                );
        }

        public static ICollection<TicketResponseModel> ConvertTickets(ICollection<TicketServiceModel> serviceModels)
        {
            List<TicketResponseModel> responseModels = new List<TicketResponseModel>();

            // if the list is null assume empty and return an empty response model list
            if(serviceModels == null)
            {
                return new List<TicketResponseModel>();
            }

            foreach(var serviceModel in serviceModels)
            {
                TicketResponseModel responseModel = ConvertTicket(serviceModel);
                responseModels.Add(responseModel);
            }

            return responseModels;
        }

        public static ICollection<PackageResponseModel> ConvertPackages(ICollection<PackageServiceModel> packageServiceModels,
            ICollection<PersonServiceModel> personServiceModels, ICollection<Room> rooms)
        {
            List<PackageResponseModel> responseModels = new List<PackageResponseModel>();

            foreach(var serviceModel in packageServiceModels)
            {
                PersonServiceModel personServiceModel = personServiceModels.FirstOrDefault(p => p.Id == serviceModel.ReceiverId);
                Room room = rooms.FirstOrDefault(r => r.Id.ToString() == serviceModel.CollectionPointId);

                PackageResponseModel responseModel = ConvertPackage(serviceModel, personServiceModel, room);
                responseModels.Add(responseModel);
            }

            return responseModels;
        }
    }
}
