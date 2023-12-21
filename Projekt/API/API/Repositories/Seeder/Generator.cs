using System;
using System.Text;

namespace API.Repositories.Seeder.Seeder
{
    public class Generator
    {
        private Random rand;

        private int Id = 0;

        public Generator(int seed)
        {
            rand = new Random(seed);
        }

        private string getLoremIpsum(int minWords, int maxWords)
        {
            var words = new[] { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat" };


            int numWords = rand.Next(maxWords - minWords) + minWords + 1;
            int numSentences = (int)Math.Floor((double)numWords / 10);

            var sb = new StringBuilder();
            for (int s = 0; s < numSentences; s++)
            {
                for (int w = 0; w < numWords; w++)
                {
                    if (w > 0) { sb.Append(" "); }
                    sb.Append(words[rand.Next(words.Length)]);
                }
                sb.Append(". ");
            }
            return sb.ToString();
        }

        public string getName()
        {
            List<string> name = new(["Kasia", "Basia", "Jasia", "Asia"]);
            List<string> surname = new(["Kowalska", "Robalska", "Porowska", "Kubowska"]);
            return name[rand.Next(name.Count)] + " " + surname[rand.Next(surname.Count)];
        }

        public string getMail()
        {
            List<string> domains = new(["gmail.com", "yahoo.com", "outlook.com"]);
            List<string> nick = new(["miska", "malinka", "parowka", "zajac", "pajak"]);
            return nick[rand.Next(nick.Count)] + rand.Next(100) + "@" + domains[rand.Next(domains.Count)];
        }

        public DateTime getRandomDate(DateTime from, DateTime to)
        {
            int range = (to - from).Days;
            return from.AddDays(rand.Next(range));
        }

        public UserProfile getNewUser()
        {
            UserProfile user = new UserProfile();
            user.Id = Id++;
            user.Email = getMail();
            user.UserName = getName();
            user.Bio = getLoremIpsum(10, 50);
            return user;
        }

        public List<UserProfile> getNewUsers(int n)
        {
            List<UserProfile> list = new List<UserProfile>();
            for (int i = 0; i < n; i++)
            {
                list.Add(getNewUser());
            }
            return list;
        }

        public Post getPost(UserProfile user)
        {
            Post post = new Post();
            post.Id = Id++;
            post.Title = getLoremIpsum(3, 7);
            post.Content = getLoremIpsum(3, 50);
            post.CreatedAt = getRandomDate(new DateTime(1999, 1, 1), DateTime.Today);
            post.User = user;
            post.Comments = new List<Comment>();
            return post;
        }

        public List<Post> getPosts(UserProfile user, int n)
        {
            List<Post> list = new List<Post>();
            for (int i = 0; i < n; i++)
            {
                list.Add(getPost(user));
            }
            return list;
        }

        public Comment GetComment(Post post, UserProfile user)
        {
            Comment comment = new Comment();
            comment.Id = Id++;
            comment.User = user;
            comment.CreatedAt = getRandomDate(post.CreatedAt, DateTime.Today);
            comment.Text = getLoremIpsum(3, 50);
            comment.PostId = post.Id;
            return comment;
        }

        public List<Comment> getComments(Post post, UserProfile user, int n)
        {
            List<Comment> comments = new List<Comment>();
            for (int i = 0; i < n; i++)
            {
                comments.Add(GetComment(post, user));
            }
            return comments;
        }
    }
}
