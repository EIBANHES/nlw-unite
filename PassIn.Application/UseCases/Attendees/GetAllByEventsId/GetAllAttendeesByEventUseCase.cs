using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.GetAllByEventsId;
public class GetAllAttendeesByEventUseCase
{

    private readonly PassInDbContext _dbContext;

    public GetAllAttendeesByEventUseCase()
    {
        _dbContext = new PassInDbContext();
    }
    public ResponseAllAttendeesJson Execute(Guid eventId)
    {
        var attendees = _dbContext.Events.Include(ev => ev.Attendees).FirstOrDefault(ev => ev.Id == eventId);
        if (attendees is null)
            throw new NotFoundException("An event with this id dont exist.");

        return new ResponseAllAttendeesJson
        {
            Attendees = attendees.Attendees.Select(attendee => new ResponseAttendeeJson 
            { 
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.Email,
                CreatedAt = attendee.Created_At
            }).ToList()
        };
    }
}
