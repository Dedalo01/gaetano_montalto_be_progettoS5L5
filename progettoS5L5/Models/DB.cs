using Microsoft.Data.SqlClient;

namespace progettoS5L5.Models
{
    public class DB
    {
        private static string connectionString = "Server=MSI\\SQLEXPRESS; Initial Catalog=Eser_S5L4; Integrated Security=true; TrustServerCertificate=True";

        public static SqlConnection conn = new SqlConnection(connectionString);
    }
}
