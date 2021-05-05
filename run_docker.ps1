$SrcPath = "./src/"
$DockerImageName = "deploy-rover-client"

Write-Host "Building Solution..."
dotnet build $SrcPath

Write-Host "Building docker image: ${DockerImageName}"
docker build -t ${DockerImageName} -f Dockerfile .

Write-Host "Will run the application..."
docker run -it --rm $DockerImageName
