using System.ComponentModel.DataAnnotations;

namespace CrossOver.DTOs.UsuarioDTO
{
    public class UsuarioLoginDTO
    {
        
        public string email { get; set; }
        
        public int password { get; set; }
    }
}
