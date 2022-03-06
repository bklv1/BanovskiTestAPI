using Microsoft.EntityFrameworkCore;


namespace BanovskiTestAPI.SQLFolder
{
    public class PlayersContext : DbContext
    {
        public PlayersContext(DbContextOptions options) : base(options)
        {}
      
        public DbSet<PlayerInfo> playerInfo { get; set; }
        public DbSet<TeamInfo> teamInfo { get; set; }
       
    }
}
