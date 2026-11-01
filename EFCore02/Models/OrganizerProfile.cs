using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Models
{
    public class OrganizerProfile
    {
        public int OrganizerProfileId { get; set; }

        public string? Biography { get; set; }

        public string? Website { get; set; }

        public string? LogoUrl { get; set; }

        
        public int OrganizerId { get; set; }

        
        public Organizer Organizer { get; set; } = null!;
    }
}
