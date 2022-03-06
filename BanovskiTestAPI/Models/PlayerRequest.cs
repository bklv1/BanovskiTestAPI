using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanovskiTestAPI.Models
{
    public class PlayerRequest
    {
        public int Id { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerClub { get; set; }
        public int JerseyNumber { get; set; }        
    
    }
}
