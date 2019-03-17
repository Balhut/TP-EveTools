echo Restoring TP-EveTools.Core:
cd ../src/TP-EveTools.Core/
dotnet restore
echo Restoring TP-EveTools.Infrastructure:
cd ../TP-EveTools.Infrastructure/
dotnet restore
echo Restoring TP-EveTools.Api:
cd ../TP-EveTools.Api/
dotnet restore
echo Restoring TP-EveTools.Api.ClientApp:
cd ClientApp
npm install
cd ../../../scripts