using Microsoft.Data.SqlClient;

namespace progettoS5L5.Models
{
    public class DB
    {
        private static string connectionString = "Server=MSI\\SQLEXPRESS; Initial Catalog=progettoSettimanaleS2L5; Integrated Security=true; TrustServerCertificate=True";

        public static SqlConnection conn = new SqlConnection(connectionString);
    }
}
