using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é campo obrigatório para login")]
        [EmailAddress(ErrorMessage = "E-mail em formtato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no macimo {1} caracteres.")]
        public string Email { get; set; }
    }
}
