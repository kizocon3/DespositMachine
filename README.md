# DespositMachine.Web Application


## Overview
This is an ASP.NET Core web application simulating a bottle/can deposit machine like in grocery stores. 
It allows users to insert bottles and cans, calculates the total deposit amount in value, and view logs of all actions.


## Assumtions
1. All containers have a valid sticker, so no validation of container type or authenticity is required.
2. The Hardware processing speed is simulated with `Task.Delay`:
   - Can: 0.5 per second → 2 seconds per can
   - Bottle: 1 per second → 1 second per bottle
3. For demo purposes, a `canSpeed and bottleSpeed` is applied to speed up the UI response (e.g., Can = 0.2s, Bottle = 0.4s) without changing logic.
4. The Voucher amount is automatically reset after printing.
5. The Logs are stored in memory and are cleared when the application restarts. Persistence to a database is not implemented.
6. The UI uses Bootstrap for styling and responsiveness. but only for desktop basic styling is applied for simplicity.


## Functionality
1. Insert Can/Bottle buttons simulate hardware processing and update the total.
2. Processing status is displayed dynamically during insertion.
3. Print Voucher button resets total and logs the voucher.
1. Log section displays each container inserted and voucher printing events.
5. Total is always displayed with currency (NOK).
6. UI elements are centered using Bootstrap flex utilities.
7. I avoid the use of inline styles and script tags in the Razor Pages, instead opting for separate CSS and JavaScript files for better maintainability and separation of concerns.
8. The application is built using ASP.NET Core MVC with Razor Pages for the frontend and C# for the backend logic.
9. The project targets .NET 8.0 and uses the latest C# language features for improved readability and maintainability.

## Removed It  
Shared/_Layout.cshtml ( Ignore this part! it’s just here for testing/demo purposes )

## How to Run
1. Open the solution in Visual Studio 2022 or later
2. Restore NuGet packages and build the solution
1. Insert <LangVersion>latest</LangVersion> in the .csproj file to enable the latest C# features if not already set
3. Run the application (F5 or Ctrl+F5)
4. Insert cans and bottles using the buttons and observe the total and logs updating accordingly
5. Print the voucher to reset the total and log the event

  
