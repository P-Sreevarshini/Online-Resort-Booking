using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
 
using System.ComponentModel.DataAnnotations.Schema;
 
namespace dotnetapp.Models
{
    public class Booking
    {
        [Key]
        public long BookingId { get; set; }
 
        public int? NoOfPersons { get; set; }
 
        public DateTime? FromDate { get; set; }
 
        public DateTime? ToDate { get; set; }
 
        public string? Status { get; set; }
 
        public double? TotalPrice { get; set; }
 
        public string? Address { get; set; }
 
        // Foreign key for the Many-to-One relationship with User
        public long? UserId { get; set; } // Nullable foreign key
  // [JsonIgnore]
 
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } // Nullable navigation property
    // [JsonIgnore]
 
        public long? ResortId { get; set; } // Nullable foreign key
   // [JsonIgnore]
        [ForeignKey(nameof(ResortId))]
        public virtual Resort? Resort { get; set; } // Nullable navigation property
 
    }
}