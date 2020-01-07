cd GitHubAutomation
msbuild.exe Framework.csproj
cd ../packages\NUnit.ConsoleRunner.3.10.0\tools
nunit3-console.exe --testparam:browser=Chrome --testparam:environment=dev "../../../GitHubAutomation/bin/Debug/GitHubAutomation.dll" --where "cat=IncorrectEmail"
