using System.ComponentModel.DataAnnotations;

namespace Nexus.Requests
{
    public class UsuarioRequest
    {
        [Required(ErrorMessage = "O campo 'Nome do Usuário' é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo 'Nome do Usuário' deve ter entre 3 e 100 caracteres")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "O campo 'CPF' é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo 'CPF' deve ter 11 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo 'Email' é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo 'Email' não é um endereço de email válido")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' é obrigatório")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "O campo 'Telefone' deve ter entre 10 e 15 caracteres")]
        public string telefone { get; set; }
    }
}
