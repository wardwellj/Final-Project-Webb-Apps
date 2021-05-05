using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class KZRoster
    {
        List<Player> players;
        List<Team> teams;

        public List<Player> Players 
        { 
            get { return players; } 
            set { players = value; } 
        }

        public List<Team> Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        public KZRoster(List<Player> plyrs, List<Team> Ts)
        {
            this.players = plyrs;
            this.teams = Ts;
        }
    }
}