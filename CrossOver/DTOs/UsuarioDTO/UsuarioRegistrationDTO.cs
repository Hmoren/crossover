namespace CrossOver.DTOs.UsuarioDTO
{
    public class UsuarioRegistrationDTO
    {
        public int code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

    }
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
