using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    // Define a class named HockeyCoach that inherits from the base class Person
    public class HockeyCoach : Person
    {
        // Define a readonly public field that can only be assigned a value
        // in the constructor
        //[JsonInclude]
        public readonly string StartDate;

        // Define a greedy constructor with fullName and startDate as parameters
        // The ": base(fullName)" means pass fullName to the base class (Person) constructor
        public HockeyCoach(string fullName, string startDate) : base(fullName)
        {
            this.StartDate = startDate; 
        }


        // Override the ToString() method to return a CSV
        public override string ToString()
        {
            return $"{FullName},{StartDate}";
        }
    }
}
