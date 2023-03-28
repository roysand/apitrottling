# Introduction
This is a template solution for standard REST API for Bas Kommunkasjon.

## Backend architecture

The backend architecture is inspired by best practises to achieve "Clean code" arhitecture, separating Infrastructure (Entity framework, Mail services, and other external services), Domain models, Application (Business logic) and Presentation (Rest API with/swagger).

Read more for a similar aproach in this blog post:
https://www.rubicon-world.com/blog/2020/06/a-developers-guide-to-cqrs-using-net-core-and-mediatr/

![](https://images.prismic.io/rubicon-worldcom/de9ec27c-062e-4874-9e92-cc5ea0b6f0a5_clean-architecture-2x.png?auto=compress%2Cformat&w=1400&h=696)

Or Google *Jason Taylor* (Microsoft Speaker)


### Template use the following packages / technologies

This template use the following:
- Mediatr
- FluentValidation
- AutoMapper
- Swagger
- .Net Core 7.x
- Entity Framework Core
- SQL Server



# Getting Started

1. Download the nuget package
2. Install the nuget with this command *dotnet new install 'nuget package name'*
3. Create a new solution using the new template with this command *dotnet new 'templatename'*
4. Unsure name of new template run this command *dotnet new list*
5. To delete the new install template *dotnet new uninstall 'templatename'*

# Build and Test
1. Open the new solution in your preferred code editor
2. To test if the template compile and  run
3. There is one external dependency to run this template. The code use a database table with name *PrefDb_Login_Name*. Add the following to your User Secret: *ApplicationSettings:DbConnectionString* value is database connection string to a database with this table.


# If you want to learn more about creating good readme files?

Then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)