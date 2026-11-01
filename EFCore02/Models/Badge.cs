using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Models
{
    public enum BadgeTier
    {
        Standard,
        VIP
    }
    public class Badge
    {
        public int BadgeId { get; set; }

        public string BadgeNumber { get; set; } = string.Empty;

        public DateTime IssueDate { get; set; }

        public BadgeTier Tier { get; set; }

        
        public int AttendeeId { get; set; }

        
        public Attendee Attendee { get; set; } = null!;
    }
}
