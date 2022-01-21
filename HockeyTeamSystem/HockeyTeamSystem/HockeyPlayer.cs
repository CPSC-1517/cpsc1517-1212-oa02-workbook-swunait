using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyPlayer
    {
        private string _fullName;
        private int _primaryNumber;
        public PlayerPosition Position { get; private set; }

        public int PrimaryNumber 
        { 
            get { return _primaryNumber; } 
            private set 
            { 
                // Validate PrimaryNumber is between 1 and 99
                if (value < 1 || value > 99)
                {
                    throw new ArgumentException("HockeyPlayer PrimaryNumber must between 1 and 99.");
                }
                _primaryNumber = value; 
            }
        }

        // Define an fully-implemented property for FullName 
        // with readonly information.
        // Validate FullName is not null, not empty, and not a whitespace.
        // Validate FullName contains at minimum 3 characters
        public string FullName
        {
            get { return _fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("HockeyPlayer FullName is required");
                }
                if (value.Trim().Length <= 2)
                {
                    throw new ArgumentException("HockeyPlayer FullName must contain 3 or more characters");
                }
                _fullName = value.Trim();
            }
        }

        // Define an greedy constructor 
#pragma warning disable CS8618
        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition position)
        {
            FullName = fullName;
            PrimaryNumber = primaryNumber;
            Position = position;
        }

        // Override the ToString() method to return a CSV 
        public override string ToString()
        {
            return $"{FullName}, {PrimaryNumber}, {Position}";
        }

    }
}
