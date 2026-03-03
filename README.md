# Task

Task Details

1. We'd like you to implement can/bottle deposit machine, like those at many norwegian grocery
stores.
2. This is a machine
where you turn in bottles/cans for recycling, while receiving a voucher for the returned value for
you to use at the store.
3. You are free to choose how you want present/implement the UI.

# Requirements
1. The product owner has put together the following list of user stories for this application.

# RS-001

As a drinks' manufacturer,
I'd like the system to accept empty bottles
So that we can reacquire used bottles for recycling.

# RS-002
As a drinks' manufacturer,
I'd like the system to accept empty cans,
So that we can reacquire used cans for recycling.

# RS-003
As a customer,
I'd like the system to give me a voucher as a reward for turning in bottles,
So that I can buy stuff

# RS-004
As a drinks' manufacturer,
I'd like a backend system to log whenever a bottle/can is turned in or a voucher is printed,
So that we can report the efficiency of each recycling station.

# Specifications and Clarifications
1. Cans are valued at 2 NOK each.
2. Bottles are valued at 3 NOK each.
3. Inputting a bottle/can should be represented through a UI element, e.g. a button or a
console prompt.
4. For the purposes of this application, it is enough to present the printed voucher on screen
next to the bottle inputs.
5. You can assume that all containers have a valid sticker on it for valid identification.
6. The hardware running on the recycling machine is able to process a can at a rate of 0,5 per
second and for the plastic bottles it's 1 per second.

#Technology and Architecture

You choose the architecture, design, programming language and technology you would like to use
to solve this assignment.
However, keep in mind that it might be beneficial that these are somewhat related to the
technologies you'd like us to
view as your strengths


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

## How to Run
1. Open the solution in Visual Studio 2022 or later
2. Restore NuGet packages and build the solution
1. Insert <LangVersion>latest</LangVersion> in the .csproj file to enable the latest C# features if not already set
3. Run the application (F5 or Ctrl+F5)
4. Insert cans and bottles using the buttons and observe the total and logs updating accordingly
5. Print the voucher to reset the total and log the event

  
