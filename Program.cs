using System;
using System.Data.SqlClient; // Espacio de nombres para el proveedor de SQL Server
using Models; // Espacio de nombres para los modelos
using System.Configuration; // Espacio de nombres para el administrador de configuración

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Cadena de conexión a la base de datos
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                // Probar la conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    Console.WriteLine("Conexión con la base de datos exitosa.");

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                // En caso de que no se pueda conectar a la base de datos, se lanza una excepción personalizada
                throw new Exception("No se ha podido conectar a la base de datos.", ex);
            }

            // Creación de una instancia de Usuario
            var usuario = new Usuario(1, "John", "Doe", "johndoe", "password", "johndoe@example.com");

            // Creación de una instancia de Producto
            var producto = new Producto(1, "Producto 1", 10.5, 20.0, 100, 1);

            // Creación de una instancia de ProductoVendido
            var productoVendido = new ProductoVendido(1, 1, 80, 1);

            // Creación de una instancia de Venta
            var venta = new Venta(1, "Venta 1", 1);

            Console.WriteLine("Hello, World!"); // Impresión de un mensaje en la consola
        }
    }
}