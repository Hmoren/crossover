using System.ComponentModel.DataAnnotations;

namespace CrossOver.DTOs.UsuarioDTO
{
    public class UsuarioRegitrationRequestDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} la longitud debe estar entre {2} y {1}.", MinimumLength = 1)]
        public string name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "{0} la longitud debe estar entre {2} y {1}.", MinimumLength = 4)]
        public string email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} la longitud debe estar entre {2} y {1}.", MinimumLength = 6)]
        public string password { get; set; }
    }
}
