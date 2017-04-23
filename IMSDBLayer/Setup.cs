using DbUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDBLayer
{
    public class Setup
    {
        public Setup(string connstring)
        {
            var connectionString = connstring;
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                            DeployChanges.To
                            .SqlDatabase(connectionString)
                            .WithScriptsEmbeddedInAssembly(System.Reflection.Assembly.GetExecutingAssembly())
                            .LogToConsole()
                            .Build();

            var result = upgrader.PerformUpgrade();


            if (!result.Successful)
            {
                throw new Exception("Database is not updated");
            }
        }


    }
}
