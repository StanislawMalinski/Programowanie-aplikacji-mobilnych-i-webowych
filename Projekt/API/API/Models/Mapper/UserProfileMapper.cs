namespace API.Models.Mapper
{
    public static class UserProfileMapper
    {
        public static UserProfile mapDtoToUser(UserProfileDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new UserProfile
            {
                Id = dto.Id,
                UserName = dto.UserName,
                Email = dto.Email,
                Bio = dto.Bio
            };
        }

        public static UserProfileDto mapUserToDto(UserProfile userProfile)
        {
            if (userProfile == null)
            {
                return null;
            }

            return new UserProfileDto
            {
                Id = userProfile.Id,
                UserName = userProfile.UserName,
                Email = userProfile.Email,
                Bio = userProfile.Bio
            };
        }
    }
}
