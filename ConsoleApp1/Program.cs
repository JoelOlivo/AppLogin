using System;
using System.Data.SqlClient;
using System.Data;

class Program
{
    static void Main()
    {
        var connectionString = "Data Source=CRISTIANOLIVO\\SQLEXPRESS01;Database=BOPP_TEST;Trusted_Connection=True;TrustServerCertificate=True;";

        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
        }
    }
}

