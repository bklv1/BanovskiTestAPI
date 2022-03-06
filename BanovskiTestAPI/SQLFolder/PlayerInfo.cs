using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanovskiTestAPI.SQLFolder
{
    public class PlayerInfo
    {
        [Key]
        public int Id { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerClub { get; set; }
        public int JerseyNumber { get; set; }        
        public List<TeamInfo> AllClubs { get; set; }        
    }
   
}

