namespace Nexus.dto
{
    public class PedidoResponseDTO
    {
        public int IdPedido { get; set; }
        public long CodigoPedido { get; set; }

        public int Quantidade { get; set; }

        public int ValorPedido { get; set; }

        public int IdUsuario { get; set; }
    }
}
