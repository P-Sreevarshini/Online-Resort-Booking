using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace dotnetapp.Models
{
    public class Review
    {
         [Key]
        public int ReviewId { get; set; } 

        public string Subject { get; set; }

        public string Body { get; set; }

        [Range(1, 5)] 
        public int Rating { get; set; }

        public DateTime DateCreated { get; set; }
        public long UserId { get; set; }

  //   [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
     //   public virtual ICollection<User>? Users { get; set; }

    }
}