# LaunchTimeDB (Desafio DBServer)

No desafio, foi basicamente implementado através de 2 aplicações.


## Stack Utilizada
- **Backend**: .Net 3.1 (REST API, DDD, Swagger, Cors, Injeção de Dependência e xUnit para Teste de Unidade)
- **Frontend**: React 17.0 (com Componentes Funcionais/Function Components)

Para executar cada projeto, estão em suas respectivas pastas:
- Backend_.Net_3_1/
- Frontend_React/

A única execução que se faz necessária antes de iniciar a aplicação, é no projeto React/Frontend, que basta executar "npm install" e será baixado as dependências necessárias para execução.

## Collections de Postman
Para facilitar o uso da REST API, você pode Importar **collections de Postman** que também foram incluídas, estando no seguinte diretório também na raiz do repositório:
 - PostmanCollections/
 
* Dica para importar no Postman: Import > File > Seleciona o arquivo **"/PostmanCollections/LaunchTimeDB.postman_collection.json"**, e para as variáveis de ambiente, clique no botão **"Manager Environment"** (do lado do "olhinho"), clique em **Import** e selecione o arquivo: **"/PostmanCollections/Environments/local.postman_environment.json"**.


### **Importante**
Todos os dados estão mockados entre as aplicações, sendo salvos apenas no momento de execução, sem banco de dados ou integrações entre as aplicações.

@williamgoi
