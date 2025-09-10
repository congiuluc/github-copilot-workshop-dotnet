# 🧪 Phase 09: Advanced Testing - Comprehensive Test Suite
**🎯 GitHub Copilot Feature**: Intelligent test generation and quality assurance automation

[![⬅️ Back to Workshop Home](https://img.shields.io/badge/⬅️-Back%20to%20Workshop%20Home-blue?style=flat-square)](../README.md) [![⬅️ Previous: Phase 08](https://img.shields.io/badge/⬅️-Previous%3A%20Phase%2008-lightgrey?style=flat-square)](phase08-ai-commit-messages.md)


## 🎯 Objective

Master GitHub Copilot's test generation and optimization capabilities to create comprehensive test suites. Learn to generate unit tests, integration tests, performance tests, and end-to-end tests with intelligent AI assistance.

## 📖 About Advanced Testing with Copilot

GitHub Copilot's testing capabilities provide:
- **Intelligent test generation** - Automatic test case creation from code
- **Test pattern recognition** - Learning from existing test patterns
- **Edge case identification** - Discovering boundary conditions and error scenarios
- **Mock generation** - Creating test doubles and stubs
- **Test data builders** - Generating realistic test data
- **Performance test creation** - Load and stress testing scenarios
- **Test optimization** - Improving test speed and reliability

## 🛠️ What You'll Implement

In this phase, you'll build:
- ✅ Comprehensive unit test suite with xUnit
- ✅ Integration tests with TestServer
- ✅ Performance and load testing
- ✅ End-to-end API testing
- ✅ Test data builders and factories
- ✅ Advanced mocking strategies
- ✅ Test coverage analysis and optimization

## 📋 Step-by-Step Instructions

### Step 1: Set Up Testing Infrastructure 🏗️

**Create comprehensive test project with exact steps:**

1. **Create test project structure:**
   - Open VS Code terminal (`Ctrl+` ` or View → Terminal)
   - Navigate to your workspace directory:
   ```bash
   cd "d:\Customers\customer\workshop_dotnet"
   ```
   - Create test project:
   ```bash
   dotnet new xunit -n TaskManagementAPI.Tests --framework net8.0
   ```
   - Navigate to test directory:
   ```bash
   cd TaskManagementAPI.Tests
   ```

2. **Add project reference and testing packages:**
   - Add reference to main project:
   ```bash
   dotnet add reference ../TaskManagementAPI/TaskManagementAPI.csproj
   ```
   - Install essential testing packages:
   ```bash
   dotnet add package Microsoft.AspNetCore.Mvc.Testing
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   dotnet add package Moq
   dotnet add package FluentAssertions
   dotnet add package Bogus
   dotnet add package NBomber
   dotnet add package AutoFixture
   dotnet add package AutoFixture.Xunit2
   dotnet add package Microsoft.Extensions.Logging.Abstractions
   ```

3. **Use Copilot Chat to verify test setup:**
   - Open Copilot Chat (`Ctrl+Shift+I`)
   - Type this exact prompt:
   ```
   I just created a test project called TaskManagementAPI.Tests with xUnit. 
   
   Can you help me verify that I have all the necessary testing packages for:
   - Unit testing with xUnit, Moq, FluentAssertions
   - Integration testing with TestServer
   - Performance testing with NBomber  
   - Test data generation with Bogus and AutoFixture
   - In-memory database testing
   
### Step 2: Generate Unit Tests with Specific Copilot Prompts 🔬

**Create comprehensive unit tests using exact prompts:**

1. **Create test folder structure:**
   - In TaskManagementAPI.Tests project, create folders:
   ```
   Services/
   Controllers/
   Models/
   Utils/
   Integration/
   Performance/
   ```

2. **Generate TaskService unit tests:**
   - Create file: `Services/TaskServiceTests.cs`
   - Open Copilot Chat and use this exact prompt:
   ```
   Create comprehensive unit tests for TaskService class. I need:

   Test Class Structure:
   - Use xUnit framework with [Fact] and [Theory] attributes
   - Mock IApplicationDbContext and ILogger<TaskService> dependencies
   - Use Moq for mocking and FluentAssertions for assertions
   - Include proper test class setup and teardown

   Test Methods Required:
   1. GetAllAsync_WhenTasksExist_ReturnsAllTasks()
   2. GetAllAsync_WhenNoTasks_ReturnsEmptyList()
   3. GetByIdAsync_WhenTaskExists_ReturnsTask()
   4. GetByIdAsync_WhenTaskNotFound_ReturnsNull()
   5. CreateAsync_WithValidTask_ReturnsCreatedTask()
   6. CreateAsync_WithInvalidTask_ThrowsValidationException()
   7. UpdateAsync_WhenTaskExists_ReturnsUpdatedTask()
   8. UpdateAsync_WhenTaskNotFound_ReturnsNull()
   9. DeleteAsync_WhenTaskExists_ReturnsTrue()
   10. DeleteAsync_WhenTaskNotFound_ReturnsFalse()

   Each test should:
   - Use Arrange/Act/Assert pattern
   - Include proper mock setup
   - Test both success and failure scenarios
   - Use meaningful test data
   - Include async testing best practices

   Show me the complete test class with all methods implemented.
   ```

3. **Copy the generated test class:**
   - ✅ Review the generated tests for completeness
   - ✅ Verify all methods use proper async/await patterns
   - ✅ Check that mocks are set up correctly
   - Paste the code into `Services/TaskServiceTests.cs`

4. **Generate additional edge case tests:**
   - In the same file, use Copilot Chat with this prompt:
   ```
   Add these additional edge case tests to the TaskServiceTests class:

   Edge Cases:
   - GetByIdAsync_WithZeroId_ThrowsArgumentException()
   - GetByIdAsync_WithNegativeId_ThrowsArgumentException()
   - CreateAsync_WithNullTask_ThrowsArgumentNullException()
   - CreateAsync_WithEmptyTitle_ThrowsValidationException()
   - CreateAsync_WithTitleTooLong_ThrowsValidationException()
   - UpdateAsync_WithNullUpdateData_ThrowsArgumentNullException()
   - DeleteAsync_WithZeroId_ThrowsArgumentException()

   Database Error Scenarios:
   - GetAllAsync_WhenDatabaseThrows_LogsErrorAndRethrows()
   - CreateAsync_WhenSaveFailsWithDbException_LogsErrorAndRethrows()
   - UpdateAsync_WhenConcurrencyConflict_ThrowsConcurrencyException()

   Use [Theory] with [InlineData] for parameterized tests where appropriate.
   Include comprehensive error message validation.
   ```

```csharp
using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TaskManagement.API.Services;
using TaskManagement.API.Models;
using TaskManagement.API.DTOs;
using TaskManagement.API.Data;

public class TaskServiceTests : IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly Mock<ILogger<TaskService>> _mockLogger;
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        // Setup in-memory database for testing
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        _context = new ApplicationDbContext(options);
        _mockLogger = new Mock<ILogger<TaskService>>();
        _taskService = new TaskService(_context, _mockLogger.Object);

        // Seed test data
        SeedTestData();
    }

    [Fact]
    public async Task CreateTaskAsync_WithValidData_ShouldCreateTaskSuccessfully()
    {
        // Arrange
        var createDto = new CreateTaskDto
        {
            Title = "Test Task",
            Description = "Test Description",
            Priority = TaskPriority.High,
            DueDate = DateTime.UtcNow.AddDays(7),
            UserId = 1
        };

        // Act
        var result = await _taskService.CreateTaskAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be(createDto.Title);
        result.Description.Should().Be(createDto.Description);
        result.Priority.Should().Be(createDto.Priority);
        result.Status.Should().Be(TaskStatus.New);
        result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));

        // Verify database changes
        var taskInDb = await _context.Tasks.FindAsync(result.Id);
        taskInDb.Should().NotBeNull();
        taskInDb!.Title.Should().Be(createDto.Title);
    }

    [Theory]
    [InlineData(null, "Description")]
    [InlineData("", "Description")]
    [InlineData("   ", "Description")]
    public async Task CreateTaskAsync_WithInvalidTitle_ShouldThrowArgumentException(string invalidTitle, string description)
    {
        // Arrange
        var createDto = new CreateTaskDto
        {
            Title = invalidTitle,
            Description = description,
            Priority = TaskPriority.Medium,
            UserId = 1
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _taskService.CreateTaskAsync(createDto));
        exception.Message.Should().Contain("Title");
    }

    [Fact]
    public async Task CreateTaskAsync_WithTitleTooLong_ShouldThrowArgumentException()
    {
        // Arrange
        var createDto = new CreateTaskDto
        {
            Title = new string('A', 201), // Exceeds 200 character limit
            Description = "Test Description",
            Priority = TaskPriority.Medium,
            UserId = 1
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _taskService.CreateTaskAsync(createDto));
        exception.Message.Should().Contain("200 characters");
    }

    [Fact]
    public async Task GetByIdAsync_WithExistingId_ShouldReturnTask()
    {
        // Arrange
        var existingTask = _context.Tasks.First();

        // Act
        var result = await _taskService.GetByIdAsync(existingTask.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(existingTask.Id);
        result.Title.Should().Be(existingTask.Title);
    }

    [Fact]
    public async Task GetByIdAsync_WithNonExistentId_ShouldReturnNull()
    {
        // Arrange
        var nonExistentId = 99999;

        // Act
        var result = await _taskService.GetByIdAsync(nonExistentId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task UpdateTaskAsync_WithValidData_ShouldUpdateSuccessfully()
    {
        // Arrange
        var existingTask = _context.Tasks.First();
        var updateDto = new UpdateTaskDto
        {
            Title = "Updated Title",
            Description = "Updated Description",
            Priority = TaskPriority.Low
        };

        // Act
        var result = await _taskService.UpdateTaskAsync(existingTask.Id, updateDto);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be(updateDto.Title);
        result.Description.Should().Be(updateDto.Description);
        result.Priority.Should().Be(updateDto.Priority);
        result.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));

        // Verify database changes
        var taskInDb = await _context.Tasks.FindAsync(existingTask.Id);
        taskInDb!.Title.Should().Be(updateDto.Title);
    }

    [Fact]
    public async Task UpdateTaskAsync_WithNonExistentId_ShouldThrowNotFoundException()
    {
        // Arrange
        var nonExistentId = 99999;
        var updateDto = new UpdateTaskDto
        {
            Title = "Updated Title",
            Description = "Updated Description",
            Priority = TaskPriority.Low
        };

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _taskService.UpdateTaskAsync(nonExistentId, updateDto));
    }

    [Fact]
    public async Task DeleteTaskAsync_WithExistingId_ShouldDeleteSuccessfully()
    {
        // Arrange
        var taskToDelete = _context.Tasks.First();
        var taskId = taskToDelete.Id;

        // Act
        var result = await _taskService.DeleteTaskAsync(taskId);

        // Assert
        result.Should().BeTrue();

        // Verify deletion
        var deletedTask = await _context.Tasks.FindAsync(taskId);
        deletedTask.Should().BeNull();
    }

    [Fact]
    public async Task DeleteTaskAsync_WithNonExistentId_ShouldReturnFalse()
    {
        // Arrange
        var nonExistentId = 99999;

        // Act
        var result = await _taskService.DeleteTaskAsync(nonExistentId);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public async Task GetUserTasksAsync_WithValidUserId_ShouldReturnUserTasks()
    {
        // Arrange
        var userId = 1;

        // Act
        var result = await _taskService.GetUserTasksAsync(userId);

        // Assert
        result.Should().NotBeNull();
        result.Should().AllSatisfy(task => task.UserId.Should().Be(userId));
        result.Should().BeOrderedByDescending(task => task.CreatedAt);
    }

    [Fact]
    public async Task GetUserTasksAsync_WithInvalidUserId_ShouldThrowArgumentException()
    {
        // Arrange
        var invalidUserId = 0;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _taskService.GetUserTasksAsync(invalidUserId));
    }

    [Fact]
    public async Task MarkAsCompletedAsync_WithValidId_ShouldMarkTaskCompleted()
    {
        // Arrange
        var task = _context.Tasks.First(t => !t.IsCompleted);
        var taskId = task.Id;

        // Act
        var result = await _taskService.MarkAsCompletedAsync(taskId);

        // Assert
        result.Should().BeTrue();

        // Verify completion
        var completedTask = await _context.Tasks.FindAsync(taskId);
        completedTask!.IsCompleted.Should().BeTrue();
        completedTask.CompletedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        completedTask.Status.Should().Be(TaskStatus.Completed);
    }

    [Theory]
    [MemberData(nameof(GetTaskStatisticsTestData))]
    public async Task GetTaskStatisticsAsync_WithVariousScenarios_ShouldReturnCorrectStatistics(
        List<TaskItem> tasks, 
        int expectedTotal, 
        int expectedCompleted, 
        int expectedPending)
    {
        // Arrange
        await _context.Tasks.AddRangeAsync(tasks);
        await _context.SaveChangesAsync();

        // Act
        var result = await _taskService.GetTaskStatisticsAsync(1);

        // Assert
        result.TotalTasks.Should().Be(expectedTotal);
        result.CompletedTasks.Should().Be(expectedCompleted);
        result.PendingTasks.Should().Be(expectedPending);
    }

    public static IEnumerable<object[]> GetTaskStatisticsTestData()
    {
        yield return new object[]
        {
            new List<TaskItem>
            {
                new() { Id = 100, Title = "Task 1", UserId = 1, IsCompleted = true },
                new() { Id = 101, Title = "Task 2", UserId = 1, IsCompleted = false },
                new() { Id = 102, Title = "Task 3", UserId = 1, IsCompleted = true }
            },
            3, 2, 1
        };
    }

    private void SeedTestData()
    {
        var tasks = new List<TaskItem>
        {
            new()
            {
                Id = 1,
                Title = "Sample Task 1",
                Description = "Sample Description 1",
                Priority = TaskPriority.High,
                Status = TaskStatus.New,
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                IsCompleted = false
            },
            new()
            {
                Id = 2,
                Title = "Sample Task 2",
                Description = "Sample Description 2",
                Priority = TaskPriority.Medium,
                Status = TaskStatus.InProgress,
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                IsCompleted = false
            },
            new()
            {
                Id = 3,
                Title = "Sample Task 3",
                Description = "Sample Description 3",
                Priority = TaskPriority.Low,
                Status = TaskStatus.Completed,
                UserId = 2,
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                IsCompleted = true,
                CompletedAt = DateTime.UtcNow.AddDays(-1)
            }
        };

        _context.Tasks.AddRange(tasks);
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
```

### Step 3: Generate Integration Tests 🔗

**Create integration tests with TestServer:**

1. **Create Integration Test File:**
   - Navigate to `tests\TaskManagement.API.Tests.Integration\Controllers` folder
   - Right-click the `Controllers` folder
   - Select "New File"
   - Name it `TaskControllerIntegrationTests.cs`

2. **Open Copilot Chat and use this prompt:**
   ```
   Create comprehensive integration tests for the TaskController API endpoints with these requirements:

   Test Setup:
   - Use WebApplicationFactory<Program> for test server setup
   - Configure in-memory database for testing
   - Include authentication setup with JWT tokens
   - Seed test data for consistent testing

   API Endpoint Tests (Test all HTTP methods):
   - GET /api/tasks - Test with/without authentication, pagination
   - GET /api/tasks/{id} - Test valid/invalid IDs, authorization
   - POST /api/tasks - Test valid/invalid payloads, validation errors
   - PUT /api/tasks/{id} - Test updates, not found scenarios
   - DELETE /api/tasks/{id} - Test deletion, authorization
   - GET /api/tasks/user/{userId} - Test user-specific tasks

   Authentication Tests:
   - Unauthorized access returns 401
   - Invalid JWT token returns 401
   - Expired token handling
   - Role-based access control

   Validation Tests:
   - Required field validation (400 responses)
   - Data type validation
   - Business rule validation
   - Model binding errors

   Error Handling Tests:
   - 404 for non-existent resources
   - 500 for server errors
   - Proper error response format

   Performance Tests:
   - Response time under 200ms for simple operations
   - Bulk operations handling
   - Concurrent request handling

   Include helper methods for:
   - JWT token generation
   - Test data seeding
   - HTTP request builders
   - Response assertion helpers

   Use FluentAssertions for readable assertions.
   Include at least 15 test methods covering all scenarios.
   ```

**Complete integration test implementation:**

```csharp
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Xunit;
using FluentAssertions;
using TaskManagement.API;
using TaskManagement.API.Data;
using TaskManagement.API.DTOs;
using TaskManagement.API.Models;

public class TaskControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;

    public TaskControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Remove the real database and add in-memory database
                services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });

                // Build service provider and seed data
                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                SeedTestData(context);
            });
        });

        _client = _factory.CreateClient();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    [Fact]
    public async Task GetTasks_WithValidAuth_ShouldReturnTasks()
    {
        // Arrange
        await AuthenticateAsync();

        // Act
        var response = await _client.GetAsync("/api/tasks");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<TaskDto>>>(content, _jsonOptions);
        
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
        apiResponse.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetTasks_WithoutAuth_ShouldReturnUnauthorized()
    {
        // Act
        var response = await _client.GetAsync("/api/tasks");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task CreateTask_WithValidData_ShouldCreateTask()
    {
        // Arrange
        await AuthenticateAsync();
        var createDto = new CreateTaskDto
        {
            Title = "Integration Test Task",
            Description = "Created via integration test",
            Priority = TaskPriority.High,
            DueDate = DateTime.UtcNow.AddDays(5)
        };

        var json = JsonSerializer.Serialize(createDto, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/tasks", content);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskDto>>(responseContent, _jsonOptions);
        
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
        apiResponse.Data.Should().NotBeNull();
        apiResponse.Data!.Title.Should().Be(createDto.Title);
        
        // Verify location header
        response.Headers.Location.Should().NotBeNull();
    }

    [Theory]
    [InlineData("", "Description", "Title is required")]
    [InlineData(null, "Description", "Title is required")]
    [InlineData("Valid Title", "", "Description is required")]
    public async Task CreateTask_WithInvalidData_ShouldReturnBadRequest(
        string title, 
        string description, 
        string expectedError)
    {
        // Arrange
        await AuthenticateAsync();
        var createDto = new CreateTaskDto
        {
            Title = title,
            Description = description,
            Priority = TaskPriority.Medium
        };

        var json = JsonSerializer.Serialize(createDto, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/tasks", content);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskDto>>(responseContent, _jsonOptions);
        
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeFalse();
        apiResponse.Errors.Should().Contain(expectedError);
    }

    [Fact]
    public async Task UpdateTask_WithValidData_ShouldUpdateTask()
    {
        // Arrange
        await AuthenticateAsync();
        var taskId = 1; // From seeded data
        var updateDto = new UpdateTaskDto
        {
            Title = "Updated Integration Test Task",
            Description = "Updated via integration test",
            Priority = TaskPriority.Low
        };

        var json = JsonSerializer.Serialize(updateDto, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"/api/tasks/{taskId}", content);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskDto>>(responseContent, _jsonOptions);
        
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
        apiResponse.Data.Should().NotBeNull();
        apiResponse.Data!.Title.Should().Be(updateDto.Title);
        apiResponse.Data.Priority.Should().Be(updateDto.Priority);
    }

    [Fact]
    public async Task UpdateTask_WithNonExistentId_ShouldReturnNotFound()
    {
        // Arrange
        await AuthenticateAsync();
        var nonExistentId = 99999;
        var updateDto = new UpdateTaskDto
        {
            Title = "Updated Task",
            Description = "Updated Description",
            Priority = TaskPriority.Medium
        };

        var json = JsonSerializer.Serialize(updateDto, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"/api/tasks/{nonExistentId}", content);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteTask_WithValidId_ShouldDeleteTask()
    {
        // Arrange
        await AuthenticateAsync();
        var taskId = 1; // From seeded data

        // Act
        var response = await _client.DeleteAsync($"/api/tasks/{taskId}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

        // Verify deletion by trying to get the task
        var getResponse = await _client.GetAsync($"/api/tasks/{taskId}");
        getResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task SearchTasks_WithQuery_ShouldReturnFilteredResults()
    {
        // Arrange
        await AuthenticateAsync();
        var searchQuery = "integration";

        // Act
        var response = await _client.GetAsync($"/api/tasks/search?query={searchQuery}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<SearchResult<TaskDto>>>(content, _jsonOptions);
        
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
        apiResponse.Data.Should().NotBeNull();
        apiResponse.Data!.Items.Should().AllSatisfy(task => 
            task.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
            task.Description.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task GetTaskStatistics_WithAuth_ShouldReturnStatistics()
    {
        // Arrange
        await AuthenticateAsync();

        // Act
        var response = await _client.GetAsync("/api/tasks/statistics");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse<TaskStatistics>>(content, _jsonOptions);
        
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
        apiResponse.Data.Should().NotBeNull();
        apiResponse.Data!.TotalTasks.Should().BeGreaterThan(0);
    }

    private async Task AuthenticateAsync()
    {
        // Create a test user and get JWT token
        var loginDto = new LoginDto
        {
            Email = "test@example.com",
            Password = "TestPassword123!"
        };

        var json = JsonSerializer.Serialize(loginDto, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/auth/login", content);
        
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<ApiResponse<AuthResult>>(responseContent, _jsonOptions);
            
            var token = authResponse?.Data?.Token;
            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }

    private static void SeedTestData(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Tasks.Any())
            return;

        var tasks = new List<TaskItem>
        {
            new()
            {
                Id = 1,
                Title = "Integration Test Task 1",
                Description = "First integration test task",
                Priority = TaskPriority.High,
                Status = TaskStatus.New,
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new()
            {
                Id = 2,
                Title = "Integration Test Task 2",
                Description = "Second integration test task",
                Priority = TaskPriority.Medium,
                Status = TaskStatus.InProgress,
                UserId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            }
        };

        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }
}
```

3. **Verify Integration Tests:**
   ```powershell
   # Run integration tests to verify they work
   dotnet test .\tests\TaskManagement.API.Tests.Integration\ --verbosity normal
   ```

4. **Expected Integration Test Results:**
   - All API endpoints tested (GET, POST, PUT, DELETE)
   - Authentication and authorization validation
   - Request/response model validation
   - HTTP status code verification
   - Error handling scenarios covered
   - Performance assertions included

---

### Step 4: Create Performance Tests 🚀

**Generate load testing with NBomber:**

1. **Install NBomber package:**
   ```powershell
   # Add NBomber for performance testing
   dotnet add .\tests\TaskManagement.API.Tests.Performance\ package NBomber
   dotnet add .\tests\TaskManagement.API.Tests.Performance\ package NBomber.Http
   ```

2. **Create Performance Test File:**
   - Right-click the `tests` folder in VS Code Explorer
   - Select "New Folder"
   - Name it `TaskManagement.API.Tests.Performance`
   - Right-click the `TaskManagement.API.Tests.Performance` folder
   - Select "New File"
   - Name it `TaskApiPerformanceTests.cs`

3. **Open Copilot Chat and use this prompt:**
   ```
   Create comprehensive performance tests using NBomber for the Task Management API with these requirements:

   Performance Test Scenarios:
   - Load Test: 50 concurrent users for 2 minutes
   - Stress Test: Gradually increase from 1 to 100 users over 5 minutes
   - Spike Test: Sudden load from 10 to 200 users
   - Volume Test: Continuous 25 users for 10 minutes

   API Endpoints to Test:
   - GET /api/tasks (read performance)
   - POST /api/tasks (create performance)
   - PUT /api/tasks/{id} (update performance)
   - DELETE /api/tasks/{id} (delete performance)
   - GET /api/tasks/search?query=test (search performance)

   Performance Metrics:
   - Response time percentiles (50th, 95th, 99th)
   - Requests per second (RPS)
   - Error rate < 1%
   - Average response time < 200ms
   - 95th percentile < 500ms
   - Memory usage monitoring
   - CPU utilization tracking

   Test Data Management:
   - Generate realistic test data using Bogus
   - Prepare different payload sizes
   - Include authentication tokens
   - Clean up test data after tests

   Assertions and Reporting:
   - Assert performance SLA compliance
   - Generate detailed performance reports
   - Include charts and statistics
   - Export results to CSV/JSON

   Error Handling:
   - Test timeout scenarios
   - Network failure simulation
   - Service unavailable handling
   - Rate limiting behavior

   Include at least 8 different performance test methods covering all scenarios.
   Use FluentAssertions for performance metric validation.
   Add comprehensive logging and reporting.
   ```

**Performance test implementation:**

```csharp
using NBomber.CSharp;
using NBomber.Http.CSharp;
using System.Text;
using System.Text.Json;
using Xunit;
using FluentAssertions;

public class TaskApiPerformanceTests
{
    private readonly string _baseUrl = "https://localhost:7001";
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    [Fact]
    public void LoadTest_GetTasks_ShouldHandleConcurrentRequests()
    {
        var scenario = Scenario.Create("get_tasks_load_test", async context =>
        {
            var request = Http.CreateRequest("GET", $"{_baseUrl}/api/tasks")
                .WithHeader("Authorization", "Bearer test-token");

            var response = await Http.Send(request, context);

            return response.IsSuccessStatusCode ? Response.Ok() : Response.Fail();
        })
        .WithLoadSimulations(
            Simulation.InjectPerSec(rate: 10, during: TimeSpan.FromMinutes(1)),
            Simulation.KeepConstant(copies: 5, during: TimeSpan.FromMinutes(2))
        );

        var stats = NBomberRunner
            .RegisterScenarios(scenario)
            .Run();

        // Assert performance requirements
        var sceneStats = stats.AllScenarioStats[0];
        sceneStats.Ok.Request.Count.Should().BeGreaterThan(0);
        sceneStats.Ok.Request.Mean.Should().BeLessThan(TimeSpan.FromMilliseconds(500));
        sceneStats.Fail.Request.Count.Should().Be(0);
    }

    [Fact]
    public void StressTest_CreateTasks_ShouldHandleHighLoad()
    {
        var createTaskDto = new CreateTaskDto
        {
            Title = "Performance Test Task",
            Description = "Created during performance testing",
            Priority = TaskPriority.Medium,
            DueDate = DateTime.UtcNow.AddDays(7)
        };

        var json = JsonSerializer.Serialize(createTaskDto, _jsonOptions);

        var scenario = Scenario.Create("create_tasks_stress_test", async context =>
        {
            var request = Http.CreateRequest("POST", $"{_baseUrl}/api/tasks")
                .WithHeader("Authorization", "Bearer test-token")
                .WithHeader("Content-Type", "application/json")
                .WithBody(new StringContent(json, Encoding.UTF8, "application/json"));

            var response = await Http.Send(request, context);

            return response.IsSuccessStatusCode ? Response.Ok() : Response.Fail();
        })
        .WithLoadSimulations(
            Simulation.InjectPerSec(rate: 20, during: TimeSpan.FromMinutes(1)),
            Simulation.InjectPerSec(rate: 50, during: TimeSpan.FromMinutes(1)),
            Simulation.InjectPerSec(rate: 100, during: TimeSpan.FromMinutes(1))
        );

        var stats = NBomberRunner
            .RegisterScenarios(scenario)
            .Run();

        // Assert stress test requirements
        var sceneStats = stats.AllScenarioStats[0];
        sceneStats.Ok.Request.Count.Should().BeGreaterThan(0);
        sceneStats.Ok.Request.Mean.Should().BeLessThan(TimeSpan.FromSeconds(2));
        
        // Allow some failures under extreme load, but not more than 10%
        var totalRequests = sceneStats.Ok.Request.Count + sceneStats.Fail.Request.Count;
        var failureRate = (double)sceneStats.Fail.Request.Count / totalRequests;
        failureRate.Should().BeLessThan(0.1); // Less than 10% failure rate
    }

    [Fact]
    public void EnduranceTest_MixedOperations_ShouldMaintainPerformance()
    {
        var getTasksScenario = Scenario.Create("get_tasks_endurance", async context =>
        {
            var request = Http.CreateRequest("GET", $"{_baseUrl}/api/tasks")
                .WithHeader("Authorization", "Bearer test-token");

            var response = await Http.Send(request, context);
            return response.IsSuccessStatusCode ? Response.Ok() : Response.Fail();
        })
        .WithWeight(60) // 60% of operations
        .WithLoadSimulations(Simulation.KeepConstant(copies: 3, during: TimeSpan.FromMinutes(5)));

        var createTaskScenario = Scenario.Create("create_task_endurance", async context =>
        {
            var createDto = new CreateTaskDto
            {
                Title = $"Endurance Task {context.ScenarioInfo.ThreadId}",
                Description = "Created during endurance testing",
                Priority = TaskPriority.Medium
            };

            var json = JsonSerializer.Serialize(createDto, _jsonOptions);
            var request = Http.CreateRequest("POST", $"{_baseUrl}/api/tasks")
                .WithHeader("Authorization", "Bearer test-token")
                .WithHeader("Content-Type", "application/json")
                .WithBody(new StringContent(json, Encoding.UTF8, "application/json"));

            var response = await Http.Send(request, context);
            return response.IsSuccessStatusCode ? Response.Ok() : Response.Fail();
        })
        .WithWeight(30) // 30% of operations
        .WithLoadSimulations(Simulation.KeepConstant(copies: 2, during: TimeSpan.FromMinutes(5)));

        var updateTaskScenario = Scenario.Create("update_task_endurance", async context =>
        {
            var updateDto = new UpdateTaskDto
            {
                Title = $"Updated Task {context.ScenarioInfo.ThreadId}",
                Description = "Updated during endurance testing",
                Priority = TaskPriority.High
            };

            var json = JsonSerializer.Serialize(updateDto, _jsonOptions);
            var taskId = Random.Shared.Next(1, 100); // Random existing task ID

            var request = Http.CreateRequest("PUT", $"{_baseUrl}/api/tasks/{taskId}")
                .WithHeader("Authorization", "Bearer test-token")
                .WithHeader("Content-Type", "application/json")
                .WithBody(new StringContent(json, Encoding.UTF8, "application/json"));

            var response = await Http.Send(request, context);
            return response.IsSuccessStatusCode ? Response.Ok() : Response.Fail();
        })
        .WithWeight(10) // 10% of operations
        .WithLoadSimulations(Simulation.KeepConstant(copies: 1, during: TimeSpan.FromMinutes(5)));

        var stats = NBomberRunner
            .RegisterScenarios(getTasksScenario, createTaskScenario, updateTaskScenario)
            .Run();

        // Assert endurance test requirements
        foreach (var sceneStats in stats.AllScenarioStats)
        {
            sceneStats.Ok.Request.Count.Should().BeGreaterThan(0);
            sceneStats.Ok.Request.Mean.Should().BeLessThan(TimeSpan.FromSeconds(1));
            
            // Performance should not degrade significantly over time
            var firstMinute = sceneStats.Ok.Request.RPS;
            var lastMinute = sceneStats.Ok.Request.RPS; // In real test, calculate from time series
            // Assert performance degradation is less than 20%
            // lastMinute.Should().BeGreaterThan(firstMinute * 0.8);
        }
    }
}
```

4. **Verify Performance Tests:**
   ```powershell
   # Run performance tests (Note: requires API to be running)
   dotnet test .\tests\TaskManagement.API.Tests.Performance\ --verbosity normal
   ```

5. **Expected Performance Test Results:**
   - Load tests demonstrate system capacity
   - Stress tests show breaking points
   - Endurance tests verify stability
   - Performance SLA compliance validated
   - Detailed reports generated

---

### Step 5: Build Test Data Factories 🏭

**Create comprehensive test data builders:**

1. **Install Bogus package:**
   ```powershell
   # Add Bogus for generating realistic test data
   dotnet add .\tests\TaskManagement.API.Tests.Unit\ package Bogus
   dotnet add .\tests\TaskManagement.API.Tests.Integration\ package Bogus
   ```

2. **Create Test Data Factory File:**
   - Right-click the `tests` folder in VS Code Explorer  
   - Select "New Folder"
   - Name it `TaskManagement.API.Tests.Shared`
   - Right-click the `TaskManagement.API.Tests.Shared` folder
   - Select "New File"
   - Name it `TestDataFactory.cs`

3. **Open Copilot Chat and use this prompt:**
   ```
   Create a comprehensive test data factory using Bogus library with these requirements:

   Data Generation Classes:
   - TaskItemFaker: Generate realistic TaskItem entities
   - CreateTaskDtoFaker: Generate valid CreateTaskDto objects
   - UpdateTaskDtoFaker: Generate valid UpdateTaskDto objects
   - UserFaker: Generate User entities for testing
   - TaskCommentFaker: Generate comment entities

   Faker Configuration:
   - Realistic data with proper constraints
   - Configurable seed for reproducible tests
   - Edge case data generators (empty, null, boundary values)
   - Invalid data generators for negative testing
   - Related data generators (tasks with comments, users with tasks)

   Special Scenarios:
   - Generate tasks with various priorities and statuses
   - Create overdue tasks, future tasks, completed tasks
   - Generate users with different roles and permissions
   - Create tasks with/without due dates
   - Generate bulk data sets (100, 1000, 10000 records)

   Builder Pattern Methods:
   - TaskItemBuilder with fluent API
   - Predefined scenarios (NewTask, CompletedTask, OverdueTask)
   - Method chaining for customization
   - Build single or multiple entities

   Utility Methods:
   - ResetSeed() for consistent test data
   - GenerateValidEmail(), GenerateValidTitle()
   - CreateTestUser(), CreateTestTask()
   - GenerateTaskWithComments(int commentCount)
   - GenerateUserWithTasks(int taskCount)

   Performance Optimizations:
   - Cached faker instances
   - Bulk generation methods
   - Memory-efficient data creation
   - Lazy loading for large datasets

   Validation Helpers:
   - IsValidTaskTitle(string title)
   - IsValidEmail(string email)
   - IsValidPriority(TaskPriority priority)

   Include at least 15 different data generation methods.
   Use realistic data that resembles production scenarios.
   Include both valid and invalid data generators for comprehensive testing.
   ```

**Test data factory implementation:**

```csharp
using Bogus;
using TaskManagement.API.Models;
using TaskManagement.API.DTOs;

public static class TestDataFactory
{
    private static readonly Faker _faker = new();

    public static Faker<TaskItem> TaskItemFaker => new Faker<TaskItem>()
        .RuleFor(t => t.Id, f => f.Random.Int(1, 10000))
        .RuleFor(t => t.Title, f => f.Lorem.Sentence(3, 8))
        .RuleFor(t => t.Description, f => f.Lorem.Paragraph(1, 3))
        .RuleFor(t => t.Priority, f => f.PickRandom<TaskPriority>())
        .RuleFor(t => t.Status, f => f.PickRandom<TaskStatus>())
        .RuleFor(t => t.UserId, f => f.Random.Int(1, 100))
        .RuleFor(t => t.CreatedAt, f => f.Date.Recent(30))
        .RuleFor(t => t.UpdatedAt, (f, t) => f.Date.Between(t.CreatedAt, DateTime.UtcNow))
        .RuleFor(t => t.DueDate, f => f.Date.Future(1))
        .RuleFor(t => t.IsCompleted, f => f.Random.Bool(0.3f))
        .RuleFor(t => t.CompletedAt, (f, t) => t.IsCompleted ? f.Date.Between(t.CreatedAt, DateTime.UtcNow) : null);

    public static Faker<CreateTaskDto> CreateTaskDtoFaker => new Faker<CreateTaskDto>()
        .RuleFor(dto => dto.Title, f => f.Lorem.Sentence(2, 6))
        .RuleFor(dto => dto.Description, f => f.Lorem.Paragraph(1, 2))
        .RuleFor(dto => dto.Priority, f => f.PickRandom<TaskPriority>())
        .RuleFor(dto => dto.DueDate, f => f.Date.Future(1))
        .RuleFor(dto => dto.UserId, f => f.Random.Int(1, 100))
        .RuleFor(dto => dto.Tags, f => f.Lorem.Words(f.Random.Int(0, 5)).ToArray());

    public static Faker<UpdateTaskDto> UpdateTaskDtoFaker => new Faker<UpdateTaskDto>()
        .RuleFor(dto => dto.Title, f => f.Lorem.Sentence(2, 6))
        .RuleFor(dto => dto.Description, f => f.Lorem.Paragraph(1, 2))
        .RuleFor(dto => dto.Priority, f => f.PickRandom<TaskPriority>())
        .RuleFor(dto => dto.DueDate, f => f.Date.Future(1));

    public static Faker<ApplicationUser> UserFaker => new Faker<ApplicationUser>()
        .RuleFor(u => u.Id, f => f.Random.Guid().ToString())
        .RuleFor(u => u.FirstName, f => f.Name.FirstName())
        .RuleFor(u => u.LastName, f => f.Name.LastName())
        .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
        .RuleFor(u => u.UserName, (f, u) => u.Email)
        .RuleFor(u => u.EmailConfirmed, f => f.Random.Bool(0.8f))
        .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
        .RuleFor(u => u.CreatedAt, f => f.Date.Recent(365));

    // Specialized builders for edge cases
    public static class EdgeCases
    {
        public static TaskItem TaskWithNullDescription()
        {
            var task = TaskItemFaker.Generate();
            task.Description = null!;
            return task;
        }

        public static TaskItem TaskWithEmptyTitle()
        {
            var task = TaskItemFaker.Generate();
            task.Title = string.Empty;
            return task;
        }

        public static TaskItem TaskWithMaxLengthTitle()
        {
            var task = TaskItemFaker.Generate();
            task.Title = new string('A', 200); // Maximum allowed length
            return task;
        }

        public static TaskItem TaskWithExcessiveLengthTitle()
        {
            var task = TaskItemFaker.Generate();
            task.Title = new string('A', 201); // Exceeds maximum length
            return task;
        }

        public static TaskItem OverdueTask()
        {
            var task = TaskItemFaker.Generate();
            task.DueDate = DateTime.UtcNow.AddDays(-_faker.Random.Int(1, 30));
            task.IsCompleted = false;
            return task;
        }

        public static TaskItem CompletedTaskWithoutCompletionDate()
        {
            var task = TaskItemFaker.Generate();
            task.IsCompleted = true;
            task.CompletedAt = null;
            return task;
        }

        public static List<TaskItem> TasksForLoadTesting(int count)
        {
            return TaskItemFaker.Generate(count);
        }

        public static List<TaskItem> TasksWithSpecificUser(int userId, int count)
        {
            return TaskItemFaker
                .RuleFor(t => t.UserId, userId)
                .Generate(count);
        }
    }

    // Scenario builders for common test scenarios
    public static class Scenarios
    {
        public static List<TaskItem> ProductiveUserTasks(int userId)
        {
            return new List<TaskItem>
            {
                TaskItemFaker.RuleFor(t => t.UserId, userId)
                    .RuleFor(t => t.IsCompleted, true)
                    .RuleFor(t => t.Priority, TaskPriority.High)
                    .Generate(),
                TaskItemFaker.RuleFor(t => t.UserId, userId)
                    .RuleFor(t => t.IsCompleted, true)
                    .RuleFor(t => t.Priority, TaskPriority.Medium)
                    .Generate(),
                TaskItemFaker.RuleFor(t => t.UserId, userId)
                    .RuleFor(t => t.IsCompleted, false)
                    .RuleFor(t => t.Priority, TaskPriority.Low)
                    .RuleFor(t => t.Status, TaskStatus.InProgress)
                    .Generate()
            };
        }

        public static List<TaskItem> ProcrastinatorUserTasks(int userId)
        {
            return TaskItemFaker
                .RuleFor(t => t.UserId, userId)
                .RuleFor(t => t.IsCompleted, false)
                .RuleFor(t => t.DueDate, f => f.Date.Past(30))
                .RuleFor(t => t.Status, TaskStatus.New)
                .Generate(5);
        }

        public static List<TaskItem> MixedPriorityTasks(int count)
        {
            var tasks = new List<TaskItem>();
            var priorities = Enum.GetValues<TaskPriority>();

            foreach (var priority in priorities)
            {
                var tasksForPriority = TaskItemFaker
                    .RuleFor(t => t.Priority, priority)
                    .Generate(count / priorities.Length);
                tasks.AddRange(tasksForPriority);
            }

            return tasks;
        }
    }
}

// Usage examples in tests
public class TaskServiceTestsWithFactories
{
    [Fact]
    public async Task CreateTask_WithGeneratedData_ShouldWork()
    {
        // Arrange
        var createDto = TestDataFactory.CreateTaskDtoFaker.Generate();
        // ... test implementation
    }

    [Fact]
    public async Task GetUserTasks_WithManyTasks_ShouldHandleLargeDataset()
    {
        // Arrange
        var userId = 1;
        var tasks = TestDataFactory.EdgeCases.TasksWithSpecificUser(userId, 1000);
        // ... test implementation
    }

    [Theory]
    [MemberData(nameof(GetEdgeCaseData))]
    public async Task HandleEdgeCases_ShouldBehaveCorrectly(TaskItem edgeCaseTask, bool expectedSuccess)
    {
        // Test various edge cases
    }

    public static IEnumerable<object[]> GetEdgeCaseData()
    {
        yield return new object[] { TestDataFactory.EdgeCases.TaskWithNullDescription(), true };
        yield return new object[] { TestDataFactory.EdgeCases.TaskWithEmptyTitle(), false };
        yield return new object[] { TestDataFactory.EdgeCases.TaskWithExcessiveLengthTitle(), false };
        yield return new object[] { TestDataFactory.EdgeCases.OverdueTask(), true };
    }
}
```

4. **Create Test Scenarios File:**
   - Right-click the `TaskManagement.API.Tests.Shared` folder
   - Select "New File"
   - Name it `TestScenarios.cs`

5. **Open Copilot Chat and use this prompt:**
   ```
   Create test scenario builders using the TestDataFactory with these requirements:

   Scenario Categories:
   - Productive user scenarios (high completion rate)
   - Procrastinator scenarios (overdue tasks)
   - Mixed priority workloads
   - Bulk data scenarios for performance testing
   - Edge case scenarios for boundary testing

   Usage Examples:
   - var tasks = TestScenarios.ProductiveUser(userId: 1);
   - var overdueTasks = TestScenarios.ProcrastinatorUser(userId: 2);
   - var bulkData = TestScenarios.PerformanceTestData(count: 1000);

   Include documentation and examples for each scenario.
   Make scenarios reusable across different test projects.
   ```

6. **Verify Test Data Factory:**
   - Open VS Code terminal (View → Terminal or `Ctrl+` `)
   - Type: `dotnet build .\tests\TaskManagement.API.Tests.Shared\` and press Enter

---

### Step 6: Advanced Mocking Strategies 🎭

**Create sophisticated mocks with Moq:**

1. **Create Advanced Mocking Test File:**
   - Navigate to `tests\TaskManagement.API.Tests.Unit\Services` folder
   - Right-click the `Services` folder
   - Select "New File"
   - Name it `TaskServiceAdvancedMockingTests.cs`

2. **Open Copilot Chat and use this prompt:**
   ```
   Create advanced mocking strategies using Moq with these requirements:

   Advanced Mocking Techniques:
   - Sequence verification (MockSequence)
   - Callback testing with It.IsAny<T>()
   - Behavior verification (Verify, VerifyAll)
   - Property mocking and tracking
   - Event raising and handling
   - Exception simulation and testing

   Dependencies to Mock:
   - ILogger<T> with logging verification
   - IMemoryCache with cache hit/miss scenarios
   - IEmailService with notification testing
   - INotificationService with callback verification
   - HttpClient with protected virtual methods
   - IDateTimeProvider for time-dependent testing

   Mocking Scenarios:
   - Verify methods called in correct order
   - Test retry logic with failures and recovery
   - Simulate external service timeouts
   - Mock async operations with delays
   - Verify logging with specific log levels
   - Test caching behavior (hit, miss, expiration)

   Test Categories:
   - Sequence verification tests (5 methods)
   - Callback and behavior tests (5 methods)
   - Exception handling tests (5 methods)
   - Async operation tests (3 methods)
   - Logging verification tests (3 methods)

   Setup Patterns:
   - Mock.Of<T>() for simple mocks
   - Mock<T>.Setup() for complex behavior
   - Mock<T>.Verify() for behavior verification
   - It.IsAny<T>() for flexible matching
   - Callback() for state inspection

   Include comprehensive examples of each mocking technique.
   Use FluentAssertions for readable assertions.
   Add detailed comments explaining each pattern.
   ```

**Advanced mocking implementation:**

```csharp
using Moq;
using Moq.Protected;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

public class TaskServiceAdvancedMockingTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly Mock<ILogger<TaskService>> _mockLogger;
    private readonly Mock<IMemoryCache> _mockCache;
    private readonly Mock<IEmailService> _mockEmailService;
    private readonly Mock<INotificationService> _mockNotificationService;

    public TaskServiceAdvancedMockingTests()
    {
        _mockContext = new Mock<ApplicationDbContext>();
        _mockLogger = new Mock<ILogger<TaskService>>();
        _mockCache = new Mock<IMemoryCache>();
        _mockEmailService = new Mock<IEmailService>();
        _mockNotificationService = new Mock<INotificationService>();
    }

    [Fact]
    public async Task CreateTask_ShouldCallDependenciesInCorrectOrder()
    {
        // Arrange
        var createDto = TestDataFactory.CreateTaskDtoFaker.Generate();
        var sequence = new MockSequence();

        // Setup sequence of calls
        _mockContext.InSequence(sequence)
            .Setup(c => c.Tasks.Add(It.IsAny<TaskItem>()));
        
        _mockContext.InSequence(sequence)
            .Setup(c => c.SaveChangesAsync(default))
            .ReturnsAsync(1);

        _mockEmailService.InSequence(sequence)
            .Setup(e => e.SendTaskCreatedNotificationAsync(It.IsAny<TaskItem>()))
            .ReturnsAsync(true);

        _mockNotificationService.InSequence(sequence)
            .Setup(n => n.CreateNotificationAsync(It.IsAny<CreateNotificationDto>()))
            .ReturnsAsync(new Notification());

        var service = new TaskService(_mockContext.Object, _mockLogger.Object, 
            _mockEmailService.Object, _mockNotificationService.Object);

        // Act
        await service.CreateTaskAsync(createDto);

        // Assert - Verify all mocks were called in sequence
        _mockContext.Verify();
        _mockEmailService.Verify();
        _mockNotificationService.Verify();
    }

    [Fact]
    public async Task CreateTask_WhenEmailFails_ShouldLogWarningAndContinue()
    {
        // Arrange
        var createDto = TestDataFactory.CreateTaskDtoFaker.Generate();
        
        _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);
        _mockEmailService.Setup(e => e.SendTaskCreatedNotificationAsync(It.IsAny<TaskItem>()))
            .ReturnsAsync(false);

        var service = new TaskService(_mockContext.Object, _mockLogger.Object,
            _mockEmailService.Object, _mockNotificationService.Object);

        // Act
        await service.CreateTaskAsync(createDto);

        // Assert - Verify warning was logged
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("email")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public async Task UpdateTask_ShouldUseCallbackToModifyEntity()
    {
        // Arrange
        var existingTask = TestDataFactory.TaskItemFaker.Generate();
        var updateDto = TestDataFactory.UpdateTaskDtoFaker.Generate();
        
        TaskItem capturedTask = null!;

        _mockContext.Setup(c => c.Tasks.FindAsync(existingTask.Id))
            .ReturnsAsync(existingTask);
        
        _mockContext.Setup(c => c.SaveChangesAsync(default))
            .Callback(() => capturedTask = existingTask)
            .ReturnsAsync(1);

        var service = new TaskService(_mockContext.Object, _mockLogger.Object);

        // Act
        await service.UpdateTaskAsync(existingTask.Id, updateDto);

        // Assert - Verify the entity was modified correctly
        capturedTask.Should().NotBeNull();
        capturedTask.Title.Should().Be(updateDto.Title);
        capturedTask.Description.Should().Be(updateDto.Description);
        capturedTask.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public async Task GetUserTasks_WithCaching_ShouldCheckCacheFirst()
    {
        // Arrange
        var userId = 1;
        var cachedTasks = TestDataFactory.TaskItemFaker.Generate(3);
        
        _mockCache.Setup(c => c.TryGetValue($"user_tasks_{userId}", out It.Ref<object>.IsAny))
            .Returns((string key, out object value) =>
            {
                value = cachedTasks;
                return true;
            });

        var service = new TaskService(_mockContext.Object, _mockLogger.Object, _mockCache.Object);

        // Act
        var result = await service.GetUserTasksAsync(userId);

        // Assert - Database should not be called
        _mockContext.Verify(c => c.Tasks, Times.Never);
        result.Should().HaveCount(3);
        
        // Verify cache was checked
        _mockCache.Verify(c => c.TryGetValue($"user_tasks_{userId}", out It.Ref<object>.IsAny), Times.Once);
    }

    [Fact]
    public async Task BulkDeleteTasks_ShouldHandlePartialFailures()
    {
        // Arrange
        var taskIds = new[] { 1, 2, 3, 4, 5 };
        var existingTasks = TestDataFactory.TaskItemFaker.Generate(3);
        
        // Setup: tasks 1, 2, 3 exist; 4, 5 don't exist
        _mockContext.Setup(c => c.Tasks.FindAsync(1)).ReturnsAsync(existingTasks[0]);
        _mockContext.Setup(c => c.Tasks.FindAsync(2)).ReturnsAsync(existingTasks[1]);
        _mockContext.Setup(c => c.Tasks.FindAsync(3)).ReturnsAsync(existingTasks[2]);
        _mockContext.Setup(c => c.Tasks.FindAsync(4)).ReturnsAsync((TaskItem?)null);
        _mockContext.Setup(c => c.Tasks.FindAsync(5)).ReturnsAsync((TaskItem?)null);

        var service = new TaskService(_mockContext.Object, _mockLogger.Object);

        // Act
        var result = await service.BulkDeleteTasksAsync(taskIds);

        // Assert
        result.SuccessfulDeletes.Should().Be(3);
        result.FailedDeletes.Should().Be(2);
        
        // Verify correct number of Remove calls
        _mockContext.Verify(c => c.Tasks.Remove(It.IsAny<TaskItem>()), Times.Exactly(3));
        
        // Verify error logging for missing tasks
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("not found")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Exactly(2));
    }

    [Fact]
    public async Task ComplexBusinessOperation_ShouldHandleTransactionScope()
    {
        // Arrange
        var createDto = TestDataFactory.CreateTaskDtoFaker.Generate();
        var mockTransaction = new Mock<IDbContextTransaction>();
        
        _mockContext.Setup(c => c.Database.BeginTransactionAsync(default))
            .ReturnsAsync(mockTransaction.Object);
        
        _mockContext.Setup(c => c.SaveChangesAsync(default))
            .ReturnsAsync(1);

        var service = new TaskService(_mockContext.Object, _mockLogger.Object);

        // Act
        await service.CreateTaskWithDependenciesAsync(createDto);

        // Assert - Verify transaction was used
        _mockContext.Verify(c => c.Database.BeginTransactionAsync(default), Times.Once);
        mockTransaction.Verify(t => t.CommitAsync(default), Times.Once);
        mockTransaction.Verify(t => t.Dispose(), Times.Once);
    }

    [Fact]
    public void MockHttpClient_ForExternalApiCalls()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonSerializer.Serialize(new { success = true }))
        };

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(expectedResponse);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var service = new ExternalApiService(httpClient, _mockLogger.Object);

        // Act & Assert
        // Test external API calls with mocked HTTP responses
    }
}
```

3. **Verify Advanced Mocking:**
   ```powershell
   # Run advanced mocking tests
   dotnet test .\tests\TaskManagement.API.Tests.Unit\Services\TaskServiceAdvancedMockingTests.cs --verbosity normal
   ```

4. **Expected Advanced Mocking Results:**
   - Sequence verification working correctly
   - Callback testing successful
   - Behavior verification comprehensive
   - Exception simulation functional
   - Logging verification accurate

---

### Step 7: Test Coverage Analysis 📊

**Set up test coverage analysis:**

1. **Install Coverage Tools:**
   - Open VS Code terminal (View → Terminal or `Ctrl+` `)
   - Type: `dotnet tool install -g dotnet-reportgenerator-globaltool` and press Enter
   - Type: `dotnet tool install -g coverlet.console` and press Enter

