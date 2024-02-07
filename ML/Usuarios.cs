namespace ML
{
    public class Usuarios
    {
        public int UsuariosID { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public int? Edad {  get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Imagen {  get; set; }
        public List<object>? UsuariosObject {  get; set; }
    }
}