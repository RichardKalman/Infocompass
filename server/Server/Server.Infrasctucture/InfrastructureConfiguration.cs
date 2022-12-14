using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Infrasctucture
{
    public interface IInfrastructureConfiguration
    {
        string DbConnectionString { get; }
    }

    public class InfrastructureConfiguration : IInfrastructureConfiguration
    {
        public string DbConnectionString => "Initial Catalog=TesztVehicle; Data Source=localhost,1433; Persist Security Info=True;User ID=SA;Password=";
    }
}
