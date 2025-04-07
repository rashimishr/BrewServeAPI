# BrewServeAPI 🍻

BrewServeAPI is a .NET Core Web API designed to manage beers, breweries, and bars. It offers flexible filtering options and adheres to clean architectural principles.

## Features

- **Entity Management**: Create, update, and retrieve Beers, Breweries, and Bars.
- **Dynamic Filtering**: Filter beers based on attributes like alcohol content.
- **Logging**: Integrated with Serilog for comprehensive logging.
- **Unit Testing**: NUnit tests covering core functionalities.

### Project Architecture

The solution is structured into distinct projects:

- **Brewserve**: Main API project containing controllers and startup configurations.
- **Brewserve.Core**: Defines core domain entities and interfaces.
- **Brewserve.Data**: Implements data access using Entity Framework Core.
- **Brewserve.Infrastructure**: Contains infrastructure-related code, such as logging configurations.
- **Brewserve.Tests**: Houses unit tests for various components.

### Design Patterns Employed

- **Repository Pattern**: Abstracts data access logic, promoting separation of concerns.
- **Strategy Pattern**: Implements dynamic filtering strategies for beers.

### Tech Stack

- **.NET Core**
- **SQL Server**
- **Entity Framework Core**
- **Serilog**: For structured logging.
- **NUnit**: For unit testing.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- SQL Server instance
- Visual Studio or any preferred IDE

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/rashimishr/BrewServeAPI.git
   ```

2. Navigate to the project directory and restore dependencies:

   ```bash
   cd BrewServeAPI
   dotnet restore
   ```

3. Update the `appsettings.json` with your SQL Server connection string.

4. Apply database migrations:

   ```bash
   dotnet ef database update --project Brewserve.Data --startup-project Brewserve
   ```

5. Run the API:

   ```bash
   dotnet run --project Brewserve
   ```

### API Endpoints

#### Beer

- `POST /beer`: Insert a single beer.
- `PUT /beer/{id}`: Update a beer by ID.
- `GET /beer`: Retrieve all beers with optional filtering query parameters, e.g., `?gtAlcoholByVolume=5.0&ltAlcoholByVolume=8.0`.
- `GET /beer/{id}`: Retrieve a beer by ID.

## Brewery

- `POST /brewery`: Insert a single brewery.
- `PUT /brewery/{id}`: Update a brewery by ID.
- `GET /brewery`: Retrieve all breweries.
- `GET /brewery/{id}`: Retrieve a brewery by ID.

## Brewery Beers

```
- POST /brewery/beer - Insert a single brewery beer link
- GET /brewery/{breweryId}/beer - Get a single brewery by Id with associated beers
- GET /brewery/beer - Get all breweries with associated beers
```

## Bar

- `POST /bar`: Insert a single bar.
- `PUT /bar/{id}`: Update a bar by ID.
- `GET /bar`: Retrieve all bars.
- `GET /bar/{id}`: Retrieve a bar by ID.

## Bar Beers

```
- POST /bar/beer - Insert a single bar beer link
- GET /bar/{barId}/beer - Get a single bar with associated beers
- GET /bar/beer - Get all bars with associated beers
``` 

## Running Tests

Navigate to the `Brewserve.Tests` project and execute:

```bash
dotnet test
```

## 🤝 Contributing

Contributions are welcome!

## 📄 License

This project is licensed under the MIT License.

## 👨‍💻 Author

Developed by [@rashimishr](https://github.com/rashimishr).