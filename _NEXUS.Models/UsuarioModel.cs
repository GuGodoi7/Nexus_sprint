using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace _NEXUS.Models
{
    [Collection("NX_USUARIO")]
    public class UsuarioModel
    {
        public UsuarioModel(string email, string passwordHash)
        {
            Email = email;
            SetPassword(passwordHash);
        }

        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUsuario { get; set; }

        [BsonElement("NomeUsuario")]
        [Required]
        public string NomeUsuario { get; set; }

        [BsonElement("CPF")]
        [Required]
        public long CPF { get; set; }

        [BsonElement("Email")]
        [Required]
        public string Email { get; set; }

        [BsonElement("password")]
        [Required]
        public string PasswordHash { get; private set; }

        [BsonElement("Telefone")]
        [Required]
        public long Telefone { get; set; }

        private void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, PasswordHash);
        }

    }
}
