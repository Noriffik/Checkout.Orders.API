# Checkout.Orders.API

The solution is based on ASP.NET Core. 
It contains several projects:

- `Checkout.Orders.API` contains the web part of the project with the implementations of APIs
- `Checkout.Orders.Domain` contains the logic part with the definition of the Handlers and the Repository
- `Checkout.Orders.API.Tests` contains both unit tests and integration tests using the WebClientFactory
- `Checkout.Orders.API.Contract` contains the contract for the APIs. This project is created with the purpose to deliver it into an internal NuGet repo.(Consumer purpose)
- `Checkout.Orders.API.Client` contains the client for the APIs. This project is created with the purpose to deliver it into an internal NuGet repo. (Consumer purpose)
- `Checkout.Orders.API.Client.Tests` contains  the tests of the client.

## Considerations

- The `MemoryOrderRepository` is intended for demo purposes. In a real application it will be replaced with a real data-source

- The `Mediator` is implemented in a DIY way for showcase purposes. In a real application I will probably use a 3rd pary plugin. The implemented mediator doesn't consider asyncronous processing as well as cancellation policies (CancellationToken).

- I've kept the informations about entities as simple as possible to avoid to define large entities with a lot of mocked records

- The service uses `Automapper` to implement the mapping strategy. `Automapper` comes with a performance cost. It abuses of reflection to detect properties and map them togther. In case of large entities, or a performance-critial approach, It is better considering a manual mapping between entities.
