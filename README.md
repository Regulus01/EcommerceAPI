
# Sobre o projeto

Projeto de web API de uma marketplace utilizando tecnologias em nuvem. No projeto foi abordado utilizando modelado utilizando DDD, onde é divido em contextos.


## API Reference

#### Obtém o token de autenticação

```http
  Post /api/Authentication
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Email` | `string`   | **Required**. Email do usuário para a autenticação |
| `Password` | `string`| **Required**. Senha do usuário no sistema |

#### Cadastro no sistema

```http
  Post /api/Cadastrar
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Nome`      | `string` | **Required**. Nome do usuário     |
| `Email`      | `string` | **Required**. Email para cadastro no sistema    |
| `Password`      | `string` | **Required**. Senha utilizada para autenticação no sistema    |


## Tecnologias

* Aws RDS 
* Entity Framework
* Dotnet 8.0
* Postgres SQL

## Authors

- [@José](https://github.com/Regulus01)
