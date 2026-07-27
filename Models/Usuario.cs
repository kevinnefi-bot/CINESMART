namespace CINESMART.Models
{
    // Modelo de Usuario para el sistema de registro y login
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = "";

        public string Correo { get; set; } = "";

        public string Clave { get; set; } = "";

        public string Rol { get; set; } = "cliente"; // "cliente" o "admin"
    }
}
