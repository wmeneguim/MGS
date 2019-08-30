# mgs

O projeto foi feito na IDE Visual Studio 2017, utilizando a tecnologia ASP.Net C# 4.7.2 WebForms e tendo como persistência de dados o SQLServer 2017.

Passos para execução do website:

1-Abra o arquivo pontuacao.sql no SQLServer e execute o script para criação do banco de dados e tabela;

2-Abra o projeto myGameScore no visual studio;

3-Clique com o botão direito do mouse no projeto "myGameScore" e defina como projeto de inicialização;

4-Dentro do projeto "myGameScore" procurar pela página Pontuacoes.aspx, clicar com o botão direito e definir como página de inicialização;

5-Abra o arquivo Web.config do projeto e atualize a ConnectionString com a sua conexão do banco de dados do SQLServer.

6-Ainda no arquivo Web.config dentro ta tag appSettings, se seu SQLServer estiver com a cultura padrão US e não PT-BR, será necessário alterar o value da key cultureDataFormat de value="dd/MM/yyyy" para value="MM/dd/yyyy";

7-Após ter executado o script e alterado o Web.config, execute o projeto;

8-Execute o projeto.
