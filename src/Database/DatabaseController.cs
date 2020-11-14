namespace IMPA
{
    public class DatabaseController
    {
        private readonly IDatabaseContext _databaseContext;

        public DatabaseController(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
