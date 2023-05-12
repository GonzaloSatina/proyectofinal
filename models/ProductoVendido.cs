public class ProductoVendido
{
    // Propiedades del producto vendido
    public int Id { get; set; } // Identificador único del producto vendido
    public int IdProducto { get; set; } // Identificador del producto que se vendió
    public int Stock { get; set; } // Cantidad del producto que se vendió
    public int IdVenta { get; set; } // Identificador de la venta a la que pertenece el producto vendido

    public double PrecioUnitario { get; set; } // Precio unitario del producto vendido

    // Constructor sin argumentos de la clase ProductoVendido
    public ProductoVendido()
    {
        // Inicialización de las propiedades a valores predeterminados
        Id = 0;
        IdProducto = 0;
        Stock = 0;
        IdVenta = 0;
        PrecioUnitario = 0.0;

        // Mensaje de creación de la instancia de ProductoVendido
        Console.WriteLine("La instancia de ProductoVendido se ha creado satisfactoriamente.");
    }

    // Constructor con argumentos, definido anteriormente
    public ProductoVendido(int id, int idProducto, int stock, int idVenta)
    {
        Id = id;
        IdProducto = idProducto;
        Stock = stock;
        IdVenta = idVenta;

        // Mensaje de creación de la instancia de ProductoVendido
        Console.WriteLine("La instancia de ProductoVendido se ha creado satisfactoriamente.");
    }
}