using System;

namespace Models
{
    public class Producto
    {
        // Propiedades del producto
        public int Id { get; set; } // Identificador unico del producto
        public string Descripcion { get; set; } // Descripcion del producto
        public double Costo { get; set; } // Costo de produccion del producto
        public double PrecioVenta { get; set; } // Precio de venta del producto
        public int Stock { get; set; } // Cantidad en stock del producto
        public int IdUsuario { get; set; } // Identificador del usuario que creo el producto

        // Constructor por defecto
        public Producto()
        {
            // Mensaje de creacion de la instancia de Producto
            Console.WriteLine("La instancia de Producto se ha creado satisfactoriamente.");
        }

        // Constructor con argumentos
        public Producto(int id, string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {
            // Validacion de parametros
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripcion no puede ser nula o vacia.");
            }

            if (costo < 0)
            {
                throw new ArgumentException("El costo no puede ser negativo.");
            }

            if (precioVenta < 0)
            {
                throw new ArgumentException("El precio de venta no puede ser negativo.");
            }

            if (stock < 0)
            {
                throw new ArgumentException("La cantidad en stock no puede ser negativa.");
            }

            // Inicializacion de las propiedades por medio de los argumentos
            Id = id;
            Descripcion = descripcion;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;

            // Mensaje de creacion de la instancia de Producto
            Console.WriteLine("La instancia de Producto se ha creado satisfactoriamente.");
        }
    }
}