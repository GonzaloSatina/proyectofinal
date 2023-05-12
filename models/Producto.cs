public class Producto
{
    // Propiedades del producto
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public double Costo
    {
        get { return costo; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("El costo no puede ser negativo.");
            }

            costo = value;
        }
    }

    public double PrecioVenta
    {
        get { return precioVenta; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("El precio de venta no puede ser negativo.");
            }

            precioVenta = value;
        }
    }

    public int Stock
    {
        get { return stock; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("La cantidad en stock no puede ser negativa.");
            }

            stock = value;
        }
    }

    public int IdUsuario { get; set; }

    // Constructor sin argumentos de la clase Producto
    public Producto()
    {
        // Inicialización de las propiedades a valores predeterminados
        Id = 0;
        Descripcion = null;
        Costo = 0.0;
        PrecioVenta = 0.0;
        Stock = 0;
        IdUsuario = 0;

        // Mensaje de creación de la instancia de Producto
        Console.WriteLine("La instancia de Producto se ha creado satisfactoriamente.");
    }

    // Constructor de la clase Producto con argumentos
    public Producto(int id, string descripcion, double costo, double precioVenta, int stock, int idUsuario)
    {
        // Validación de parámetros
        if (string.IsNullOrWhiteSpace(descripcion))
        {
            throw new ArgumentException("La descripción no puede ser nula o vacía.");
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

        // Inicialización de las propiedades por medio de las propiedades públicas
        Id = id;
        Descripcion = descripcion;
        Costo = costo;
        PrecioVenta = precioVenta;
        Stock = stock;
        IdUsuario = idUsuario;

        // Mensaje de creación de la instancia de Producto
        Console.WriteLine("La instancia de Producto se ha creado satisfactoriamente.");
    }
}