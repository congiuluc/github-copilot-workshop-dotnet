# 💡 Phase 06: Code Actions - Smart Fixes and Suggestions
**🎯 GitHub Copilot Feature**: AI-powered quick fixes and intelligent improvements

[![⬅️ Back to Workshop Home](https://img.shields.io/badge/⬅️-Back%20to%20Workshop%20Home-blue?style=flat-square)](../README.md) [![⬅️ Previous: Phase 05](https://img.shields.io/badge/⬅️-Previous%3A%20Phase%2005-lightgrey?style=flat-square)](phase05-code-review.md)


## 🎯 Objective

Master GitHub Copilot's Code Actions to implement error handling and edge cases with intelligent suggestions. Learn to leverage AI-powered quick fixes, smart suggestions, and proactive code improvements.

## 📖 About Code Actions

GitHub Copilot's Code Actions provide intelligent assistance:
- **Smart error detection** - Identify potential issues before they become problems
- **Quick fixes** - Instant solutions for common coding issues
- **Proactive suggestions** - Recommendations for code improvements
- **Context-aware fixes** - Solutions that understand your specific situation
- **Edge case handling** - Comprehensive error scenarios and boundary conditions

## 🛠️ What You'll Implement

In this phase, you'll add:
- ✅ Comprehensive error handling strategies
- ✅ Input validation and sanitization
- ✅ Edge case management
- ✅ Defensive programming patterns
- ✅ Robust exception handling
- ✅ Graceful degradation mechanisms

## 📋 Step-by-Step Instructions

### Step 1: Enable Code Actions and Quick Fixes 💡

**Understand how to access Code Actions:**

1. **Access Code Actions in VS Code:**
   - Look for light bulb icons 💡 that appear in your code editor
   - Use keyboard shortcuts: `Ctrl+.` (Windows/Linux) or `Cmd+.` (Mac) to open Quick Actions
   - Use `Alt+Enter` for alternative quick actions
   - Right-click context menu → "Quick Fix" or "Refactor"

2. **Configure Copilot for Code Actions:**
   ```powershell
   # Verify Copilot extension is enabled for quick fixes
   # In VS Code: Extensions → GitHub Copilot → Settings → Enable "Copilot: Enable Auto Completions"
   ```

3. **Expected Code Action Types:**
   - 🔍 **Error fixes** - Resolve compilation errors
   - ⚡ **Quick fixes** - Common pattern improvements
   - 🚀 **Refactoring** - Code structure improvements
   - 🛡️ **Security fixes** - Address security concerns
   - 📝 **Documentation** - Add missing documentation

---

### Step 2: Implement Robust Input Validation 📋

**Create a method that needs input validation:**

1. **Open TaskService file:**
   ```powershell
   # Open the TaskService for editing
   code .\src\TaskManagement.API\Services\TaskService.cs
   ```

2. **Add method with missing validation (intentionally flawed):**

2. **Add method with missing validation (intentionally flawed):**
   ```csharp
   // Add this method to TaskService - intentionally missing validation
   public async Task<TaskItem> CreateTaskAsync(CreateTaskDto dto)
   {
       var task = new TaskItem
       {
           Title = dto.Title, // No validation
           Description = dto.Description,
           Priority = dto.Priority,
           UserId = dto.UserId, // No user existence check
           CreatedAt = DateTime.UtcNow,
           DueDate = dto.DueDate // No date validation
       };

       _context.Tasks.Add(task);
       await _context.SaveChangesAsync(); // No error handling
       
       return task;
   }
   ```

3. **Position cursor on the method and trigger Code Actions:**
   - Click anywhere in the CreateTaskAsync method
   - Press `Ctrl+.` to open Quick Actions menu
   - Look for Copilot suggestions

4. **Use Copilot Chat for comprehensive validation:**
   ```
   Add comprehensive input validation to this CreateTaskAsync method with these requirements:

   Parameter Validation:
   - Check if dto is null and throw ArgumentNullException
   - Validate Title is not null, empty, or whitespace
   - Ensure Title length is between 1 and 200 characters
   - Validate Description length doesn't exceed 1000 characters
   - Check UserId is greater than 0
   - Validate DueDate is not in the past (if provided)

   Business Rule Validation:
   - Verify user exists in database before creating task
   - Check if user has permission to create tasks
   - Validate priority is within valid enum range
   - Ensure task title is unique for the user

   Error Handling:
   - Use guard clauses for early returns
   - Throw specific exceptions with meaningful messages
   - Add proper logging for validation failures
   - Return validation results instead of throwing

   Security Considerations:
   - Sanitize input strings to prevent injection attacks
   - Validate user authorization
   - Implement rate limiting checks
   - Log security violations

   Please provide the complete validated method implementation.
   ```

5. **Apply the validation improvements:**
   - Review the generated validation code
   - Replace the unsafe method with the validated version

6. **Verify the validation works:**
   ```powershell
   # Build to verify validation code compiles
   dotnet build .\src\TaskManagement.API\
   ```
        Description = dto.Description,
        Priority = dto.Priority,
        UserId = dto.UserId
---

### Step 3: Handle Exception Scenarios 🚨

**Create code that needs exception handling:**

1. **Add a method with potential exceptions:**
   ```csharp
   // Add this method to TaskService - needs exception handling
   public async Task<TaskItem> UpdateTaskAsync(int taskId, UpdateTaskDto dto)
   {
       var task = await _context.Tasks.FindAsync(taskId); // Potential null
       
       task.Title = dto.Title; // NullReferenceException risk
       task.Description = dto.Description;
       task.UpdatedAt = DateTime.UtcNow;
       
       await _context.SaveChangesAsync(); // Database exceptions possible
       return task;
   }
   ```

2. **Trigger Code Actions on the method:**
   - Position cursor in the UpdateTaskAsync method
   - Press `Ctrl+.` to see suggested fixes

3. **Use Copilot Chat for comprehensive exception handling:**
   ```
   Add comprehensive exception handling to this UpdateTaskAsync method:

   Null Reference Protection:
   - Check if task exists before updating
   - Throw NotFoundException if task not found
   - Validate dto parameter is not null
   - Handle null property values gracefully

   Database Exception Handling:
   - Wrap SaveChangesAsync in try-catch
   - Handle DbUpdateConcurrencyException for optimistic concurrency
   - Handle DbUpdateException for constraint violations
   - Handle SqlException for database connectivity issues

   Business Logic Exceptions:
   - Validate user has permission to update this task
   - Check if task is in a state that allows updates
   - Validate business rules before saving
   - Log all exception scenarios

   Exception Response Strategy:
   - Create custom exception types for different scenarios
   - Include meaningful error messages
   - Add error codes for client handling
   - Implement proper logging with context

   Recovery Mechanisms:
   - Implement retry logic for transient failures
   - Provide fallback mechanisms where appropriate
   - Clean up partial state on failure
   - Ensure data consistency

   Please provide the complete exception-safe implementation.
   ```

4. **Apply exception handling improvements:**
   - Review the generated exception handling code
   - Replace the unsafe method with the protected version

5. **Verify exception handling:**
   ```powershell
   # Build to verify exception handling compiles
   dotnet build .\src\TaskManagement.API\
   ```

---

### Step 4: Implement Edge Case Handling 🎯

**Create scenarios that need edge case handling:**

1. **Add a method with edge case vulnerabilities:**
   ```csharp
   // Add this method to TaskService - needs edge case handling
   public async Task<decimal> CalculateUserProductivityAsync(int userId)
   {
       var userTasks = await _context.Tasks
           .Where(t => t.UserId == userId)
           .ToListAsync();
           
       var completedTasks = userTasks.Count(t => t.IsCompleted);
       
       return (decimal)completedTasks / userTasks.Count; // Division by zero!
   }
   ```

2. **Use Code Actions for edge case detection:**
   - Position cursor on the division line
   - Press `Ctrl+.` to see Code Actions
   - Look for "Add null/zero checks" suggestions

3. **Use Copilot Chat for comprehensive edge case handling:**
   ```
   Add comprehensive edge case handling to this productivity calculation method:

   Division by Zero Protection:
   - Check if userTasks.Count is zero before division
   - Return appropriate default value for users with no tasks
   - Handle null or empty collections gracefully
   - Document the return value meaning

   Data Validation Edge Cases:
   - Handle invalid userId values (negative, zero, very large)
   - Validate user exists in database
   - Handle corrupted data scenarios
   - Deal with extremely large datasets

   Boundary Conditions:
   - Handle users with thousands of tasks
   - Manage memory efficiently for large result sets
   - Set reasonable limits on data processing
   - Implement pagination for large datasets

   Special Scenarios:
   - Handle users with all completed tasks (100% productivity)
   - Handle users with no completed tasks (0% productivity)
   - Handle users with negative completion dates
   - Handle tasks without proper status

   Performance Edge Cases:
   - Optimize for users with many tasks
   - Handle database timeout scenarios
   - Implement caching for frequently requested users
   - Use async enumeration for large datasets

   Error Handling:
   - Return meaningful results for all edge cases
   - Log unusual scenarios for monitoring
   - Provide detailed error messages for debugging
   - Implement graceful degradation

   Please provide the complete edge-case-safe implementation.
   ```

4. **Apply edge case improvements:**
   - Review the generated edge case handling
   - Replace the vulnerable method with the safe version

5. **Verify edge case handling:**
   ```powershell
   # Build to verify edge case code compiles
   dotnet build .\src\TaskManagement.API\
   ```

---

### Step 5: Add Defensive Programming Patterns 🛡️

**Implement defensive programming techniques:**

1. **Create a method that needs defensive programming:**
   ```csharp
   // Add this method to TaskService - needs defensive programming
   public async Task<List<TaskItem>> GetTasksByDateRangeAsync(DateTime startDate, DateTime endDate, int userId)
   {
       return await _context.Tasks
           .Where(t => t.UserId == userId && t.CreatedAt >= startDate && t.CreatedAt <= endDate)
           .ToListAsync();
   }
   ```

2. **Use Copilot Chat for defensive programming implementation:**
   ```
   Add defensive programming patterns to this date range query method:

   Parameter Validation:
   - Validate startDate is not default DateTime value
   - Ensure endDate is after startDate
   - Check userId is valid and positive
   - Validate date range is reasonable (not too large)

   Input Sanitization:
   - Normalize date values to UTC
   - Handle different time zone scenarios
   - Validate date formats and ranges
   - Prevent unreasonably large date ranges

   Precondition Checks:
   - Verify user exists and is active
   - Check user has permission to view tasks
   - Validate database connection is available
   - Ensure required indexes exist for performance

   Postcondition Validation:
   - Verify returned results match expected criteria
   - Check for data consistency
   - Validate result set size is reasonable
   - Ensure no sensitive data is leaked

   Guard Clauses:
   - Use early returns for invalid parameters
   - Implement parameter validation at method start
   - Add meaningful exception messages
   - Log invalid parameter attempts

   Contract Programming:
   - Define clear method contracts
   - Document preconditions and postconditions
   - Implement invariant checks
   - Add assertion statements for debugging

   Please provide the complete defensive implementation.
   ```

3. **Apply defensive programming patterns:**
   - Review the generated defensive code
   - Replace the basic method with the defensive version

4. **Verify defensive programming:**
   ```powershell
   # Build to verify defensive code compiles
   dotnet build .\src\TaskManagement.API\
   ```

---

### Step 6: Implement Graceful Degradation 🔄

**Add graceful degradation mechanisms:**

1. **Create a method that needs graceful degradation:**
   ```csharp
   // Add this method to TaskService - needs graceful degradation
   public async Task<TaskSummaryDto> GetTaskSummaryAsync(int userId)
   {
       var tasks = await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
       var user = await _context.Users.FindAsync(userId);
       var stats = await CalculateUserStatsAsync(userId); // External service call
       
       return new TaskSummaryDto
       {
           TotalTasks = tasks.Count,
           CompletedTasks = tasks.Count(t => t.IsCompleted),
           UserName = user.Username,
           ProductivityScore = stats.ProductivityScore // May fail
       };
   }
   ```

2. **Use Copilot Chat for graceful degradation:**
   ```
   Add graceful degradation to this task summary method:

   Service Failure Handling:
   - Handle external service (stats) being unavailable
   - Provide default values when services fail
   - Continue execution even if optional data fails
   - Implement circuit breaker pattern for external calls

   Partial Data Scenarios:
   - Return summary even if some data is missing
   - Use cached data when fresh data is unavailable
   - Provide best-effort results with reduced functionality
   - Mark incomplete data clearly in response

   Fallback Mechanisms:
   - Use local calculations when external services fail
   - Provide basic summary when detailed analysis fails
   - Implement multiple data sources with fallbacks
   - Cache successful results for future failures

   Progressive Enhancement:
   - Start with basic data and add enhancements
   - Allow partial success responses
   - Implement timeout handling for slow operations
   - Provide immediate response with async background processing

   Error Communication:
   - Include information about what failed
   - Provide partial results with warnings
   - Log degradation events for monitoring
   - Give users clear understanding of data quality

   Performance Degradation:
   - Handle slow database responses gracefully
   - Implement timeout mechanisms
   - Provide cached results when possible
   - Use simplified calculations for performance

   Please provide the complete graceful degradation implementation.
   ```

3. **Apply graceful degradation patterns:**
   - Review the generated resilient code
   - Replace the fragile method with the resilient version

4. **Verify graceful degradation:**
   ```powershell
   # Build to verify graceful degradation compiles
   dotnet build .\src\TaskManagement.API\
   ```

---

### Step 7: Add Comprehensive Logging and Monitoring 📊

**Implement logging for Code Actions scenarios:**

1. **Use Copilot Chat to add logging throughout your services:**
   ```
   Add comprehensive logging to all TaskService methods with these requirements:

   Structured Logging:
   - Use ILogger with structured logging patterns
   - Include correlation IDs for request tracking
   - Log method entry and exit with parameters
   - Add performance timing for important operations

   Error Logging:
   - Log all exceptions with full context
   - Include stack traces for debugging
   - Add error correlation information
   - Log business rule violations

   Security Logging:
   - Log authentication failures
   - Track authorization violations
   - Monitor suspicious activity patterns
   - Log data access attempts

   Performance Logging:
   - Track slow database queries
   - Monitor external service call durations
   - Log memory usage for large operations
   - Track cache hit/miss ratios

   Business Event Logging:
   - Log task creation, updates, deletions
   - Track user activity patterns
   - Monitor business process completion
   - Log important state changes

   Monitoring Integration:
   - Add metrics for monitoring dashboards
   - Include health check information
   - Provide alerting triggers
   - Support distributed tracing

   Please add comprehensive logging to all existing methods.
   ```

2. **Apply logging improvements:**
   - Review and apply the generated logging code
   - Ensure all critical paths have appropriate logging

3. **Verify logging implementation:**
   ```powershell
   # Build to verify logging code compiles
   dotnet build .\src\TaskManagement.API\
   ```

---

### Step 8: Create Custom Exception Types 🎯

**Implement domain-specific exceptions:**

1. **Create custom exception classes:**
   - Right-click the `src\TaskManagement.API` folder in VS Code Explorer
   - Select "New Folder"
   - Name it `Exceptions`

2. **Use Copilot Chat to create exception hierarchy:**
   ```
   Create a comprehensive custom exception hierarchy for the Task Management system:

   Base Exception Classes:
   - TaskManagementException (base for all domain exceptions)
   - ValidationException (for validation failures)
   - BusinessRuleException (for business rule violations)
   - SecurityException (for security-related issues)

   Specific Exception Types:
   - TaskNotFoundException
   - UserNotFoundException
   - DuplicateTaskException
   - InvalidTaskStateException
   - TaskPermissionException
   - TaskValidationException

   Exception Properties:
   - Include error codes for client handling
   - Add detailed error messages
   - Include context information (user ID, task ID, etc.)
   - Support inner exceptions for root cause analysis

   Exception Features:
   - Serializable for distributed systems
   - Support for localization
   - Include suggested actions for resolution
   - Add severity levels

   Factory Methods:
   - Create factory methods for common scenarios
   - Include context-specific exception creation
   - Support fluent exception building
   - Add logging integration

   Please create all exception classes in separate files.
   ```

3. **Create exception files:**
   - Right-click the `Exceptions` folder you just created
   - Select "New File" and create:
     - `TaskNotFoundException.cs`
     - `ValidationException.cs`
     - Continue for other exceptions as suggested by Copilot

4. **Verify exception hierarchy:**
   - Open VS Code terminal (View → Terminal or `Ctrl+` `)
   - Type: `dotnet build .\src\TaskManagement.API\` and press Enter

---

### Step 9: Implement Result Pattern 🎁

**Replace exceptions with Result pattern where appropriate:**

1. **Create Result pattern classes:**
   - Right-click the `src\TaskManagement.API` folder in VS Code Explorer
   - Select "New Folder"
   - Name it `Common`
   - Right-click the `Common` folder
   - Select "New File"
   - Name it `Result.cs`

2. **Use Copilot Chat to implement Result pattern:**
   ```
   Create a comprehensive Result pattern implementation for the Task Management API:

   Result<T> Class:
   - Generic Result<T> for successful operations with data
   - Result class for operations without return data
   - Include success/failure state
   - Support multiple error messages
   - Add error codes for client handling

   Error Handling:
   - Include error details and context
   - Support error severity levels
   - Add error categories (Validation, Business, System)
   - Include suggested actions for resolution

   Factory Methods:
   - Success() factory methods
   - Failure() factory methods with various error types
   - FromException() for converting exceptions
   - ValidationFailure() for validation errors

   Utility Methods:
   - IsSuccess and IsFailure properties
   - Match() method for pattern matching
   - Map() and Bind() for functional composition
   - ToActionResult() for ASP.NET Core integration

   Extension Methods:
   - ToResult() extensions for common types
   - ThenAsync() for chaining async operations
   - OnSuccess() and OnFailure() callbacks
   - LogResult() for automatic logging

   Example Usage:
   - Show how to replace try-catch with Result pattern
   - Demonstrate chaining operations
   - Show controller integration
   - Include async scenarios

   Please provide complete Result pattern implementation.
   ```

3. **Apply Result pattern to existing methods:**
   - Update service methods to return Result<T> instead of throwing exceptions
   - Modify controllers to handle Result pattern responses

4. **Verify Result pattern implementation:**
   ```powershell
   # Build to verify Result pattern compiles
   dotnet build .\src\TaskManagement.API\
   ```
    };

    _context.Tasks.Add(task);
    await _context.SaveChangesAsync();
    return task;
}
```

### Step 3: Handle Database Exceptions with Code Actions 🗄️

**Create code that needs database exception handling:**

```csharp
public async Task<bool> UpdateTaskAsync(int id, UpdateTaskDto dto)
{
    var task = await _context.Tasks.FindAsync(id);
    task.Title = dto.Title;
    task.Description = dto.Description;
    
    await _context.SaveChangesAsync();
    return true;
}
```

**Use Code Actions for exception handling:**

1. **Select the database operations**
2. **Press `Ctrl+.` for Code Actions**
3. **Choose suggestions for:**
   - "Add try-catch for database operations"
   - "Handle entity not found"
   - "Add concurrency conflict handling"

**Expected Code Action Result:**
```csharp
public async Task<bool> UpdateTaskAsync(int id, UpdateTaskDto dto)
{
    try
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            _logger.LogWarning("Task with ID {TaskId} not found", id);
            return false;
        }

        // Validate input
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Title cannot be empty", nameof(dto.Title));

        task.Title = dto.Title.Trim();
        task.Description = dto.Description?.Trim() ?? string.Empty;
        task.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        _logger.LogInformation("Task {TaskId} updated successfully", id);
        return true;
    }
    catch (DbUpdateConcurrencyException ex)
    {
        _logger.LogError(ex, "Concurrency conflict updating task {TaskId}", id);
        throw new InvalidOperationException("Task was modified by another user", ex);
    }
    catch (DbUpdateException ex)
    {
        _logger.LogError(ex, "Database error updating task {TaskId}", id);
        throw new InvalidOperationException("Failed to update task due to database error", ex);
    }
}
```

### Step 4: Implement Async Best Practices with Code Actions ⚡

**Create async code that needs improvement:**

```csharp
public async Task<List<TaskItem>> GetUserTasksAsync(int userId)
{
    var user = _context.Users.Find(userId); // Sync call in async method
    if (user == null) return null;
    
    var tasks = _context.Tasks.Where(t => t.UserId == userId).ToList(); // Sync call
    return tasks;
}
```

**Use Code Actions to fix async issues:**

1. **Copilot will show warnings/suggestions**
2. **Press `Ctrl+.` on highlighted code**
3. **Choose fixes like:**
   - "Convert to async call"
   - "Add ConfigureAwait(false)"
   - "Fix async/await pattern"

**Code Action Result:**
```csharp
public async Task<List<TaskItem>?> GetUserTasksAsync(int userId, CancellationToken cancellationToken = default)
{
    if (userId <= 0)
        throw new ArgumentException("UserId must be greater than zero", nameof(userId));

    var user = await _context.Users.FindAsync(new object[] { userId }, cancellationToken)
        .ConfigureAwait(false);
    
    if (user == null)
    {
        _logger.LogInformation("User {UserId} not found", userId);
        return null;
    }
    
    var tasks = await _context.Tasks
        .Where(t => t.UserId == userId)
        .ToListAsync(cancellationToken)
        .ConfigureAwait(false);
    
    return tasks;
}
```

### Step 5: Add Comprehensive Error Boundaries 🚨

**Create a controller method needing error handling:**

```csharp
[HttpGet("{id}")]
public async Task<ActionResult<TaskDto>> GetTask(int id)
{
    var task = await _taskService.GetByIdAsync(id);
    var dto = _mapper.Map<TaskDto>(task);
    return Ok(dto);
}
```

**Use Code Actions for error boundaries:**

1. **Select the controller method**
2. **Apply Code Actions for:**
   - "Add error handling"
   - "Add response codes documentation"
   - "Add validation"

**Code Action Enhancement:**
```csharp
/// <summary>
/// Retrieves a specific task by ID
/// </summary>
/// <param name="id">The task ID</param>
/// <returns>The task details</returns>
/// <response code="200">Returns the task details</response>
/// <response code="400">Invalid task ID provided</response>
/// <response code="404">Task not found</response>
/// <response code="500">Internal server error</response>
[HttpGet("{id}")]
[ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public async Task<ActionResult<TaskDto>> GetTask(int id)
{
    if (id <= 0)
    {
        _logger.LogWarning("Invalid task ID provided: {TaskId}", id);
        return BadRequest(new { error = "Task ID must be greater than zero" });
    }

    try
    {
        var task = await _taskService.GetByIdAsync(id);
        if (task == null)
        {
            _logger.LogInformation("Task {TaskId} not found", id);
            return NotFound(new { error = $"Task with ID {id} not found" });
        }

        var dto = _mapper.Map<TaskDto>(task);
        return Ok(dto);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error retrieving task {TaskId}", id);
        return StatusCode(500, new { error = "An error occurred while retrieving the task" });
    }
}
```

### Step 6: Implement Defensive Programming Patterns 🛡️

**Create code that needs defensive programming:**

```csharp
public decimal CalculateCompletionRate(List<TaskItem> tasks)
{
    var completedTasks = tasks.Count(t => t.IsCompleted);
    return (decimal)completedTasks / tasks.Count * 100;
}
```

**Use Code Actions for defensive patterns:**

1. **Code Actions will suggest:**
   - "Add null checks"
   - "Handle division by zero"
   - "Add boundary checks"

**Defensive Code Result:**
```csharp
public decimal CalculateCompletionRate(List<TaskItem>? tasks)
{
    // Defensive check for null collection
    if (tasks == null)
    {
        _logger.LogWarning("Null task collection provided to CalculateCompletionRate");
        return 0m;
    }

    // Defensive check for empty collection
    if (tasks.Count == 0)
    {
        _logger.LogInformation("Empty task collection provided to CalculateCompletionRate");
        return 0m;
    }

    try
    {
        var completedTasks = tasks.Count(t => t?.IsCompleted == true);
        var completionRate = (decimal)completedTasks / tasks.Count * 100;
        
        // Ensure rate is within expected bounds
        return Math.Max(0m, Math.Min(100m, completionRate));
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error calculating completion rate for {TaskCount} tasks", tasks.Count);
        return 0m;
    }
}
```

### Step 7: Add Circuit Breaker Pattern with Code Actions 🔌

**Create code that needs resilience patterns:**

```csharp
public async Task<string> GetExternalTaskDataAsync(int taskId)
{
    using var httpClient = new HttpClient();
    var response = await httpClient.GetAsync($"https://api.external.com/tasks/{taskId}");
    return await response.Content.ReadAsStringAsync();
}
```

**Use Code Actions for resilience:**

1. **Code Actions suggest:**
   - "Add retry pattern"
   - "Add timeout handling"
   - "Add circuit breaker"

**Enhanced Resilience Code:**
```csharp
public async Task<string?> GetExternalTaskDataAsync(int taskId, CancellationToken cancellationToken = default)
{
    const int maxRetries = 3;
    const int timeoutSeconds = 30;

    for (int attempt = 1; attempt <= maxRetries; attempt++)
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(timeoutSeconds);

            var response = await httpClient.GetAsync(
                $"https://api.external.com/tasks/{taskId}", 
                cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync(cancellationToken);
                _logger.LogInformation("Successfully retrieved external data for task {TaskId}", taskId);
                return content;
            }

            _logger.LogWarning("External API returned {StatusCode} for task {TaskId}, attempt {Attempt}",
                response.StatusCode, taskId, attempt);

            if (attempt == maxRetries)
                return null;

            // Exponential backoff
            await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)), cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error retrieving external data for task {TaskId}, attempt {Attempt}",
                taskId, attempt);
            
            if (attempt == maxRetries)
                throw;
        }
        catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
        {
            _logger.LogError(ex, "Timeout retrieving external data for task {TaskId}, attempt {Attempt}",
                taskId, attempt);
            
            if (attempt == maxRetries)
                return null;
        }
    }

    return null;
}
```

### Step 8: Implement Smart Caching with Code Actions 💾

**Create code that needs caching:**

```csharp
public async Task<List<TaskItem>> GetPopularTasksAsync()
{
    return await _context.Tasks
        .Where(t => t.IsCompleted)
        .OrderByDescending(t => t.CreatedAt)
        .Take(10)
        .ToListAsync();
}
```

**Use Code Actions for caching:**

1. **Code Actions suggest:**
   - "Add caching layer"
   - "Add cache invalidation"
   - "Add cache key management"

### Step 9: Advanced Error Handling Patterns 🔧

**Implement Result pattern with Code Actions:**

```csharp
// Code Actions can help create Result<T> pattern
public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T? Value { get; private set; }
    public string? Error { get; private set; }
    public Exception? Exception { get; private set; }

    private Result(T value)
    {
        IsSuccess = true;
        Value = value;
    }

    private Result(string error, Exception? exception = null)
    {
        IsSuccess = false;
        Error = error;
        Exception = exception;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(string error, Exception? exception = null) => new(error, exception);
}
```

### Step 10: Performance Monitoring with Code Actions 📊

**Add performance monitoring:**

```csharp
// Code Actions can suggest adding performance monitoring
public async Task<Result<TaskDto>> CreateTaskWithMonitoringAsync(CreateTaskDto dto)
{
    using var activity = _activitySource.StartActivity("CreateTask");
    var stopwatch = Stopwatch.StartNew();

    try
    {
        // Validation
        if (dto == null)
            return Result<TaskDto>.Failure("Task data is required");

        // Business logic
        var task = await _taskService.CreateAsync(dto);
        var taskDto = _mapper.Map<TaskDto>(task);

        // Success metrics
        _metrics.Counter("tasks_created_total").Add(1);
        _metrics.Histogram("task_creation_duration").Record(stopwatch.ElapsedMilliseconds);

        return Result<TaskDto>.Success(taskDto);
    }
    catch (Exception ex)
    {
        // Error metrics
        _metrics.Counter("task_creation_errors_total").Add(1);
        _logger.LogError(ex, "Error creating task");
        
        return Result<TaskDto>.Failure("Failed to create task", ex);
    }
    finally
    {
        stopwatch.Stop();
        activity?.SetTag("duration_ms", stopwatch.ElapsedMilliseconds);
    }
}
```

## ✅ Phase 6 Verification

**Test the implemented error handling:**

1. **Test edge cases:**
   - Null inputs
   - Invalid IDs
   - Empty collections
   - Network failures

2. **Verify error responses:**
   - Appropriate HTTP status codes
   - Meaningful error messages
   - Proper logging

3. **Performance testing:**
   - Measure improvement from caching
   - Verify timeout handling
   - Test retry mechanisms

## 🎉 What You've Learned

In this phase, you mastered:

- ✅ **Smart error detection** with proactive Code Actions
- ✅ **Input validation** with comprehensive edge case handling
- ✅ **Exception handling** with proper error boundaries
- ✅ **Async best practices** with cancellation and timeout support
- ✅ **Defensive programming** with null checks and boundary validation
- ✅ **Resilience patterns** with retry and circuit breaker logic
- ✅ **Performance monitoring** with metrics and observability

## 🧠 Code Actions Best Practices

### 1. **Proactive Error Handling**
- Always validate inputs at method boundaries
- Handle null references explicitly
- Implement proper exception boundaries

### 2. **Async Patterns**
- Use ConfigureAwait(false) in library code
- Implement cancellation token support
- Handle timeouts appropriately

### 3. **Defensive Programming**
- Check preconditions early
- Validate assumptions explicitly
- Handle edge cases gracefully

## 💡 Pro Tips for Code Actions

1. **Watch for light bulb indicators** - They show available actions
2. **Use keyboard shortcuts** - `Ctrl+.` for quick access
3. **Review suggestions carefully** - Understand what each action does
4. **Combine multiple actions** - Build comprehensive solutions
5. **Test edge cases** - Verify your error handling works

## 🔄 Common Code Action Patterns

### Error Handling Pattern:
```
1. Identify potential failure points
2. Apply Code Actions for validation
3. Add appropriate exception handling
4. Implement logging and monitoring
5. Test failure scenarios
```

### Performance Pattern:
```
1. Identify slow operations
2. Apply caching Code Actions
3. Add performance monitoring
4. Implement timeout handling
5. Test under load
```

**💡 Pro Tip**: Code Actions are proactive suggestions that appear as light bulbs in your editor. They anticipate problems and offer solutions before you even ask!

## 🎯 Next Phase

Ready for advanced code generation? In [Phase 07: Editor Completions](./phase07-editor-completions.md), you'll learn to build complete features with advanced multi-line suggestions! 🧠

---

**🏆 Error Handling Expert!** You've learned to implement robust error handling and edge cases with intelligent Code Actions. Your applications will now be much more resilient! 💡

[![➡️ Next: Phase 07 - Editor Completions](https://img.shields.io/badge/➡️-Next%3A%20Phase%2007%20Editor%20Completions-green?style=flat-square)](phase07-editor-completions.md)

