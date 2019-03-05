using Evolantis.Data;
using System.Configuration;

namespace Application
{
    public class Connection : IDatabaseSettings
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["connection"].ToString(); }
        }
    }
}
