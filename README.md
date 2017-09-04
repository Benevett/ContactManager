# Contact Manager
A simple project using Visual Studio 2017 DotnetCore2 Angular template
build using web api and bootstrap css template.

This has been published to azure and is available at [ask me]

so you will be able to have a look without having to get it to run locally

# Assumptions and Caveats
This is by no means a finished product and I am aware that it is fairly basic in terms of flashy UI but  it is am attempt to illustrate some of the concepts used to produce he contact manager app required.
I chose the angular template since I have previously worked with angular2 and wanted to see how the new template works.

1. There is no security
This means that anyone can access the site.
Normally I would use the Aspnet identity to lock down the co	controllers and use bearer tokens to control access to the web api.

2. Logging is minimal – just to illustrate what could be done
3. There are no sensible unit tests to speak of
4. The UI is not great and the navigation isn't quite right
5. There is minimal exception handling
6. There is no validation on the user input fields so you can put invalid phone numbers etc.,
