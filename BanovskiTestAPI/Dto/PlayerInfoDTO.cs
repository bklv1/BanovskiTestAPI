using BanovskiTestAPI.SQLFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanovskiTestAPI.DTO
{
    public class PlayerInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public string CurrentTeam { get; set; }
        public List<TeamHistory> TeamHistory { get; set; } = new List<TeamHistory>();
    }

    public class TeamHistory
    {
      public string ClubName { get; set; }      
    }
}
