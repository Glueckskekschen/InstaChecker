// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Hello I am Insta Checker!");
//Im Browser anmelden 
// Auf Follower gehen
// Ganz nach unten scrollen bis es nicht mehr weiter geht (use Mittlere Maustaste)
// Rechte Maustaste speichern unter...
// speichern als follower.htm

// Auf Abos gehen
// Ganz nach unten scrollen bis es nicht mehr weiter geht (use Mittlere Maustaste)
// Rechte Maustaste speichern unter...
// speichern als abos.htm


string USER = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

//FOLLOWER
string readContents;
string path = USER + "\\Pictures\\follower.htm";
using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
{
    readContents = streamReader.ReadToEnd();
}
// <span class="_ap3a _aaco _aacw _aacx _aad7 _aade" dir="auto">NAME</span>
string pattern = "<span class=._ap3a _aaco _aacw _aacx _aad7 _aade. dir=.auto.>(.*?)<";
Regex rg = new Regex(pattern);
// Get all matches
MatchCollection matchedColl = rg.Matches(readContents);
Console.WriteLine("Follower: \t" + matchedColl.Count);
int iFollower = matchedColl.Count;
string[] arrayFOLLOWER = matchedColl.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();


//ABOS
path = USER + "\\Pictures\\abos.htm";
using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
{
    readContents = streamReader.ReadToEnd();
}
//<span class="_ap3a _aaco _aacw _aacx _aad7 _aade" dir="auto">NAME</span>
rg = new Regex(pattern);
matchedColl = rg.Matches(readContents);
Console.WriteLine("Abos: \t\t" + matchedColl.Count);
Console.WriteLine("Diff: \t\t" + (matchedColl.Count-iFollower));
string[] arrayABOS = matchedColl.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();

var final = arrayABOS.Except(arrayFOLLOWER).ToList();
foreach (string s in final)
{
    Console.WriteLine("[~] " + s);
}
path = USER + "\\Pictures\\Vergleich.txt";
File.AppendAllLines(path, final);
Console.WriteLine("ENDE");