using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    class RackRepo
    {
        // Privat list of rack 
        private List<Rack> _rack = new List<Rack>();

        // Public list, to get or set rack from the private list
        public List<Rack> Rack
        {
            get { return _rack; }
            set { _rack = value; }
        }

        // AddRack() method adds a new Rack to the list
        public void AddRack(Rack rack)
        {
            _rack.Add(rack);

            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");

            rack.InsertIntoDatabase(connectionString);
        }
    }
}
