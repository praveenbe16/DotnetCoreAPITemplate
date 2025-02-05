# **DotnetCoreAPITemplate**

A starter template for building robust .NET microservices with the following features:

- **Swagger**: Integrated API documentation and testing interface.
- **Serilog**: Logging to console and files.
- **Policy-Based Authorization**: Role-based and policy-based security.
- **Middleware**: Custom exception handling middleware.
- **Layered Architecture**: Separation of concerns with controllers, services, repositories, and data factory.
- **Request/Response DTOs**: Clean data handling between layers.

---

## **Folder Structure**

### **1. DotnetCoreAPITemplate.API**
- **Description**: The main entry point for the microservice, containing controllers, middleware, and configuration files.
- **Key Files**:
  - **`Program.cs`**: Configures the application pipeline with middleware, Serilog, Swagger, and authentication.
  - **`Controllers/`**: Houses API controllers that handle HTTP requests.
    - Example: `WeatherController.cs` for CRUD operations.
  - **`Middlewares/`**: Contains custom middleware.
    - Example: `ExceptionHandlingMiddleware.cs` for global exception handling.
  - **`Properties/launchSettings.json`**: Configures launch profiles for debugging.

### **2. DotnetCoreAPITemplate.Application**
- **Description**: Contains business logic and interfaces for services.
- **Subfolders**:
  - **`Interfaces/`**: Defines interfaces for services.
    - Example: `IWeatherService.cs`.
  - **`Services/`**: Implements business logic.
    - Example: `WeatherService.cs`.

### **3. DotnetCoreAPITemplate.Infrastructure**
- **Description**: Manages data access and repositories.
- **Subfolders**:
  - **`Repositories/`**: Implements database access logic.
    - Example: `WeatherRepository.cs`.
  - **`DataFactory/`**: Handles database connection creation.
    - Example: `SqlConnectionFactory.cs`.

### **4. DotnetCoreAPITemplate.Domain**
- **Description**: Represents the domain layer with models and DTOs.
- **Subfolders**:
  - **`Models/`**: Defines domain entities.
    - Example: `Weather.cs`.
  - **`DTOs/`**: Contains request and response DTOs for API communication.
    - Example: `WeatherRequestDTO.cs`, `WeatherResponseDTO.cs`.

### **5. DotnetCoreAPITemplate.Common**
- **Description**: Contains shared utilities, constants, and event handlers.
- **Subfolders**:
  - **`Constants/`**: Holds reusable constants.
    - Example: `ErrorMessages.cs`.
  - **`Utilities/`**: Helper methods for common operations.
    - Example: `JwtHelper.cs`.

### **6. DotnetCoreAPITemplate.Tests**
- **Description**: Unit tests for the microservice.
- **Subfolders**:
  - **`TestHelpers/`**: Contains reusable mocks and helpers for testing.
    - Example: `MockWeatherService.cs`.
  - **`UnitTests/`**: Unit test cases for services and controllers.
    - Example: `WeatherServiceTests.cs`.

---

## **Key Features**

### **Swagger Integration**
- API documentation is accessible at `/swagger`.
- Includes Bearer token authentication for testing secure endpoints.
- Configuration:
  - **`Program.cs`**:
    ```csharp
    builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer' [space] and then your valid token."
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                new List<string>()
            }
        });
    });
    ```

---

### **Policy-Based Authorization**
- Defines role-based or custom policies for secure endpoints.
- Example Policy:
  ```csharp
  builder.Services.AddAuthorization(options =>
  {
      options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
  });
  ```
- Usage:
  - Annotate controllers or actions with `[Authorize(Policy = "AdminOnly")]`.

---

### **Middleware**
- **ExceptionHandlingMiddleware**: Handles unhandled exceptions globally.
- Example Code:
  ```csharp
  public class ExceptionHandlingMiddleware
  {
      private readonly RequestDelegate _next;

      public ExceptionHandlingMiddleware(RequestDelegate next)
      {
          _next = next;
      }

      public async Task Invoke(HttpContext context)
      {
          try
          {
              await _next(context);
          }
          catch (Exception ex)
          {
              context.Response.StatusCode = 500;
              await context.Response.WriteAsJsonAsync(new { Error = ex.Message });
          }
      }
  }
  ```

---

### **Serilog**
- Logs to both the console and a rolling log file.
- Configuration in `appsettings.json`:
  ```json
  "Serilog": {
      "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
      "WriteTo": [
          { "Name": "Console" },
          { "Name": "File", "Args": { "path": "logs/log-.txt", "rollingInterval": "Day" } }
      ]
  }
  ```
- Enabled in `Program.cs` with:
  ```csharp
  builder.Host.UseSerilog((context, configuration) =>
      configuration.ReadFrom.Configuration(context.Configuration));
  ```

---

## **Using as a Template**

### **1. Install the Template**
- Clone the repository or download the ZIP file.
- Navigate to the folder and run:
  ```bash
  dotnet new --install .
  ```

### **2. Create a New Project**
- Use the template with:
  ```bash
  dotnet new DotnetCoreAPITemplate -n YourProjectName
  ```

---

## **Development and Testing**

### **Run the Application**
```bash
dotnet run --project DotnetCoreAPITemplate.API
```

### **Run Tests**
```bash
dotnet test
```

---

## **Contributing**
Feel free to submit pull requests or suggest features to improve this template.
