using _NEXUS.Models;
using _NEXUS.Repository.Interfaces;
using _NEXUS.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    public class UsersServiceTests
    {
        private readonly Mock<IUsuarioRepository> _mockUsersRepository;
        private readonly UsuarioService _usersService;

        public UsersServiceTests()
        {

            _mockUsersRepository = new Mock<IUsuarioRepository>();


            _usersService = new UsuarioService(_mockUsersRepository.Object);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnListOfUsers()
        {

            var usersList = new List<UsuarioModel>
            {
                new UsuarioModel { IdUsuario = 1, NomeUsuario = "User 1", CPF = 12345678901, email = "user1@example.com", telefone = 9988776655 },
                new UsuarioModel { IdUsuario = 2, NomeUsuario = "User 2", CPF = 98765432100, email = "user2@example.com", telefone = 9988776644 }
            };


            _mockUsersRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(usersList);


            var result = await _usersService.GetAllUsersAsync();

            var resultList = result.ToList();


            Assert.NotNull(resultList);
            Assert.Equal(2, resultList.Count);
            Assert.Equal("User 1", resultList[0].NomeUsuario);
            Assert.Equal("User 2", resultList[1].NomeUsuario);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {

            var user = new UsuarioModel { IdUsuario = 1, NomeUsuario = "User 1", CPF = 12345678901, email = "user1@example.com", telefone = 9988776655 };

            _mockUsersRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);


            var result = await _usersService.GetUserByIdAsync(1);


            Assert.NotNull(result);
            Assert.Equal("User 1", result.NomeUsuario);
            Assert.Equal(12345678901, result.CPF);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnNull_WhenUserDoesNotExist()
        {

            _mockUsersRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((UsuarioModel)null);

            var result = await _usersService.GetUserByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateUser_ShouldAddUser()
        {

            var newUser = new UsuarioModel { NomeUsuario = "User 3", CPF = 11223344556, email = "user3@example.com", telefone = 9988776633 };

            await _usersService.CreateUserAsync(newUser);


            _mockUsersRepository.Verify(repo => repo.AddAsync(newUser), Times.Once);
        }
    }
}
