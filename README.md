
<div align="center">
   <h2>⚜️ N E X U S ⚜️</h2>
</div>

<h3>👥 Integrantes do Grupo</h3>

- Matheus O.A.C Silva - RM 98502
- Amorgan M. Lopes - RM 98552
- Guilherme C. de Matos - RM 98874
- Gustavo G. da Silva - RM 99585
- Erick K. da Silva - RM 550371

- --------------------------------------------------
## 🏛 Arquitetura<h3>

Optamos por uma arquitetura monolítica pois o projeto tem um escopo definido e as funcionalidades são bem integradas, facilitando a comunicação entre os módulos. Além disso, como a aplicação é menor, o desenvolvimento e os testes são mais simples, já que se lida com um único aplicativo. Não há expectativa de grande crescimento ou mudanças complexas no curto prazo, então o monolito é mais prático e econômico para as necessidades atuais. Também ajuda a economizar nos custos de infraestrutura.
- --------------------------------------------------
## 📚 Projeto 

<p>Bem-vindo ao Nexus. O projeto consiste no desenvolvimento de um Chatbot funcional que utiliza o WhatsApp como plataforma principal. Esse Chatbot será capaz de se integrar a diversos sistemas externos, como APIs de inteligência artificial, e-commerce, e sistemas de recomendações. Isso permitirá oferecer um atendimento personalizado e eficaz aos clientes e usuários.</p>
<p>O público-alvo do projeto Nexus são empresas que buscam soluções inovadoras para melhorar o atendimento ao cliente, aumentando assim, sua satisfação e consequentemente otimizando suas operações comerciais.</p>

<br/>

- --------------------------------------------------
## 🧠 Design Patterns Utilizados

- **Singleton**: Gerenciamento de configurações.
- **Repository Pattern**: Para abstração do acesso a dados.
- **Service Layer**: Desacoplamento da lógica de negócios.

## 📋 Endpoints

#### **Usuários**
- `GET /api/Users` - Retorna todos os usuários.
- `GET /api/Users/{id}` - Retorna um usuário específico por ID.
- `POST /api/Users` - Cria um novo usuário.
- `PUT /api/Users/{id}` - Atualiza um usuário existente por ID.
- `DELETE /api/Users/{id}` - Exclui um usuário por ID.

#### **Produtos**
- `GET /api/Produtos` - Retorna todos os produtos.
- `GET /api/Produtos/{id}` - Retorna um produto específico por ID.
- `POST /api/Produtos` - Cria um novo produto.
- `PUT /api/Produtos/{id}` - Atualiza um produto existente por ID.
- `DELETE /api/Produtos/{id}` - Exclui um produto por ID.

#### **Pedidos**
- `GET /api/Pedidos` - Retorna todos os pedidos.
- `GET /api/Pedidos/{id}` - Retorna um pedido específico por ID.
- `POST /api/Pedidos` - Cria um novo pedido.
- `PUT /api/Pedidos/{id}` - Atualiza um pedido existente por ID.
- `DELETE /api/Pedidos/{id}` - Exclui um pedido por ID.


## 🚀 Como Rodar a Aplicação

Pré-requisitos:
- .NET 8 
- Oracle Database
- Visual Studio ou VS Code
- Git  

Passos:
1. Clone o repositório:
   ```bash
   git clone https://github.com/GuGodoi7/Nexus_sprint.git
   cd Nexus_sprint
   cd Nexus
2. Configure a string de conexão no appsettings.json:
    ```json
      {
        "ConnectionStrings": {
              "NXContext": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=xxxxx;Password=xxxxx;"
        }
      }

4. Restaure as dependências e execute a aplicação:
     ```bash
    dotnet restore
    dotnet run --launch-profile https
5. Acesse o Swagger (localhost varia de acordo com a maquina):
    ```bash
      https://localhost:7232/swagger/index.html

     
