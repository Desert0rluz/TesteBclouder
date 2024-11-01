# Gerenciador de Tarefas

Este é um sistema simples de Gerenciamento de Tarefas desenvolvido em C# (.NET 8.0). O sistema permite cadastrar pessoas e suas tarefas, além de fazer a associação entre elas. 

## Funcionalidades

- **Cadastro de Pessoas**: Criar, visualizar, atualizar e remover pessoas.
- **Cadastro de Tarefas**: Criar, visualizar, atualizar e remover tarefas.
- **Associação de Tarefas a Pessoas**: Uma pessoa pode ser responsável por várias tarefas, e cada tarefa pode ter apenas uma pessoa responsável.
- **Acompanhamento de Status**: Alterar o status das tarefas entre “pendente”, “em progresso” e “concluída”.
- **Validação de Exclusão**: Não é permitido excluir uma pessoa se ainda houver tarefas pendentes associadas a ela.

Tanto o cadastro de pessoas, quanto o cadastro de Tarefas podem ser feitos sem vinculo inicial, para realizar o vinculo basta modificar o cadastro e adicionar o Id da pessoa responsavel pela tarefa.

## Tecnologias Utilizadas

- **Backend**: C# (.NET 8.0)
- **Banco de Dados**: SQL Server
- **Frameworks**: Entity Framework para acesso ao banco de dados

## Estrutura do Projeto

ProjetoBclouder/
├── ProjetoBclouder.API/
│   ├── Controllers/
│   │   ├── PessoaController.cs
│   │   └── TarefaController.cs
│   └── Program.cs
├── ProjetoBclouder.Data/
│   ├── Data/
│   │   ├── DAL.cs
│   │   └── ProjetoBclouderDbContext.cs
│   └── Migrations/
└── ProjetoBclouder.Models/
    ├── Models/
    │   ├── Pessoa.cs
    │   └── Tarefa.cs

## Configuração do Banco de Dados

1. Crie um banco de dados no SQL Server.
2. Atualize a string de conexão no arquivo `ProjetoBclouderDBContext.cs` do projeto API para apontar para seu banco de dados:

Execute as migrações para criar as tabelas necessárias:

            Add-Migration InitialCreate
            Update-Database

Depois disso é só rodar o projeto.
A pagina inicial do Swagger vai abrir no navegador e todos os endpoints estarão disponiveis para serem testados.
