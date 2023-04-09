using AutoMapper;
using Core.Application.Contracts.Infrastructure;
using Core.Application.Contracts.Persistence;
using Core.Application.Exceptions;
using Core.Application.Models.Mail;
using Core.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Core.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository,
            IEmailService emailService, ILogger<CreateEventCommandHandler> logger)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            //For Validation
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if(validatorResult.Errors.Count > 0)
            {
                throw new ValidationException(validatorResult);
            }

            @event = await _eventRepository.AddAsync(@event);

            // Sending email notification to admin address
            var email = new Email()
            {
                To ="nabilhekal8@gmail.com",
                Subject = $"A new event was created {request}",
                Body = "A new event was created from clean architecture project."
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
            }

            return @event.CategoryId;
        }
    }
}
