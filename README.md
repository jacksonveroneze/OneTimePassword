![Image](https://github.com/jacksonveroneze/OneTimePassword/blob/main/assets/otp.png)

# One Time Password

Projeto desenvolvido com o objetivo de estudar OTP. O mesmo gera e valida tokens.

![GitHub](https://img.shields.io/github/license/jacksonveroneze/OneTimePassword?logoColor=%20)
![GitHub last commit](https://img.shields.io/github/last-commit/jacksonveroneze/OneTimePassword)

## 💻 Sobre o projeto

Tabela de conteúdos
=================
<!--ts-->
   * [Sobre](#sobre)
   * [Tabela de Conteudo](#tabela-de-conteudo)
   * [Status do Projeto](#status-do-projeto)
   * [Features](#features)
   * [Demonstração da aplicação](#demonstracao-da-aplicação)
   * [Tecnologias](#tecnologias)
   * [Contribuição](#contribuição)
   * [Licença](#licença)
<!--te-->

## Status do Projeto

🚧  Em construção...  🚧

## ✅ Features

- [x] Geração de token
- [x] Validação de token
- [ ] Configurar tempo de validade do token
- [ ] Configurar tamanho do token

## 🎲 Demonstração da aplicação

### Gerar token
```shell
curl --location --request POST 'http://onetimepassword-env-1.eba-ajm2bkfv.sa-east-1.elasticbeanstalk.com/api/v1/totp/new' \
--header 'Accept: application/json' \
--header 'Content-Type: application/json' \
--data-raw '{
    "time": 1
}'
````

### Validar token
```shell
curl --location --request POST 'http://onetimepassword-env-1.eba-ajm2bkfv.sa-east-1.elasticbeanstalk.com/api/v1/totp/validate' \
--header 'Accept: application/json' \
--header 'Content-Type: application/json' \
--data-raw '{
    "token": "861892"
}'
````

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [C# 8.0](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [ASP.NET Core 3.1](https://dotnet.microsoft.com/)
- [ASP.NET WebApi Core 3.1](https://dotnet.microsoft.com/apps/aspnet)
- [Refit](https://github.com/reactiveui/refit)
- [Serilog](https://serilog.net/)
- [Docker](https://www.docker.com/)

## ✅ Contribuição

1. Faça um **fork** do projeto.
2. Crie uma nova branch com as suas alterações: `git checkout -b my-feature`
3. Salve as alterações e crie uma mensagem de commit contando o que você fez: `git commit -m "feature: My new feature"`
4. Envie as suas alterações: `git push origin my-feature`
> Caso tenha alguma dúvida confira este [guia de como contribuir no GitHub](https://github.com/firstcontributions/first-contributions)

## 📝 Licença

Este projeto esta sobe a licença MIT.

Feito por Jackson Veroneze 👋🏽 [Entre em contato!](https://www.linkedin.com/in/jacksonveroneze/)
