using AutoMapper;
using Core.Application.Features.Categories.Commands.CreateCategory;
using Core.Application.Features.Categories.Queries.GetCategoriesList;
using Core.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Core.Application.Features.Events.Commands.CreateEvent;
using Core.Application.Features.Events.Commands.UpdateEvent;
using Core.Application.Features.Events.Queries.GetEventDetail;
using Core.Application.Features.Events.Queries.GetEventsList;
using Core.Application.Features.Orders.GetOrdersForMonth;
using Core.Domain.Common;
using Core.Domain.Entities;

namespace Core.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
