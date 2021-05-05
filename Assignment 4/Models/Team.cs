using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class Team
    {
        private int id;
        public int Id { get { return id; }}

        public string Name { get; set; }
        public string Region { get; set; }
        public Player Capt { get; set; }
        public List<Player> teamPlayers { get; set; }

        public Team() {}

        public Team(string name, string reg, int id)
        {
            this.id = id;
            this.Name = name;
            this.Region = reg;
            teamPlayers = new List<Player>();
        }

        public void addPlayer(Player p)
        {
            if(p.Region == this.Region && p.Id > 10000)
            {
                teamPlayers.Add(p);
                p.Teams.Add(this);
            }
        }

        public void setCapt(Player p)
        {
            var onTeam = false;

            foreach(Player x in teamPlayers)
            {
                if (x == p)
                {
                    onTeam = true;
                }
            }

            if (onTeam == true)
            {
                this.Capt = p;
                p.setTeamCap(this);
            }
        }
    }
}