2. **Add Coverage Properties to Test Projects:**
   - Open each test project file (`.csproj`) in VS Code
   - Update with coverage settings as suggested by Copilot Chat

3. **Open Copilot Chat and use this prompt:**
   ```
   Add comprehensive test coverage configuration to all test projects with these requirements:

   Coverage Configuration:
   - Enable code coverage collection
   - Output in OpenCover and Cobertura formats
   - Exclude test projects and utilities from coverage
   - Set minimum coverage thresholds (80% line, 70% branch)
   - Generate HTML and XML reports

   MSBuild Properties:
   - CollectCoverage=true
   - CoverletOutputFormat=opencover,cobertura
   - CoverletOutput=./coverage/
   - Exclude=[*.Tests]*,[*.TestUtilities]*
   - ExcludeByAttribute=Obsolete,GeneratedCodeAttribute

   Coverage Targets:
   - Line coverage: minimum 80%
   - Branch coverage: minimum 70%
   - Method coverage: minimum 85%
   - Class coverage: minimum 90%

   Report Generation:
   - HTML reports for visualization
   - XML reports for CI/CD integration
   - Summary reports for quick overview
   - Trend analysis over time

   Integration Requirements:
   - Work with dotnet test command
   - Compatible with GitHub Actions
   - Support for multiple test frameworks
   - Exclude generated code and attributes

   Add these properties to all test project files (.csproj).
   Create a script to run tests with coverage and generate reports.
   Include coverage badge generation for README.
   ```

