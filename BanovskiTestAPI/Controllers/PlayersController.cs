using BanovskiTestAPI.DTO;
using BanovskiTestAPI.Models;
using BanovskiTestAPI.SQLFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BanovskiTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private PlayersContext _dbContext;
        public PlayersController(PlayersContext dbContext)
        {
           _dbContext = dbContext;
        }

        [HttpGet("GetPlayers")]
        public IActionResult Get()
        {
            try
            {

                var players = _dbContext.playerInfo.Select(x => new PlayerInfoDTO()
                {
                    Id = x.Id,
                    FirstName = x.PlayerFirstName,
                    LastName = x.PlayerLastName,
                    CurrentTeam = x.PlayerClub,
                    JerseyNumber = x.JerseyNumber,
                    TeamHistory = x.AllClubs.Select(y => new DTO.TeamHistory()
                    {
                        ClubName = y.TeamName
                    }).ToList()
                }).ToList();
                
                if (players.Count==0)
                {
                    return StatusCode(404, "There is no player found!");
                }
                
                return Ok(players);
                
            }
            catch (Exception)
            {
               return StatusCode(500, "An error occured while fetching all users!");                
            }         
        }

        [HttpPost("CreatePlayer")]
        public IActionResult Create([FromBody] PlayerRequest request)
        {
            PlayerInfo player = new PlayerInfo();
            TeamInfo team = new TeamInfo();
           

            player.Id = request.Id;            
            player.PlayerFirstName = request.PlayerFirstName;
            player.PlayerLastName = request.PlayerLastName;
            player.PlayerClub = request.PlayerClub;
            player.JerseyNumber = request.JerseyNumber;

            team.TeamName = request.PlayerClub;
            
            try
            {                             
                             
               _dbContext.playerInfo.Add(player);
               _dbContext.SaveChanges();
                
                var id = player.Id;
                team.PlayerInfoId = id;
                _dbContext.teamInfo.Add(team);
                _dbContext.SaveChanges();
                
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured while creating a player!");                
            }

            var players = _dbContext.playerInfo.Select(x => new PlayerInfoDTO()
            {
                Id = x.Id,
                FirstName = x.PlayerFirstName,
                LastName = x.PlayerLastName,
                CurrentTeam= x.PlayerClub,
                JerseyNumber = x.JerseyNumber,

               TeamHistory = x.AllClubs.Select(y => new DTO.TeamHistory()
               {
                   ClubName = y.TeamName
               }).ToList()
            }).ToList();

            return Ok(players);
              

        }

        [HttpPut("UpdatePlayer")]
        public IActionResult Update([FromBody] PlayerRequest request)
        {
            
            try
            {
                var player = _dbContext.playerInfo.FirstOrDefault(x => x.Id == request.Id);
               
                if(player == null)
                {
                    return StatusCode(404, "Player not found!");
                }
                player.Id = request.Id;
                player.PlayerFirstName = request.PlayerFirstName;
                player.PlayerLastName = request.PlayerLastName;
                player.PlayerClub = request.PlayerClub;
                player.JerseyNumber = request.JerseyNumber;

                TeamInfo team = new TeamInfo();
                team.TeamName = request.PlayerClub;
                var id = player.Id;
                team.PlayerInfoId = id;
                _dbContext.teamInfo.Add(team);

                _dbContext.Entry(player).State = EntityState.Modified;              
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured while updating a player!");
            }
           
            var players = _dbContext.playerInfo.Select(x => new PlayerInfoDTO()
            {
                Id = x.Id,
                FirstName = x.PlayerFirstName,
                LastName = x.PlayerLastName,
                CurrentTeam = x.PlayerClub,
                JerseyNumber = x.JerseyNumber,
                TeamHistory = x.AllClubs.Select(y => new DTO.TeamHistory()
                {
                    ClubName = y.TeamName
                    
                }).ToList()
            }).ToList();
            return Ok(players);
        }

        [HttpDelete("DeletePlayer/{Id}")]
        public IActionResult Delete([FromRoute]int Id)
        {
            try
            {
                var teams = _dbContext.teamInfo.Where(z => z.PlayerInfoId == Id);
                var player = _dbContext.playerInfo.FirstOrDefault(x => x.Id == Id);
                
                if (player == null)
                {
                    return StatusCode(404, "Player not found!");
                }

                foreach (var team in teams)
                {
                    _dbContext.Entry(team).State = EntityState.Deleted;
                }
                _dbContext.SaveChanges();
                _dbContext.Entry(player).State = EntityState.Deleted;                
                _dbContext.SaveChanges();
               
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured while deleting a player!");
            }
            var players = _dbContext.playerInfo.Select(x => new PlayerInfoDTO()
            {
                Id = x.Id,
                FirstName = x.PlayerFirstName,
                LastName = x.PlayerLastName,
                CurrentTeam = x.PlayerClub,
                JerseyNumber = x.JerseyNumber,
                TeamHistory = x.AllClubs.Select(y => new DTO.TeamHistory()
                {
                    ClubName = y.TeamName
                }).ToList()
            }).ToList();
            return Ok(players);
        }

    }   
}
