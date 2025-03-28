# ArtBooking.2025

Contains ArtBooking demo application for "Backend applications programming" university course. Building application starts from simple web api project and advances to layered monolith application with possibility to use in microservices architecture.

> NOTE: Check other branches of this repo!

## LAB #1 - creating dotnet projects

**prerequisites:**
1. `DotNet SDK v.8` installed - https://dotnet.microsoft.com/en-us/download/dotnet/8.0
2. `Visual Studio Code` as code editor - https://code.visualstudio.com/docs/languages/dotnet
3. `C# Dev Kit` extension for VS Code - https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit

**dotnet CLI** (command line iterface)
https://learn.microsoft.com/en-us/dotnet/core/tools/

> `dotnet -v`
> Displays the version of the installed .NET SDK.

> `dotnet new --help`
> Shows help information for the dotnet new command, listing available templates and usage details.

> `dotnet new {template} -n {project-name}`
> Creates a new project based on the specified template, with the given project name.

**Various types of web projects**
> `dotnet new mvc -n MVC_demo`
> Generates a new ASP.NET Core MVC project in MVC_demo folder.

> `dotnet new webapi -n WebApi_demo`
> Creates a new ASP.NET Core Web API (minimal api) project in WebApi_demo folder.

> `dotnet new webapi --help`
> Displays help information for the dotnet new webapi template, showing available options.

> `dotnet new webapi --controllers`
> Creates a Web API project with controllers enabled.

**Running the application**
> dotnet run

Debugging With Visual Studio Code:
1. In sidebar open the "Run and Debug" panel (Ctrl+Shift+D).
2. In the "Run and Debug" panel, click blue button "Run and Debug".
3. Top select menu should popup.
4. Pick C# project configuration.
5. In the next steps choose default options.
6. In the END: Once confiugred you can start debugging picking configuration from pull down directly in "Run and Debug", and start with "green arrow".