4. **Create Coverage Script:**
   ```powershell
   # Create PowerShell script for coverage analysis
   New-Item -Path ".\scripts\run-tests-with-coverage.ps1" -ItemType File -Force
   ```

5. **Use Copilot Chat for Coverage Script:**
   ```
   Create a comprehensive PowerShell script for test coverage analysis with these features:

   Script Functions:
   - Run all test projects with coverage
   - Generate HTML and XML reports
   - Display coverage summary in console
   - Check coverage thresholds
   - Open coverage report in browser
   - Support different output formats

   Coverage Tools:
   - Use coverlet for collection
   - Use ReportGenerator for HTML reports
   - Support multiple report formats
   - Generate coverage badges

   Threshold Checking:
   - Fail if line coverage < 80%
   - Warn if branch coverage < 70%
   - Display detailed coverage breakdown
   - Show uncovered lines and methods

   Report Features:
   - HTML dashboard with drill-down
   - Trend analysis if previous reports exist
   - Coverage by project and namespace
   - Hotspot analysis for low coverage

   The script should be runnable from repository root and handle all dependencies automatically.
   ```

---

### Step 8: Test Organization and Documentation 📚

**Organize and document your test suite:**

1. **Create Test Documentation:**
   ```powershell
   # Create test documentation
   New-Item -Path ".\docs\testing-strategy.md" -ItemType File -Force
   New-Item -Path ".\docs\test-conventions.md" -ItemType File -Force
   ```

