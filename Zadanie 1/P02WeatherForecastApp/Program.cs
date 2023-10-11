// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text.RegularExpressions;

while (true)
{
    Console.WriteLine("City name:");
    string city = Console.ReadLine();
    string url = $"https://www.google.com/search?q=pogoda {city}";

    WebClient wc = new WebClient();
    string data = wc.DownloadString(url);

   
    try
    {
        string regexTemplate = "<div class=\"BNeawe iBp4i AP7Wnd\">(-{0,1}\\d{1,3})�C<\\/div>";

        Regex rx = new Regex(regexTemplate);
        Match match = rx.Match(data);

        //string result = match.Groups[0].Value;// tutaj siedzi cały dopasowany ciag
        string result = match.Groups[1].Value;

        Console.WriteLine(result);
    }
    catch (Exception)
    {
        Console.WriteLine("Nie udało się pobrać temperatury");
        continue;
    }
}
