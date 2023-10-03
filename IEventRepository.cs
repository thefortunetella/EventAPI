using System.Collections.Generic;
using EventAPI.Models;

namespace EventAPI.Repositories
{
    public interface IEventRepository
    {
        Event CreateEvent(Event eventDetails);
        Event GetEvent(int id);
        Event UpdateEvent(int id, Event eventDetails);
        bool DeleteEvent(int id);
    }
}
