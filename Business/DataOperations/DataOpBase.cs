using System.Configuration;

namespace Business.DataOperations
{
    public class DataOpBase
    {
        public MCDbDataContext dataContext;
        public DataOpBase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MCDbConnectionString"].ConnectionString;
            dataContext = new MCDbDataContext(connectionString);
        }
    }
}
