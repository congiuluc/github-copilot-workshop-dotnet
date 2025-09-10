# 🧠 Phase 07: Editor Completions - Advanced Multi-Line Suggestions
**🎯 GitHub Copilot Feature**: Complex code generation and intelligent pattern recognition

[![⬅️ Back to Workshop Home](https://img.shields.io/badge/⬅️-Back%20to%20Workshop%20Home-blue?style=flat-square)](../README.md) [![⬅️ Previous: Phase 06](https://img.shields.io/badge/⬅️-Previous%3A%20Phase%2006-lightgrey?style=flat-square)](phase06-code-actions.md)


## 🎯 Objective

Master GitHub Copilot's advanced editor completions to build complete features with intelligent multi-line suggestions. Learn to leverage AI-powered block completion, function generation, and comprehensive feature implementation.

## 📖 About Editor Completions

GitHub Copilot's Editor Completions provide powerful assistance:
- **Multi-line suggestions** - Complete code blocks and functions
- **Context-aware completions** - Understanding your project's patterns
- **Feature-level generation** - Building entire functionalities
- **Pattern recognition** - Learning from your codebase style
- **Intelligent file completions** - Suggesting complete file structures
- **API integration completions** - Understanding external dependencies

## 🛠️ What You'll Implement

In this phase, you'll build:
- ✅ Complete CRUD operations with advanced features
- ✅ Full authentication and authorization system
- ✅ Comprehensive search and filtering capabilities
- ✅ Advanced reporting and analytics features
- ✅ Real-time notifications system
- ✅ Complete API documentation and testing suite

## 📋 Step-by-Step Instructions

### Step 1: Enable Advanced Editor Completions 🧠

**Configure Copilot for maximum assistance:**

1. **Configure VS Code settings for optimal completions:**
   ```powershell
   # Open VS Code settings
   code --user-data-dir C:\tmp\copilot-settings
   # Or open settings via Ctrl+, and search for "Copilot"
   ```

2. **Enable advanced completion features:**
   - In VS Code: Settings → Extensions → GitHub Copilot
   - ✅ Enable "Copilot: Enable Auto Completions"
   - ✅ Enable "Copilot: Enable Multi-line Completions"
   - ✅ Set "Copilot: Advanced Settings" to maximum assistance

3. **Learn completion navigation shortcuts:**
   - `Tab` - Accept full multi-line suggestions
   - `Alt+]` and `Alt+[` - Cycle through alternative suggestions
   - `Ctrl+→` - Accept word-by-word (partial acceptance)
   - `Escape` - Dismiss current suggestion
   - `Ctrl+Enter` - Open Copilot suggestions panel

4. **Context building techniques:**
   - Write descriptive comments before coding
   - Use meaningful variable and method names
   - Maintain consistent patterns in your codebase
   - Include relevant imports and dependencies

---

### Step 2: Build Complete Authentication System 🔐

**Start with a comment to guide Copilot:**

1. **Create authentication interfaces directory:**
   - Right-click the `src\TaskManagement.API\Services` folder in VS Code Explorer
   - Select "New Folder"
   - Name it `Authentication`
   - Right-click the `src\TaskManagement.API` folder
   - Select "New Folder"
   - Name it `Interfaces`
   - Right-click the `Interfaces` folder
   - Select "New Folder"
   - Name it `Authentication`

2. **Create authentication service interface file:**
   - Right-click the `Interfaces\Authentication` folder
   - Select "New File"
   - Name it `IAuthenticationService.cs`

3. **Open the interface file and start with this descriptive comment:**

3. **Open the interface file and start with this descriptive comment:**
   ```csharp
   // Create a complete authentication service interface with comprehensive features:
   // - JWT token generation and validation with refresh tokens
   // - Password hashing using BCrypt with salt
   // - User registration with email verification
   // - Login with remember me functionality
   // - Password reset with secure token generation
   // - Role-based access control with claims
   // - Two-factor authentication support
   // - Account lockout after failed attempts
   // - Session management and logout
   // - User profile management and updates
   ```

4. **Position cursor after the comment and press Tab to accept Copilot's suggestions:**
   - Let Copilot generate the complete interface definition
   - Review and accept the suggested method signatures
   - Look for comprehensive authentication methods

5. **Expected interface structure from Copilot:**
   ```csharp
   using TaskManagement.API.DTOs.Authentication;
   using TaskManagement.API.Models;
   
   namespace TaskManagement.API.Interfaces.Authentication;
   
   public interface IAuthenticationService
   {
       Task<AuthenticationResult> RegisterAsync(RegisterDto registerDto);
       Task<AuthenticationResult> LoginAsync(LoginDto loginDto);
       Task<AuthenticationResult> RefreshTokenAsync(string refreshToken);
       Task<bool> LogoutAsync(string userId);
       Task<bool> VerifyEmailAsync(string token);
       Task<bool> ForgotPasswordAsync(string email);
       Task<bool> ResetPasswordAsync(ResetPasswordDto resetDto);
       Task<bool> ChangePasswordAsync(string userId, ChangePasswordDto changeDto);
       Task<bool> EnableTwoFactorAsync(string userId);
       Task<bool> VerifyTwoFactorAsync(string userId, string code);
   }
   ```

6. **Create authentication DTOs:**
   - Right-click the `src\TaskManagement.API` folder in VS Code Explorer
   - Select "New Folder"
   - Name it `DTOs`
   - Right-click the `DTOs` folder
   - Select "New Folder"
   - Name it `Authentication`
   - Right-click the `Authentication` folder and create these files:
     - `RegisterDto.cs`
     - `LoginDto.cs`
     - `AuthenticationResult.cs`

7. **Let Copilot generate DTOs with this approach:**
   - Open each DTO file
   - Start with a descriptive comment about the DTO's purpose
   - Let Copilot suggest complete DTO implementations

8. **Create the authentication service implementation:**
   - Right-click the `Services\Authentication` folder
   - Select "New File"
   - Name it `AuthenticationService.cs`

9. **Let Copilot generate the complete implementation:**
   - Open the AuthenticationService.cs file
   - Start with this comprehensive comment to guide Copilot:
   ```csharp
   // Complete authentication service implementation with:
   // - Constructor injection for UserManager, SignInManager, IConfiguration, IEmailService, ILogger, ITokenService
   // - RegisterAsync method with email verification, password validation, and user creation
   // - LoginAsync method with credential validation, account lockout, and JWT token generation
   // - RefreshTokenAsync method with token validation and new token generation
   // - Password reset functionality with secure token generation and email sending
   // - Two-factor authentication with TOTP support
   // - Comprehensive error handling and logging
   // - Role management and claims handling
   ```

10. **Accept Copilot's implementation and verify:**
    - Open VS Code terminal (View → Terminal or `Ctrl+` `)
    - Type: `dotnet build .\src\TaskManagement.API\` and press Enter

---

### Step 3: Build Advanced Search and Filtering 🔍

**Create comprehensive search functionality:**

1. **Create search interfaces:**
   - Right-click the `Services` folder
   - Select "New Folder"
   - Name it `Search`
   - Right-click the `Interfaces` folder
   - Select "New Folder" 
   - Name it `Search`
   - Right-click the `Interfaces\Search` folder
   - Select "New File"
   - Name it `ISearchService.cs`
   - Right-click the `DTOs` folder
   - Select "New Folder"
   - Name it `Search`

2. **Guide Copilot with comprehensive search requirements:**
   ```csharp
   // Create advanced search service with comprehensive filtering capabilities:
   // - Full-text search across task titles and descriptions using SQL Server Full-Text Search
   // - Advanced filtering by priority, status, date ranges, user assignments
   // - Faceted search with aggregation counts for each filter category
   // - Sorting by relevance, date, priority, and custom criteria
   // - Pagination with cursor-based navigation for large result sets
   // - Auto-complete suggestions for search terms
   // - Search history and saved searches for users
   // - Real-time search results with debouncing
   // - Search analytics and popular queries tracking
   // - Elasticsearch integration for enterprise-level search
   ```

3. **Let Copilot generate search interface:**
   - Position cursor after the comment
   - Press Tab to accept Copilot's suggested interface
   - Look for comprehensive search methods

4. **Expected search interface from Copilot:**
   ```csharp
   public interface ISearchService
   {
       Task<SearchResult<TaskDto>> SearchTasksAsync(SearchRequest request);
       Task<List<string>> GetAutoCompleteAsync(string query, int maxResults = 10);
       Task<SearchFacets> GetSearchFacetsAsync(string query = "");
       Task<List<SearchSuggestion>> GetSearchSuggestionsAsync(string userId);
       Task SaveSearchAsync(string userId, SavedSearch search);
       Task<SearchAnalytics> GetSearchAnalyticsAsync(DateTime from, DateTime to);
   }
   ```

5. **Create search implementation with Copilot:**
   - Right-click the `Services\Search` folder
   - Select "New File"
   - Name it `SearchService.cs`

6. **Guide Copilot for implementation:**
   - Start with comprehensive comment about search implementation
   - Include requirements for performance, caching, and scalability
   - Let Copilot generate the complete service with all methods

---

### Step 4: Build Real-time Notifications System 🔔

**Create comprehensive notification system:**

1. **Create notification infrastructure:**
   
   **Using VS Code Explorer:**
   - Right-click on `src\TaskManagement.API` → New Folder → `Services`
   - Right-click on `Services` → New Folder → `Notifications`
   - Right-click on `src\TaskManagement.API` → New Folder → `Hubs`
   - Right-click on `src\TaskManagement.API` → New Folder → `Interfaces`
   - Right-click on `Interfaces` → New Folder → `Notifications`
   - Right-click on `Notifications` → New File → `INotificationService.cs`

2. **Guide Copilot with notification requirements:**
   ```csharp
   // Create comprehensive real-time notification system with:
   // - SignalR hub for real-time browser notifications
   // - Email notifications with HTML templates and attachments
   // - SMS notifications using Twilio or similar service
   // - Push notifications for mobile apps using Firebase
   // - In-app notification center with read/unread status
   // - Notification preferences and delivery settings per user
   // - Notification templates with dynamic content
   // - Batch processing for bulk notifications
   // - Notification delivery status tracking and retry logic
   // - Integration with external notification services
   // - Notification analytics and engagement metrics
   ```

3. **Let Copilot generate notification interfaces and implementations:**
   - Create INotificationService interface with comprehensive methods
   - Generate NotificationHub for SignalR real-time functionality
   - Build EmailNotificationService for email delivery
   - Create NotificationTemplateService for template management

4. **Create SignalR Hub with Copilot:**
   
   **Using VS Code Explorer:**
   - Right-click on `Hubs` folder → New File → `NotificationHub.cs`

5. **Guide Copilot for SignalR implementation:**
   ```csharp
   // SignalR hub for real-time notifications with:
   // - Connection management and user grouping
   // - Authentication and authorization
   // - Message broadcasting to specific users or groups
   // - Connection state management and reconnection handling
   // - Rate limiting and throttling
   // - Message queuing for offline users
   ```

---

### Step 5: Build Advanced Reporting and Analytics 📊

**Create comprehensive reporting system:**

1. **Create reporting infrastructure:**
   
   **Using VS Code Explorer:**
   - Right-click on `Services` folder → New Folder → `Reporting`
   - Right-click on `Interfaces` folder → New Folder → `Reporting`
   - Right-click on `Interfaces\Reporting` → New File → `IReportingService.cs`
   - Right-click on `src\TaskManagement.API` → New Folder → `DTOs`
   - Right-click on `DTOs` → New Folder → `Reporting`

2. **Guide Copilot with reporting requirements:**
   ```csharp
   // Create advanced reporting and analytics service with:
   // - Dashboard metrics with real-time updates (tasks completed, productivity scores)
   // - Time-series analytics for trend analysis and forecasting
   // - User productivity reports with comparative analysis
   // - Team performance dashboards with collaboration metrics
   // - Custom report builder with drag-and-drop interface
   // - Data export in multiple formats (PDF, Excel, CSV, JSON)
   // - Scheduled report generation and email delivery
   // - Report caching and performance optimization
   // - Advanced filtering and grouping capabilities
   // - Chart generation with multiple visualization types
   // - Drill-down capabilities for detailed analysis
   ```

3. **Let Copilot generate reporting interfaces:**
   - Accept comprehensive interface with analytics methods
   - Include dashboard, reports, and export functionality
   - Add caching and performance optimization methods

4. **Create report models and DTOs:**
   
   **Using VS Code Explorer:**
   - Right-click on `DTOs\Reporting` → New File → `DashboardMetrics.cs`
   - Right-click on `DTOs\Reporting` → New File → `ProductivityReport.cs`
   - Right-click on `DTOs\Reporting` → New File → `TeamPerformance.cs`

---

### Step 6: Build Complete API Documentation 📚

**Generate comprehensive API documentation:**

1. **Install Swagger/OpenAPI packages:**
   ```powershell
   # Add comprehensive API documentation packages
   dotnet add .\src\TaskManagement.API\ package Swashbuckle.AspNetCore
   dotnet add .\src\TaskManagement.API\ package Swashbuckle.AspNetCore.Annotations
   dotnet add .\src\TaskManagement.API\ package Swashbuckle.AspNetCore.Filters
   ```

2. **Guide Copilot for Swagger configuration:**
   ```csharp
   // Configure comprehensive Swagger documentation with:
   // - Detailed API descriptions and examples
   // - Authentication schemes (JWT Bearer, API Key)
   // - Request/response models with validation attributes
   // - Error response documentation with status codes
   // - API versioning support and deprecation notices
   // - Interactive testing interface with auth token input
   // - Code generation support for client SDKs
   // - Custom themes and branding
   // - Performance metrics and response times
   // - Rate limiting documentation
   ```

3. **Let Copilot generate Swagger configuration:**
   - Add to Program.cs or Startup.cs
   - Include comprehensive documentation setup
   - Add authentication configuration

4. **Enhance controllers with documentation:**
   ```powershell
   # Open existing controllers to add documentation
   code .\src\TaskManagement.API\Controllers\TaskController.cs
   ```

5. **Guide Copilot for controller documentation:**
   ```csharp
   // Add comprehensive API documentation attributes to all controller methods:
   // - [HttpGet] with route patterns and parameter descriptions
   // - [ProducesResponseType] for all possible response codes
   // - [SwaggerOperation] with detailed summaries and descriptions
   // - [SwaggerResponse] with example responses
   // - Parameter validation attributes and descriptions
   // - Authorization requirements documentation
   ```

---

### Step 7: Build Performance Monitoring 📈

**Create comprehensive performance monitoring:**

1. **Create monitoring infrastructure:**
   
   **Using VS Code Explorer:**
   - Right-click on `Services` folder → New Folder → `Monitoring`
   - Right-click on `Interfaces` folder → New Folder → `Monitoring`
   - Right-click on `Interfaces\Monitoring` → New File → `IPerformanceMonitor.cs`

2. **Guide Copilot for monitoring service:**
   ```csharp
   // Create comprehensive performance monitoring service with:
   // - Application metrics collection (response times, throughput, error rates)
   // - Database performance monitoring with query analysis
   // - Memory usage tracking and garbage collection metrics
   // - Custom business metrics (tasks created/completed per hour)
   // - Health checks for dependencies (database, external APIs)
   // - Alert thresholds and notification triggers
   // - Performance baseline tracking and anomaly detection
   // - Real-time dashboards with charts and graphs
   // - Historical data storage and trend analysis
   // - Integration with Application Insights or similar APM tools
   ```

3. **Let Copilot generate monitoring implementation:**
   - Accept comprehensive interface and implementation
   - Include metrics collection and alerting
   - Add dashboard and reporting capabilities

---

### Step 8: Build Integration Testing Suite 🧪

**Create comprehensive integration tests:**

1. **Guide Copilot for integration test setup:**
   ```csharp
   // Create comprehensive integration test suite with:
   // - TestServer setup with in-memory database
   // - Authentication test scenarios with JWT tokens
   // - API endpoint testing with various scenarios
   // - Database integration tests with real data
   // - External service mocking and testing
   // - Performance testing with load scenarios
   // - End-to-end workflow testing
   // - Error handling and edge case testing
   // - Test data factories and builders
   // - Parallel test execution and isolation
   ```

2. **Let Copilot generate complete test classes:**
   - Create test infrastructure with TestServer
   - Generate comprehensive test methods
   - Include authentication and authorization tests

3. **Verify all implementations:**
   ```powershell
   # Build entire solution to verify all generated code
   dotnet build .\src\TaskManagement.API\
   
   # Run tests to verify integration
   dotnet test .\tests\ --verbosity normal
   ```
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        IEmailService emailService,
        ILogger<AuthenticationService> logger,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _emailService = emailService;
        _logger = logger;
        _tokenService = tokenService;
    }

    public async Task<AuthResult> RegisterAsync(RegisterDto dto)
    {
        try
        {
            // Check if user already exists
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Errors = { "User with this email already exists" }
                };
            }

            // Create new user
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CreatedAt = DateTime.UtcNow,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return new AuthResult
                {
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            // Assign default role
            await _userManager.AddToRoleAsync(user, "User");

            // Generate email verification token
            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await _emailService.SendEmailVerificationAsync(user.Email, user.Id, emailToken);

            _logger.LogInformation("User {Email} registered successfully", dto.Email);

            return new AuthResult
            {
                IsSuccess = true,
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during user registration for {Email}", dto.Email);
            return new AuthResult
            {
                IsSuccess = false,
                Errors = { "An error occurred during registration" }
            };
        }
    }

    // Copilot will continue with other methods...
    public async Task<AuthResult> LoginAsync(LoginDto dto)
    {
        // Complete login implementation with JWT generation
        // Email verification checks, account lockout handling
        // Two-factor authentication support, etc.
    }
}
```

### Step 3: Build Advanced Search and Filtering System 🔍

**Create a comment to guide the advanced search:**

```csharp
// Create a comprehensive search service with full-text search,
// advanced filtering, sorting, pagination, faceted search,
// search suggestions, and analytics tracking
```

**Let Copilot build the complete search interface and implementation:**

```csharp
public interface ISearchService
{
    Task<SearchResult<TaskDto>> SearchTasksAsync(SearchRequest request);
    Task<SearchResult<UserDto>> SearchUsersAsync(SearchRequest request);
    Task<List<SearchSuggestion>> GetSearchSuggestionsAsync(string query, SearchType type);
    Task<SearchAnalytics> GetSearchAnalyticsAsync(DateTime from, DateTime to);
    Task<List<string>> GetPopularSearchTermsAsync(int count = 10);
    Task<bool> TrackSearchAsync(string query, string userId, SearchType type);
}

public class SearchService : ISearchService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SearchService> _logger;
    private readonly IMemoryCache _cache;
    private readonly IElasticsearchClient _elasticsearchClient;

    public async Task<SearchResult<TaskDto>> SearchTasksAsync(SearchRequest request)
    {
        try
        {
            var query = _context.Tasks.AsQueryable();

            // Full-text search
            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                query = query.Where(t => 
                    EF.Functions.Contains(t.Title, request.Query) ||
                    EF.Functions.Contains(t.Description, request.Query) ||
                    t.Tags.Any(tag => EF.Functions.Contains(tag.Name, request.Query)));
            }

            // Advanced filters
            if (request.Filters?.Any() == true)
            {
                foreach (var filter in request.Filters)
                {
                    query = filter.Field switch
                    {
                        "priority" => query.Where(t => filter.Values.Contains(t.Priority.ToString())),
                        "status" => query.Where(t => filter.Values.Contains(t.Status.ToString())),
                        "assignee" => query.Where(t => filter.Values.Contains(t.AssigneeId.ToString())),
                        "dueDate" => ApplyDateFilter(query, filter),
                        "createdBy" => query.Where(t => filter.Values.Contains(t.CreatedBy.ToString())),
                        _ => query
                    };
                }
            }

            // Date range filter
            if (request.DateFrom.HasValue)
                query = query.Where(t => t.CreatedAt >= request.DateFrom.Value);
            
            if (request.DateTo.HasValue)
                query = query.Where(t => t.CreatedAt <= request.DateTo.Value);

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply sorting
            query = request.SortBy switch
            {
                "title" => request.SortDirection == "desc" 
                    ? query.OrderByDescending(t => t.Title)
                    : query.OrderBy(t => t.Title),
                "priority" => request.SortDirection == "desc"
                    ? query.OrderByDescending(t => t.Priority)
                    : query.OrderBy(t => t.Priority),
                "dueDate" => request.SortDirection == "desc"
                    ? query.OrderByDescending(t => t.DueDate)
                    : query.OrderBy(t => t.DueDate),
                "createdAt" => request.SortDirection == "desc"
                    ? query.OrderByDescending(t => t.CreatedAt)
                    : query.OrderBy(t => t.CreatedAt),
                _ => query.OrderByDescending(t => t.CreatedAt)
            };

            // Apply pagination
            var tasks = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(t => t.Tags)
                .Include(t => t.Assignee)
                .Include(t => t.Creator)
                .ToListAsync();

            // Map to DTOs
            var taskDtos = tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Priority = t.Priority,
                Status = t.Status,
                DueDate = t.DueDate,
                CreatedAt = t.CreatedAt,
                AssigneeName = t.Assignee?.FirstName + " " + t.Assignee?.LastName,
                CreatorName = t.Creator?.FirstName + " " + t.Creator?.LastName,
                Tags = t.Tags?.Select(tag => tag.Name).ToList() ?? new List<string>()
            }).ToList();

            // Build facets for advanced filtering UI
            var facets = await BuildSearchFacetsAsync(request.Query);

            // Track the search
            await TrackSearchAsync(request.Query ?? "", request.UserId ?? "", SearchType.Tasks);

            return new SearchResult<TaskDto>
            {
                Items = taskDtos,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize),
                Facets = facets,
                SearchTime = DateTime.UtcNow
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching tasks with query: {Query}", request.Query);
            throw;
        }
    }

    private async Task<List<SearchFacet>> BuildSearchFacetsAsync(string? query)
    {
        // Build facets for filtering UI
        var facets = new List<SearchFacet>();

        // Priority facet
        var priorityFacet = await _context.Tasks
            .GroupBy(t => t.Priority)
            .Select(g => new SearchFacetItem 
            { 
                Value = g.Key.ToString(), 
                Count = g.Count(),
                Label = g.Key.ToString()
            })
            .ToListAsync();

        facets.Add(new SearchFacet
        {
            Field = "priority",
            Label = "Priority",
            Items = priorityFacet
        });

        // Status facet
        var statusFacet = await _context.Tasks
            .GroupBy(t => t.Status)
            .Select(g => new SearchFacetItem
            {
                Value = g.Key.ToString(),
                Count = g.Count(),
                Label = g.Key.ToString()
            })
            .ToListAsync();

        facets.Add(new SearchFacet
        {
            Field = "status",
            Label = "Status",
            Items = statusFacet
        });

        return facets;
    }
}
```

### Step 4: Build Real-Time Notifications System 📲

**Comment to guide Copilot:**

```csharp
// Create a complete real-time notification system with SignalR,
// email notifications, push notifications, notification preferences,
// notification history, and delivery tracking
```

**Complete notification system:**

```csharp
public interface INotificationService
{
    Task SendNotificationAsync(NotificationRequest request);
    Task SendBulkNotificationAsync(BulkNotificationRequest request);
    Task<List<NotificationDto>> GetUserNotificationsAsync(string userId, int page = 1, int pageSize = 20);
    Task<bool> MarkAsReadAsync(string userId, int notificationId);
    Task<bool> MarkAllAsReadAsync(string userId);
    Task<NotificationPreferences> GetNotificationPreferencesAsync(string userId);
    Task<bool> UpdateNotificationPreferencesAsync(string userId, NotificationPreferences preferences);
    Task<NotificationStats> GetNotificationStatsAsync(string userId);
}

[Route("api/[controller]")]
[Authorize]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IHubContext<NotificationHub> _hubContext;

    [HttpGet]
    public async Task<ActionResult<PagedResult<NotificationDto>>> GetNotifications(
        [FromQuery] int page = 1, 
        [FromQuery] int pageSize = 20)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var notifications = await _notificationService.GetUserNotificationsAsync(userId!, page, pageSize);
        
        return Ok(new PagedResult<NotificationDto>
        {
            Items = notifications,
            Page = page,
            PageSize = pageSize,
            TotalCount = notifications.Count
        });
    }

    [HttpPost("{id}/read")]
    public async Task<ActionResult> MarkAsRead(int id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await _notificationService.MarkAsReadAsync(userId!, id);
        
        if (!result)
            return NotFound();

        // Send real-time update
        await _hubContext.Clients.User(userId!).SendAsync("NotificationRead", id);
        
        return Ok();
    }

    [HttpPost("read-all")]
    public async Task<ActionResult> MarkAllAsRead()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        await _notificationService.MarkAllAsReadAsync(userId!);
        
        // Send real-time update
        await _hubContext.Clients.User(userId!).SendAsync("AllNotificationsRead");
        
        return Ok();
    }
}

// SignalR Hub for real-time notifications
public class NotificationHub : Hub
{
    private readonly ILogger<NotificationHub> _logger;

    public NotificationHub(ILogger<NotificationHub> logger)
    {
        _logger = logger;
    }

    public async Task JoinNotificationGroup(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"notifications_{userId}");
        _logger.LogInformation("User {UserId} joined notification group", userId);
    }

    public async Task LeaveNotificationGroup(string userId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"notifications_{userId}");
        _logger.LogInformation("User {UserId} left notification group", userId);
    }

    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"notifications_{userId}");
        }
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"notifications_{userId}");
        }
        await base.OnDisconnectedAsync(exception);
    }
}
```

### Step 5: Build Advanced Reporting and Analytics 📊

**Guide Copilot with comprehensive reporting requirements:**

```csharp
// Create a complete reporting and analytics system with 
// dashboard data, custom reports, data export, charts,
// KPI tracking, trend analysis, and scheduled reports
```

**Complete analytics service:**

```csharp
public interface IAnalyticsService
{
    Task<DashboardData> GetDashboardDataAsync(string userId, DateRange dateRange);
    Task<List<ChartData>> GetTaskCompletionTrendAsync(DateRange dateRange);
    Task<List<ChartData>> GetUserProductivityAsync(DateRange dateRange);
    Task<List<ChartData>> GetPriorityDistributionAsync(DateRange dateRange);
    Task<ReportData> GenerateCustomReportAsync(ReportRequest request);
    Task<byte[]> ExportReportAsync(ReportRequest request, ExportFormat format);
    Task<List<KpiMetric>> GetKpiMetricsAsync(string userId, DateRange dateRange);
}

public class AnalyticsService : IAnalyticsService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AnalyticsService> _logger;
    private readonly IMemoryCache _cache;

    public async Task<DashboardData> GetDashboardDataAsync(string userId, DateRange dateRange)
    {
        var cacheKey = $"dashboard_{userId}_{dateRange.From:yyyyMMdd}_{dateRange.To:yyyyMMdd}";
        
        if (_cache.TryGetValue(cacheKey, out DashboardData? cachedData))
            return cachedData!;

        try
        {
            var tasks = await _context.Tasks
                .Where(t => t.CreatedAt >= dateRange.From && t.CreatedAt <= dateRange.To)
                .ToListAsync();

            var dashboardData = new DashboardData
            {
                TotalTasks = tasks.Count,
                CompletedTasks = tasks.Count(t => t.IsCompleted),
                PendingTasks = tasks.Count(t => !t.IsCompleted),
                OverdueTasks = tasks.Count(t => !t.IsCompleted && t.DueDate < DateTime.UtcNow),
                
                CompletionRate = tasks.Count > 0 
                    ? (decimal)tasks.Count(t => t.IsCompleted) / tasks.Count * 100 
                    : 0,

                AverageCompletionTime = await CalculateAverageCompletionTimeAsync(dateRange),
                
                TasksByPriority = tasks
                    .GroupBy(t => t.Priority)
                    .ToDictionary(g => g.Key.ToString(), g => g.Count()),

                TasksByStatus = tasks
                    .GroupBy(t => t.Status)
                    .ToDictionary(g => g.Key.ToString(), g => g.Count()),

                RecentActivity = await GetRecentActivityAsync(userId, 10),
                
                TopPerformers = await GetTopPerformersAsync(dateRange, 5),
                
                TrendData = await GetTaskCompletionTrendAsync(dateRange)
            };

            _cache.Set(cacheKey, dashboardData, TimeSpan.FromMinutes(15));
            return dashboardData;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating dashboard data for user {UserId}", userId);
            throw;
        }
    }

    public async Task<List<ChartData>> GetTaskCompletionTrendAsync(DateRange dateRange)
    {
        var data = await _context.Tasks
            .Where(t => t.CreatedAt >= dateRange.From && t.CreatedAt <= dateRange.To)
            .GroupBy(t => t.CreatedAt.Date)
            .Select(g => new ChartData
            {
                Label = g.Key.ToString("yyyy-MM-dd"),
                Value = g.Count(),
                SecondaryValue = g.Count(t => t.IsCompleted),
                Category = "Daily"
            })
            .OrderBy(x => x.Label)
            .ToListAsync();

        return data;
    }

    private async Task<TimeSpan> CalculateAverageCompletionTimeAsync(DateRange dateRange)
    {
        var completedTasks = await _context.Tasks
            .Where(t => t.IsCompleted && 
                       t.CreatedAt >= dateRange.From && 
                       t.CreatedAt <= dateRange.To &&
                       t.CompletedAt.HasValue)
            .Select(t => new { t.CreatedAt, t.CompletedAt })
            .ToListAsync();

        if (!completedTasks.Any())
            return TimeSpan.Zero;

        var totalTime = completedTasks
            .Sum(t => (t.CompletedAt!.Value - t.CreatedAt).TotalMinutes);

        return TimeSpan.FromMinutes(totalTime / completedTasks.Count);
    }
}
```

### Step 6: Build Complete API Documentation System 📚

**Let Copilot generate comprehensive API documentation:**

```csharp
// Create complete API documentation with Swagger, examples,
// response models, error codes, authentication details,
// rate limiting info, and interactive testing
```

**Complete API documentation setup:**

```csharp
public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Task Management API",
                Version = "v1.0",
                Description = "A comprehensive task management system with advanced features",
                Contact = new OpenApiContact
                {
                    Name = "API Support",
                    Email = "support@taskmanagement.com",
                    Url = new Uri("https://taskmanagement.com/support")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });

            // Add JWT Authentication
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });

            // Include XML documentation
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            // Add examples
            options.SchemaFilter<ExampleSchemaFilter>();
            options.OperationFilter<ExampleOperationFilter>();
        });

        return services;
    }
}

// Example schema filter
public class ExampleSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(CreateTaskDto))
        {
            schema.Example = new OpenApiObject
            {
                ["title"] = new OpenApiString("Complete project documentation"),
                ["description"] = new OpenApiString("Write comprehensive API documentation with examples"),
                ["priority"] = new OpenApiString("High"),
                ["dueDate"] = new OpenApiString("2024-12-31T23:59:59Z"),
                ["assigneeId"] = new OpenApiInteger(1),
                ["tags"] = new OpenApiArray
                {
                    new OpenApiString("documentation"),
                    new OpenApiString("api")
                }
            };
        }
    }
}
```

### Step 7: Implement Advanced Caching Strategy 💾

**Comment for comprehensive caching:**

```csharp
// Implement advanced caching strategy with Redis, in-memory caching,
// cache invalidation, cache warming, distributed caching,
// cache-aside pattern, and performance monitoring
```

**Complete caching implementation:**

```csharp
public interface ICacheService
{
    Task<T?> GetAsync<T>(string key) where T : class;
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null) where T : class;
    Task RemoveAsync(string key);
    Task RemovePatternAsync(string pattern);
    Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> getItem, TimeSpan? expiration = null) where T : class;
    Task InvalidateTagAsync(string tag);
    Task WarmCacheAsync();
}

public class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CacheService> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    public async Task<T?> GetAsync<T>(string key) where T : class
    {
        try
        {
            // Try memory cache first
            if (_memoryCache.TryGetValue(key, out T? memoryCachedItem))
            {
                _logger.LogDebug("Cache hit (memory): {Key}", key);
                return memoryCachedItem;
            }

            // Try distributed cache
            var distributedValue = await _distributedCache.GetStringAsync(key);
            if (!string.IsNullOrEmpty(distributedValue))
            {
                var item = JsonSerializer.Deserialize<T>(distributedValue, _jsonOptions);
                
                // Store in memory cache for faster access
                _memoryCache.Set(key, item, TimeSpan.FromMinutes(5));
                
                _logger.LogDebug("Cache hit (distributed): {Key}", key);
                return item;
            }

            _logger.LogDebug("Cache miss: {Key}", key);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving from cache: {Key}", key);
            return null;
        }
    }

    public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> getItem, TimeSpan? expiration = null) where T : class
    {
        var cachedItem = await GetAsync<T>(key);
        if (cachedItem != null)
            return cachedItem;

        var item = await getItem();
        if (item != null)
        {
            await SetAsync(key, item, expiration);
        }

        return item;
    }

    public async Task WarmCacheAsync()
    {
        _logger.LogInformation("Starting cache warming...");

        var warmupTasks = new List<Task>
        {
            WarmDashboardDataAsync(),
            WarmPopularTasksAsync(),
            WarmUserStatisticsAsync(),
            WarmSystemConfigurationAsync()
        };

        await Task.WhenAll(warmupTasks);
        _logger.LogInformation("Cache warming completed");
    }

    private async Task WarmDashboardDataAsync()
    {
        // Pre-load dashboard data for active users
        // Implementation details...
    }
}
```

### Step 8: Build Complete Testing Suite 🧪

**Let Copilot generate comprehensive tests:**

```csharp
// Create comprehensive testing suite with unit tests, integration tests,
// performance tests, API tests, security tests, and test data builders
```

**Complete test implementation:**

```csharp
public class TaskServiceTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly Mock<ILogger<TaskService>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly TaskService _taskService;

    public TaskServiceTests()
    {
        _mockContext = new Mock<ApplicationDbContext>();
        _mockLogger = new Mock<ILogger<TaskService>>();
        _mockMapper = new Mock<IMapper>();
        _taskService = new TaskService(_mockContext.Object, _mockLogger.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateTaskAsync_WithValidData_ShouldReturnSuccess()
    {
        // Arrange
        var createDto = TaskTestData.CreateValidCreateTaskDto();
        var expectedTask = TaskTestData.CreateValidTask();
        var expectedDto = TaskTestData.CreateValidTaskDto();

        _mockMapper.Setup(m => m.Map<TaskItem>(createDto)).Returns(expectedTask);
        _mockMapper.Setup(m => m.Map<TaskDto>(expectedTask)).Returns(expectedDto);
        
        var mockSet = CreateMockDbSet(new List<TaskItem>());
        _mockContext.Setup(c => c.Tasks).Returns(mockSet.Object);
        _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

        // Act
        var result = await _taskService.CreateTaskAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedDto);
        
        mockSet.Verify(m => m.Add(It.IsAny<TaskItem>()), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CreateTaskAsync_WithInvalidTitle_ShouldReturnFailure(string invalidTitle)
    {
        // Arrange
        var createDto = TaskTestData.CreateValidCreateTaskDto();
        createDto.Title = invalidTitle;

        // Act
        var result = await _taskService.CreateTaskAsync(createDto);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().Contain("Title is required");
    }

    private Mock<DbSet<T>> CreateMockDbSet<T>(List<T> data) where T : class
    {
        var queryable = data.AsQueryable();
        var mockSet = new Mock<DbSet<T>>();
        
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
        
        return mockSet;
    }
}

// Test data builders
public static class TaskTestData
{
    public static CreateTaskDto CreateValidCreateTaskDto() => new()
    {
        Title = "Test Task",
        Description = "Test Description",
        Priority = TaskPriority.Medium,
        DueDate = DateTime.UtcNow.AddDays(7),
        AssigneeId = 1,
        Tags = new[] { "test", "example" }
    };

    public static TaskItem CreateValidTask() => new()
    {
        Id = 1,
        Title = "Test Task",
        Description = "Test Description",
        Priority = TaskPriority.Medium,
        Status = TaskStatus.New,
        CreatedAt = DateTime.UtcNow,
        DueDate = DateTime.UtcNow.AddDays(7),
        AssigneeId = 1,
        CreatedBy = 1
    };

    public static TaskDto CreateValidTaskDto() => new()
    {
        Id = 1,
        Title = "Test Task",
        Description = "Test Description",
        Priority = TaskPriority.Medium,
        Status = TaskStatus.New,
        CreatedAt = DateTime.UtcNow,
        DueDate = DateTime.UtcNow.AddDays(7)
    };
}
```

## ✅ Phase 7 Verification

**Test the complete features:**

1. **Authentication System:**
   - Test user registration and login
   - Verify JWT token generation
   - Test role-based access control

2. **Search and Filtering:**
   - Test full-text search functionality
   - Verify advanced filtering options
   - Test pagination and sorting

3. **Real-time Notifications:**
   - Test SignalR connections
   - Verify notification delivery
   - Test notification preferences

4. **Analytics and Reporting:**
   - Generate dashboard data
   - Test custom reports
   - Verify data export functionality

## 🎉 What You've Learned

In this phase, you mastered:

- ✅ **Complete feature generation** with multi-line suggestions
- ✅ **Complex service implementations** with proper patterns
- ✅ **Advanced system architecture** with multiple components
- ✅ **Real-time functionality** with SignalR integration
- ✅ **Comprehensive testing** with various test types
- ✅ **Performance optimization** with advanced caching
- ✅ **Complete API documentation** with interactive examples

## 🧠 Editor Completions Best Practices

### 1. **Effective Prompting**
```
1. Write descriptive comments
2. Use meaningful variable names
3. Follow consistent patterns
4. Provide context clues
```

### 2. **Pattern Recognition**
```
1. Establish coding patterns early
2. Use consistent naming conventions
3. Follow architectural principles
4. Maintain code organization
```

### 3. **Acceptance Strategies**
```
1. Review suggestions carefully
2. Accept in logical chunks
3. Modify as needed
4. Test thoroughly
```

## 💡 Pro Tips for Editor Completions

1. **Write descriptive comments** - They guide Copilot's suggestions
2. **Use consistent patterns** - Copilot learns from your codebase
3. **Accept incrementally** - Review and accept in logical sections
4. **Provide context** - Include related files and dependencies
5. **Test generated code** - Always verify functionality


**💡 Pro Tip**: Editor Completions shine when you establish clear patterns and context. Start with descriptive comments and method signatures to guide Copilot toward generating exactly what you need!

## 🎯 Next Phase

Ready for automated development workflows? In [Phase 08: AI Commit Messages](./phase08-ai-commit-messages.md), you'll learn to automate your Git workflow with intelligent commit messages! 🚀

---

**🏆 Code Generation Master!** You've learned to use advanced Editor Completions for building complete features. This level of AI assistance dramatically accelerates development while maintaining high code quality! 🧠

[![➡️ Next: Phase 08 - AI Commit Messages](https://img.shields.io/badge/➡️-Next%3A%20Phase%2008%20AI%20Commit%20Messages-green?style=flat-square)](phase08-ai-commit-messages.md)

