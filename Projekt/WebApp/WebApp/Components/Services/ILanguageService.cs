namespace WebApp.Components.Services
{
    public interface ILanguageService
    {
        void SetLanguage(string language);
        string GetPhrase(string phrase);
    }
}