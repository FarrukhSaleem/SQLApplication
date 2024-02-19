using SQLApplication.Models;
using System.Data.SqlClient;

namespace SQLApplication.Services
{
    public class ProductService
    {
        private static string db_source = "trainingazuredb.database.windows.net";
        private static string db_user = "trainingazuredb";
        private static string db_password = "Tr@iningAzuredb";
        private static string db_database = "TrainingAzureDB";

        private SqlConnection GetConnection() {
           var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }
        public List<Product> GetProducts() { 
            SqlConnection conn = GetConnection();
            List<Product> _products = new List<Product>();
            string statement = "SELECT ProductID,ProductName,Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement,conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read()) {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity= reader.GetInt32(2)   
                    };
                    _products.Add(product);
                }
            }
            return _products;
        }
    }
}
