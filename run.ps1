$SrcPath = "./src/"
$DeployRoverClientPath = "${SrcPath}DeployRoverClient/bin/Debug/net5.0/DeployRoverClient.dll"

Write-Host "Will build the solution..."
dotnet build $SrcPath

Write-Host "Will start the application at ${DeployRoverClientPath}"
dotnet ${DeployRoverClientPath}
