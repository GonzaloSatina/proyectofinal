using System;
using System.Data.SqlClient;
using Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(config);

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddConsole();
            });

            services.AddTransient<Usuario>();
            services.AddTransient<Producto>();
            services.AddTransient<ProductoVendido>();
            services.AddTransient<Venta>();

            var serviceProvider = services.BuildServiceProvider();

            try
            {
                // Cadena de conexion a la base de datos
                string connectionString = config.GetConnectionString("MyConnectionString");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var logger = serviceProvider.GetService<ILogger<Program>>();
                    logger.LogInformation("Conexion con la base de datos exitosa.");
                }
            }
            catch (SqlException ex)
            {
                var logger = serviceProvider.GetService<ILogger<Program>>();
                logger.LogError(ex, "No se ha podido conectar a la base de datos.");
                return;
            }

            // Creacion de una instancia de Usuario
            var usuario = serviceProvider.GetService<Usuario>();

            // Creacion de una instancia de Producto
            var producto = serviceProvider.GetService<Producto>();

            // Creacion de una instancia de ProductoVendido
            var productoVendido = serviceProvider.GetService<ProductoVendido>();

            // Creacion de una instancia de Venta
            var venta = serviceProvider.GetService<Venta>();

            Console.WriteLine("Hello, World!"); // Impresion de un mensaje en la consola
        }
    }
}