public class Venta
{
    // Propiedades de la venta
    public int Id { get; set; } // Identificador unico de la venta
    public string Comentarios { get; set; } // Descripcion o comentarios de la venta
    public int IdUsuario { get; set; } // Identificador del usuario que realizo la venta

    public DateTime Fecha { get; set; } // Fecha de la venta

    // Constructor sin argumentos de la clase Venta
    public Venta()
    {
        // Inicializacion de las propiedades a valores predeterminados
        Id = 0;
        Comentarios = null;
        IdUsuario = 0;
        Fecha = DateTime.Now;

        // Mensaje de creacion de la instancia de Venta
        Console.WriteLine("La instancia de Venta se ha creado satisfactoriamente.");
    }

    // Constructor con argumentos, definido anteriormente
    public Venta(int id, string comentarios, int idUsuario)
    {
        Id = id;
        Comentarios = comentarios;
        IdUsuario = idUsuario;
        Fecha = DateTime.Now;

        // Mensaje de creacion de la instancia de Venta
        Console.WriteLine("La instancia de Venta se ha creado satisfactoriamente.");
    }
}