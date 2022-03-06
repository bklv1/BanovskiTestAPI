using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BanovskiTestAPI.SQLFolder
{
    public class TeamInfo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int PlayerId { get; set; }
        public string TeamName { get; set; }
        public int PlayerInfoId { get; set; }
    }
}
