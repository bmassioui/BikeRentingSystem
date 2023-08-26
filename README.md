# Bike Renting System with .NET 7, Blazor WASM, Identity Core, Entity Framework Core, SQL Server

This repository contains a Bike Renting System built using .NET 7, Blazor WebAssembly (WASM), Identity Core, Entity Framework Core, and SQL Server. The project is organized into three sub-projects: Server, Client, and Shared.   
* The Server project: Handles the backend logic and data storage.
* The Client project: Provides the user interface using Blazor WASM.
* The Shared project: Contains shared code and models.

## Prerequisites

Before you begin, make sure you have the following tools installed:

- .NET 7 SDK
- Docker (for running the project in a containerized environment)

## Getting Started

Follow these steps to set up and run the Bike Renting System:

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/bmassioui/BikeRentalSystem.git
   ```

2. Navigate to the cloned repository:

   ```bash
   cd BikeRentalSystem
   ```

### Server

3. Navigate to the Server project directory:

   ```bash
   cd Server
   ```

4. Set up the database connection string in `appsettings.json`.

5. Run the database migrations to create the necessary tables:

   ```bash
   dotnet ef database update
   ```

6. Build and run the Server project:

   ```bash
   dotnet run
   ```

   The server should now be running on `https://localhost:5001`.

### Client

7. Open a new terminal window and navigate to the Client project directory:

   ```bash
   cd ../Client
   ```

8. Build and run the Client project:

   ```bash
   dotnet run
   ```

   The client application should now be accessible through your web browser at `https://localhost:5001`.

## Usage

Once the application is running, you can use the Bike Renting System to:

- View available bikes
- Rent a bike
- Return a rented bike
- Manage user accounts and authentication

## Docker

To run the Bike Renting System using Docker, follow these steps:

1. Build the Docker image for the Server project:

   ```bash
   docker build -t bike-renting-server ./Server
   ```

2. Build the Docker image for the Client project:

   ```bash
   docker build -t bike-renting-client ./Client
   ```

3. Run the Docker containers:

   ```bash
   docker run -d -p 8080:80 --name bike-renting-server-container bike-renting-server
   docker run -d -p 8081:80 --name bike-renting-client-container bike-renting-client
   ```

   The Server and Client containers should now be running and accessible on `http://localhost:8080` and `http://localhost:8081` respectively.

## Contributing

If you'd like to contribute to this project, please follow the typical GitHub fork and pull request workflow.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgments

- This project was inspired by the need for a modern and efficient bike-renting system.
- Special thanks to the contributors of .NET, Blazor, Identity Core, Entity Framework Core, and SQL Server for providing excellent tools and frameworks.

Feel free to customize and extend this README as needed for your project. Good luck and happy coding!
```

You can copy and paste this Markdown content into your README.md file in your repository. Make sure to replace placeholders like `your-username` with actual values and adjust any paths or URLs as needed for your project structure.
