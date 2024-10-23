using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace _NEXUS.Models
{
    [Collection("NX_PRODUTOS")]
    public class PedidosModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPedido { get; set; }

        [BsonElement("CodigoPedido")]
        [Required]
        public long CodigoPedido { get; set; }

        [BsonElement("Quantidade")]
        [Required]
        public int Quantidade { get; set; }

        [BsonElement("ValorPedido")]
        [Required]
        public int ValorPedido { get; set; }

        //1..N
        public int IdUsuario { get; set; }
        public UsuarioModel? Usuario { get; set; }

    }
}
