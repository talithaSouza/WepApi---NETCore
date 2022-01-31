using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Nome é campo obrigatório para login")]
        [StringLength(60, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é campo obrigatório para login")]
        [EmailAddress(ErrorMessage = "E-mail em formtato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no macimo {1} caracteres.")]
        public string Email { get; set; }

    }
}
