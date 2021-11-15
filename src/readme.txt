Repositório do projeto:

   https://github.com/Guilherme1997/DevelopersChallenge

Orientações para a execução do projeto :

    Instale a versão 5.0.402 do .Net Core

   Adicione a conexão do banco de dados local, no caminho: 

	auvo/DevelopersChallenge/src/auvo/Auvo-api/appsettings.json

   Adicionar a conexão na propriedade: 
	DefaultConnection.	

    Na pasta de infrastrutura(auvo/DevelopersChallenge/src/auvo/Infrastructure)  adicione as migrações para ter acesso ao banco

	dotnet ef --startup-project ../Auvo-api   migrations add MudancaTipoValor
	
	dotnet ef --startup-project ../Auvo-api database update


ORM via Nuget:

	dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.11

        dotnet add package Microsoft.EntityFrameworkCore --version 5.0.11

        dotnet add package EntityFramework --version 6.4.4     


