using System;

public class Usuario
{
    // Campos privados de la clase Usuario
    private int id;
    private string nombre;
    private string apellido;
    private string nombreUsuario;
    private string contrasena;
    private string mail;
    private DateTime fechaCreacion;

    // Propiedades publicas de la clase Usuario
    public int Id 
    { 
        get { return id; } 
        set { id = value; } 
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Apellido
    {
        get { return apellido; }
        set { apellido = value; }
    }

    public string NombreUsuario
    {
        get { return nombreUsuario; }
        set 
        { 
            // Validación del nombre de usuario
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.");
            }

            nombreUsuario = value; 
        }
    }

    public string Contrasena
    {
        get { return contrasena; }
        set { contrasena = value; }
    }

    public string Mail
    {
        get { return mail; }
        set 
        {
            // Validación del correo electrónico
            if (!IsValidEmail(value))
            {
                throw new ArgumentException("El formato del correo electrónico no es válido.");
            }

            mail = value; 
        }
    }

    public DateTime FechaCreacion 
    { 
        get { return fechaCreacion; } 
        set { fechaCreacion = value; }
    }

    // Constructor sin argumentos de la clase Usuario
    public Usuario()
    {
        // Inicialización de los campos privados a valores predeterminados
        id = 0;
        nombre = null;
        apellido = null;
        nombreUsuario = null;
        contrasena = null;
        mail = null;
        fechaCreacion = DateTime.Now;

        // Mensaje de creación de la instancia de Usuario
        Console.WriteLine("La instancia de Usuario se ha creado satisfactoriamente.");
    }

    // Constructor con argumentos de la clase Usuario
    public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasena, string mail)
    {
        // Validación de parámetros
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede ser nulo o vacío.");
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            throw new ArgumentException("El apellido no puede ser nulo o vacío.");
        }

        if (string.IsNullOrWhiteSpace(nombreUsuario))
        {
            throw new ArgumentException("El nombre de usuario no puede ser nulo o vacío.");
        }

        if (string.IsNullOrWhiteSpace(contrasena))
        {
            throw new ArgumentException("La contraseña no puede ser nula o vacía.");
        }

        if (!IsValidEmail(mail))
        {
            throw new ArgumentException("El formato del correo electrónico no es válido.");
        }

        // Inicialización de los campos privados por medio de las propiedades públicas
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.nombreUsuario = nombreUsuario;
        this.contrasena = contrasena;
        this.mail = mail;
        fechaCreacion = DateTime.Now;

        // Mensaje de creación de la instancia de Usuario
        Console.WriteLine("La instancia de Usuario se ha creado satisfactoriamente.");
    }

    // Método privado para validar el formato del correo electrónico
    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}