using System;

namespace WebApp.Components.Services
{
    public interface IClientUserProfile
    {
        public Task<UserProfile> PostUserProfile(UserProfile userProfile);
        public Task<UserProfile> GetUserProfile(string id);
        public Task<UserProfile> PutUserProfile(string id, UserProfile userProfile);
        public Task<Boolean> DeleteUserProfile(string id);
    }
}
