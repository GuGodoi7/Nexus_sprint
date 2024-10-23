using System.ComponentModel.DataAnnotations;

namespace Nexus.Requests
{
    public class PedidoUseCase
    {
        [Required(ErrorMessage = "O campo 'Código do Pedido' é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo 'Código do Pedido' deve ter entre 3 e 100 caracteres")]
        public string CodigoPedido { get; set; }

        [Required(ErrorMessage = "O campo 'Quantidade' é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo 'Quantidade' deve ser um número positivo")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo 'Valor do Pedido' é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo 'Valor do Pedido' deve ser maior que zero")]
        public decimal ValorPedido { get; set; }
    }
}
