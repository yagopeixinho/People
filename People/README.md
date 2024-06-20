<div align="center">
     <h1>People</h1>
</div>

<h4 align="center">Gerencie a diversidade. </h4>


<p align="center">
  <a href="#visão-geral">Visão Geral</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#instalação">Instalação</a> •   
  <a href="#recursos">Recursos</a> • 
  <a href="#contato">Contato</a> •   
  <a href="#licença">Licença</a>   

</p>

## Visão Geral
O People é um projeto que combina uma API externa + o gerenciamento de usuários em uma plataforma pŕopria. Esse projeto tem como objetivo principal fornecer uma paltaforma pra gerenciamento de usuários com a maior diversidade possível.
## Funcionalidades

1. **Consumo de API externa:**  O People faz o consumo da API externa https://randomuser.me/.

2. **Gerenciamento Simplificado:** O usuário pode adicionar facilmente um usuário que vem de uma API externa, além de fazer a edição e leitura de outros usuários.


## 🛠 Tecnologias
- .Net Core 8 
- Entity Framework Core
- PostgreSQL
- C#
- HTML, CSS e JS (Razor)

## Instalação
Antes de rodar o projeto, é necessário ter instalado em sua máquina:

- [Git](https://git-scm.com/)
- Visualizador de Banco de Dados - Opcional
- Um IDE de sua preferência (Windows: Recomendo o Visual Studio 2022; Linux: Recomendo o JetBrains Rider)

### 📦 Clonando repositório

```bash
$ git clone git@github.com:yagopeixinho/People.git
```

### Banco de Dados
O People utiliza o PostgresQL como o seu banco de dados principal. Basta criar o banco de dados adequado em suas configurações.

Você precisa inserir as informações corretas no arquivo _appsettings.json_:
```c#
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=host;Database=nomeDoBanco;Username=postgres;Password=SuaSenha;"
  },
  "Logging": {
  
}

```

> Vale ressaltar que o banco de dados já precisa estar criado em seu ambiente local.

Com o seu Banco de Dados criado e conectado adequadamente, Sua aplicação já está pronta pra rodar, e você já poderá visualizar o consumo para a API externa. ENtrentanto, ainda não é possível fazer alterações no banco de dados.

Para isso vamos precisar realizar um migrate do nosso banco de dados.

cd people

dotnet ef database update

## Arquitetura
Durante a tomada de decisões importantes, optei por a famosa tradicional arquitetura MVC, tratando suas responsabildades e camadas ainda mais segregadas. O People.Core, People.Infrastructure e People.Web possuem suas especificações e responsabilidades, desde a controle da visualização do usuário até a proteção de camadas mais privadas da apliucação. 

Também foi incluido uma parte **Externa** reesponsável somente pela comunicação com a API.

## Contato
- 📬 Me envie um e-mail: peixinhoyago@gmail.com
- Se você tem alguma dúvida ou quer entrar em contato comigo por qualquer outro motivo, você pode encontrar minhas redes sociais e mais informação sobre mim [clicando aqui](https://github.com/yagopeixinho/yagopeixinho/blob/master/README.md)

## Licença
Esse projeto não possui nenhuma licença.


