#!/usr/bin/env node
generator("Necdet");

function generator(table) {

  // Klasörler
  KlasorOlustur(__dirname + `/../Core/Application/Features`);
  KlasorOlustur(__dirname + `/../Core/Application/Features/Commands`);
  KlasorOlustur(__dirname + `/../Core/Application/Features/Commands/${table}Commands`);
  KlasorOlustur(__dirname + `/../Core/Application/Features/Queries`);
  KlasorOlustur(__dirname + `/../Core/Application/Features/Queries/${table}Queries`);
  KlasorOlustur(__dirname + `/../Core/Application/Repositories`);
  KlasorOlustur(__dirname + `/../Core/Domain/Configuration`);
  KlasorOlustur(__dirname + `/../Core/Domain/Entities`);
  KlasorOlustur(__dirname + `/../Infrastructure/Persistence`);
  KlasorOlustur(__dirname + `/../Infrastructure/Persistence/Repositories`);


  // Commands
  path = __dirname + `/../Core/Application/Features/Commands/${table}Commands/Create${table}`;
  KlasorOlustur(path);
  Handler = DosyaOku("./template/CreateXXXCommandHandler.cs").replace(/\$TABLE/g, table);
  Request = DosyaOku("./template/CreateXXXCommandRequest.cs").replace(/\$TABLE/g, table);
  Response = DosyaOku("./template/CreateXXXCommandResponse.cs").replace(/\$TABLE/g, table);
  Validator = DosyaOku("./template/CreateXXXCommandValidator.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/Create${table}CommandHandler.cs`, Handler);
  DosyaOlustur(`${path}/Create${table}CommandRequest.cs`, Request);
  DosyaOlustur(`${path}/Create${table}CommandResponse.cs`, Response);
  DosyaOlustur(`${path}/Create${table}CommandValidator.cs`, Validator);

  path = __dirname + `/../Core/Application/Features/Commands/${table}Commands/Delete${table}`;
  KlasorOlustur(path);
  Handler = DosyaOku("./template/DeleteXXXCommandHandler.cs").replace(/\$TABLE/g, table);
  Request = DosyaOku("./template/DeleteXXXCommandRequest.cs").replace(/\$TABLE/g, table);
  Response = DosyaOku("./template/DeleteXXXCommandResponse.cs").replace(/\$TABLE/g, table);
  Validator = DosyaOku("./template/DeleteXXXCommandValidator.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/Delete${table}CommandHandler.cs`, Handler);
  DosyaOlustur(`${path}/Delete${table}CommandRequest.cs`, Request);
  DosyaOlustur(`${path}/Delete${table}CommandResponse.cs`, Response);
  DosyaOlustur(`${path}/Delete${table}CommandValidator.cs`, Validator);
  
  path = __dirname + `/../Core/Application/Features/Commands/${table}Commands/Update${table}`;
  KlasorOlustur(path);
  Handler = DosyaOku("./template/UpdateXXXCommandHandler.cs").replace(/\$TABLE/g, table);
  Request = DosyaOku("./template/UpdateXXXCommandRequest.cs").replace(/\$TABLE/g, table);
  Response = DosyaOku("./template/UpdateXXXCommandResponse.cs").replace(/\$TABLE/g, table);
  Validator = DosyaOku("./template/UpdateXXXCommandValidator.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/Update${table}CommandHandler.cs`, Handler);
  DosyaOlustur(`${path}/Update${table}CommandRequest.cs`, Request);
  DosyaOlustur(`${path}/Update${table}CommandResponse.cs`, Response);
  DosyaOlustur(`${path}/Update${table}CommandValidator.cs`, Validator);





  // Queries
  path = __dirname + `/../Core/Application/Features/Queries/${table}Queries/GetAll${table}`;
  KlasorOlustur(path);
  Handler = DosyaOku("./template/GetAllXXXQueryHandler.cs").replace(/\$TABLE/g, table);
  Request = DosyaOku("./template/GetAllXXXQueryRequest.cs").replace(/\$TABLE/g, table);
  Response = DosyaOku("./template/GetAllXXXQueryResponse.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/GetAll${table}QueryHandler.cs`, Handler);
  DosyaOlustur(`${path}/GetAll${table}QueryRequest.cs`, Request);
  DosyaOlustur(`${path}/GetAll${table}QueryResponse.cs`, Response);

  path = __dirname + `/../Core/Application/Features/Queries/${table}Queries/GetById${table}`;
  KlasorOlustur(path);
  Handler = DosyaOku("./template/GetByIdXXXQueryHandler.cs").replace(/\$TABLE/g, table);
  Request = DosyaOku("./template/GetByIdXXXQueryRequest.cs").replace(/\$TABLE/g, table);
  Response = DosyaOku("./template/GetByIdXXXQueryResponse.cs").replace(/\$TABLE/g, table);
  Validator = DosyaOku("./template/GetByIdXXXQueryValidator.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/GetById${table}QueryHandler.cs`, Handler);
  DosyaOlustur(`${path}/GetById${table}QueryRequest.cs`, Request);
  DosyaOlustur(`${path}/GetById${table}QueryResponse.cs`, Response);
  DosyaOlustur(`${path}/GetById${table}QueryValidator.cs`, Validator);

  path = __dirname + `/../Core/Application/Features/Queries/${table}Queries/Search${table}`;
  KlasorOlustur(path);
  Handler = DosyaOku("./template/SearchXXXQueryHandler.cs").replace(/\$TABLE/g, table);
  Request = DosyaOku("./template/SearchXXXQueryRequest.cs").replace(/\$TABLE/g, table);
  Response = DosyaOku("./template/SearchXXXQueryResponse.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/Search${table}QueryHandler.cs`, Handler);
  DosyaOlustur(`${path}/Search${table}QueryRequest.cs`, Request);
  DosyaOlustur(`${path}/Search${table}QueryResponse.cs`, Response);



  // I Repo
  path = __dirname + `/../Core/Application/Repositories/${table}Repository`;
  KlasorOlustur(path);
  Read = DosyaOku("./template/IXXXReadRepository.cs").replace(/\$TABLE/g, table);
  Write = DosyaOku("./template/IXXXWriteRepository.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/I${table}ReadRepository.cs`, Read);
  DosyaOlustur(`${path}/I${table}WriteRepository.cs`, Write);
  


  // Configuration
  path = __dirname + `/../Core/Domain/Configuration`;
  Write = DosyaOku("./template/XXXConfiguration.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/${table}Configuration.cs`, Write);

  // Entity
  path = __dirname + `/../Core/Domain/Entities`;
  Write = DosyaOku("./template/XXX.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/${table}.cs`, Write);

  

  // Repo
  path = __dirname + `/../Infrastructure/Persistence/Repositories/${table}Repository`;
  KlasorOlustur(path);
  Read = DosyaOku("./template/XXXReadRepository.cs").replace(/\$TABLE/g, table);
  Write = DosyaOku("./template/XXXWriteRepository.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/${table}ReadRepository.cs`, Read);
  DosyaOlustur(`${path}/${table}WriteRepository.cs`, Write);



  // Controller
  path = __dirname + `/../Presentation/Api/Controllers`;
  Write = DosyaOku("./template/XXXsController.cs").replace(/\$TABLE/g, table);
  DosyaOlustur(`${path}/${table}sController.cs`, Write);

}

// Fonksiyonlar
function DosyaOku(yol) {
  return require("fs").readFileSync(yol, "utf8");
}

function KlasorOlustur(yol) {
  const fs = require("fs");
  try {
    if (!fs.existsSync(yol)) {
      fs.mkdir(yol, (err) => {
        if (err) {
          return console.error(err);
        }
        console.log(yol + " klasör oluşturuldu.");
      });
    }
  } catch (error) {}
}

function DosyaOlustur(yol, data) {
  const fs = require("fs");
  try {
    fs.writeFile(yol, data, function (e) {
      if (e) throw e;
      console.log(`${yol} oluşturuldu.`);
    });
  } catch (error) {}
}
