using System.Reflection.Emit;
using Models;

namespace API.Repositories.Seeder.Seeder
{
    public class Seeder : ISeeder
    {
        private IUserProfileRepository _userProfileRepository;
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private IJwtRepository _jwtRepository;

        private int numberOfUsers = 10;
        private int minNumberOfPostsPerUser = 5;
        private int maxNumberOfPosts = 20;
        private int minNumberOfCommentsPerPost = 0;
        private int maxNumberOfCommentsPerPost = 3;
        private int seed = 1;

        private Generator _generator;
        private Random _rand;

        public Seeder(ICommentRepository commentRepository, IPostRepository postRepository, IUserProfileRepository userProfileRepository, IJwtRepository jwtRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userProfileRepository = userProfileRepository;
            _jwtRepository = jwtRepository;
            _generator = new Generator(seed);
            _rand = new Random(seed);
    }

        public void clean()
        {
            _userProfileRepository.allDeleteUserProfile();
            _postRepository.allDeletePost();
            _commentRepository.allDeleteComment();
        }

        public void populate()
        {
            populateWithUsers();
            populateWithPosts();
            populateWithComments();
        }
        private void populateWithUsers(){
            List<UserProfile> users = _generator.getNewUsers(numberOfUsers);
            foreach (UserProfile user in users)
            {
                Thread.Sleep(100);
                JwtDto jwt = _generator.getJwt(user);
                _userProfileRepository.CreateUserProfile(user);
                _jwtRepository.AddJwt(jwt);
            }
        }

        private void populateWithPosts()
        {
            List<UserProfile> users = _userProfileRepository.GetAllUserProfile();
            List<Post> posts = new List<Post>();
            foreach (UserProfile user in users)
            {
                Thread.Sleep(100);
                posts.AddRange(
                    _generator.getPosts(user, _rand.Next(maxNumberOfPosts - minNumberOfPostsPerUser) + minNumberOfPostsPerUser));
            }
            foreach (Post post in posts)
            {
                Thread.Sleep(100);
                _postRepository.CreatePost(post);
            }
        }

        private void populateWithComments()
        {
            
        }
    }
}
