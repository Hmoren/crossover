using System.ComponentModel.DataAnnotations;

namespace CrossOver.DTOs.Usuario
{
    public class UsuarioRequestDTO
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string location { get; set; }
    }
}
