# mgs

O projeto foi feito na IDE Visual Studio 2017, utilizando a tecnologia ASP.Net C# 4.7.2 WebForms e tendo como persistência de dados o SqlServer 2017.

Passos para execução do website:

1-Abra o projeto myGameScore no visual studio;

2-Aba o arquivo pontuacao.sql no SQLServer e execute o script para criação do banco de dados e tabela;

3-Antes de iniciarmos a execução do projeto é necessário alterar o arquivo Web.config do projeto com a sua conexão do banco de dados.

3.1-Abra o arquivo Web.config e localize: connectionString="Data Source=WNOTE;Initial Catalog=GameScore;Integrated Security=True;"

3.2-Após localizar, altere para as configurações de sua máquina;

4-Ainda no Web.config dentro ta tag appSettings, se seu SQLServer estiver com a cultura US e não PT-BR, será necessário alterar o value da key cultureDataFormat.

4.1-De: key="cultureDataFormat" value="dd/MM/yyyy" 4.2-Para: key="cultureDataFormat" value="MM/dd/yyyy"

5-Após ter executado o script e alterado o Web.config, execute o projeto.
