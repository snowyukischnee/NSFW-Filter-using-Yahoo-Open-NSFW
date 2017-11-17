using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO {
    public class BlacklistDAO : DBContext {
        public List<Blacklist> GetBlacklist() {
            List<Blacklist> res = new List<Blacklist>();
            string queryString = "select * from Blacklist";
            SqlCommand command = new SqlCommand(queryString, connection);
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    res.Add(new Blacklist {
                        Domain = (string)reader["Domain"]
                    });
                }
                reader.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return res;
        }
    }
}
