using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyTeam
    {
        // Define a computed (read-only) property for TotalPoints that
        // sum the Points for each HockeyPlayer in the team
        public int TotalPoints
        {
            get
            {
                int sum = 0;
                foreach(HockeyPlayer currentPlayer in HockeyPlayers)
                {
                    sum += currentPlayer.Points;
                }
                return sum;
            }
        }


        // Define a fully-implemented property with a backing field for the team name
        private string _teamName;   // Define a private backing field for the property
        public string TeamName      // Define a readonly property for TeamName with a private set
        {
            get { return _teamName; }
            private set 
            { 
                // Validate the new team name is not null, an empty string, or only whitespaces
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("HockeyTeam TeamName is requried");
                }
                // Validate the new team name contains 5 or more characters
                if (value.Trim().Length < 5 )
                {
                    throw new ArgumentException("HockeyTeam TeamName must contain 5 or more characters.");
                }
                _teamName = value; 
            }
        }

        // Define a auto-implemented property with a private set for Division
        public TeamDivision Division { get; private set; }

        // Define a auto-implemented readonly property for the HockeyPlayers
        public List<HockeyPlayer> HockeyPlayers { get; } = new List<HockeyPlayer>();
        
        // Define a read-only property for PlayerCount
        public int PlayerCount
        {
            get { return HockeyPlayers.Count; }
        }

        // Define a readonly property with a private set for the Coach
        // The Coach property is known as Aggregation/Composition when the field/property
        // is an object
        public HockeyCoach Coach { get; private set; }

        // Define a greedy constructor that has a parameter the for the
        // team name, team division, and coach
#pragma warning disable 
        public HockeyTeam(string teamName, TeamDivision divison, HockeyCoach coach)
        {
            TeamName = teamName;
            Division = divison;
            Coach = coach;
        }

        // Define a method to add a player to the team
        public void AddPlayer(HockeyPlayer player)
        {
            // Validate that the player is not null
            if (player == null)
            {
                throw new ArgumentNullException("HockeyTeam add HockeyPlayer is required.");
            }
            // Validate that the number of players is less than 23

            // Validate that player (by primary number) is not already on the team


            HockeyPlayers.Add(player);
        }


        public override string ToString()
        {
            return $"{TeamName},{Coach},{Division}";
        }

    }
}
