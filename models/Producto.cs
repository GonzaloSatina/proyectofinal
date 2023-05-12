public class Producto
{
    // Propiedades del producto
    public int Id { get; set; } // Identificador unico del producto
    public string Descripcion { get; set; } // Descripcion del producto
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
    } // Costo de produccion del producto
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
    } // Precio de venta del producto
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
    } // Cantidad en stock del producto
    public int IdUsuario { get; set; } // Identificador del usuario que creo el producto

    // Campo privado utilizado por las propiedades de Costo, PrecioVenta y Stock
    private double costo;
    private double precioVenta;
    private int stock;

    // Constructor sin argumentos de la clase Producto
    public Producto()
    {
        // Inicializacion de las propiedades a valores predeterminados
        Id = 0;
        Descripcion = null;
        Costo = 0.0;
        PrecioVenta = 0.0;
        Stock = 0;
        IdUsuario = 0;

        // Mensaje de creacion de la instancia de Producto
        Console.WriteLine("La instancia de Producto se ha creado satisfactoriamente.");
    }

    // Constructor de la clase Producto con argumentos
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

        // Inicializacion de las propiedades por medio de las propiedades publicas
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