using System;
using System.Text.Json;

namespace WebApp.Components.Services
{
    public class LanguageService : ILanguageService
    {

        private string _language = "pl";
        private Dictionary<string, Dictionary<string, string>> _jsonDictionary;

        public LanguageService(string pathToLanguageFile)
        {
            string jsonString = File.ReadAllText(pathToLanguageFile);
            _jsonDictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonString);
        }

        public void SetLanguage(string language)
        {
            _language = language;
        }

        public string GetPhrase(string key)
        {
            try{
            string phrase = _jsonDictionary[key][_language];
            return phrase;
            }
            catch(Exception e)
            {


                return "############### Phrase not found ###############";
            }
        }
    }
}
        