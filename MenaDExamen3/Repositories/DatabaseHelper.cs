using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenaDExamen3.Repositories
{
    class DatabaseHelper
    {
        public static string GetDatabasePath(string dbname)
        {
            string folderPath = FileSystem.AppDataDirectory;
            return Path.Combine(folderPath, dbname);
        }
    }
}
