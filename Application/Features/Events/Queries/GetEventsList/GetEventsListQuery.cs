using Core.Application.Features.Events.Queries.GetEventsList;
using MediatR;

namespace Core.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<List<EventListVm>>
    {
    }
}
