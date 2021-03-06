using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class Player
    {
        private int id;
        public int Id { get { return id; } }
        public string IGN { get; set; }
        public string Region { get; set; }
        public double KD { get; set; }
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
            this.id = id;
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
                if (p.IGN == this.IGN && p.Id == this.Id)
                {
                    captOfTeam = t.Name;
                    t.Capt = this;
                }
            }
        }
    }
}