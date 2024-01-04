using Models;

namespace WebApp.Models
{
    public class UserContext 
    {
        public bool IsAuthenticated { get; set; }
        public UserProfile UserProfile { get; set; }
        public Jwt jwt { get; set; }

        public UserContext()
        {
            IsAuthenticated = false;
        }

        public UserProfile GetUserProfile(){
            if (UserProfile == null) {
                return new UserProfile();
            }
            return UserProfile;
        }

        public Boolean isAdmin(){
            if (jwt == null) {
                return false;
            }
            return jwt.Permissions.Contains("admin");
        }

        public Boolean isUser(){
            if (jwt == null) {
                return false;
            }
            return jwt.Permissions.Contains("user");
        }

        public Boolean isId(int id){
            if (UserProfile == null) {
                return false;
            }
            return UserProfile.Id == id;
        }
    }
}
