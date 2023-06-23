using System;
using System.Data.SqlClient;

namespace _01.InitialSetup
{
    internal class Config
    {
        public const string ConnectionString = @"Server=PREDATOR-LAPTOP;Database=master;Integrated Security=true;TrustServerCertificate=true";
        public const string ConnectionString2 = @"Server=PREDATOR-LAPTOP;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
    }
}