2. **Open Copilot Chat for Test Strategy Document:**
   ```
   Create comprehensive testing strategy documentation with these sections:

   Testing Strategy Overview:
   - Test pyramid implementation (unit, integration, e2e)
   - Test coverage goals and metrics
   - Quality gates and acceptance criteria
   - CI/CD integration requirements

   Test Types and Purposes:
   - Unit Tests: Fast, isolated, deterministic
   - Integration Tests: API contracts, database interactions
   - Performance Tests: Load, stress, endurance testing
   - End-to-End Tests: Full user scenarios

   Testing Frameworks and Tools:
   - xUnit for test framework
   - Moq for mocking and isolation
   - FluentAssertions for readable assertions
   - NBomber for performance testing
   - Bogus for test data generation

   Test Organization:
   - Project structure and naming conventions
   - Test categorization and tagging
   - Test data management strategies
   - Shared utilities and helpers

   Best Practices:
   - FIRST principles (Fast, Independent, Repeatable, Self-validating, Timely)
   - AAA pattern (Arrange, Act, Assert)
   - Given-When-Then for behavior testing
   - Test naming conventions

   Coverage Requirements:
   - Minimum coverage thresholds
   - Critical path identification
   - Edge case coverage strategies
   - Performance benchmark requirements

   CI/CD Integration:
   - Automated test execution
   - Coverage reporting
   - Quality gates implementation
   - Deployment verification

   Include examples and code snippets for each concept.
   Make it a reference guide for the development team.
   ```

