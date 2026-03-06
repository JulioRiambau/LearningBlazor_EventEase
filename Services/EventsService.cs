using System.Collections.Generic;
using System.Threading.Tasks;
using EventEase.Models;
using System;

namespace EventEase.Services
{
    public class EventsService
    {
        private readonly Dictionary<Guid, Event> _events = new Dictionary<Guid, Event>();

        public EventsService()
        {
            AddInitialEvent("Tech Conference", new DateTime(2026, 3, 10), "New York");
            AddInitialEvent("Music Festival", new DateTime(2026, 4, 5), "Los Angeles");
            AddInitialEvent("Art Expo", new DateTime(2026, 5, 15), "Chicago");
        }

        private void AddInitialEvent(string name, DateTime date, string location)
        {
            var id = Guid.NewGuid();
            var ev = new Event { Id = id, Name = name, Date = date, Location = location };
            _events[id] = ev;
        }

        public async Task<IReadOnlyList<Event>> GetEventsAsync()
        {
            await Task.Delay(200); // Simulate small delay
            // throw new Exception("Simulated error in GetEventsAsync");
            return new List<Event>(_events.Values);
        }

        public async Task AddEventAsync(Event newEvent)
        {
            await Task.Delay(200); // Simulate small delay
            if (newEvent.Id == Guid.Empty)
                newEvent.Id = Guid.NewGuid();
            _events[newEvent.Id] = newEvent;
        }

        public async Task<Event?> GetEventByIdAsync(Guid id)
        {
            await Task.Delay(200); // Simulate small delay
            _events.TryGetValue(id, out var ev);
            return ev;
        }
    }
}
