using System;
using System.Data.SqlClient;  // Importación del espacio de nombres System.Data.SqlClient 
using Models;  // Importación del espacio de nombres Models
using Microsoft.Extensions.Configuration;  // Importación del espacio de nombres Microsoft.Extensions.Configuration
using Microsoft.Extensions.DependencyInjection;  // Importación del espacio de nombres Microsoft.Extensions.DependencyInjection
using Microsoft.Extensions.Logging;  // Importación del espacio de nombres Microsoft.Extensions.Logging

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()  // Creación de una instancia ConfigurationBuilder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)  // Agregar archivo JSON de configuración (opcional)
                .Build();  // Construye y devuelve una instancia de IConfiguration

            var services = new ServiceCollection();  // Creación de una colección de servicios

            services.AddSingleton<IConfiguration>(config);  // Agregar instancia de config como una instancia única de servicio

            services.AddLogging(builder =>  // Configuración del proveedor de registros
            {
                builder.AddConfiguration(config.GetSection("Logging"));  // Agregar configuración relacionada con los registros
                builder.AddConsole();  // Agregar proveedor de registro para imprimir los registros a la consola
            });

            services.AddTransient<Usuario>();  // Agregar Usuario como una dependencia temporal
            services.AddTransient<Producto>();  // Agregar Producto como una dependencia temporal
            services.AddTransient<ProductoVendido>();  // Agregar ProductoVendido como una dependencia temporal
            services.AddTransient<Venta>();  // Agregar Venta como una dependencia temporal

            var serviceProvider = services.BuildServiceProvider();  // Construir la colección de servicios completa

            try
            {
                // Cadena de conexion a la base de datos
                string connectionString = config.GetConnectionString("MyConnectionString");  // Obtener la cadena de conexión de la configuración

                using (SqlConnection connection = new SqlConnection(connectionString))  // Abrir la conexión a la base de datos y envolverla en una sentencia "using" para liberar los recursos automáticamente
                {
                    connection.Open();  // Abrir la conexión 
                    var logger = serviceProvider.GetService<ILogger<Program>>();  // Obtener instancia de ILogger a través del proveedor de servicios
                    logger.LogInformation("Conexion con la base de datos exitosa.");  // Registrar mensaje de información en el registro
                }
            }
            catch (SqlException ex)  // Manejar la excepción SqlException
            {
                var logger = serviceProvider.GetService<ILogger<Program>>();  // Obtener instancia de ILogger a través del proveedor de servicios
                logger.LogError(ex, "No se ha podido conectar a la base de datos.");  // Registrar mensaje de error en el registro
                return;  // Salir de la aplicación en caso de error
            }

            var usuario = serviceProvider.GetService<Usuario>();  // Crear una instancia de Usuario a través del proveedor de servicios
            var producto = serviceProvider.GetService<Producto>();  // Crear una instancia de Producto a través del proveedor de servicios
            var productoVendido = serviceProvider.GetService<ProductoVendido>(); // Crear una instancia de ProductoVendido a través del proveedor de servicios
            var venta = serviceProvider.GetService<Venta>();  // Crear una instancia de Venta a través del proveedor de servicios

            Console.WriteLine("Hello, World!"); // Impresion de un mensaje en la consola
        }
    }
}