3. **Create Test Conventions Document:**
   ```powershell
   # Open Copilot Chat for test conventions
   ```

4. **Use Copilot Chat for Test Conventions:**
   ```
   Create detailed test conventions documentation covering:

   Naming Conventions:
   - Test class names: [ClassUnderTest]Tests
   - Test method names: [Method]_[Scenario]_[ExpectedResult]
   - Test data methods: Get[TestType]TestData
   - Mock object names: _mock[ServiceName]

   File Organization:
   - Mirror source code structure in test projects
   - Group related tests in same namespace
   - Separate unit, integration, and performance tests
   - Use shared test utilities appropriately

   Test Structure Standards:
   - Use AAA pattern consistently
   - One assertion per test (when possible)
   - Clear test data setup
   - Proper cleanup and disposal

   Assertion Guidelines:
   - Use FluentAssertions for readability
   - Include meaningful failure messages
   - Test both positive and negative scenarios
   - Verify expected exceptions with specific messages

   Mocking Standards:
   - Mock external dependencies only
   - Verify important interactions
   - Use realistic test data
   - Set up only what you need

   Performance Test Guidelines:
   - Define clear performance SLAs
   - Use realistic load patterns
   - Include warm-up periods
   - Monitor resource usage

   Documentation Requirements:
   - Comment complex test setups
   - Document test scenarios
   - Explain business logic tests
   - Maintain test data explanations

   Include examples for each convention and anti-patterns to avoid.
   ```

