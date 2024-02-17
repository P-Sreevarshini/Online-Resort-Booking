using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnetapp.Models
{
    public class Resort
    {
        [Key]
        public long ResortId { get; set; }

        public string ResortName { get; set; }

        public string ResortImageUrl { get; set; }

        public string ResortLocation { get; set; }

        public string ResortAvailableStatus { get; set; }

        public long Price { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}

