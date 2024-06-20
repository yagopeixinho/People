<div align="center">
     <img src="https://i.ibb.co/GRfBVZY/People-Logo.png" />
</div>

</br>
</br>

<p align="center">
  <a href="#visão-geral">Visão Geral</a> •
  <a href="#funcionalidades">Funcionalidades</a> •
  <a href="#instalação">Instalação</a> •   
  <a href="#arquitetura">Recursos</a> • 
  <a href="#contato">Contato</a> •   
  <a href="#licença">Licença</a>   

</p>

## Visão Geral
O People é um projeto que integra uma API externa com o gerenciamento de usuários em uma plataforma própria. Seu objetivo principal é oferecer uma plataforma abrangente para o gerenciamento de usuários, focando na máxima diversidade e funcionalidade possível.

## Funcionalidades

1. Conexão ao banco de dados PostGres
2. Tabela para armazenar os dados de usuários gerados pela API Random User Generator
3. Inserção de dados na tabela
4. Consumo de API Random User Generator para gerar novos usuários
5. Armazenar os dados do suusários gerados na tabela do banco de dados PostgreSQL
6. Relatório que lista todos os usuários armazenados no banco de dados PostgreSQL
7. Páginas HTML que _carregam os dados do relatório do usuário_, _Exiba os dados em uma tabela_. _Permitem que o usuário edite os dados dos usuários_

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
O People utiliza PostgreSQL como seu banco de dados principal. Para configurar corretamente o banco de dados, siga estas etapas:

Configuração no arquivo appsettings.json:

Insira as informações corretas de conexão no arquivo _appsettings.json_ do seu projeto:


```C#
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=host;Database=nomeDoBanco;Username=postgres;Password=SuaSenha;"
  },
  "Logging": {
    // Configurações de logging
  }
}
```

Substitua ``host, nomeDoBanco, postgres`` e ``SuaSenha`` pelos valores adequados de acordo com sua configuração do PostgreSQL.

### Criação do Banco de Dados

Certifique-se de que o banco de dados PostgreSQL já está criado em seu ambiente local antes de prosseguir.

#### Aplicação das Migrações

Para aplicar as migrações necessárias ao banco de dados, siga os passos abaixo:

```bash
cd People

// Abra o terminal e execute o comando abaixo
dotnet ef database update
```

> Se ocorrerem problemas durante o processo de migração, uma solução comum é excluir a pasta _Migrations_ e recriar as migrações novamente.

Após seguir esses passos, seu ambiente estará configurado e pronto para gerenciar os dados dos usuários no People.


## Arquitetura
Durante a tomada de decisões importantes para o desenvolvimento deste projeto, optei por adotar a conhecida e robusta arquitetura MVC 
(Model-View-Controller), amplamente reconhecida por sua capacidade de separar claramente as responsabilidades dentro de uma aplicação. 
Essa escolha estratégica não apenas facilita a manutenção do código, mas também promove uma melhor organização das funcionalidades e 
uma escalabilidade mais eficiente.

### Divisão em Camadas

> Para garantir uma estrutura coesa e modular, o projeto foi dividido em três principais camadas

**People.Core:** Esta camada representa o núcleo da aplicação, onde reside a lógica de negócios e os modelos de dados fundamentais. Aqui são definidas as entidades principais como **User**, que encapsulam os dados e as operações relacionadas.
Além disso, são estabelecidas interfaces para serviços essenciais que serão implementados nas camadas subsequentes.

**People.Infrastructure:** Responsável pela persistência de dados e pela interação com recursos externos, esta camada engloba os repositórios que acessam o banco de dados ou outras fontes de dados externas. 
Aqui também são implementados serviços específicos que se comunicam diretamente com APIs externas, garantindo a separação de responsabilidades e facilitando a manutenção e o teste dessas integrações.

**People.Web:** A camada de apresentação e interação com o usuário final. Esta camada inclui os controladores MVC que gerenciam as requisições e as respostas do usuário, conectando as 
operações de negócio definidas em People.Core com as interfaces gráficas e a lógica de apresentação implementada nas views. As views são responsáveis por renderizar os dados e interagir de forma intuitiva 
com o usuário, seguindo os princípios de separação de preocupações (SoC) promovidos pela arquitetura MVC.

**Camada Externa** (External): Uma adição significativa ao projeto é a inclusão de uma camada externa dedicada exclusivamente à comunicação com APIs externas. 
Esta camada encapsula toda a lógica necessária para interagir com serviços externos, como autenticação, construção de requisições, manipulação de respostas e tratamento de erros de rede. Isso não só simplifica a integração com APIs de terceiros, mas também isola potenciais mudanças nessas integrações, garantindo que o restante da aplicação permaneça estável e coeso.

### Benefícios da Abordagem:

**Separação de Responsabilidades:** Cada camada tem um propósito bem definido, facilitando o entendimento e a manutenção do código ao longo do ciclo de vida do projeto.

**Escalabilidade:** A estrutura modular permite que novas funcionalidades sejam adicionadas ou modificadas com relativa facilidade, sem impactar outras partes do sistema.

**Testabilidade:** A separação clara entre as camadas facilita a escrita de testes automatizados, garantindo a qualidade e confiabilidade do software desenvolvido.

**Padrões de Design:** O uso de padrões como injeção de dependência, interfaces e camadas bem definidas promove boas práticas de desenvolvimento, resultando em um código mais limpo e organizado.

## Contato
- 📬 Me envie um e-mail: peixinhoyago@gmail.com
- Se você tem alguma dúvida ou quer entrar em contato comigo por qualquer outro motivo, você pode encontrar minhas redes sociais e mais informação sobre mim [clicando aqui](https://github.com/yagopeixinho/yagopeixinho/blob/master/README.md)

## Licença
Esse projeto não possui nenhuma licença.


