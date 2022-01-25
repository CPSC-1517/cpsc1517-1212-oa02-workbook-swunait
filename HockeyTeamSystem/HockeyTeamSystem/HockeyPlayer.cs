using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyPlayer : Person
    {
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

        // Define an greedy constructor 
#pragma warning disable CS8618
        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition position)
            : base(fullName)
        {
            PrimaryNumber = primaryNumber;
            Position = position;
        }

        // Override the ToString() method to return a CSV 
        public override string ToString()
        {
            return $"{FullName},{PrimaryNumber},{Position}";
        }

    }
}
