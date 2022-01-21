// See https://aka.ms/new-console-template for more information
using HockeyTeamSystem;

// Test with valid FullName, PrimaryNumber
HockeyPlayer player1 = new("    Connor McDavid  ", 97, PlayerPosition.Center);
Console.WriteLine(player1); // The HockeyPlayer.ToString() will be invoked indirectly
// Test with invalid PrimaryNumber
try
{
    HockeyPlayer player2 = new("Connor McDavid", 0, PlayerPosition.Center);
    Console.WriteLine("Test case has failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
try
{
    HockeyPlayer player2 = new("Connor McDavid", 100, PlayerPosition.Center);
    Console.WriteLine("Test case has failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
// Test with null for FullName
try
{
    HockeyPlayer player2 = new(null, 97, PlayerPosition.Center);
    Console.WriteLine("Test case has failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
// Test with empty string for FullName
try
{
    HockeyPlayer player2 = new("", 97, PlayerPosition.Center);
    Console.WriteLine("Test case has failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
// Test with whitespaces for FullName
try
{
    HockeyPlayer player2 = new("            ", 97, PlayerPosition.Center);
    Console.WriteLine("Test case has failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}