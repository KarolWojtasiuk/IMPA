namespace IMPA
{
    public class DatabaseController
    {
        public UsersRepository Users { get; init; }

        private readonly IDatabaseContext _dbContext;

        public DatabaseController(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            Users = new(_dbContext);
        }
    }
}
