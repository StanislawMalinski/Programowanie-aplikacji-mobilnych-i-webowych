using API.Repositories.Seeder;
using API.Repositories.Seeder.Seeder;

namespace API.Services
{
    public class SeederService : ISeederService
    {
        private readonly ISeeder _seeder;
        public SeederService(ISeeder seeder)
        {
            _seeder = seeder;
        }

        public void Clean()
        {
            _seeder.clean();
        }

        public void Populate()
        {
            _seeder.populate();
        }
    }


}