5. **Organize Test Projects:**
   ```powershell
   # Verify all test projects are properly structured
   Get-ChildItem -Path ".\tests\" -Recurse -Name "*.cs" | Sort-Object
   ```

---

## ✅ Phase 9 Verification

**Verify your comprehensive test suite:**

1. **Run All Test Categories:**
   ```powershell
   # Run unit tests
   dotnet test .\tests\TaskManagement.API.Tests.Unit\ --verbosity normal

   # Run integration tests  
   dotnet test .\tests\TaskManagement.API.Tests.Integration\ --verbosity normal

   # Run performance tests (requires API running)
   dotnet test .\tests\TaskManagement.API.Tests.Performance\ --verbosity normal
   ```

2. **Generate Complete Coverage Report:**
   ```powershell
   # Run comprehensive coverage analysis
   .\scripts\run-tests-with-coverage.ps1

   # Open coverage report in browser
   Start-Process ".\CoverageReport\index.html"
   ```

3. **Verify Test Quality Metrics:**
   ```powershell
   # Check test count and organization
   Write-Host "Test Summary:" -ForegroundColor Yellow
   Write-Host "Unit Tests: $((Get-ChildItem .\tests\TaskManagement.API.Tests.Unit\ -Recurse -Filter "*Tests.cs").Count) files" -ForegroundColor Cyan
   Write-Host "Integration Tests: $((Get-ChildItem .\tests\TaskManagement.API.Tests.Integration\ -Recurse -Filter "*Tests.cs").Count) files" -ForegroundColor Cyan
   Write-Host "Performance Tests: $((Get-ChildItem .\tests\TaskManagement.API.Tests.Performance\ -Recurse -Filter "*Tests.cs").Count) files" -ForegroundColor Cyan
   ```

