using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    class RackOwnerRepo
    {
        // Privat list of rack owners
        private List<RackOwner> _rackOwner = new List<RackOwner>();

        // Public list, to get or set rack owner from the private list
        public List<RackOwner> RackOwner
        {
            get { return _rackOwner; }
            set { _rackOwner = value; }
        }

        // AddRackOwner() method adds a new RackOwner to the list TEST
        public void AddRackOwner(RackOwner rackOwner)
        {
            _rackOwner.Add(rackOwner);

            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");

            rackOwner.InsertIntoDatabase(connectionString);
        }
    }
}
