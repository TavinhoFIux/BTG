# BTG
    Sistema para visualizar, editar e deletar produtos numa tabela realizando um crud basico!

## Tecnologias utilizadas
    Angular 16.
    Node 18.16.0
    .NET 6.0.
    SQL Server 2022.
    Visual Studio Code
    Microsoft Visual Studio

### Guia para instalação das tecnologias
    1 - Para instalação do Node.JS acessar site: https://nodejs.org/ e baixar versão 18.16.0 e instale na sua máquina.

    2 - Para instalação do angular CLI acessar terminar e executar script: npm install -g @angular/cli.

    3 - Para instalação do .NET 6.0 acessar site:  e baixar versão 7.0.302 e instale na sua máquina.

    4 - Para instalação do SQL Server 2022 acessar site: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads e baixe a versão Developer e instale na sua máquina.

    5 - Para instalação do Visual Studio Code acessar site: https://visualstudio.microsoft.com/pt-br/downloads/ e instalar na sua máquina.

    6 - Para instalação do Microsoft Visual Studio acessar site: https://visualstudio.microsoft.com/pt-br/downloads/ e baixe a versão Community e instale na sua máquina.

#### Rodando o frontEnd
    1 -  Vá até diretorio onde se encontra o frontEnd, abra o terminal e execute o comando: cd .\FrontEnd\

    2 -  Agora escute o comando para instalar toda as dependencia que FronEnd necessita para ser executado, usando comando: npm install

    3 -  Para rodar o frontEnd execute o comando: ng serve

#### Rodando a WebApi
    1 - Abra o projeto WebApi no Visual Studio. 

    2 - Agora abra o arquivo appsettings.json lá voce vera ConnectionStrings dentro dela tem propriedade ctx altere o Server para nome do seu servidor de banco de dados exemplo: "Server=MeuServidor;Initial Catalog=BtgDb;Trusted_Connection=True;                    MultipleActiveResultSets=true;TrustServerCertificate=True"

    3 - Antes de rodar a WebApi, voc� precisa rodar as migrations. Para isso, primeiro instale o [EF Tools](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install#get-the-entity-framework-core-tools):
        ```
        dotnet tool install --global dotnet-ef
        ```
        Agora, pode rodar as migrations de fato:
        ```
        dotnet ef database update 
        ``` 
        Pronto, a WebApi j� criou as tabelas e alguns registros no seu localDB. 

        Rode o projeto e, se tudo deu certo, voc� dever� ver uma p�gina do Swagger com as APIs que utilizaremos no teste.