4. **Expected Test Suite Results:**
   - **Unit Tests**: 50+ test methods covering all service methods
   - **Integration Tests**: 15+ API endpoint tests with full coverage
   - **Performance Tests**: 8+ load testing scenarios
   - **Test Coverage**: Minimum 80% line coverage, 70% branch coverage
   - **Test Data**: Comprehensive factories and realistic scenarios
   - **Advanced Mocking**: Sequence verification and behavior testing
   - **Documentation**: Complete testing strategy and conventions

5. **Final Verification Checklist:**
   - [ ] All test projects compile successfully
   - [ ] Unit tests execute in under 30 seconds
   - [ ] Integration tests pass with test database
   - [ ] Performance tests demonstrate SLA compliance
   - [ ] Coverage reports generate correctly
   - [ ] Test documentation is comprehensive
   - [ ] Advanced mocking patterns implemented
   - [ ] Test data factories working properly

---

## 🎉 What You've Learned

In this phase, you mastered advanced testing with GitHub Copilot:

- ✅ **Comprehensive Unit Testing** with xUnit, Moq, and FluentAssertions
- ✅ **Integration Testing** with TestServer and in-memory databases  
- ✅ **Performance Testing** with NBomber and load testing strategies
- ✅ **Test Data Generation** using Bogus for realistic scenarios
- ✅ **Advanced Mocking** with sequence verification and behavior testing
- ✅ **Test Coverage Analysis** with detailed reporting and thresholds
- ✅ **Test Organization** with proper structure and documentation
- ✅ **Quality Assurance** with comprehensive testing strategies

