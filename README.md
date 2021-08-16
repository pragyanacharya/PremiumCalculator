# PremiumCalculator
This project calculates premium based on different parameters. 

Solution Structure

The solution is divided into 2 parts as below
1. UI
2. API

Overview
1. UI- This is a .Net Core 3.1 web app project. The view is developed using Razor pages with all client validations using jQuery. The corresponding test project is placed within the same folder
2. API- This is a .Net Core 3.1 Web API project. The API follows a CQRS architecture pattern. This is divided into 4 layers as below.
  2.1 Web Api Layer-This is the outer modt layer consisting of controllers which receives the request.
  2.2 Application Layer- All business logic sits inside Application layer.
  2.3 Repository Layer-  The database related queries and commands are placed in Repository layer(no context or configuration in this case as there is nor real data base)
  2.4 Domain Layer-The inner most layer is Domain layer which holds all entities(Empty in this case as there is nor real data connection)

Steps to run:

Make sure to select Multiple start-up projects option from Solution properties. Start Calculation andWebApi project.
Click the Start, it should brings up 2 browser instance, UI and another for the API.
Enter the required field and click calculate button to get the premium amount. You can also recalculate the premium by changing the Occupation Type dropdown.
There is a reset button to reset the form fields. 
