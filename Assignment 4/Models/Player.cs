using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class Player
    {
        private int playerId;
        public int PlayerId { get { return playerId; } }
        public string IGN { get; set; }
        public string Region { get; set; }
        public double KD { get; set; }
        private string TeamIds = "";
        public List<Team> Teams { get; set; }

        private bool isCaptain = false;
        public bool isCapt 
        {
            get { return isCaptain; }  
        }

        private string captOfTeam = "";
        public string CaptOfTeam
        {
            get { return captOfTeam; }
        }

        public Player(string ign, string reg, double kd, int id)
        {
            this.playerId = id;
            this.IGN = ign;
            this.KD = kd;
            this.Region = reg;
            Teams = new List<Team>();
        }



        public void setTeamCap(Team t)
        {
            if(this.isCapt == true)
            {
                throw new Exception($"{this.IGN} is already a captain of a team. Team Name:{CaptOfTeam}");
            }
            foreach(Player p in t.teamPlayers)
            {
                if (p.IGN == this.IGN && p.PlayerId == this.PlayerId)
                {
                    captOfTeam = t.Name;
                    t.Capt = this;
                }
            }
        }
    }
}