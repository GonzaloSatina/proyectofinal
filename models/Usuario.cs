using System;

namespace Models
{
    public class Usuario
    {
        // Campos privados de la clase Usuario
        // Cada propiedad correspondiente se utiliza para acceder y modificar estos campos privados
        private int id; // Identificador unico del usuario
        private string nombre; // Nombre del usuario
        private string apellido; // Apellido del usuario
        private string nombreUsuario; // Nombre de usuario del usuario (debe ser unico)
        private string contrasena; // Contrasena del usuario
        private string mail; // Direccion de correo electronico del usuario
        private DateTime fechaCreacion; // Fecha de creacion del usuario

        // Propiedades publicas de la clase Usuario
        // Cada propiedad establece sus propias reglas de validacion (cuando es necesario)

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
                // Validacion del nombre de usuario
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de usuario no puede ser nulo o vacio.");
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
                // Validacion del correo electronico
                if (!IsValidEmail(value))
                {
                    throw new ArgumentException("El formato del correo electronico no es valido.");
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
            // Inicializacion de los campos privados a valores predeterminados
            id = 0;
            nombre = null;
            apellido = null;
            nombreUsuario = null;
            contrasena = null;
            mail = null;
            fechaCreacion = DateTime.Now;

            // Mensaje de creacion de la instancia de Usuario
            Console.WriteLine("La instancia de Usuario se ha creado satisfactoriamente.");
        }

        // Constructor con argumentos de la clase Usuario
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasena, string mail)
        {
            // Validacion de parametros
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede ser nulo o vacio.");
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido no puede ser nulo o vacio.");
            }

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario no puede ser nulo o vacio.");
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new ArgumentException("La contrasena no puede ser nula o vacia.");
            }

            if (!IsValidEmail(mail))
            {
                throw new ArgumentException("El formato del correo electronico no es valido.");
            }

            // Inicializacion de los campos privados por medio de las propiedades publicas
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario = nombreUsuario;
            this.contrasena = contrasena;
            this.mail = mail;
            fechaCreacion = DateTime.Now;

            // Mensaje de creacion de la instancia de Usuario
            Console.WriteLine("La instancia de Usuario se ha creado satisfactoriamente.");
        }

        // Método privado para validar el formato del correo electrónico.
        // Retorna true si el correo es válido y false si no lo es.
        private static bool IsValidEmail(string email)
        {
            try 
            {
                // Creamos una instancia de la clase MailAddress, pasando el correo electrónico como parámetro en su constructor. 
                // La clase MailAddress se encuentra en el espacio de nombres System.Net.Mail, que es parte de la biblioteca de clases base de .NET Framework. 
                var addr = new System.Net.Mail.MailAddress(email);

                // Comparamos el valor de la propiedad Address de la instancia addr y el valor de la variable email para asegurarnos
                // de que no hubo ninguna modificación en la dirección de correo electrónico durante la instancia de MailAddress.
                return addr.Address == email;
            }
            catch (FormatException)
            {
                // Si se produce una excepción de formato al crear la instancia de MailAddress, significa que el correo electrónico es inválido.
                return false;
            }
            catch (Exception ex)
            {
                // Si se produce cualquier otra excepción al crear la instancia de MailAddress, se lanza una excepción y se imprime un mensaje de error.
                throw new Exception($"Se produjo una excepción al validar el correo electrónico: {ex.Message}");
            }
        }
    }
}