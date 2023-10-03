using System.Collections.Generic;
using EventAPI.Models;

namespace EventAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private List<Event> _events = new List<Event>();
        private int _nextId = 1;

        public Event CreateEvent(Event eventDetails)
        {
            eventDetails.Id = _nextId++;
            _events.Add(eventDetails);
            return eventDetails;
        }

        public Event GetEvent(int id)
        {
            return _events.Find(eventItem => eventItem.Id == id);
        }

        public Event UpdateEvent(int id, Event eventDetails)
        {
            var existingEvent = _events.Find(eventItem => eventItem.Id == id);
            if (existingEvent == null)
            {
                return null;
            }

            existingEvent.Title = eventDetails.Title;
            existingEvent.Description = eventDetails.Description;
            existingEvent.Date = eventDetails.Date;
            existingEvent.Owner = eventDetails.Owner;
            existingEvent.Participants = eventDetails.Participants;

            return existingEvent;
        }

        public bool DeleteEvent(int id)
        {
            var eventDetails = _events.Find(eventItem => eventItem.Id == id);
            if (eventDetails == null)
            {
                return false;
            }
            _events.Remove(eventDetails);
            return true;
        }
    }
}
