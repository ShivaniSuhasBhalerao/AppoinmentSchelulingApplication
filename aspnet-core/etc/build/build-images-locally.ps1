param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../../"

$dbMigratorFolder = Join-Path $slnFolder "src/AppoinmentSchelulingProject.DbMigrator"

Write-Host "********* BUILDING DbMigrator *********" -ForegroundColor Green
Set-Location $dbMigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/appoinmentschelulingproject-db-migrator:$version .



$angularAppFolder = Join-Path $slnFolder "../angular"
$hostFolder = Join-Path $slnFolder "src/AppoinmentSchelulingProject.HttpApi.Host"

Write-Host "********* BUILDING Angular Application *********" -ForegroundColor Green
Set-Location $angularAppFolder
yarn
npm run build:prod
docker build -f Dockerfile.local -t mycompanyname/appoinmentschelulingproject-web:$version .

Write-Host "********* BUILDING Api.Host Application *********" -ForegroundColor Green
Set-Location $hostFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/appoinmentschelulingproject-api:$version .




### ALL COMPLETED
Write-Host "COMPLETED" -ForegroundColor Green
Set-Location $currentFolder