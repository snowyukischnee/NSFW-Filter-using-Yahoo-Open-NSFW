using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO {
    public class BlockingHandleDAO : DBContext {
        public BlockingHandle GetBlockingHandle() {
            BlockingHandle res = null;
            string queryString = "select top 1 * from BlockingHandle order by id desc";
            SqlCommand command = new SqlCommand(queryString, connection);
            try {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    res = new BlockingHandle {
                        Image = (string)reader["Image"],
                        HTMLPage = (string)reader["HTMLPage"]
                    };
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
