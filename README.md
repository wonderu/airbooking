# Example of flight booking service

Technologies:
Client:
 - AngularJS - industrial standard JavaScript-framework in single-page applications developing. 
 - Bootstrap - industrial standard CSS-framework responsive web applications developing.
 
Server:
 - Operating System: MS Windows
 - Platform: MS .NET
 - Language: C#
 - Database: MS SQL Server
 - Web engine: ASP.NET MVC
 - REST: Web API
 - Logging: NLog
 - Dependency Injection: Simple Injector
 - Mapping: AutoMapper
 - ORM: Entity Framework
 - Unit tests: MS Unit
 
Design patterns and principles
 - MVC pattern is the basement of the ASP.NET MVC technology and the main server-pages are built using it. AngularJS also uses MVC-pattern.
 - Singleton pattern is used for Logging purposes
 - Factory method pattern is for Entity Framework context creating.
 - Dependency Injection pattern implements inversion of control for resolving dependencies. Used it everywhere in the application and in the tests.
 - Mock pattern can simulates the behavior of complex, real objects. Used in unit tests. 
 - Observer pattern helps AngularJS to control states
 - State pattern is used for changing pages in client side

The application is built as designed. It has tier-architecture and built on DI-pattern. 
It allows to test almost whole own code and divide definition and realiztion.

Prerequisites:
 - Operating System: Windows 7, 8, 10, 2012, 2016
 - Browser: updated Google Chrome
 - RDBMS: MS SQL Server 2014 Express
 - RAD: Visual Studio 2019 Community, Professional or Enterprise
 - (optional) Integration Testing: SoapUI Open Source (https://www.soapui.org/downloads/soapui.html)

Limits:
 - Realized only one use case "Booking"
 - The project has no client validation
 - Price and Payment services are stubs

How to compile:
1) Open Airbooking.sln in Visual Studio.
2) Right click on topmost node in Solution explorer and click "Restore NuGet Packages". It should download needed packages. If you have no such menu the packages skipp this step.
3) Right click on topmost node in Solution explorer and click "Rebuild Solution"

How to start project in Visual Studio:
1) Right click on Airbooking.Api project and click "Set as StartUp project".
2) Point connection string (DefaultConnection) to your MS SQL Server in Airbooking.Api\Web.Config
3) In Project Properties of Airbooking.Api set Web -> Servers: IIS Express and https://localhost:44336/. 
3) Run the project. (VS shows dialogs about certificates, click "Yes")
4) Try to login with any email and password: it creates database automatically. Wait for 2-10 minutes (generating test data). Test data is only for several days from today. 
5) Register to the system as internal user or Google user.
6) Go to https://localhost:44336/#/
7) Try to find flight (attention: there are no any validation. you can use [today, today + 5] days intervals. Query "SELECT distinct [DepartureDate] FROM [Airbooking].[dbo].[FlightSchedules]" shows you actual flights dates) and book it. 
You will receive email with your booking.
8) (optional) You can run SoapUI for integration testing. Sources\Airbooking.Api.Tests\IntegrationApiTest-soapui-project.xml. 
You should change user email/password in AirbookingTest-> "https://localhost:44336/ TestSuite" -> "Booking TestCase" -> "Login".

Issues:
 - I'm using obsolete Automapper methods. Have no time to redevelop.
 - Aibooking.API should be called Aibooking.Web

I think that created solution could be good starting point for junior or regular developer to continue development of booking system.
