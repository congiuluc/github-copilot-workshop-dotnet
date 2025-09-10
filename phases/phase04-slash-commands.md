# ⚙️ Phase 04: Slash Commands - Quick Actions and Templates
**🎯 GitHub Copilot Feature**: Predefined commands for rapid development patterns

[![⬅️ Back to Workshop Home](https://img.shields.io/badge/⬅️-Back%20to%20Workshop%20Home-blue?style=flat-square)](../README.md) [![⬅️ Previous: Phase 03](https://img.shields.io/badge/⬅️-Previous%3A%20Phase%2003-lightgrey?style=flat-square)](phase03-inline-chat.md)


## 🎯 Objective

Master GitHub Copilot's slash commands to rapidly generate service layers and interfaces using predefined templates and quick actions. Learn to leverage built-in commands for common development patterns.

## 📖 About Slash Commands

GitHub Copilot's slash commands provide instant access to common patterns:
- **`/explain`** - Understand code and architecture
- **`/fix`** - Resolve issues and bugs
- **`/tests`** - Generate comprehensive test suites
- **`/new`** - Create new files and components
- **`/doc`** - Generate documentation
- **Template generation** - Quick scaffolding for common patterns

## 🛠️ What You'll Generate

In this phase, you'll create:
- ✅ Service layer interfaces and implementations
- ✅ Repository pattern with generic base
- ✅ Data Transfer Objects (DTOs)
- ✅ Controller templates with full CRUD
- ✅ Middleware components
- ✅ Configuration classes

## 📋 Step-by-Step Instructions

### Step 1: Generate Service Interface with `/new` 🆕

**Create the service interface using specific steps:**

1. **Open VS Code in your workshop project**
2. **Create the Services folder:**
   - Right-click on the project root
   - Select "New Folder"
   - Name it `Services`

3. **Open GitHub Copilot Chat:**
   - Press `Ctrl+Shift+I` (Windows) or `Cmd+Shift+I` (Mac)
   - OR click the Copilot Chat icon in the Activity Bar

4. **Create new interface file:**
   - In Copilot Chat, type exactly:
   ```
   /new
   Create a new file: Services/ITaskService.cs
   
   Generate ITaskService interface for task management with these exact methods:
   - Task<PagedResult<TaskDto>> GetAllAsync(TaskFilter filter, PaginationOptions pagination)
   - Task<TaskDto?> GetByIdAsync(int id)
   - Task<TaskDto> CreateAsync(CreateTaskDto createTaskDto)
   - Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto updateTaskDto)
   - Task<bool> DeleteAsync(int id, bool softDelete = true)
   - Task<PagedResult<TaskDto>> SearchAsync(string searchTerm, TaskFilter filter, PaginationOptions pagination)
   
   Include proper XML documentation comments for each method.
   ```

5. **Accept the generated code:**
   - Click "Accept" in the Copilot Chat response
   - OR copy the code and create the file manually:
     - Right-click `Services` folder → "New File"
     - Name it `ITaskService.cs`
     - Paste the generated code

**Expected Output:**
```csharp
using TaskManagementAPI.Models;
using TaskManagementAPI.DTOs;

namespace TaskManagementAPI.Services;

/// <summary>
/// Interface for task management operations
/// </summary>
public interface ITaskService
{
    Task<PagedResult<TaskDto>> GetAllAsync(TaskFilter filter, PaginationOptions pagination);
    Task<TaskDto?> GetByIdAsync(int id);
    Task<TaskDto> CreateAsync(CreateTaskDto createTaskDto);
    Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto updateTaskDto);
    Task<bool> DeleteAsync(int id, bool softDelete = true);
    Task<PagedResult<TaskDto>> SearchAsync(string searchTerm, TaskFilter filter, PaginationOptions pagination);
}
```

### Step 2: Generate Service Implementation with Templates ⚡

**Create the concrete service implementation:**

1. **Create new file for implementation:**
   - In Copilot Chat, type exactly:
   ```
   /new
   Create a new file: Services/TaskService.cs
   
   Generate TaskService class that implements ITaskService with:
   - Constructor dependency injection for IRepository<TaskItem>, IMapper, ILogger<TaskService>, IMemoryCache
   - Implement all ITaskService methods
   - Add comprehensive error handling with try-catch blocks
   - Include logging statements for each operation
   - Use AutoMapper for entity-to-DTO mapping
   - Implement caching for GetByIdAsync method
   - Add input validation for all parameters
   - Follow async/await best practices
   ```

2. **Review and accept the generated implementation:**
   - Check that all interface methods are implemented
   - Verify dependency injection is properly configured
   - Ensure error handling is comprehensive

3. **If dependencies are missing, create them:**
   - Open Copilot Chat and type:
   ```
   /new
   Create missing dependency files:
   - Models/PagedResult.cs - Generic paged result class
   - Models/TaskFilter.cs - Task filtering options
   - Models/PaginationOptions.cs - Pagination parameters
   - DTOs/TaskDto.cs - Task data transfer object
   - DTOs/CreateTaskDto.cs - Task creation DTO
   - DTOs/UpdateTaskDto.cs - Task update DTO
   ```

### Step 3: Generate Repository Pattern with `/new` 🗄️

**Create the repository layer step-by-step:**

1. **Create Repositories folder:**
   - Right-click project root → "New Folder" → Name it `Repositories`

2. **Generate generic repository interface:**
   - In Copilot Chat, type exactly:
   ```
   /new
   Create file: Repositories/IRepository.cs
   
   Generate generic repository interface with these exact methods:
   - Task<T?> GetByIdAsync(int id)
   - Task<IEnumerable<T>> GetAllAsync()
   - Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
   - Task<T> AddAsync(T entity)
   - Task<T> UpdateAsync(T entity)
   - Task DeleteAsync(int id)
   - Task<bool> ExistsAsync(int id)
   - Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
   
   Include where T : class constraint and proper using statements.
   ```

3. **Generate task-specific repository interface:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Repositories/ITaskRepository.cs
   
   Generate ITaskRepository interface that inherits from IRepository<TaskItem> with additional methods:
   - Task<IEnumerable<TaskItem>> GetByUserIdAsync(string userId)
   - Task<IEnumerable<TaskItem>> GetByStatusAsync(TaskStatus status)
   - Task<IEnumerable<TaskItem>> SearchAsync(string searchTerm)
   - Task<IEnumerable<TaskItem>> GetOverdueTasksAsync()
   ```

4. **Generate repository implementation:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Repositories/TaskRepository.cs
   
   Generate TaskRepository class that implements ITaskRepository using Entity Framework:
   - Constructor with ApplicationDbContext dependency
   - Implement all interface methods using Entity Framework
   - Use proper async/await patterns
   - Include comprehensive error handling
   - Add logging for database operations
   ```

**Expected Repository Interface:**
```csharp
using System.Linq.Expressions;

namespace TaskManagementAPI.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
}
```

### Step 4: Generate DTOs with `/new` 📄

**Create Data Transfer Objects with validation:**

1. **Create DTOs folder:**
   - Right-click project root → "New Folder" → Name it `DTOs`

2. **Generate TaskDto for read operations:**
   - In Copilot Chat, type exactly:
   ```
   /new
   Create file: DTOs/TaskDto.cs
   
   Generate TaskDto class with these exact properties:
   - int Id
   - string Title
   - string? Description
   - TaskStatus Status
   - TaskPriority Priority
   - DateTime CreatedAt
   - DateTime? UpdatedAt
   - DateTime? DueDate
   - string? AssigneeId
   - string? AssigneeName
   - bool IsCompleted
   - string? Category
   
   Include proper nullable annotations and XML documentation.
   ```

3. **Generate CreateTaskDto:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: DTOs/CreateTaskDto.cs
   
   Generate CreateTaskDto with validation attributes:
   - [Required] string Title
   - string? Description
   - [Required] TaskStatus Status
   - [Required] TaskPriority Priority
   - DateTime? DueDate
   - string? AssigneeId
   - string? Category
   
   Include DataAnnotations validation attributes and proper error messages.
   ```

4. **Generate UpdateTaskDto:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: DTOs/UpdateTaskDto.cs
   
   Generate UpdateTaskDto with optional properties for partial updates:
   - string? Title
   - string? Description
   - TaskStatus? Status
   - TaskPriority? Priority
   - DateTime? DueDate
   - string? AssigneeId
   - bool? IsCompleted
   - string? Category
   
   Include validation attributes where appropriate.
   ```

5. **Generate TaskSummaryDto for list views:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: DTOs/TaskSummaryDto.cs
   
   Generate lightweight TaskSummaryDto for list displays:
   - int Id
   - string Title
   - TaskStatus Status
   - TaskPriority Priority
   - DateTime? DueDate
   - bool IsCompleted
   - string? AssigneeName
   ```

### Step 5: Use `/tests` for Service Testing 🧪

**Generate comprehensive test suite:**

1. **Create test project structure:**
   - In VS Code terminal (`Ctrl+` ` or View → Terminal), run:
   ```bash
   dotnet new xunit -n TaskManagementAPI.Tests
   cd TaskManagementAPI.Tests
   dotnet add reference ../TaskManagementAPI/TaskManagementAPI.csproj
   dotnet add package Moq
   dotnet add package FluentAssertions
   dotnet add package Microsoft.Extensions.Logging.Abstractions
   ```

2. **Generate service tests:**
   - Open Copilot Chat and type exactly:
   ```
   /tests
   Create file: TaskManagementAPI.Tests/Services/TaskServiceTests.cs
   
   Generate comprehensive unit tests for TaskService with these test scenarios:
   
   GetAllAsync tests:
   - Should return paged results when valid parameters provided
   - Should apply filter correctly
   - Should handle empty results
   - Should throw exception when invalid pagination
   
   GetByIdAsync tests:
   - Should return task when valid id provided
   - Should return null when task not found
   - Should throw exception when invalid id
   
   CreateAsync tests:
   - Should create task successfully with valid data
   - Should throw validation exception with invalid data
   - Should set created date automatically
   
   UpdateAsync tests:
   - Should update task successfully when exists
   - Should return null when task not found
   - Should handle concurrent updates
   
   DeleteAsync tests:
   - Should soft delete by default
   - Should hard delete when specified
   - Should return false when task not found
   
   Use Moq for mocking dependencies and FluentAssertions for assertions.
   ```

3. **Generate repository tests:**
   - In Copilot Chat, type:
   ```
   /tests
   Create file: TaskManagementAPI.Tests/Repositories/TaskRepositoryTests.cs
   
   Generate integration tests for TaskRepository using InMemory database:
   - Test all CRUD operations
   - Test query methods with actual data
   - Test error scenarios
   - Include setup and teardown methods
   ```

4. **Run tests to verify:**
   - In terminal, run:
   ```bash
   dotnet test
   ```

### Step 6: Generate Controller with `/new` 🎮

**Create REST API controller:**

1. **Create Controllers folder if not exists:**
   - Right-click project root → "New Folder" → Name it `Controllers`

2. **Generate TaskController:**
   - In Copilot Chat, type exactly:
   ```
   /new
   Create file: Controllers/TaskController.cs
   
   Generate TaskController class with these exact endpoints:
   - [HttpGet] GetTasks with optional filter and pagination query parameters
   - [HttpGet("{id}")] GetTask(int id)
   - [HttpPost] CreateTask([FromBody] CreateTaskDto dto)
   - [HttpPut("{id}")] UpdateTask(int id, [FromBody] UpdateTaskDto dto)
   - [HttpDelete("{id}")] DeleteTask(int id, [FromQuery] bool hardDelete = false)
   - [HttpGet("search")] SearchTasks([FromQuery] string term, query parameters)
   
   Include:
   - [ApiController] and [Route("api/[controller]")] attributes
   - Proper HTTP status codes (200, 201, 404, 400, 500)
   - OpenAPI/Swagger documentation attributes
   - Constructor dependency injection for ITaskService and ILogger
   - Comprehensive error handling with try-catch blocks
   - Input validation with ModelState.IsValid
   ```

3. **Add authentication and authorization:**
   - Select the generated controller code
   - In Copilot Chat, type:
   ```
   /fix
   Add authentication and authorization to this controller:
   - Add [Authorize] attribute to class
   - Add specific role-based authorization where needed
   - Include user context extraction from claims
   - Add proper error responses for unauthorized access
   ```

4. **Test the controller:**
   - Build the project: `dotnet build`
   - Run the project: `dotnet run`
   - Open browser to `https://localhost:5001/swagger` to view API documentation

### Step 7: Use `/explain` for Architecture Review 🔍

**Analyze the generated architecture:**

1. **Select all service layer files:**
   - Hold `Ctrl` and click to select multiple files:
     - `Services/ITaskService.cs`
     - `Services/TaskService.cs`
     - `Repositories/IRepository.cs`
     - `Repositories/TaskRepository.cs`

2. **Open Copilot Chat and analyze:**
   - Type exactly:
   ```
   /explain
   Analyze the service layer architecture we've created:
   
   1. How do the interfaces (ITaskService, IRepository) promote testability and maintainability?
   2. What are the specific benefits of using the repository pattern in this implementation?
   3. How does the DTO pattern improve API design and security?
   4. What are the performance implications of our async/await usage?
   5. How does this architecture support SOLID principles?
   6. What dependency injection patterns are we using?
   7. How does this design enable future scalability?
   ```

3. **Review dependency injection setup:**
   - Open `Program.cs` file
   - In Copilot Chat, type:
   ```
   /explain
   Review this Program.cs configuration:
   - Are all our services properly registered?
   - What's the lifetime scope of each registration?
   - Are there any missing dependencies?
   - How can we improve the DI configuration?
   ```

4. **Analyze code quality:**
   - Select the `TaskService.cs` file
   - In Copilot Chat, type:
   ```
   /explain
   Analyze this service implementation for:
   - Code complexity and readability
   - Error handling completeness
   - Performance optimization opportunities
   - Security considerations
   - Best practice adherence
   ```

### Step 8: Generate Middleware with `/new` 🔧

**Create custom middleware components:**

1. **Create Middleware folder:**
   - Right-click project root → "New Folder" → Name it `Middleware`

2. **Generate error handling middleware:**
   - In Copilot Chat, type exactly:
   ```
   /new
   Create file: Middleware/ErrorHandlingMiddleware.cs
   
   Generate ErrorHandlingMiddleware class that:
   - Implements global exception handling
   - Returns standardized error responses
   - Logs exceptions with proper details
   - Handles different exception types (ValidationException, NotFoundException, etc.)
   - Returns appropriate HTTP status codes
   - Includes request correlation ID for tracking
   ```

3. **Generate request logging middleware:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Middleware/RequestLoggingMiddleware.cs
   
   Generate RequestLoggingMiddleware that:
   - Logs incoming requests with method, path, headers
   - Logs response status and duration
   - Includes correlation ID in all logs
   - Excludes sensitive data from logging
   - Measures request execution time
   ```

4. **Generate rate limiting middleware:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Middleware/RateLimitingMiddleware.cs
   
   Generate RateLimitingMiddleware that:
   - Implements IP-based rate limiting
   - Configurable limits per endpoint
   - Returns 429 Too Many Requests when exceeded
   - Uses in-memory cache for rate tracking
   - Includes proper headers in response
   ```

5. **Register middleware in Program.cs:**
   - Open `Program.cs`
   - In Copilot Chat, type:
   ```
   /fix
   Add middleware registration to Program.cs in correct order:
   - Add ErrorHandlingMiddleware first
   - Add RequestLoggingMiddleware second  
   - Add RateLimitingMiddleware third
   - Ensure proper order for middleware pipeline
   ```

### Step 9: Use `/fix` for Code Optimization 🛠️

**Optimize the generated code systematically:**

1. **Optimize service performance:**
   - Open `Services/TaskService.cs`
   - Select the `GetAllAsync` method
   - In Copilot Chat, type exactly:
   ```
   /fix
   Optimize this GetAllAsync method for performance:
   - Add query optimization for Entity Framework
   - Implement proper pagination with Skip/Take
   - Add caching strategy for frequently accessed data
   - Optimize database queries to reduce N+1 problems
   - Add async enumerable support for large datasets
   ```

2. **Fix memory usage issues:**
   - Select the repository implementation
   - In Copilot Chat, type:
   ```
   /fix
   Optimize memory usage in this repository:
   - Use AsNoTracking() for read-only queries
   - Implement proper disposal patterns
   - Fix potential memory leaks
   - Optimize query projections to load only needed data
   - Add connection string optimization
   ```

3. **Improve async/await patterns:**
   - Select all async methods in the controller
   - In Copilot Chat, type:
   ```
   /fix
   Review and fix async/await patterns:
   - Ensure ConfigureAwait(false) is used appropriately
   - Fix any sync-over-async patterns
   - Optimize task composition
   - Remove unnecessary async/await keywords
   - Add proper cancellation token support
   ```

4. **Enhance error handling:**
   - Select the middleware files
   - In Copilot Chat, type:
   ```
   /fix
   Improve error handling in middleware:
   - Add specific exception types for better error messages
   - Implement proper logging with structured data
   - Add retry logic for transient failures
   - Improve error response format consistency
   - Add error correlation for debugging
   ```

5. **Validate all fixes:**
   - Build the project: `dotnet build`
   - Run tests: `dotnet test`
   - Check for any compilation errors or warnings

### Step 10: Generate Configuration Classes with `/new` ⚙️

**Create strongly-typed configuration classes:**

1. **Create Configuration folder:**
   - Right-click project root → "New Folder" → Name it `Configuration`

2. **Generate database configuration:**
   - In Copilot Chat, type exactly:
   ```
   /new
   Create file: Configuration/DatabaseOptions.cs
   
   Generate DatabaseOptions class with:
   - string ConnectionString property
   - int CommandTimeout property (default 30)
   - bool EnableRetryOnFailure property (default true)
   - int MaxRetryCount property (default 3)
   - TimeSpan MaxRetryDelay property
   - IConfigurationSection binding support
   ```

3. **Generate caching configuration:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Configuration/CacheOptions.cs
   
   Generate CacheOptions with:
   - TimeSpan DefaultExpiration
   - string RedisConnectionString  
   - bool UseDistributedCache
   - Dictionary<string, TimeSpan> SpecificExpirations
   - int MaxCacheSize
   ```

4. **Generate API configuration:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Configuration/ApiOptions.cs
   
   Generate ApiOptions with:
   - string ApiVersion
   - string ApiTitle
   - string ApiDescription
   - bool EnableSwagger
   - RateLimitOptions RateLimit nested class
   - CorsOptions Cors nested class
   ```

5. **Generate authentication settings:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Configuration/AuthOptions.cs
   
   Generate AuthOptions with:
   - string JwtSecret
   - TimeSpan TokenExpiration
   - string Issuer
   - string Audience
   - bool RequireHttpsMetadata
   - bool ValidateLifetime
   ```

6. **Register configurations in Program.cs:**
   - Open `Program.cs`
   - In Copilot Chat, type:
   ```
   /fix
   Add configuration binding to Program.cs:
   - Bind DatabaseOptions from "Database" section
   - Bind CacheOptions from "Cache" section  
   - Bind ApiOptions from "Api" section
   - Bind AuthOptions from "Authentication" section
   - Add validation for required configuration values
   ```

7. **Create appsettings.json sections:**
   - Open `appsettings.json`
   - In Copilot Chat, type:
   ```
   /new
   Add configuration sections to appsettings.json for all the option classes we created:
   - Database section with connection string and timeouts
   - Cache section with expiration settings
   - Api section with version and limits
   - Authentication section with JWT settings
   ```

### Step 11: Use `/doc` for Documentation 📚

**Generate comprehensive project documentation:**

1. **Generate API documentation:**
   - Select all controller files
   - In Copilot Chat, type exactly:
   ```
   /doc
   Generate comprehensive API documentation including:
   - OpenAPI/Swagger descriptions for all endpoints
   - Request/response examples for each operation
   - Error code documentation with scenarios
   - Authentication requirements
   - Rate limiting information
   - API versioning strategy
   
   Create this as: Documentation/API.md
   ```

2. **Generate architecture documentation:**
   - Select service and repository files
   - In Copilot Chat, type:
   ```
   /doc
   Create architecture documentation explaining:
   - Overall system architecture with layers
   - Service layer responsibilities and patterns
   - Repository pattern implementation
   - Dependency injection configuration
   - Data flow between layers
   - Design patterns used (Repository, DTO, etc.)
   
   Create this as: Documentation/Architecture.md
   ```

3. **Generate setup and deployment guide:**
   - In Copilot Chat, type:
   ```
   /doc
   Create developer setup guide with:
   - Prerequisites (.NET 8, VS Code, etc.)
   - Step-by-step project setup instructions
   - Database setup and migration commands
   - Environment configuration
   - How to run the application
   - How to run tests
   - Common troubleshooting issues
   
   Create this as: Documentation/Setup.md
   ```

4. **Generate configuration documentation:**
   - Select all configuration files
   - In Copilot Chat, type:
   ```
   /doc
   Document all configuration options:
   - Explain each configuration section
   - Provide example values
   - Document environment-specific settings
   - Explain security considerations
   - Document default values and valid ranges
   
   Create this as: Documentation/Configuration.md
   ```

5. **Update main README.md:**
   - Open the root `README.md` file
   - In Copilot Chat, type:
   ```
   /doc
   Update README.md with:
   - Project overview and purpose
   - Quick start instructions
   - API endpoint summary
   - Technology stack used
   - Links to detailed documentation
   - Contributing guidelines
   - License information
   ```

### Step 12: Advanced Slash Command Combinations 🚀

**Create a complete feature module using command sequences:**

1. **Plan the Category feature:**
   - In Copilot Chat, type exactly:
   ```
   /explain
   Plan a complete "Task Categories" feature module that needs:
   - Category model with validation
   - ICategoryService interface  
   - CategoryService implementation
   - CategoryController with CRUD operations
   - Category DTOs and mappings
   - Unit tests for all components
   - Integration tests
   - API documentation
   
   What's the best order to create these components?
   ```

2. **Create the model first:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Models/Category.cs
   
   Generate Category entity with:
   - int Id (primary key)
   - string Name (required, max 100 chars)
   - string? Description (optional, max 500 chars)
   - string Color (hex color code)
   - bool IsActive (default true)
   - DateTime CreatedAt
   - DateTime UpdatedAt
   - List<TaskItem> Tasks navigation property
   
   Include validation attributes and Entity Framework configuration.
   ```

3. **Create service interface:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Services/ICategoryService.cs
   
   Generate ICategoryService interface with methods:
   - Task<List<CategoryDto>> GetAllAsync()
   - Task<CategoryDto?> GetByIdAsync(int id)
   - Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
   - Task<CategoryDto?> UpdateAsync(int id, UpdateCategoryDto dto)
   - Task<bool> DeleteAsync(int id)
   - Task<List<CategoryDto>> GetActiveAsync()
   - Task<bool> IsNameUniqueAsync(string name, int? excludeId = null)
   ```

4. **Create DTOs:**
   - In Copilot Chat, type:
   ```
   /new
   Create Category DTOs in DTOs folder:
   - CategoryDto for read operations
   - CreateCategoryDto with validation
   - UpdateCategoryDto for updates
   Include proper validation attributes and documentation.
   ```

5. **Generate service implementation:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Services/CategoryService.cs
   
   Generate CategoryService implementing ICategoryService with:
   - Repository pattern usage
   - AutoMapper for entity-DTO mapping
   - Comprehensive error handling
   - Logging for all operations
   - Business logic validation
   - Async/await best practices
   ```

6. **Create controller:**
   - In Copilot Chat, type:
   ```
   /new
   Create file: Controllers/CategoryController.cs
   
   Generate REST API controller with:
   - All CRUD endpoints
   - Proper HTTP status codes
   - OpenAPI documentation
   - Input validation
   - Error handling
   - Authentication requirements
   ```

7. **Generate comprehensive tests:**
   - In Copilot Chat, type:
   ```
   /tests
   Create complete test suite for Category feature:
   - Unit tests for CategoryService (file: Tests/Services/CategoryServiceTests.cs)
   - Integration tests for CategoryController (file: Tests/Controllers/CategoryControllerTests.cs)
   - Repository tests (file: Tests/Repositories/CategoryRepositoryTests.cs)
   
   Include all CRUD scenarios, edge cases, and error conditions.
   ```

8. **Generate documentation:**
   - In Copilot Chat, type:
   ```
   /doc
   Create documentation for Category feature:
   - API endpoint documentation
   - Business rules and validation
   - Usage examples
   - Error scenarios
   
   Add to Documentation/CategoryAPI.md
   ```

9. **Verify the complete feature:**
   - Build the project: `dotnet build`
   - Run tests: `dotnet test`
   - Start the application: `dotnet run`
   - Test endpoints in Swagger UI

## 🎯 Practical Slash Command Patterns

### Pattern 1: Complete Feature Generation
```
/new → Create interfaces and models
/new → Create implementations
/tests → Generate test suite
/doc → Create documentation
/explain → Review architecture
```

### Pattern 2: Problem-Solving Workflow
```
/explain → Understand current code
/fix → Address identified issues
/tests → Verify fixes work
/doc → Update documentation
```

### Pattern 3: Performance Optimization
```
/explain → Analyze performance bottlenecks
/fix → Optimize problematic code
/tests → Create performance tests
/doc → Document optimization strategies
```

## ✅ Phase 4 Verification

**Follow these steps to verify your generated components:**

1. **Build verification:**
   - Open VS Code terminal (`Ctrl+` ` or View → Terminal)
   - Run the build command:
   ```bash
   dotnet build
   ```
   - ✅ Verify: No compilation errors
   - ✅ Verify: All dependencies resolved

2. **Test execution:**
   - Navigate to test project:
   ```bash
   cd TaskManagementAPI.Tests
   ```
   - Run all tests:
   ```bash
   dotnet test --verbosity normal
   ```
   - ✅ Verify: All tests pass
   - ✅ Verify: Test coverage is comprehensive

3. **Project structure verification:**
   - Check your project has these folders and files:
   ```
   TaskManagementAPI/
   ├── Services/
   │   ├── ITaskService.cs
   │   └── TaskService.cs
   ├── Repositories/
   │   ├── IRepository.cs
   │   ├── ITaskRepository.cs
   │   └── TaskRepository.cs
   ├── DTOs/
   │   ├── TaskDto.cs
   │   ├── CreateTaskDto.cs
   │   ├── UpdateTaskDto.cs
   │   └── TaskSummaryDto.cs
   ├── Controllers/
   │   ├── TaskController.cs
   │   └── CategoryController.cs
   ├── Middleware/
   │   ├── ErrorHandlingMiddleware.cs
   │   ├── RequestLoggingMiddleware.cs
   │   └── RateLimitingMiddleware.cs
   ├── Configuration/
   │   ├── DatabaseOptions.cs
   │   ├── CacheOptions.cs
   │   ├── ApiOptions.cs
   │   └── AuthOptions.cs
   └── Documentation/
       ├── API.md
       ├── Architecture.md
       ├── Setup.md
       └── Configuration.md
   ```

4. **Code analysis verification:**
   - Open each generated file and verify:
   - ✅ All interfaces properly implemented
   - ✅ Services follow SOLID principles
   - ✅ DTOs include proper validation attributes
   - ✅ Controllers have appropriate HTTP methods and status codes
   - ✅ Middleware is properly configured
   - ✅ Configuration classes are strongly typed

5. **Functionality verification:**
   - Start the application:
   ```bash
   dotnet run
   ```
   - Open browser to `https://localhost:5001/swagger`
   - ✅ Verify: Swagger UI loads successfully
   - ✅ Verify: All API endpoints are documented
   - ✅ Verify: Test endpoints return expected responses

6. **Documentation verification:**
   - Check Documentation folder exists with all files
   - ✅ Verify: API.md contains endpoint documentation
   - ✅ Verify: Architecture.md explains system design
   - ✅ Verify: Setup.md has clear instructions
   - ✅ Verify: Configuration.md documents all options

## 🎉 What You've Learned

In this phase, you mastered:

- ✅ **Slash command efficiency** for rapid code generation
- ✅ **Service layer architecture** with interfaces and implementations
- ✅ **Repository pattern** for data access abstraction
- ✅ **DTO pattern** for clean API contracts
- ✅ **Template-driven development** for consistent code structure
- ✅ **Testing automation** with generated test suites

## 🧠 Key Slash Commands Reference

| Command | Purpose | Example Usage |
|---------|---------|---------------|
| `/new` | Create new components | `/new` Create service interface |
| `/explain` | Understand code | `/explain` How does this work? |
| `/fix` | Resolve issues | `/fix` Optimize this method |
| `/tests` | Generate tests | `/tests` Create unit tests |
| `/doc` | Create documentation | `/doc` Document this API |

## 💡 Slash Command Best Practices

1. **Be specific** in your slash command prompts
2. **Use context** - select relevant code before commands
3. **Chain commands** for complex workflows
4. **Verify output** - always review generated code
5. **Iterate quickly** - use commands for rapid prototyping

## 🔄 Common Command Workflows

### New Feature Workflow:
```
1. /new → Create models and interfaces
2. /new → Generate implementations
3. /tests → Add test coverage
4. /doc → Document the feature
5. /explain → Review architecture
```

### Debugging Workflow:
```
1. /explain → Understand the issue
2. /fix → Apply corrections
3. /tests → Verify the fix
4. /doc → Update documentation
```

### Code Review Workflow:
```
1. /explain → Analyze current code
2. /fix → Suggest improvements
3. /tests → Ensure quality
4. /doc → Update docs
```

**💡 Pro Tip**: Slash commands are your shortcuts to productivity! Each command is designed for specific tasks, so explore them all to find the ones that fit your workflow best.

## 🎯 Next Phase

Ready to get AI-powered code reviews? In [Phase 05: Code Review](./phase05-code-review.md), you'll learn to leverage intelligent code analysis and feedback for better code quality! 🔍

---

**🏆 Command Master!** You've learned to use slash commands for rapid, template-driven development. These commands dramatically speed up common development tasks! ⚙️

[![➡️ Next: Phase 05 - Code Review](https://img.shields.io/badge/➡️-Next%3A%20Phase%2005%20Code%20Review-green?style=flat-square)](phase05-code-review.md)

