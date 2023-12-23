namespace WebApp.Models
{
    public class UserContext : UserProfile
    {
        public UserContext()
        {
            Id = 1;
            UserName = "Stach  Maliński";
            Email = "StachoJacho@gmail.com";
            Bio = "Stanley Stach Malinski, 21 lat, student informatyki na Politechnice Warszawskiej.";
        }

        public UserProfile GetUserProfile(){
            return new UserProfile(){
                Id = Id,
                UserName = UserName,
                Email = Email,
                Bio = Bio  
            };
        }
    }
}
