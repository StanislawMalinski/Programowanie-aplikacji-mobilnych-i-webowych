using Microsoft.EntityFrameworkCore;
using Models;


namespace API.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        public DbSet<UserProfileDto> Users { get; set; }
        public DbSet<PostDto> Posts { get; set; }
        public DbSet<CommentDto> Comments { get; set; }
        public DbSet<JwtDto> Jwt { get; set; }
    }
}
