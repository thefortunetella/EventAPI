using System;
using System.Collections.Generic;

namespace EventAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User Owner { get; set; }
        public List<User> Participants { get; set; }
    }
}
