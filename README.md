# Sobre o projeto

O projeto é uma Web API para um marketplace, incorporando tecnologias em nuvem para potencializar sua escalabilidade e eficiência. 
Este projeto adota uma abordagem baseada no Domain-Driven Design (DDD), organizando-o em contextos específicos 
para otimizar a gestão e manutenção do sistema.

## O que é necessário para executar?

Para iniciar o projeto localmente, é imprescindível seguir alguns passos essenciais. Primeiramente, crie um arquivo denominado "appsettings.json" e o coloque na pasta denominada "config".

Nesse arquivo deverá incluir a string de conexão no seguinte formato. Certifique-se 
de que o banco de dados utilizado seja o PostgreSQL:
```
{
"ConnectionStrings": {
"App": "Server=*****;* Database=****; User id=*****; Password=*****;"
    }
}
```

Após a criação do arquivo de configuração, build o projeto e  execute as migrações nas respectivas pastas de infraestrutura de dados, 
abrangendo todos os contextos necessários.


## API Reference

## Authentication

#### Obtém o token de autenticação

```http
  Post /api/Authentication
```

| Parameter  | Type     | Description                                        |
|:-----------|:---------|:---------------------------------------------------|
| `Email`    | `string` | **Required**. Email do usuário para a autenticação |
| `Password` | `string` | **Required**. Senha do usuário no sistema          |

### Cadastro no sistema

```http
  Post /api/Cadastrar
```

| Parameter  | Type     | Description                                                |
|:-----------|:---------|:-----------------------------------------------------------|
| `Nome`     | `string` | **Required**. Nome do usuário                              |
| `Email`    | `string` | **Required**. Email para cadastro no sistema               |
| `Password` | `string` | **Required**. Senha utilizada para autenticação no sistema |

## Produto

### Cadastro de produtos
```http
  Post /api/Produto
```

| Parameter | Type     | Description                    |
|:----------|:---------|:-------------------------------|
| `Nome`    | `string` | **Required**. Nome do Produto  |
| `Preco`   | `string` | **Required**. Preco do produto |

### Produtos por id
```http
  GET /api/Produto/id
```

| Parameter | Type     | Description                            |
|:----------|:---------|:---------------------------------------|
| `Id`      | `Guid`   | **Required**. Id do produto no sistema |

### Listagem de produtos
```http
  GET /api/Produto?
```

| Parameter | Type  | Description                      |
|:----------|:------|:---------------------------------|
| `Skip`    | `int` | **Required**. Inicio da listagem |
| `Take`    | `int` | **Required**. Tamnho da listagem |

## Tecnologias

* Aws RDS
* Entity Framework
* Dotnet 8.0
* Postgres SQL
* Dapper

## Authors

- [@José](https://github.com/Regulus01)
