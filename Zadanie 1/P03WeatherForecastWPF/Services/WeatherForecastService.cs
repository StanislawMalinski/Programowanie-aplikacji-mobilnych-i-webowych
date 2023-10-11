using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03WeatherForecastWPF.Services
{
    class WeatherForecastService
    {
        const string url = $"https://www.google.com/search?q=pogoda";
        const string regexTemplate = "<div class=\"BNeawe iBp4i AP7Wnd\">(-{0,1}\\d{1,3})�C<\\/div>";

        public int GetTemperature(string city)
        {
            WebClient wc = new WebClient();
            string data = wc.DownloadString(url + " " + city);

            Regex rx = new Regex(regexTemplate);
            Match match = rx.Match(data);

            //string result = match.Groups[0].Value;// tutaj siedzi cały dopasowany ciag
            string result = match.Groups[1].Value;

            return Convert.ToInt32(result);

        }

        public async Task<int> GetTemperatureAsync(string city)
        {
            using (WebClient wc = new WebClient())
            {
                string data = await wc.DownloadStringTaskAsync(url + " " + city);
                Regex rx = new Regex(regexTemplate);
                Match match = rx.Match(data);
                string result = match.Groups[1].Value;
                return Convert.ToInt32(result);
            }

        }

        public async Task<int> GetTemperatureAsync2(string city)
        {
            return await Task.Run(() =>
            {
                using (WebClient wc = new WebClient())
                {
                    string data = wc.DownloadString(url + " " + city);
                    Regex rx = new Regex(regexTemplate);
                    Match match = rx.Match(data);
                    string result = match.Groups[1].Value;
                    return Convert.ToInt32(result);
                }
            });
        }

        public async Task<int> GetTemperatureAsync3(string city)
        {
            using (WebClient wc = new WebClient())
            {
                string data = await wc.DownloadStringTaskAsync(url + " " + city);
                string result = await Task.Run(() =>
                {
                    Regex rx = new Regex(regexTemplate);
                    Match match = rx.Match(data);
                    return match.Groups[1].Value;
                });
                return Convert.ToInt32(result);
            }
        }
    }
}
