# Jetty Technical Test

Hey 👋 I'm Connor Broxton, full stack developer with around 8 years experience and this is my submission for the Jetty technical test.

It is split up into 3 parts, the ASP.NET Core based API in the `api` folder, the Angular UI in the `ui` folder and some basic XUnit tests in the `test` folder. Instructions on running each part can be found in their individual folders.

When running, the employee details can be viewed on the `employee/{id}` route of the Angular app. This will display the requested info however I've also decided to add the employee age and city info as a bonus. If you encounter an error from the API you should be automatically be directed to an error page (however hopefully there aren't any 😆 so you may have to force one). If you attempt to go to the employee route for an employee that does not exist or to a route that is not valid you should be taken to a 404 page.

I've done very little styling as based on the spec it didn't seem of too much importance so I've focused on the functionality.

The API routes differ slightly from the spec as I wanted to make them a bit more restful, they are...

`/authenticate/generate`
`/employee/{id}`
`/employee/{id}/address`
