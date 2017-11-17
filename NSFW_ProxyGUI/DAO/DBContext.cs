using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO {
    public class DBContext {
        public SqlConnection connection;
        public DBContext() {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
        }
    }
}
