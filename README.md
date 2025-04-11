# Test Sonar project

## Steps to reproduce the issue

- Create a project in Sonar with code `sample-project`
- In Project Settings -> Languages -> C#
  - `sonar.cs.opencover.reportsPaths` = `**/coverage.opencover.xml`
  - `sonar.cs.vstest.reportsPaths` = `**/*.trx`
- Install dotnet tool
  - `dotnet tool install --global dotnet-sonarscanner --version 10.1.1`
- Build and test using Sonar
  - `dotnet sonarscanner begin /k:"sample-project" /d:sonar.token="{TOKEN}" /d:sonar.host.url="{HOST}" /d:sonar.ws.timeout=240 /d:sonar.verbose=true`
  - `dotnet test -c Release --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover`
  - `dotnet sonarscanner end /d:sonar.token="{TOKEN}"`