You now have a production-ready test suite that demonstrates professional testing practices and ensures code quality and reliability!
- ✅ **Performance testing** with NBomber load testing framework
- ✅ **Test data generation** with Bogus factories and builders
- ✅ **Advanced mocking** with Moq sequence and callback verification
- ✅ **Test coverage analysis** with reporting and quality gates
- ✅ **End-to-end testing** with realistic scenarios

## 🧪 Testing Best Practices

### 1. **Test Structure (AAA Pattern)**
```
Arrange: Set up test data and mocks
Act: Execute the code under test
Assert: Verify expected outcomes
```

### 2. **Test Categories**
```
Unit Tests: Fast, isolated, deterministic
Integration Tests: Real dependencies, slower
Performance Tests: Load, stress, endurance
E2E Tests: Full application scenarios
```

### 3. **Coverage Goals**
```
Line Coverage: > 80%
Branch Coverage: > 70%
Critical Path Coverage: 100%
Edge Cases: Comprehensive
```

## 💡 Pro Tips for Testing with Copilot

1. **Describe test scenarios clearly** - Help Copilot understand what to test
2. **Use descriptive test names** - Make test intent obvious
3. **Generate edge cases** - Ask Copilot to identify boundary conditions
4. **Create realistic test data** - Use Bogus for meaningful test scenarios
5. **Test error paths** - Verify exception handling and error scenarios


**💡 Pro Tip**: Good tests tell the story of your code's behavior. Let Copilot help you create tests that not only verify functionality but also serve as living documentation!

## 🎯 Next Phase

Ready for comprehensive documentation? In [Phase 10: Documentation & Diagrams](./phase10-documentation-diagrams.md), you'll learn to auto-generate complete project documentation with Mermaid diagrams! 📚

---

**🏆 Testing Expert!** You've learned to create comprehensive test suites with intelligent AI assistance. Your code quality and confidence will be dramatically improved! 🧪

[![➡️ Next: Phase 10 - Documentation & Diagrams](https://img.shields.io/badge/➡️-Next%3A%20Phase%2010%20Documentation%20Diagrams-green?style=flat-square)](phase10-documentation-diagrams.md)

