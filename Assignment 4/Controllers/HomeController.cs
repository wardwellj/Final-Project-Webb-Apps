using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_4.Models;

namespace Assignment_4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Thanks()
        {
            return View();
        }

        List<Player> players = null;
        List<Team> teams = null;
        KZRoster roster;
        int pid = 10000;
        int tid = 1000;
        int PlayerID { get { pid += 10; return pid; } }
        int TeamID { get { tid += 20; return tid; } }



        // GET: Players
        public ActionResult Roster()
        {
            CreateRosterData();

            var success = BuildRoster();

            if (success == true)
            {
                var Roster = roster;
                return View(Roster);
            }

            return new EmptyResult();
        }

        public ActionResult Teams()
        {
            CreateRosterData();

            var success = BuildRoster();

            if (success == true)
            {
                var Roster = roster;
                return View(Roster);
            }

            return new EmptyResult();
        }

        public ActionResult ShowTeam(int id)
        {
            CreateRosterData();
            Team pageTeam;
            foreach (Team t in teams)
            {
                if (t.TeamId == id)
                {
                    pageTeam = t;
                    ViewBag.Title = pageTeam.Name;
                    return View(pageTeam);
                }
                else
                {
                    if (teams.Count == 0)
                    {
                        throw new NullReferenceException("There are no teams generated.");
                    }
                    continue;
                }
            }
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult SearchRoster(string searchBy, string searchText) {
            var searchtxt = searchText.ToLower();
            List<Player> foundPlayers = new List<Player>();

            CreateRosterData();
            if (searchText != "" || searchText != null)
            {
                if (searchBy == "IGN(In Game Name)")
                {
                    foundPlayers = players.Where(x => x.IGN.ToLower().Contains(searchtxt)).ToList();
                }
                else if (searchBy == "Region")
                {
                    foundPlayers = players.Where(x => x.Region.ToLower().Contains(searchtxt)).ToList();
                }
                else if (searchBy == "KD Greater Than")
                {
                    foundPlayers = players.Where(x => x.KD >= Int32.Parse(searchtxt)).ToList();
                }
                else if (searchBy == "KD Less Than")
                {
                    foundPlayers = players.Where(x => x.KD <= Int32.Parse(searchtxt)).ToList();
                }
                else
                {
                    foundPlayers = players.Where(x => x.IGN.ToLower().Contains(searchtxt) || x.Region.ToLower().Contains(searchtxt)).ToList();
                }
                return View(foundPlayers);
            }
            else
            {
                var orderedAlbums = players.OrderBy(a => a.IGN);
                return View(orderedAlbums);
            }
        }
        [HttpPost]
        public ActionResult SearchTeams(string searchBy, string searchText) {
            var searchtxt = searchText.ToLower();
            List<Team> foundTeams = new List<Team>();

            CreateRosterData();
            if (searchText != "" || searchText != null)
            {
                if (searchBy == "Name")
                {
                    foundTeams = teams.Where(x => x.Name.ToLower().Contains(searchtxt)).ToList();
                }
                else if (searchBy == "Region")
                {
                    foundTeams = teams.Where(x => x.Region.ToLower().Contains(searchtxt)).ToList();
                }
                else if (searchBy == "Captain")
                {
                    foundTeams = teams.Where(x => x.Capt.IGN.ToLower().Contains(searchtxt)).ToList();
                }
                else
                {
                    foundTeams = teams.Where(x => x.Name.ToLower().Contains(searchtxt) || x.Region.ToLower().Contains(searchtxt)).ToList();
                }
                return View(foundTeams);
            }
            else
            {
                var orderedAlbums = teams.OrderBy(a => a.Name);
                return View(orderedAlbums);
            }
        }

        public bool BuildRoster()
        {
            if (players == null || teams == null)
            {
                if (players == null && teams != null)
                {
                    Console.WriteLine("Players is empty please add players to fill the roster.");
                    return false;
                }
                else if (teams == null && players != null)
                {
                    Console.WriteLine("Teams is empty please add teams to fill the roster.");
                    return false;
                }
                else
                {
                    Console.WriteLine("Both the Player list and Team list is empty, please fill them to build your roster.");
                    return false;
                }
            }
            else
            {
                roster = new KZRoster(players, teams);
                return true;
            }
        }

        public void CreateRosterData()
        {
            pid = 10000;
            tid = 1000;

            Team red = new Team("Red Team", "North America", TeamID);
            Team gold = new Team("Gold Team", "Europe", TeamID);
            Team black = new Team("Black Team", "North America", TeamID);
            Team Comp = new Team("Competitive", "North America", TeamID);

            Player nullified = new Player("Nullified", "North America", 5.5, PlayerID);
            Player genex = new Player("Genextion", "Europe", 3.5, PlayerID);
            Player fen = new Player("Fenessence", "North America", 7.0, PlayerID);
            Player anon = new Player("Anonymous", "Europe", 5.0, PlayerID);
            Player Kali = new Player("Kalifan", "North America", 2.5, PlayerID);
            Player unreal = new Player("unrealAsset", "North America", 3.0, PlayerID);
            Player faded = new Player("FadedAwakening", "North America", 5.0, PlayerID);
            Player shadow = new Player("Shadowness13", "North America", 5.2, PlayerID);
            Player canadian = new Player("CanadianGamerHB", "Europe", 4.0, PlayerID);
            Player Scotty = new Player("ScottyCWZ", "North America", 3.0, PlayerID);
            Player tang = new Player("DembBomb", "Europe", 3.0, PlayerID);
            Player mom = new Player("Mom", "North America", 0.1, PlayerID);

            red.addPlayer(nullified);
            red.addPlayer(fen);
            red.addPlayer(faded);
            red.addPlayer(Scotty);
            red.setCapt(faded);

            gold.addPlayer(genex);
            gold.addPlayer(anon);
            gold.addPlayer(canadian);
            gold.addPlayer(tang);
            gold.setCapt(anon);

            black.addPlayer(unreal);
            black.addPlayer(Kali);
            black.addPlayer(Scotty);
            black.addPlayer(shadow);
            black.addPlayer(faded);
            black.addPlayer(mom);
            black.setCapt(unreal);

            Comp.addPlayer(faded);
            Comp.addPlayer(nullified);
            Comp.addPlayer(shadow);
            Comp.addPlayer(Scotty);
            Comp.addPlayer(fen);
            Comp.setCapt(nullified);

            AddTeam(red);
            AddTeam(gold);
            AddTeam(black);
            AddTeam(Comp);

            AddPlayer(nullified);
            AddPlayer(genex);
            AddPlayer(fen);
            AddPlayer(anon);
            AddPlayer(Kali);
            AddPlayer(unreal);
            AddPlayer(faded);
            AddPlayer(shadow);
            AddPlayer(canadian);
            AddPlayer(Scotty);
            AddPlayer(tang);
            AddPlayer(mom);
        }


        public void NewPlayer(string ign, string region, int kd)
        {
            Player newPlayer = new Player(ign, region, kd , PlayerID);
            players.Add(newPlayer);
        }

        public void AddPlayer(Player newPlayer)
        {
            if (players == null)
            {
                players = new List<Player>();
            }
            Player NewPlayer = newPlayer;
            players.Add(NewPlayer);
        }

        public void MakeTeam(string name, string reg)
        {
            Team newTeam = new Team(name, reg, TeamID);
            teams.Add(newTeam);
        }
        public void AddTeam(Team newTeam)
        {
            if (teams == null)
            {
                teams = new List<Team>();
            }
            Team NewTeam = newTeam;
            teams.Add(NewTeam);
        }
    }
}