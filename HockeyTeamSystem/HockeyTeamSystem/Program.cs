// See https://aka.ms/new-console-template for more information
using HockeyTeamSystem;
using static System.Console;

// Define a constant for the location of players CSV data file
const string HockeyPlayerCsvFile = "../../../HockeyPlayers.csv";
// Create a new HockeyCoach instance for the team
HockeyCoach coach = new HockeyCoach("Dave Tippet","May 28, 2019");
WriteLine(coach);
// Create players for the team
HockeyPlayer player1 = new HockeyPlayer("Leon Draisaitl", 29, PlayerPosition.Center, 29, 30);
WriteLine(player1);
HockeyPlayer player2 = new HockeyPlayer("Connor McDavid", 97, PlayerPosition.Center, 20, 37);
WriteLine(player2);
HockeyPlayer player3 = new HockeyPlayer("Ryan Nugent-Hopkins", 93, PlayerPosition.Center, 3, 24);
WriteLine(player3);
HockeyPlayer player4 = new HockeyPlayer("Jesse Puljujarvi", 13, PlayerPosition.RightWing, 10, 15);
WriteLine(player4);
// Create a hockey team
HockeyTeam team1 = new HockeyTeam("Edmonton Oilers", TeamDivision.Pacific, coach);
// Add players to the hockey team
team1.AddPlayer(player1);
team1.AddPlayer(player2);
team1.AddPlayer(player3);
team1.AddPlayer(player4);
WriteLine(team1);

// Write the list of hockey players to a CSV file
// Step 1: Create a csv line for each hockey player and add it to a list of string values
List<string> csvLines = new List<string>();
foreach(HockeyPlayer currentPlayer in team1.HockeyPlayers)
{
    csvLines.Add(currentPlayer.ToString());
}
// Step 2: Write all the lines in the list of string values to a file
File.WriteAllLines(HockeyPlayerCsvFile, csvLines);
// Display the location absolute path of the csv data file
WriteLine($"Successfully created csv file at: {Path.GetFullPath(HockeyPlayerCsvFile)}");

// Read the list of hockey players from the CSV file
try
{
    WriteLine("Reading from CSV file");
    string[] csvLineArray = File.ReadAllLines(HockeyPlayerCsvFile);
    foreach(string line in csvLineArray)
    {
        HockeyPlayer currentPlayer = null;
        bool parseSuccessful = HockeyPlayer.TryParse(line, out currentPlayer);
        WriteLine(currentPlayer);
    }
}
catch (Exception ex)
{
    WriteLine(ex);
}



//Person person1 = new Person("S Wu");


//// Test with valid FullName, PrimaryNumber
//HockeyPlayer player1 = new("    Connor McDavid  ", 97, PlayerPosition.Center);
//Console.WriteLine(player1); // The HockeyPlayer.ToString() will be invoked indirectly
//// Test with invalid PrimaryNumber
//try
//{
//    HockeyPlayer player2 = new("Connor McDavid", 0, PlayerPosition.Center);
//    Console.WriteLine("Test case has failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//try
//{
//    HockeyPlayer player2 = new("Connor McDavid", 100, PlayerPosition.Center);
//    Console.WriteLine("Test case has failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//// Test with null for FullName
//try
//{
//    HockeyPlayer player2 = new(null, 97, PlayerPosition.Center);
//    Console.WriteLine("Test case has failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//// Test with empty string for FullName
//try
//{
//    HockeyPlayer player2 = new("", 97, PlayerPosition.Center);
//    Console.WriteLine("Test case has failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}
//// Test with whitespaces for FullName
//try
//{
//    HockeyPlayer player2 = new("            ", 97, PlayerPosition.Center);
//    Console.WriteLine("Test case has failed");
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}