using System;
using System.ComponentModel.DataAnnotations;

namespace RadzenBlazorDemos
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
    }
}