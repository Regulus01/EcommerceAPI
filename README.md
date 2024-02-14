# Sobre o projeto - ⚠ Em construção ⚠

O projeto é uma Web API para um E-commerce, incorporando tecnologias em nuvem para potencializar sua escalabilidade e
eficiência.
Este projeto adota uma abordagem baseada no Domain-Driven Design (DDD), organizando-o em contextos específicos
para otimizar a gestão e manutenção do sistema.

## Confira também
  * E-Commerce [FrontEnd](https://github.com/Regulus01/ECommerce)
    
## O que é necessário para executar?

Para iniciar o projeto localmente, é imprescindível seguir alguns passos essenciais. Primeiramente,
crie um arquivo denominado "appsettings.json" e o coloque na pasta denominada "config".

Nesse arquivo deverá incluir a string de conexão no seguinte formato. Certifique-se
de que o banco de dados utilizado seja o PostgreSQL:

```
{
  "ConnectionStrings": {
    "App": "Server=****; Database=****; User id=****; Password=****;Include Error Detail = true"
  },
  "Aws": {
    "S3": "key=****; secret=****"
  }
}
```

Após a criação do arquivo de configuração, build o projeto e execute as migrações nas respectivas pastas de
infraestrutura de dados, abrangendo todos os contextos necessários.

#### Observação:

É necessário configurar os serviços da AWS para utilizar alguns recursos, como por exemplo
o gerenciador de arquivos.

## API Reference

## Authentication

#### Obtém o token de autenticação

```http
  Post /api/authentication
```

| Parameter  | Type     | Description                                        |
|:-----------|:---------|:---------------------------------------------------|
| `Email`    | `string` | **Required**. Email do usuário para a autenticação |
| `Password` | `string` | **Required**. Senha do usuário no sistema          |

### Cadastro no sistema

```http
  Post /api/cadastrar
```

| Parameter  | Type     | Description                                                |
|:-----------|:---------|:-----------------------------------------------------------|
| `Nome`     | `string` | **Required**. Nome do usuário                              |
| `Email`    | `string` | **Required**. Email para cadastro no sistema               |
| `Password` | `string` | **Required**. Senha utilizada para autenticação no sistema |

## Produto

### Cadastro de produtos

```http
  Post /api/produto
```

| Parameter | Type     | Description                    |
|:----------|:---------|:-------------------------------|
| `Nome`    | `string` | **Required**. Nome do Produto  |
| `Preco`   | `string` | **Required**. Preco do produto |

### Produtos por id

```http
  GET /api/produto/id
```

| Parameter | Type   | Description                            |
|:----------|:-------|:---------------------------------------|
| `Id`      | `Guid` | **Required**. Id do produto no sistema |

### Listagem de produtos

```http
  GET /api/produto?
```

| Parameter | Type  | Description                       |
|:----------|:------|:----------------------------------|
| `Skip`    | `int` | **Required**. Inicio da listagem  |
| `Take`    | `int` | **Required**. Tamanho da listagem |

### Atualização de foto de capa 

```http
  PATCH /api/produto/{id}/fotodeCapa
```

| Parameter           | Type     | Description                           |
|:--------------------|:---------|:--------------------------------------|
| `Id`                | `Guid`   | **Required**. Id do produto           |
| `caminhoFotoDeCapa` | `string` | **Required**. Caminho da foto de capa |

## GerenciadorDeArquivos (S3)

```http
  POST /api/gerenciador
```

| Parameter    | Type   | Description                                                                                     |
|:-------------|:-------|:------------------------------------------------------------------------------------------------|
| `EntidadeId` | `int`  | **Required**. Id da entidade da imagem ex: Produto                                              |
| `Entidade`   | `enum` | **Required**. Nome da entidade do produto enum. 1 - Produto                                     |
| `Ordem`      | `int`  | **Required**. Ordem para exibição das fotos, por regra, a ordem 1 é destinada para foto de capa |

```http
  Get /api/gerenciador/{entidadeId} - Obtem todos os arquivos de uma entidade
```

| Parameter | Type   | Description              |
|:----------|:-------|:-------------------------|
| `Id`      | `Guid` | **Required**. EntidadeId |

```http
  Dele /api/gerenciador/{Id} - Remove um arquivo do gerenciador e do S3
```

| Parameter | Type   | Description                      |
|:----------|:-------|:---------------------------------|
| `Id`      | `Guid` | **Required**.  Id do gerenciador |

## Tecnologias

* Aws RDS
* Aws S3
* Entity Framework
* Dotnet 8.0
* Postgres SQL
* Dapper

## Authors

- [@José](https://github.com/Regulus01)
