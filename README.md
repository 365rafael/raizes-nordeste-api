# Raízes Nordeste API

API REST desenvolvida em ASP.NET Core 8 para gerenciamento de vendas, estoque, pedidos e pagamentos de uma rede de restaurantes nordestinos.

## Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- BCrypt
- Repository Pattern
- Service Layer

## Arquitetura

Projeto desenvolvido seguindo Arquitetura em Camadas:

- RaizesNordeste.API
- RaizesNordeste.Application
- RaizesNordeste.Domain
- RaizesNordeste.Infrastructure

## Funcionalidades

### Usuários

- Cadastro
- Login
- Geração de Token JWT

### Produtos

- Cadastro
- Consulta
- Atualização
- Exclusão

### Unidades

- Cadastro
- Consulta
- Atualização
- Exclusão

### Estoque

- Controle por unidade
- Entrada de estoque
- Saída de estoque
- Bloqueio de estoque negativo

### Pedidos

- Criação de pedidos
- Múltiplos itens
- Cálculo automático do total
- Baixa automática do estoque

### Pagamentos

- Processamento de pagamento
- Geração de transação simulada
- Atualização automática do status do pedido

## Usuário Inicial

Email:

admin@raizesnordeste.com

Senha:

Admin@123

## Como Executar

1. Clonar repositório

```bash
git clone URL_DO_REPOSITORIO
```

2. Configurar connection string em appsettings.json


```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=RaizesNordesteDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

4. Executar migrations

```bash
dotnet ef database update
```

4. Executar aplicação

```bash
dotnet run
```

5. Acessar Swagger

```text
https://localhost:xxxx/swagger
```

## Segurança

A API utiliza autenticação JWT.

Para acessar endpoints protegidos:

1. Realizar login
2. Copiar token
3. Utilizar botão Authorize do Swagger

## Autor

Rafael Arantes da Silva
