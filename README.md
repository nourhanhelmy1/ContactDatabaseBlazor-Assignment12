# Blazor Contact Database

Welcome to the Blazor Contact Database project! This application allows you to manage contacts through a web-based interface.

## Overview

The Blazor Contact Database is a web application built using Blazor WebAssembly for the client-side and ASP.NET Core for the server-side. It provides the functionality to:

- Login with user authentication using Auth0.
- View contacts for users and administrators.
- Search for contacts by name or email.
- Add new contacts as an administrator.
- Edit contacts as an administrator.

## Getting Started

To run this project locally, follow these steps:

1. Clone the repository:

   ```sh
   git clone https://github.com/your-username/BlazorContactDatabase.git

2. Open the ContactDatabase.API project in Visual Studio.

3. Set the ContactDatabase.API.Server project as the startup project.

4. Run the project (F5 or Start Debugging).

5. The Blazor application should launch in your browser, and you'll be able to interact with it.

## Authentication and Authorization
The application uses Auth0 for user authentication and role-based authorization. Users can log in with their credentials, and access to certain features is based on their assigned role.

## Project Structure
The repository consists of the following projects:

- ContactDatabase.API.Client: The Blazor WebAssembly client application.
- ContactDatabase.API.Server: The ASP.NET Core server application.
- ContactDatabase.API.Shared: Shared models and utilities used by both client and server.

## Dependencies
The project relies on the following technologies:

- ASP.NET Core
- Blazor WebAssembly
- Entity Framework Core
- EdgeDB.Net.Driver
- Auth0 for authentication

## Contributing
If you find any issues or want to enhance the project, feel free to submit a pull request.
