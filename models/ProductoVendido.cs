using System;

namespace Models
{
    public class ProductoVendido
    {
        // Propiedades del producto vendido
        public int Id { get; set; } // Identificador unico del producto vendido
        public int IdProducto { get; set; } // Identificador del producto que se vendio
        public int Stock { get; set; } // Cantidad del producto que se vendio
        public int IdVenta { get; set; } // Identificador de la venta a la que pertenece el producto vendido
        public double PrecioUnitario { get; set; } // Precio unitario del producto vendido

        // Constructor por defecto
        public ProductoVendido()
        {
            // Mensaje de creacion de la instancia de ProductoVendido
            Console.WriteLine("La instancia de ProductoVendido se ha creado satisfactoriamente.");
        }

        // Constructor con argumentos
        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            // Inicializacion de las propiedades por medio de los argumentos
            Id = id;
            IdProducto = idProducto;
            Stock = stock;
            IdVenta = idVenta;

            // Mensaje de creacion de la instancia de ProductoVendido
            Console.WriteLine("La instancia de ProductoVendido se ha creado satisfactoriamente.");
        }
    }
}