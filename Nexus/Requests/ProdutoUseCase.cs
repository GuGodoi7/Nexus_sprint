using System.ComponentModel.DataAnnotations;

namespace Nexus.Requests
{
    public class ProdutoUseCase
    {
        [Required(ErrorMessage = "O campo 'Nome do Produto' é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo 'Nome do Produto' deve ter entre 3 e 100 caracteres")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Tipo de Produto' é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo 'Tipo de Produto' deve ter entre 3 e 50 caracteres")]
        public string TipoProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Marca' é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo 'Marca' deve ter entre 2 e 50 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo 'Modelo' é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo 'Modelo' deve ter entre 2 e 50 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade' é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo 'Quantidade' deve ser um número positivo")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo 'Valor do Produto' é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo 'Valor do Produto' deve ser maior que zero")]
        public decimal ValorProduto { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição do Produto' é obrigatório")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "O campo 'Descrição do Produto' deve ter entre 10 e 500 caracteres")]
        public string DescricaoProduto { get; set; }
    }
}

