# 🤖 Phase 11: Agent Mode - Autonomous Code Generation
**🎯 GitHub Copilot Feature**: Advanced AI agents for complex feature development

[![⬅️ Back to Workshop Home](https://img.shields.io/badge/⬅️-Back%20to%20Workshop%20Home-blue?style=flat-square)](../README.md) [![⬅️ Previous: Phase 10](https://img.shields.io/badge/⬅️-Previous%3A%20Phase%2010-lightgrey?style=flat-square)](phase10-documentation-diagrams.md)

## 🎯 Objective

Master GitHub Copilot's Agent Mode capabilities for autonomous code generation and advanced feature development. Learn to leverage AI agents for complex feature implementation, architectural decisions, and comprehensive solution development.

## 📖 About Agent Mode

GitHub Copilot's Agent Mode provides advanced autonomous capabilities:
- **Autonomous feature development** - Complete feature implementation from requirements
- **Architectural decision making** - AI-driven design patterns and structure choices
- **Multi-file coordination** - Seamless changes across multiple files and components
- **Context-aware development** - Understanding entire project scope and dependencies
- **Intelligent problem-solving** - Complex logic implementation with minimal guidance
- **Code optimization** - Performance improvements and refactoring suggestions

## 🛠️ What You'll Build

In this phase, you'll create:
- ✅ Complete reporting dashboard with advanced analytics
- ✅ Multi-tenant architecture with data isolation
- ✅ Advanced workflow automation system
- ✅ AI-powered task recommendations engine
- ✅ Comprehensive audit logging system
- ✅ Real-time collaboration features
- ✅ Advanced security and compliance features

## 📋 Step-by-Step Instructions

### Step 1: Enable Agent Mode Features 🤖

**Configure Agent Mode in your environment:**

1. **Verify Copilot Agent capabilities:**
   ```powershell
   # Check if GitHub Copilot Chat extension is installed and up-to-date
   code --list-extensions | findstr GitHub.copilot-chat
   ```

2. **Enable advanced Copilot features:**
   ```powershell
   # Open VS Code with enhanced agent features
   # Ensure you have the latest versions of:
   # - GitHub Copilot extension
   # - GitHub Copilot Chat extension
   code .
   ```

3. **Configure agent mode settings:**
   - Press `Ctrl+,` to open Settings
   - Search for "copilot experimental"
   - ✅ Enable "GitHub Copilot: Enable experimental features"
   - ✅ Enable "GitHub Copilot Chat: Enable agent mode"
   - ✅ Enable "GitHub Copilot: Enable advanced completions"

4. **Test agent mode functionality:**
   ```powershell
   # Open Copilot Chat panel
   # Press Ctrl+Shift+P and type "GitHub Copilot Chat: Open Chat"
   ```

5. **Create project structure for agent mode development:**
   ```powershell
   # Create directories for agent-generated features
   New-Item -Path ".\src\TaskManagement.API\Features\Dashboard" -ItemType Directory -Force
   New-Item -Path ".\src\TaskManagement.API\Features\MultiTenant" -ItemType Directory -Force
   New-Item -Path ".\src\TaskManagement.API\Features\Workflow" -ItemType Directory -Force
   New-Item -Path ".\src\TaskManagement.API\Features\Recommendations" -ItemType Directory -Force
   New-Item -Path ".\src\TaskManagement.API\Features\AuditLogging" -ItemType Directory -Force
   New-Item -Path ".\src\TaskManagement.API\Features\Collaboration" -ItemType Directory -Force
   ```

---

### Step 2: Build Comprehensive Reporting Dashboard 📊

**Use Agent Mode for complex feature development:**

1. **Open Copilot Chat and use this comprehensive agent prompt:**
   ```
   I need you to act as a senior .NET architect and implement a comprehensive reporting dashboard system for our Task Management API. Please create a complete solution with the following requirements:

   DASHBOARD REQUIREMENTS:
   - Real-time analytics widgets showing task completion rates, user productivity, team performance
   - Customizable chart types: bar charts, line charts, pie charts, scatter plots, heatmaps
   - Interactive data filtering by date ranges, users, teams, projects, priorities
   - Data export functionality supporting PDF reports, Excel spreadsheets, CSV files
   - User-specific dashboard customization with drag-and-drop widget arrangement
   - Drill-down capabilities for detailed analysis of metrics
   - Performance KPI tracking with configurable thresholds and alerts
   - Multi-tenant support with tenant-specific dashboards
   - Caching for improved performance with Redis integration
   - Real-time updates using SignalR for live dashboard updates

   TECHNICAL IMPLEMENTATION:
   - Create DashboardController with comprehensive REST API endpoints
   - Implement DashboardService with advanced analytics calculations
   - Build ChartDataService for generating different chart data formats
   - Create ExportService for PDF/Excel/CSV export functionality
   - Implement DashboardRepository with optimized database queries
   - Build WidgetService for customizable dashboard widgets
   - Create RealtimeService using SignalR for live updates
   - Implement caching layer with Redis for performance

   DATABASE SCHEMA:
   - Design dashboard configuration tables
   - Create widget definition and user preference tables
   - Implement analytics aggregation tables for performance
   - Add indexes for optimized querying

   Please create all necessary files, interfaces, services, controllers, DTOs, and database models. Include comprehensive error handling, validation, logging, and unit tests.
   ```

2. **Let the agent generate the complete dashboard system:**
   - Review the agent's generated code structure
   - Examine the comprehensive file organization
   - Verify the implementation covers all requirements

3. **Expected agent-generated file structure:**
   ```powershell
   # Agent should create these files automatically:
   # .\src\TaskManagement.API\Features\Dashboard\Controllers\DashboardController.cs
   # .\src\TaskManagement.API\Features\Dashboard\Services\DashboardService.cs
   # .\src\TaskManagement.API\Features\Dashboard\Services\ChartDataService.cs
   # .\src\TaskManagement.API\Features\Dashboard\Services\ExportService.cs
   # .\src\TaskManagement.API\Features\Dashboard\DTOs\DashboardDto.cs
   # .\src\TaskManagement.API\Features\Dashboard\Models\Widget.cs
   # And many more...
   ```

4. **Verify the generated dashboard implementation:**
   - Open VS Code terminal (View → Terminal or `Ctrl+` `)
   - Type: `dotnet build .\src\TaskManagement.API\` and press Enter

---

### Step 3: Implement Multi-Tenant Architecture 🏢

**Use Agent Mode for architectural transformation:**

1. **Use this comprehensive agent prompt for multi-tenancy:**
   ```
   Transform our Task Management API into a multi-tenant SaaS application with complete tenant isolation. Please implement a comprehensive multi-tenant architecture with these requirements:

   MULTI-TENANT REQUIREMENTS:
   - Tenant identification through subdomain, custom domain, or tenant ID in headers
   - Complete data isolation between tenants with database schema per tenant approach
   - Tenant-specific configuration and customization capabilities
   - Tenant onboarding and provisioning automation
   - Billing and subscription management integration
   - Tenant-specific feature flags and limitations
   - Cross-tenant reporting and analytics for platform administrators
   - Tenant backup and data export capabilities
   - White-label customization with tenant branding

   TECHNICAL IMPLEMENTATION:
   - Create TenantMiddleware for tenant identification and context
   - Implement ITenantService for tenant management operations
   - Build TenantResolver for multi-strategy tenant identification
   - Create TenantDbContext with dynamic connection string resolution
   - Implement TenantConfiguration system for tenant-specific settings
   - Build subscription and billing management components
   - Create tenant provisioning service with automated setup
   - Implement tenant isolation testing and validation

   SECURITY & ISOLATION:
   - Ensure complete data isolation between tenants
   - Implement tenant-aware authorization policies
   - Add tenant context to all database queries
   - Create tenant-specific caching strategies
   - Implement audit logging with tenant context

   DATABASE STRATEGY:
   - Implement database-per-tenant approach
   - Create tenant management database
   - Build automated database provisioning
   - Implement tenant data migration utilities

   Please create the complete multi-tenant infrastructure including all services, middleware, configuration, and database components.
   ```

2. **Review agent-generated multi-tenant architecture:**
   - Examine the comprehensive tenant management system
   - Verify data isolation implementation
   - Check tenant identification strategies

---

### Step 4: Build Advanced Workflow Automation 🔄

**Create intelligent workflow system:**

1. **Use this agent prompt for workflow automation:**
   ```
   Create a comprehensive workflow automation system for our Task Management API that provides intelligent task orchestration and business process automation:

   WORKFLOW REQUIREMENTS:
   - Visual workflow designer with drag-and-drop interface
   - Conditional logic and branching based on task properties
   - Automated task assignment based on workload, skills, and availability
   - Escalation workflows for overdue or high-priority tasks
   - Integration workflows with external systems (email, Slack, Teams)
   - Approval workflows for task completion and modifications
   - Recurring task generation with complex scheduling patterns
   - SLA monitoring and automatic notifications for violations
   - Workflow templates and sharing across teams
   - Advanced triggers based on events, time, or data conditions

   TECHNICAL IMPLEMENTATION:
   - Create WorkflowEngine for executing workflow definitions
   - Implement WorkflowDesigner API for visual workflow creation
   - Build TriggerService for event-based workflow execution
   - Create ActionService for workflow step execution
   - Implement ConditionEvaluator for complex business rules
   - Build NotificationService integration for workflow communications
   - Create WorkflowScheduler for time-based triggers
   - Implement WorkflowAudit for execution tracking and debugging

   WORKFLOW COMPONENTS:
   - Triggers: Manual, Scheduled, Event-based, Data-driven
   - Actions: Task creation/update, Notifications, API calls, Data operations
   - Conditions: Field comparisons, Complex expressions, Custom validations
   - Connectors: External system integrations and API endpoints

   Please create the complete workflow automation system including the engine, designer APIs, and execution infrastructure.
   ```

2. **Validate workflow system implementation:**
   - Test workflow creation and execution
   - Verify trigger mechanisms work correctly
   - Check integration capabilities

---

### Step 5: Develop AI-Powered Recommendations Engine 🧠

**Build intelligent task recommendation system:**

1. **Use this agent prompt for AI recommendations:**
   ```
   Build an advanced AI-powered task recommendation engine that provides intelligent suggestions for task management optimization:

   AI RECOMMENDATION REQUIREMENTS:
   - Task priority suggestions based on historical data and deadlines
   - Smart task assignment recommendations using machine learning
   - Workload balancing suggestions to optimize team productivity
   - Deadline prediction and adjustment recommendations
   - Task dependency detection and ordering suggestions
   - Productivity pattern analysis and improvement recommendations
   - Resource allocation optimization suggestions
   - Time estimation improvements based on historical completion data
   - Skill-based task routing recommendations
   - Proactive bottleneck identification and resolution suggestions

   MACHINE LEARNING IMPLEMENTATION:
   - Create ML.NET models for task completion time prediction
   - Implement collaborative filtering for task assignment recommendations
   - Build clustering algorithms for task categorization
   - Create anomaly detection for identifying productivity issues
   - Implement reinforcement learning for continuous improvement
   - Build feature engineering pipelines for model training
   - Create model evaluation and retraining automation

   RECOMMENDATION SERVICES:
   - TaskRecommendationService for intelligent task suggestions
   - UserProductivityAnalyzer for performance insights
   - WorkloadOptimizerService for balanced task distribution
   - PredictiveAnalyticsService for forecasting and planning
   - RecommendationEngine with multiple algorithm support
   - ModelTrainingService for continuous learning improvement

   API INTEGRATION:
   - Real-time recommendation endpoints
   - Batch processing for large-scale analysis
   - A/B testing framework for recommendation effectiveness
   - Feedback collection for recommendation quality improvement

   Please create the complete AI recommendation system with ML models, training pipelines, and API endpoints.
   ```

2. **Test AI recommendation functionality:**
   - Verify ML model integration works correctly
   - Test recommendation API endpoints
   - Validate prediction accuracy

---

### Step 6: Implement Comprehensive Audit Logging 📋

**Create enterprise-grade audit system:**

1. **Use this agent prompt for audit logging:**
   ```
   Implement a comprehensive audit logging system for enterprise compliance and security monitoring:

   AUDIT LOGGING REQUIREMENTS:
   - Complete user activity tracking with detailed context
   - Data change auditing with before/after values
   - API access logging with request/response details
   - Security event logging including authentication failures
   - Performance monitoring with detailed execution metrics
   - Compliance reporting for regulatory requirements (GDPR, SOX, HIPAA)
   - Real-time security monitoring and alerting
   - Long-term audit data retention and archival
   - Tamper-proof audit trails with cryptographic integrity
   - Advanced search and filtering capabilities for audit data

   TECHNICAL IMPLEMENTATION:
   - Create AuditMiddleware for automatic request/response logging
   - Implement IAuditService with multiple storage backends
   - Build AuditEventCollector for efficient event gathering
   - Create AuditReportGenerator for compliance reporting
   - Implement SecurityMonitor for real-time threat detection
   - Build AuditDataRetentionService for lifecycle management
   - Create AuditSearchService with advanced querying capabilities
   - Implement audit data encryption and integrity verification

   AUDIT EVENT TYPES:
   - User authentication and authorization events
   - Data CRUD operations with field-level changes
   - API access patterns and usage statistics
   - Security policy violations and suspicious activities
   - System configuration changes and admin operations
   - Performance anomalies and system health events

   COMPLIANCE FEATURES:
   - Automated compliance report generation
   - Data retention policy enforcement
   - Audit trail integrity verification
   - Privacy-compliant logging with data anonymization
   - Regulatory requirement mapping and validation

   Please create the complete audit logging infrastructure with compliance reporting and security monitoring capabilities.
   ```

2. **Verify audit logging implementation:**
   - Test audit event collection across all operations
   - Validate compliance reporting functionality
   - Check security monitoring alerts

---

### Step 7: Build Real-Time Collaboration Features 👥

**Create advanced collaboration system:**

1. **Use this agent prompt for collaboration features:**
   ```
   Build a comprehensive real-time collaboration system that enables seamless teamwork and communication:

   COLLABORATION REQUIREMENTS:
   - Real-time task updates and synchronization across all clients
   - Live commenting and discussion threads on tasks
   - @mention notifications and team member tagging
   - Collaborative task editing with conflict resolution
   - Shared workspaces and team project management
   - Real-time presence indicators showing who's online
   - Live cursors and editing indicators for shared documents
   - Activity feeds and team notification centers
   - File sharing and collaborative document management
   - Video/voice call integration for task discussions

   REAL-TIME IMPLEMENTATION:
   - SignalR hubs for real-time communication
   - WebRTC integration for video/audio calls
   - Operational Transform (OT) for collaborative editing
   - Conflict resolution algorithms for concurrent updates
   - Real-time synchronization with optimistic updates
   - Presence management and user status tracking
   - Message queuing for reliable delivery
   - Connection management and reconnection handling

   COLLABORATION SERVICES:
   - CollaborationHub for real-time communications
   - PresenceService for user status management
   - ConflictResolutionService for handling edit conflicts
   - NotificationService for @mentions and alerts
   - ActivityFeedService for team activity streams
   - FileCollaborationService for document sharing
   - VideoCallService for integrated communications

   UI/UX FEATURES:
   - Live editing indicators and user cursors
   - Real-time typing indicators in comments
   - Collaborative toolbar and shared controls
   - Activity timeline with live updates
   - Team member presence sidebar
   - Notification center with real-time alerts

   Please create the complete real-time collaboration system with all communication, synchronization, and conflict resolution features.
   ```

2. **Test collaboration features:**
   - Verify real-time synchronization works across multiple clients
   - Test conflict resolution mechanisms
   - Validate notification delivery

---

### Step 8: Comprehensive Agent Mode Integration Testing 🧪

**Validate all agent-generated features:**

1. **Create comprehensive integration tests:**
   ```
   Create a comprehensive integration test suite that validates all agent-generated features working together:

   INTEGRATION TEST REQUIREMENTS:
   - End-to-end workflow testing across all features
   - Multi-tenant data isolation validation
   - Real-time collaboration testing with multiple users
   - Dashboard functionality with live data updates
   - AI recommendation accuracy and performance testing
   - Audit logging completeness and integrity verification
   - Performance testing under load with all features active
   - Security testing including authorization and data protection
   - Failure scenario testing and recovery validation
   - Cross-feature integration and data flow verification

   TEST IMPLEMENTATION:
   - Create TestServer with all features configured
   - Build test data factories for complex scenarios
   - Implement multi-user simulation for collaboration testing
   - Create performance benchmarks for AI recommendations
   - Build audit verification tools for compliance testing
   - Implement chaos testing for resilience validation

   Please create comprehensive integration tests that validate the entire system works correctly with all agent-generated features.
   ```

2. **Execute comprehensive testing:**
   - Open VS Code terminal (View → Terminal or `Ctrl+` `)
   - Type: `dotnet test .\tests\ --verbosity normal --logger "console;verbosity=detailed"` and press Enter
   - Type: `dotnet test .\tests\ --filter "Category=Performance" --verbosity normal` and press Enter
   - Type: `dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults` and press Enter

3. **Validate final system integration:**
   - In the terminal, type: `dotnet build .\TaskManagement.sln` and press Enter
   - Type: `dotnet run --project .\src\TaskManagement.API\` and press Enter

4. **Generate comprehensive project summary:**
   ```powershell
   # Create project metrics report
   Write-Host "=== AGENT MODE IMPLEMENTATION SUMMARY ===" -ForegroundColor Green
   Write-Host "Features Implemented by AI Agent:" -ForegroundColor Yellow
   Get-ChildItem -Path ".\src\TaskManagement.API\Features" -Recurse -Include "*.cs" | Measure-Object | Select-Object Count
   Write-Host "Total Lines of Agent-Generated Code:" -ForegroundColor Yellow
   (Get-Content -Path ".\src\TaskManagement.API\Features\**\*.cs" | Measure-Object -Line).Lines
   Write-Host "Integration Tests Created:" -ForegroundColor Yellow
   Get-ChildItem -Path ".\tests" -Recurse -Include "*Integration*.cs" | Measure-Object | Select-Object Count
   ```
   - Responsive design for mobile and desktop
   ```

### Step 2: Advanced Analytics Dashboard 📊

**Let Agent Mode create a complete analytics system:**

```csharp
// Agent Mode will generate comprehensive analytics infrastructure
// Prompt: Create a complete analytics dashboard system with real-time data,
// customizable widgets, and advanced reporting capabilities

// Models/Analytics/AnalyticsDashboard.cs
public class AnalyticsDashboard
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DashboardLayout Layout { get; set; } = new();
    public List<DashboardWidget> Widgets { get; set; } = new();
    public DashboardSettings Settings { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsPublic { get; set; }
    public List<string> SharedWithUsers { get; set; } = new();
}

public class DashboardWidget
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public WidgetType Type { get; set; }
    public WidgetPosition Position { get; set; } = new();
    public WidgetSize Size { get; set; } = new();
    public WidgetDataSource DataSource { get; set; } = new();
    public WidgetConfiguration Configuration { get; set; } = new();
    public DateTime LastUpdated { get; set; }
    public bool IsRealTime { get; set; }
    public int RefreshIntervalSeconds { get; set; } = 60;
}

public class WidgetDataSource
{
    public string Query { get; set; } = string.Empty;
    public List<DataFilter> Filters { get; set; } = new();
    public DataAggregation Aggregation { get; set; } = new();
    public DateRange DateRange { get; set; } = new();
    public List<string> GroupByFields { get; set; } = new();
}

public enum WidgetType
{
    LineChart,
    BarChart,
    PieChart,
    ScatterPlot,
    Table,
    KpiCard,
    Gauge,
    Heatmap,
    TreeMap,
    Funnel
}

// Services/Analytics/AnalyticsService.cs
public interface IAnalyticsService
{
    Task<DashboardData> GetDashboardDataAsync(int dashboardId, string userId);
    Task<AnalyticsDashboard> CreateDashboardAsync(CreateDashboardDto dto, string userId);
    Task<AnalyticsDashboard> UpdateDashboardAsync(int dashboardId, UpdateDashboardDto dto, string userId);
    Task<bool> DeleteDashboardAsync(int dashboardId, string userId);
    Task<List<AnalyticsDashboard>> GetUserDashboardsAsync(string userId);
    Task<WidgetData> GetWidgetDataAsync(int widgetId, DataRequestParameters parameters);
    Task<ExportResult> ExportDashboardAsync(int dashboardId, ExportFormat format, string userId);
    Task<List<AnalyticsMetric>> GetAvailableMetricsAsync();
    Task<List<KpiTrend>> GetKpiTrendsAsync(string userId, DateRange dateRange);
}

public class AnalyticsService : IAnalyticsService
{
    private readonly ApplicationDbContext _context;
    private readonly IMemoryCache _cache;
    private readonly ILogger<AnalyticsService> _logger;
    private readonly IHubContext<AnalyticsHub> _hubContext;
    private readonly IBackgroundTaskQueue _taskQueue;

    public AnalyticsService(
        ApplicationDbContext context,
        IMemoryCache cache,
        ILogger<AnalyticsService> logger,
        IHubContext<AnalyticsHub> hubContext,
        IBackgroundTaskQueue taskQueue)
    {
        _context = context;
        _cache = cache;
        _logger = logger;
        _hubContext = hubContext;
        _taskQueue = taskQueue;
    }

    public async Task<DashboardData> GetDashboardDataAsync(int dashboardId, string userId)
    {
        var dashboard = await _context.AnalyticsDashboards
            .Include(d => d.Widgets)
            .FirstOrDefaultAsync(d => d.Id == dashboardId && 
                (d.UserId == userId || d.IsPublic || d.SharedWithUsers.Contains(userId)));

        if (dashboard == null)
            throw new NotFoundException($"Dashboard {dashboardId} not found or access denied");

        var dashboardData = new DashboardData
        {
            Dashboard = dashboard,
            WidgetData = new Dictionary<int, WidgetData>(),
            LastUpdated = DateTime.UtcNow,
            RefreshRate = dashboard.Settings.GlobalRefreshRate
        };

        // Load data for each widget
        var widgetDataTasks = dashboard.Widgets.Select(async widget =>
        {
            try
            {
                var parameters = new DataRequestParameters
                {
                    DateRange = widget.DataSource.DateRange,
                    Filters = widget.DataSource.Filters,
                    Aggregation = widget.DataSource.Aggregation
                };

                var widgetData = await GetWidgetDataAsync(widget.Id, parameters);
                return new { WidgetId = widget.Id, Data = widgetData };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading data for widget {WidgetId}", widget.Id);
                return new { WidgetId = widget.Id, Data = new WidgetData { HasError = true, ErrorMessage = ex.Message } };
            }
        });

        var widgetResults = await Task.WhenAll(widgetDataTasks);
        foreach (var result in widgetResults)
        {
            dashboardData.WidgetData[result.WidgetId] = result.Data;
        }

        return dashboardData;
    }

    public async Task<WidgetData> GetWidgetDataAsync(int widgetId, DataRequestParameters parameters)
    {
        var widget = await _context.DashboardWidgets
            .Include(w => w.DataSource)
            .FirstOrDefaultAsync(w => w.Id == widgetId);

        if (widget == null)
            throw new NotFoundException($"Widget {widgetId} not found");

        var cacheKey = $"widget_data_{widgetId}_{parameters.GetHashCode()}";
        
        if (_cache.TryGetValue(cacheKey, out WidgetData? cachedData))
        {
            return cachedData!;
        }

        var widgetData = await ExecuteWidgetQueryAsync(widget, parameters);
        
        // Cache the data based on widget refresh rate
        var cacheExpiry = TimeSpan.FromSeconds(widget.RefreshIntervalSeconds);
        _cache.Set(cacheKey, widgetData, cacheExpiry);

        // Send real-time update if widget is real-time
        if (widget.IsRealTime)
        {
            await _hubContext.Clients.Group($"widget_{widgetId}")
                .SendAsync("WidgetDataUpdated", widgetData);
        }

        return widgetData;
    }

    private async Task<WidgetData> ExecuteWidgetQueryAsync(DashboardWidget widget, DataRequestParameters parameters)
    {
        return widget.Type switch
        {
            WidgetType.LineChart => await GenerateLineChartDataAsync(widget, parameters),
            WidgetType.BarChart => await GenerateBarChartDataAsync(widget, parameters),
            WidgetType.PieChart => await GeneratePieChartDataAsync(widget, parameters),
            WidgetType.Table => await GenerateTableDataAsync(widget, parameters),
            WidgetType.KpiCard => await GenerateKpiDataAsync(widget, parameters),
            WidgetType.Gauge => await GenerateGaugeDataAsync(widget, parameters),
            WidgetType.Heatmap => await GenerateHeatmapDataAsync(widget, parameters),
            _ => throw new NotSupportedException($"Widget type {widget.Type} not supported")
        };
    }

    private async Task<WidgetData> GenerateLineChartDataAsync(DashboardWidget widget, DataRequestParameters parameters)
    {
        // Complex analytics query generation based on widget configuration
        var query = _context.Tasks.AsQueryable();

        // Apply date range filter
        if (parameters.DateRange != null)
        {
            query = query.Where(t => t.CreatedAt >= parameters.DateRange.From && 
                                   t.CreatedAt <= parameters.DateRange.To);
        }

        // Apply custom filters
        foreach (var filter in parameters.Filters)
        {
            query = ApplyFilterToQuery(query, filter);
        }

        // Generate time series data
        var timeSeriesData = await query
            .GroupBy(t => new { 
                Year = t.CreatedAt.Year, 
                Month = t.CreatedAt.Month, 
                Day = t.CreatedAt.Day 
            })
            .Select(g => new TimeSeriesPoint
            {
                Timestamp = new DateTime(g.Key.Year, g.Key.Month, g.Key.Day),
                Value = g.Count(),
                Label = $"{g.Key.Year}-{g.Key.Month:00}-{g.Key.Day:00}"
            })
            .OrderBy(p => p.Timestamp)
            .ToListAsync();

        return new WidgetData
        {
            Type = WidgetType.LineChart,
            TimeSeries = timeSeriesData,
            LastUpdated = DateTime.UtcNow,
            TotalDataPoints = timeSeriesData.Count
        };
    }

    public async Task<ExportResult> ExportDashboardAsync(int dashboardId, ExportFormat format, string userId)
    {
        var dashboardData = await GetDashboardDataAsync(dashboardId, userId);
        
        // Queue background export task
        var exportTask = new ExportTask
        {
            DashboardId = dashboardId,
            Format = format,
            UserId = userId,
            RequestedAt = DateTime.UtcNow
        };

        await _taskQueue.QueueBackgroundWorkItemAsync(async (cancellationToken) =>
        {
            try
            {
                var exportResult = await GenerateExportAsync(dashboardData, format);
                
                // Notify user when export is complete
                await _hubContext.Clients.User(userId)
                    .SendAsync("ExportCompleted", exportResult, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Export failed for dashboard {DashboardId}", dashboardId);
                await _hubContext.Clients.User(userId)
                    .SendAsync("ExportFailed", ex.Message, cancellationToken);
            }
        });

        return new ExportResult
        {
            Status = ExportStatus.Queued,
            Message = "Export queued for processing",
            EstimatedCompletionTime = DateTime.UtcNow.AddMinutes(5)
        };
    }
}

// Controllers/AnalyticsController.cs
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _analyticsService;
    private readonly ILogger<AnalyticsController> _logger;

    public AnalyticsController(IAnalyticsService analyticsService, ILogger<AnalyticsController> logger)
    {
        _analyticsService = analyticsService;
        _logger = logger;
    }

    /// <summary>
    /// Get dashboard data with all widgets and real-time updates
    /// </summary>
    [HttpGet("dashboards/{dashboardId}")]
    public async Task<ActionResult<ApiResponse<DashboardData>>> GetDashboard(int dashboardId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        var dashboardData = await _analyticsService.GetDashboardDataAsync(dashboardId, userId);
        
        return Ok(new ApiResponse<DashboardData>
        {
            Success = true,
            Data = dashboardData,
            Message = "Dashboard data retrieved successfully"
        });
    }

    /// <summary>
    /// Create a new customizable analytics dashboard
    /// </summary>
    [HttpPost("dashboards")]
    public async Task<ActionResult<ApiResponse<AnalyticsDashboard>>> CreateDashboard(CreateDashboardDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        var dashboard = await _analyticsService.CreateDashboardAsync(dto, userId);
        
        return CreatedAtAction(nameof(GetDashboard), new { dashboardId = dashboard.Id },
            new ApiResponse<AnalyticsDashboard>
            {
                Success = true,
                Data = dashboard,
                Message = "Dashboard created successfully"
            });
    }

    /// <summary>
    /// Export dashboard data in various formats (PDF, Excel, CSV)
    /// </summary>
    [HttpPost("dashboards/{dashboardId}/export")]
    public async Task<ActionResult<ApiResponse<ExportResult>>> ExportDashboard(
        int dashboardId, 
        [FromBody] ExportRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        var exportResult = await _analyticsService.ExportDashboardAsync(dashboardId, request.Format, userId);
        
        return Ok(new ApiResponse<ExportResult>
        {
            Success = true,
            Data = exportResult,
            Message = "Export initiated successfully"
        });
    }

    /// <summary>
    /// Get available analytics metrics and KPIs
    /// </summary>
    [HttpGet("metrics")]
    public async Task<ActionResult<ApiResponse<List<AnalyticsMetric>>>> GetAvailableMetrics()
    {
        var metrics = await _analyticsService.GetAvailableMetricsAsync();
        
        return Ok(new ApiResponse<List<AnalyticsMetric>>
        {
            Success = true,
            Data = metrics,
            Message = "Available metrics retrieved successfully"
        });
    }
}

// Real-time updates with SignalR
public class AnalyticsHub : Hub
{
    public async Task JoinDashboard(string dashboardId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"dashboard_{dashboardId}");
    }

    public async Task JoinWidget(string widgetId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"widget_{widgetId}");
    }

    public async Task LeaveDashboard(string dashboardId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"dashboard_{dashboardId}");
    }
}
```

### Step 3: Multi-Tenant Architecture 🏢

**Agent Mode creates complete multi-tenancy system:**

```csharp
// Agent Mode Prompt: Implement comprehensive multi-tenant architecture
// with data isolation, tenant-specific configurations, and scaling capabilities

// Models/MultiTenancy/Tenant.cs
public class Tenant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Subdomain { get; set; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public TenantStatus Status { get; set; }
    public TenantPlan Plan { get; set; }
    public TenantConfiguration Configuration { get; set; } = new();
    public TenantLimits Limits { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime? SuspendedAt { get; set; }
    public string? SuspensionReason { get; set; }
    public List<TenantUser> Users { get; set; } = new();
    public TenantBilling Billing { get; set; } = new();
}

public class TenantConfiguration
{
    public string Theme { get; set; } = "default";
    public string Logo { get; set; } = string.Empty;
    public Dictionary<string, object> CustomSettings { get; set; } = new();
    public List<string> EnabledFeatures { get; set; } = new();
    public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.Utc;
    public string DateFormat { get; set; } = "yyyy-MM-dd";
    public string TimeFormat { get; set; } = "HH:mm:ss";
    public string Currency { get; set; } = "USD";
    public Dictionary<string, string> Localization { get; set; } = new();
}

public class TenantLimits
{
    public int MaxUsers { get; set; } = 10;
    public int MaxTasks { get; set; } = 1000;
    public int MaxProjects { get; set; } = 10;
    public long MaxStorageBytes { get; set; } = 1073741824; // 1GB
    public int MaxApiCallsPerHour { get; set; } = 1000;
    public bool CanUseAdvancedFeatures { get; set; } = false;
    public bool CanUseIntegrations { get; set; } = false;
    public bool CanExportData { get; set; } = true;
}

// Services/MultiTenancy/ITenantService.cs
public interface ITenantService
{
    Task<Tenant> GetCurrentTenantAsync();
    Task<Tenant> GetTenantByIdAsync(int tenantId);
    Task<Tenant> GetTenantByDomainAsync(string domain);
    Task<Tenant> CreateTenantAsync(CreateTenantDto dto);
    Task<Tenant> UpdateTenantAsync(int tenantId, UpdateTenantDto dto);
    Task<bool> DeleteTenantAsync(int tenantId);
    Task<List<Tenant>> GetAllTenantsAsync(TenantFilter filter);
    Task<TenantUsage> GetTenantUsageAsync(int tenantId);
    Task<bool> ValidateTenantLimitsAsync(int tenantId, ResourceType resourceType, int quantity = 1);
}

public class TenantService : ITenantService
{
    private readonly ApplicationDbContext _context;
    private readonly ITenantContext _tenantContext;
    private readonly IMemoryCache _cache;
    private readonly ILogger<TenantService> _logger;

    public async Task<Tenant> GetCurrentTenantAsync()
    {
        var tenantId = _tenantContext.TenantId;
        if (tenantId == null)
            throw new InvalidOperationException("No tenant context available");

        var cacheKey = $"tenant_{tenantId}";
        if (_cache.TryGetValue(cacheKey, out Tenant? cachedTenant))
        {
            return cachedTenant!;
        }

        var tenant = await _context.Tenants
            .Include(t => t.Configuration)
            .Include(t => t.Limits)
            .Include(t => t.Billing)
            .FirstOrDefaultAsync(t => t.Id == tenantId);

        if (tenant == null)
            throw new NotFoundException($"Tenant {tenantId} not found");

        _cache.Set(cacheKey, tenant, TimeSpan.FromMinutes(15));
        return tenant;
    }

    public async Task<bool> ValidateTenantLimitsAsync(int tenantId, ResourceType resourceType, int quantity = 1)
    {
        var tenant = await GetTenantByIdAsync(tenantId);
        var usage = await GetTenantUsageAsync(tenantId);

        return resourceType switch
        {
            ResourceType.Users => usage.UserCount + quantity <= tenant.Limits.MaxUsers,
            ResourceType.Tasks => usage.TaskCount + quantity <= tenant.Limits.MaxTasks,
            ResourceType.Projects => usage.ProjectCount + quantity <= tenant.Limits.MaxProjects,
            ResourceType.Storage => usage.StorageUsedBytes + quantity <= tenant.Limits.MaxStorageBytes,
            ResourceType.ApiCalls => usage.ApiCallsThisHour + quantity <= tenant.Limits.MaxApiCallsPerHour,
            _ => true
        };
    }
}

// Middleware/TenantResolutionMiddleware.cs
public class TenantResolutionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ITenantService _tenantService;
    private readonly ILogger<TenantResolutionMiddleware> _logger;

    public TenantResolutionMiddleware(
        RequestDelegate next, 
        ITenantService tenantService, 
        ILogger<TenantResolutionMiddleware> logger)
    {
        _next = next;
        _tenantService = tenantService;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext)
    {
        try
        {
            var tenant = await ResolveTenantAsync(context);
            if (tenant != null)
            {
                tenantContext.SetTenant(tenant);
                context.Items["Tenant"] = tenant;
                
                // Validate tenant status
                if (tenant.Status != TenantStatus.Active)
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync($"Tenant is {tenant.Status}");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error resolving tenant for request {Path}", context.Request.Path);
        }

        await _next(context);
    }

    private async Task<Tenant?> ResolveTenantAsync(HttpContext context)
    {
        // Try to resolve by subdomain first
        var host = context.Request.Host.Host;
        if (host.Contains('.'))
        {
            var subdomain = host.Split('.')[0];
            var tenant = await _tenantService.GetTenantByDomainAsync(subdomain);
            if (tenant != null) return tenant;
        }

        // Try to resolve by custom domain
        var tenant2 = await _tenantService.GetTenantByDomainAsync(host);
        if (tenant2 != null) return tenant2;

        // Try to resolve by header
        if (context.Request.Headers.TryGetValue("X-Tenant-Id", out var tenantIdHeader))
        {
            if (int.TryParse(tenantIdHeader, out var tenantId))
            {
                return await _tenantService.GetTenantByIdAsync(tenantId);
            }
        }

        return null;
    }
}

// Data/TenantDbContext.cs - Tenant-aware DbContext
public class TenantDbContext : ApplicationDbContext
{
    private readonly ITenantContext _tenantContext;

    public TenantDbContext(DbContextOptions<ApplicationDbContext> options, ITenantContext tenantContext) 
        : base(options)
    {
        _tenantContext = tenantContext;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply tenant filtering to all entities that implement ITenantEntity
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ITenantEntity).IsAssignableFrom(entityType.ClrType))
            {
                var method = SetTenantFilterMethod.MakeGenericMethod(entityType.ClrType);
                method.Invoke(this, new object[] { modelBuilder });
            }
        }
    }

    private static readonly MethodInfo SetTenantFilterMethod = typeof(TenantDbContext)
        .GetMethod(nameof(SetTenantFilter), BindingFlags.NonPublic | BindingFlags.Static)!;

    private static void SetTenantFilter<TEntity>(ModelBuilder modelBuilder) 
        where TEntity : class, ITenantEntity
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.TenantId == null || e.TenantId == GetCurrentTenantId());
    }

    private static int? GetCurrentTenantId()
    {
        // This will be resolved at runtime through dependency injection
        return null;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var tenantId = _tenantContext.TenantId;
        
        foreach (var entry in ChangeTracker.Entries<ITenantEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.TenantId = tenantId;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}

// Interface for tenant-aware entities
public interface ITenantEntity
{
    int? TenantId { get; set; }
}

// Update existing entities to implement ITenantEntity
public partial class TaskItem : ITenantEntity
{
    public int? TenantId { get; set; }
}

public partial class ApplicationUser : ITenantEntity
{
    public int? TenantId { get; set; }
}
```

### Step 4: AI-Powered Task Recommendations 🧠

**Agent Mode creates intelligent recommendation engine:**

```csharp
// Agent Mode Prompt: Create an AI-powered task recommendation system that analyzes
// user behavior, task patterns, and productivity metrics to suggest optimal task
// prioritization, scheduling, and workflow improvements

// Models/AI/TaskRecommendation.cs
public class TaskRecommendation
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public RecommendationType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double ConfidenceScore { get; set; }
    public RecommendationPriority Priority { get; set; }
    public Dictionary<string, object> Metadata { get; set; } = new();
    public string? RelatedTaskId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ViewedAt { get; set; }
    public DateTime? AcceptedAt { get; set; }
    public DateTime? DeclinedAt { get; set; }
    public RecommendationStatus Status { get; set; }
    public string? Feedback { get; set; }
}

public enum RecommendationType
{
    TaskPrioritization,
    TimeBlocking,
    SkillDevelopment,
    WorkloadBalancing,
    DeadlineOptimization,
    CollaborationSuggestion,
    ProductivityImprovement,
    AutomationOpportunity
}

// Services/AI/IRecommendationEngine.cs
public interface IRecommendationEngine
{
    Task<List<TaskRecommendation>> GenerateRecommendationsAsync(string userId);
    Task<TaskRecommendation> GenerateSpecificRecommendationAsync(string userId, RecommendationType type);
    Task<ProductivityInsights> AnalyzeProductivityPatternsAsync(string userId);
    Task<OptimalSchedule> GenerateOptimalScheduleAsync(string userId, DateTime startDate, int days);
    Task<List<TaskSuggestion>> SuggestNextTasksAsync(string userId);
    Task<WorkloadAnalysis> AnalyzeWorkloadAsync(string userId);
    Task RecordRecommendationFeedbackAsync(int recommendationId, bool accepted, string? feedback);
}

public class RecommendationEngine : IRecommendationEngine
{
    private readonly ApplicationDbContext _context;
    private readonly IUserBehaviorAnalyzer _behaviorAnalyzer;
    private readonly IProductivityAnalyzer _productivityAnalyzer;
    private readonly IMLModelService _mlModelService;
    private readonly ILogger<RecommendationEngine> _logger;

    public async Task<List<TaskRecommendation>> GenerateRecommendationsAsync(string userId)
    {
        var recommendations = new List<TaskRecommendation>();

        // Analyze user's current state
        var userProfile = await _behaviorAnalyzer.GetUserProfileAsync(userId);
        var productivityMetrics = await _productivityAnalyzer.GetProductivityMetricsAsync(userId);
        var currentTasks = await GetUserCurrentTasksAsync(userId);

        // Generate different types of recommendations
        var recommendationTasks = new[]
        {
            GeneratePrioritizationRecommendationsAsync(userId, currentTasks, productivityMetrics),
            GenerateTimeBlockingRecommendationsAsync(userId, userProfile, currentTasks),
            GenerateWorkloadBalancingRecommendationsAsync(userId, currentTasks, productivityMetrics),
            GenerateCollaborationRecommendationsAsync(userId, currentTasks),
            GenerateAutomationRecommendationsAsync(userId, userProfile)
        };

        var allRecommendations = await Task.WhenAll(recommendationTasks);
        recommendations.AddRange(allRecommendations.SelectMany(r => r));

        // Rank and filter recommendations
        var rankedRecommendations = await RankRecommendationsAsync(recommendations, userProfile);
        
        // Store recommendations
        await StoreRecommendationsAsync(rankedRecommendations);

        return rankedRecommendations.Take(10).ToList();
    }

    private async Task<List<TaskRecommendation>> GeneratePrioritizationRecommendationsAsync(
        string userId, 
        List<TaskItem> currentTasks, 
        ProductivityMetrics metrics)
    {
        var recommendations = new List<TaskRecommendation>();

        // Analyze task completion patterns
        var completionPatterns = await _mlModelService.PredictTaskCompletionAsync(currentTasks);
        
        // Find high-impact, low-effort tasks
        var quickWins = currentTasks
            .Where(t => completionPatterns[t.Id].EstimatedEffort < 2 && 
                       completionPatterns[t.Id].ImpactScore > 0.7)
            .OrderByDescending(t => completionPatterns[t.Id].ImpactScore)
            .Take(3);

        foreach (var task in quickWins)
        {
            recommendations.Add(new TaskRecommendation
            {
                UserId = userId,
                Type = RecommendationType.TaskPrioritization,
                Title = "Quick Win Opportunity",
                Description = $"Task '{task.Title}' has high impact and low effort. Consider prioritizing it.",
                ConfidenceScore = completionPatterns[task.Id].ImpactScore,
                Priority = RecommendationPriority.High,
                RelatedTaskId = task.Id.ToString(),
                Metadata = new Dictionary<string, object>
                {
                    ["estimatedEffort"] = completionPatterns[task.Id].EstimatedEffort,
                    ["impactScore"] = completionPatterns[task.Id].ImpactScore,
                    ["taskType"] = "quickWin"
                },
                CreatedAt = DateTime.UtcNow,
                Status = RecommendationStatus.New
            });
        }

        // Identify overdue tasks that should be prioritized
        var overdueTasks = currentTasks
            .Where(t => t.DueDate.HasValue && t.DueDate < DateTime.UtcNow && !t.IsCompleted)
            .OrderBy(t => t.DueDate);

        if (overdueTasks.Any())
        {
            recommendations.Add(new TaskRecommendation
            {
                UserId = userId,
                Type = RecommendationType.TaskPrioritization,
                Title = "Overdue Tasks Need Attention",
                Description = $"You have {overdueTasks.Count()} overdue tasks. Consider addressing them urgently.",
                ConfidenceScore = 0.9,
                Priority = RecommendationPriority.Urgent,
                Metadata = new Dictionary<string, object>
                {
                    ["overdueCount"] = overdueTasks.Count(),
                    ["oldestOverdue"] = overdueTasks.First().DueDate,
                    ["taskType"] = "overdue"
                },
                CreatedAt = DateTime.UtcNow,
                Status = RecommendationStatus.New
            });
        }

        return recommendations;
    }

    private async Task<List<TaskRecommendation>> GenerateTimeBlockingRecommendationsAsync(
        string userId, 
        UserProfile userProfile, 
        List<TaskItem> currentTasks)
    {
        var recommendations = new List<TaskRecommendation>();

        // Analyze user's productive hours
        var productiveHours = userProfile.ProductiveTimeSlots;
        var tasksByComplexity = await _mlModelService.CategorizeTasksByComplexityAsync(currentTasks);

        // Recommend scheduling complex tasks during productive hours
        var complexTasks = tasksByComplexity.Where(t => t.ComplexityLevel >= ComplexityLevel.High).ToList();
        
        if (complexTasks.Any() && productiveHours.Any())
        {
            var nextProductiveSlot = productiveHours
                .Where(slot => slot.StartTime > DateTime.Now)
                .OrderBy(slot => slot.StartTime)
                .FirstOrDefault();

            if (nextProductiveSlot != null)
            {
                recommendations.Add(new TaskRecommendation
                {
                    UserId = userId,
                    Type = RecommendationType.TimeBlocking,
                    Title = "Optimize Complex Task Scheduling",
                    Description = $"Schedule complex tasks during your peak productivity hours ({nextProductiveSlot.StartTime:HH:mm} - {nextProductiveSlot.EndTime:HH:mm})",
                    ConfidenceScore = 0.8,
                    Priority = RecommendationPriority.Medium,
                    Metadata = new Dictionary<string, object>
                    {
                        ["suggestedTimeSlot"] = nextProductiveSlot,
                        ["complexTaskCount"] = complexTasks.Count,
                        ["taskType"] = "timeBlocking"
                    },
                    CreatedAt = DateTime.UtcNow,
                    Status = RecommendationStatus.New
                });
            }
        }

        // Suggest batching similar tasks
        var tasksByCategory = currentTasks.GroupBy(t => t.Category).Where(g => g.Count() > 1);
        
        foreach (var categoryGroup in tasksByCategory)
        {
            recommendations.Add(new TaskRecommendation
            {
                UserId = userId,
                Type = RecommendationType.TimeBlocking,
                Title = "Batch Similar Tasks",
                Description = $"Consider batching {categoryGroup.Count()} {categoryGroup.Key} tasks together for better focus.",
                ConfidenceScore = 0.7,
                Priority = RecommendationPriority.Medium,
                Metadata = new Dictionary<string, object>
                {
                    ["category"] = categoryGroup.Key,
                    ["taskCount"] = categoryGroup.Count(),
                    ["taskIds"] = categoryGroup.Select(t => t.Id).ToList(),
                    ["taskType"] = "batching"
                },
                CreatedAt = DateTime.UtcNow,
                Status = RecommendationStatus.New
            });
        }

        return recommendations;
    }

    public async Task<OptimalSchedule> GenerateOptimalScheduleAsync(string userId, DateTime startDate, int days)
    {
        var userProfile = await _behaviorAnalyzer.GetUserProfileAsync(userId);
        var tasks = await GetUserPendingTasksAsync(userId);
        var constraints = await GetUserConstraintsAsync(userId);

        // Use ML model to generate optimal schedule
        var scheduleRequest = new ScheduleGenerationRequest
        {
            UserId = userId,
            StartDate = startDate,
            Days = days,
            Tasks = tasks,
            UserProfile = userProfile,
            Constraints = constraints
        };

        var optimalSchedule = await _mlModelService.GenerateOptimalScheduleAsync(scheduleRequest);

        // Validate and adjust schedule based on real-world constraints
        var validatedSchedule = await ValidateScheduleAsync(optimalSchedule, constraints);

        return validatedSchedule;
    }

    private async Task<List<TaskRecommendation>> RankRecommendationsAsync(
        List<TaskRecommendation> recommendations, 
        UserProfile userProfile)
    {
        // Apply user-specific ranking based on historical acceptance rates
        var userAcceptanceRates = await GetUserAcceptanceRatesAsync(userProfile.UserId);

        foreach (var recommendation in recommendations)
        {
            var typeAcceptanceRate = userAcceptanceRates.GetValueOrDefault(recommendation.Type, 0.5);
            
            // Adjust confidence score based on user's historical acceptance
            recommendation.ConfidenceScore = recommendation.ConfidenceScore * typeAcceptanceRate;
        }

        return recommendations
            .OrderByDescending(r => r.Priority)
            .ThenByDescending(r => r.ConfidenceScore)
            .ToList();
    }
}

// Controllers/RecommendationsController.cs
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationEngine _recommendationEngine;
    private readonly ILogger<RecommendationsController> _logger;

    /// <summary>
    /// Get AI-powered task recommendations for the current user
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<TaskRecommendation>>>> GetRecommendations()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        var recommendations = await _recommendationEngine.GenerateRecommendationsAsync(userId);
        
        return Ok(new ApiResponse<List<TaskRecommendation>>
        {
            Success = true,
            Data = recommendations,
            Message = "Recommendations generated successfully"
        });
    }

    /// <summary>
    /// Get productivity insights and patterns analysis
    /// </summary>
    [HttpGet("insights")]
    public async Task<ActionResult<ApiResponse<ProductivityInsights>>> GetProductivityInsights()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        var insights = await _recommendationEngine.AnalyzeProductivityPatternsAsync(userId);
        
        return Ok(new ApiResponse<ProductivityInsights>
        {
            Success = true,
            Data = insights,
            Message = "Productivity insights generated successfully"
        });
    }

    /// <summary>
    /// Generate optimal schedule for specified time period
    /// </summary>
    [HttpPost("schedule")]
    public async Task<ActionResult<ApiResponse<OptimalSchedule>>> GenerateOptimalSchedule(
        GenerateScheduleRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        var schedule = await _recommendationEngine.GenerateOptimalScheduleAsync(
            userId, request.StartDate, request.Days);
        
        return Ok(new ApiResponse<OptimalSchedule>
        {
            Success = true,
            Data = schedule,
            Message = "Optimal schedule generated successfully"
        });
    }

    /// <summary>
    /// Provide feedback on recommendation
    /// </summary>
    [HttpPost("{recommendationId}/feedback")]
    public async Task<ActionResult<ApiResponse<string>>> ProvideFeedback(
        int recommendationId, 
        [FromBody] RecommendationFeedbackRequest request)
    {
        await _recommendationEngine.RecordRecommendationFeedbackAsync(
            recommendationId, request.Accepted, request.Feedback);
        
        return Ok(new ApiResponse<string>
        {
            Success = true,
            Message = "Feedback recorded successfully"
        });
    }
}
```

### Step 5: Advanced Workflow Automation 🔄

**Agent Mode creates intelligent workflow system:**

```csharp
// Agent Mode Prompt: Create an advanced workflow automation system with
// triggers, conditions, actions, and intelligent routing capabilities

// Models/Workflow/WorkflowDefinition.cs
public class WorkflowDefinition
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public WorkflowTrigger Trigger { get; set; } = new();
    public List<WorkflowStep> Steps { get; set; } = new();
    public WorkflowSettings Settings { get; set; } = new();
    public bool IsActive { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastExecuted { get; set; }
    public int ExecutionCount { get; set; }
    public WorkflowStatistics Statistics { get; set; } = new();
}

public class WorkflowStep
{
    public int Id { get; set; }
    public int Order { get; set; }
    public StepType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public WorkflowCondition? Condition { get; set; }
    public WorkflowAction Action { get; set; } = new();
    public List<WorkflowStep> TrueSteps { get; set; } = new();
    public List<WorkflowStep> FalseSteps { get; set; } = new();
    public TimeSpan? Delay { get; set; }
    public int MaxRetries { get; set; } = 3;
    public bool ContinueOnError { get; set; } = false;
}

// Services/Workflow/IWorkflowEngine.cs
public interface IWorkflowEngine
{
    Task<WorkflowExecution> ExecuteWorkflowAsync(int workflowId, object triggerData);
    Task<WorkflowExecution> ExecuteWorkflowAsync(WorkflowDefinition workflow, object triggerData);
    Task<List<WorkflowDefinition>> GetActiveWorkflowsAsync();
    Task<bool> RegisterTriggerAsync(WorkflowTrigger trigger);
    Task<bool> UnregisterTriggerAsync(int triggerId);
    Task<WorkflowValidationResult> ValidateWorkflowAsync(WorkflowDefinition workflow);
    Task<List<WorkflowExecution>> GetWorkflowExecutionsAsync(int workflowId, int page, int pageSize);
}

public class WorkflowEngine : IWorkflowEngine
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WorkflowEngine> _logger;
    private readonly IBackgroundTaskQueue _taskQueue;
    private readonly IHubContext<WorkflowHub> _hubContext;

    public async Task<WorkflowExecution> ExecuteWorkflowAsync(int workflowId, object triggerData)
    {
        var workflow = await _context.WorkflowDefinitions
            .Include(w => w.Steps)
            .ThenInclude(s => s.Action)
            .Include(w => w.Steps)
            .ThenInclude(s => s.Condition)
            .FirstOrDefaultAsync(w => w.Id == workflowId && w.IsActive);

        if (workflow == null)
            throw new NotFoundException($"Active workflow {workflowId} not found");

        return await ExecuteWorkflowAsync(workflow, triggerData);
    }

    public async Task<WorkflowExecution> ExecuteWorkflowAsync(WorkflowDefinition workflow, object triggerData)
    {
        var execution = new WorkflowExecution
        {
            WorkflowId = workflow.Id,
            TriggerData = JsonSerializer.Serialize(triggerData),
            StartedAt = DateTime.UtcNow,
            Status = WorkflowExecutionStatus.Running,
            Steps = new List<WorkflowStepExecution>()
        };

        try
        {
            _context.WorkflowExecutions.Add(execution);
            await _context.SaveChangesAsync();

            // Execute workflow steps
            var context = new WorkflowExecutionContext
            {
                Execution = execution,
                TriggerData = triggerData,
                Variables = new Dictionary<string, object>(),
                ServiceProvider = _serviceProvider
            };

            await ExecuteWorkflowStepsAsync(workflow.Steps.OrderBy(s => s.Order), context);

            execution.CompletedAt = DateTime.UtcNow;
            execution.Status = WorkflowExecutionStatus.Completed;

            // Update workflow statistics
            workflow.ExecutionCount++;
            workflow.LastExecuted = DateTime.UtcNow;
            workflow.Statistics.TotalExecutions++;
            workflow.Statistics.SuccessfulExecutions++;

            await _context.SaveChangesAsync();

            // Notify about completion
            await _hubContext.Clients.Group($"workflow_{workflow.Id}")
                .SendAsync("WorkflowCompleted", execution);

            _logger.LogInformation("Workflow {WorkflowId} executed successfully in {Duration}ms",
                workflow.Id, (execution.CompletedAt - execution.StartedAt)?.TotalMilliseconds);

            return execution;
        }
        catch (Exception ex)
        {
            execution.CompletedAt = DateTime.UtcNow;
            execution.Status = WorkflowExecutionStatus.Failed;
            execution.ErrorMessage = ex.Message;
            execution.ErrorDetails = ex.ToString();

            workflow.Statistics.TotalExecutions++;
            workflow.Statistics.FailedExecutions++;

            await _context.SaveChangesAsync();

            _logger.LogError(ex, "Workflow {WorkflowId} execution failed", workflow.Id);

            // Notify about failure
            await _hubContext.Clients.Group($"workflow_{workflow.Id}")
                .SendAsync("WorkflowFailed", execution);

            throw new WorkflowExecutionException($"Workflow execution failed: {ex.Message}", ex);
        }
    }

    private async Task ExecuteWorkflowStepsAsync(
        IEnumerable<WorkflowStep> steps, 
        WorkflowExecutionContext context)
    {
        foreach (var step in steps)
        {
            var stepExecution = new WorkflowStepExecution
            {
                StepId = step.Id,
                StartedAt = DateTime.UtcNow,
                Status = WorkflowStepStatus.Running
            };

            context.Execution.Steps.Add(stepExecution);

            try
            {
                // Apply delay if specified
                if (step.Delay.HasValue)
                {
                    await Task.Delay(step.Delay.Value);
                }

                // Evaluate condition if present
                bool shouldExecute = true;
                if (step.Condition != null)
                {
                    shouldExecute = await EvaluateConditionAsync(step.Condition, context);
                }

                if (shouldExecute)
                {
                    // Execute action
                    var actionResult = await ExecuteActionAsync(step.Action, context);
                    stepExecution.Result = JsonSerializer.Serialize(actionResult);

                    // Execute true branch steps
                    if (step.TrueSteps.Any())
                    {
                        await ExecuteWorkflowStepsAsync(step.TrueSteps.OrderBy(s => s.Order), context);
                    }
                }
                else
                {
                    // Execute false branch steps
                    if (step.FalseSteps.Any())
                    {
                        await ExecuteWorkflowStepsAsync(step.FalseSteps.OrderBy(s => s.Order), context);
                    }
                }

                stepExecution.CompletedAt = DateTime.UtcNow;
                stepExecution.Status = WorkflowStepStatus.Completed;

                _logger.LogDebug("Workflow step {StepId} completed successfully", step.Id);
            }
            catch (Exception ex)
            {
                stepExecution.CompletedAt = DateTime.UtcNow;
                stepExecution.Status = WorkflowStepStatus.Failed;
                stepExecution.ErrorMessage = ex.Message;

                _logger.LogError(ex, "Workflow step {StepId} failed", step.Id);

                if (!step.ContinueOnError)
                {
                    throw;
                }
            }

            await _context.SaveChangesAsync();
        }
    }

    private async Task<bool> EvaluateConditionAsync(WorkflowCondition condition, WorkflowExecutionContext context)
    {
        return condition.Type switch
        {
            ConditionType.PropertyEquals => EvaluatePropertyEquals(condition, context),
            ConditionType.PropertyGreaterThan => EvaluatePropertyGreaterThan(condition, context),
            ConditionType.PropertyLessThan => EvaluatePropertyLessThan(condition, context),
            ConditionType.PropertyContains => EvaluatePropertyContains(condition, context),
            ConditionType.CustomScript => await EvaluateCustomScriptAsync(condition, context),
            ConditionType.TimeBasedCondition => EvaluateTimeBasedCondition(condition, context),
            _ => true
        };
    }

    private async Task<object> ExecuteActionAsync(WorkflowAction action, WorkflowExecutionContext context)
    {
        return action.Type switch
        {
            ActionType.SendEmail => await ExecuteSendEmailActionAsync(action, context),
            ActionType.CreateTask => await ExecuteCreateTaskActionAsync(action, context),
            ActionType.UpdateTask => await ExecuteUpdateTaskActionAsync(action, context),
            ActionType.SendNotification => await ExecuteSendNotificationActionAsync(action, context),
            ActionType.CallWebhook => await ExecuteCallWebhookActionAsync(action, context),
            ActionType.ExecuteScript => await ExecuteScriptActionAsync(action, context),
            ActionType.WaitForApproval => await ExecuteWaitForApprovalActionAsync(action, context),
            _ => throw new NotSupportedException($"Action type {action.Type} not supported")
        };
    }

    private async Task<object> ExecuteCreateTaskActionAsync(WorkflowAction action, WorkflowExecutionContext context)
    {
        var taskService = _serviceProvider.GetRequiredService<ITaskService>();
        
        var createDto = new CreateTaskDto
        {
            Title = ProcessTemplate(action.Parameters["title"].ToString()!, context),
            Description = ProcessTemplate(action.Parameters["description"].ToString()!, context),
            Priority = Enum.Parse<TaskPriority>(action.Parameters["priority"].ToString()!),
            DueDate = action.Parameters.ContainsKey("dueDate") 
                ? DateTime.Parse(action.Parameters["dueDate"].ToString()!) 
                : null,
            AssigneeId = action.Parameters.ContainsKey("assigneeId") 
                ? action.Parameters["assigneeId"].ToString() 
                : null
        };

        var task = await taskService.CreateTaskAsync(createDto);
        
        _logger.LogInformation("Workflow action created task {TaskId}: {Title}", task.Id, task.Title);
        
        return new { TaskId = task.Id, Title = task.Title };
    }

    private string ProcessTemplate(string template, WorkflowExecutionContext context)
    {
        // Simple template processing - replace {{variable}} with actual values
        var result = template;
        
        foreach (var variable in context.Variables)
        {
            result = result.Replace($"{{{{{variable.Key}}}}}", variable.Value?.ToString() ?? "");
        }

        return result;
    }
}

// Background service for handling workflow triggers
public class WorkflowTriggerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WorkflowTriggerService> _logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessScheduledWorkflowsAsync();
                await ProcessEventTriggersAsync();
                
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in workflow trigger service");
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }

    private async Task ProcessScheduledWorkflowsAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var workflowEngine = scope.ServiceProvider.GetRequiredService<IWorkflowEngine>();

        var dueWorkflows = await context.WorkflowDefinitions
            .Where(w => w.IsActive && 
                       w.Trigger.Type == TriggerType.Schedule &&
                       w.Trigger.NextExecution <= DateTime.UtcNow)
            .ToListAsync();

        foreach (var workflow in dueWorkflows)
        {
            try
            {
                await workflowEngine.ExecuteWorkflowAsync(workflow.Id, new { TriggeredAt = DateTime.UtcNow });
                
                // Update next execution time
                workflow.Trigger.NextExecution = CalculateNextExecution(workflow.Trigger.Schedule!);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to execute scheduled workflow {WorkflowId}", workflow.Id);
            }
        }
    }
}
```

## ✅ Phase 11 Verification

**Test your autonomous AI features:**

1. **Analytics Dashboard:**
   - Create custom dashboards
   - Verify real-time data updates
   - Test data export functionality

2. **Multi-Tenant System:**
   - Test tenant isolation
   - Verify domain resolution
   - Check resource limits

3. **AI Recommendations:**
   - Generate task recommendations
   - Test productivity insights
   - Validate schedule optimization

4. **Workflow Automation:**
   - Create automated workflows
   - Test trigger conditions
   - Verify action execution

## 🎉 What You've Learned

In this phase, you mastered:

- ✅ **Autonomous feature development** with Agent Mode guidance
- ✅ **Advanced analytics systems** with real-time dashboards
- ✅ **Multi-tenant architecture** with complete data isolation
- ✅ **AI-powered recommendations** with machine learning integration
- ✅ **Workflow automation** with intelligent routing and actions
- ✅ **Complex system integration** with multiple service coordination
- ✅ **Enterprise-grade features** with scalability and performance

## 🤖 Agent Mode Best Practices

### 1. **Effective Prompting for Agent Mode**
```
1. Be specific about requirements
2. Include architectural preferences
3. Specify integration needs
4. Mention performance requirements
5. Request comprehensive implementations
```

### 2. **Complex Feature Development**
```
1. Break down into logical components
2. Define clear interfaces and contracts
3. Include error handling and logging
4. Plan for scalability and performance
5. Add comprehensive testing
```

### 3. **System Integration Patterns**
```
1. Use dependency injection consistently
2. Implement proper separation of concerns
3. Add comprehensive error boundaries
4. Include monitoring and observability
5. Plan for configuration management
```

## 💡 Pro Tips for Agent Mode

1. **Describe the complete picture** - Give Agent Mode full context of what you're building
2. **Request production-ready code** - Ask for error handling, logging, and testing
3. **Specify architectural patterns** - Mention design patterns and principles you want to follow
4. **Include performance requirements** - Specify scalability and performance needs
5. **Ask for comprehensive implementations** - Request complete feature sets, not just partial implementations

## 🎯 Workshop Complete! 🎉

**Congratulations!** You've completed all 11 phases of the comprehensive GitHub Copilot workshop! You've mastered:

- ✅ **Basic Code Completions** - Foundation development skills
- ✅ **Interactive AI Chat** - Architecture design and code reviews
- ✅ **Context-Aware Editing** - Model enhancement and validation
- ✅ **Quick Actions** - Service layer generation and interfaces
- ✅ **Code Optimization** - Refactoring and performance improvements
- ✅ **Smart Error Handling** - Robust error boundaries and edge cases
- ✅ **Advanced Feature Building** - Complete multi-line implementations
- ✅ **Automated Git Workflow** - Intelligent commit messages
- ✅ **Comprehensive Testing** - Unit, integration, and performance tests
- ✅ **Complete Documentation** - API docs, diagrams, and user guides
- ✅ **Autonomous Development** - Agent Mode for complex feature creation


**💡 Pro Tip**: Agent Mode represents the future of development - autonomous AI that can understand complex requirements and implement complete features. Embrace this technology to become a more effective developer!

## 🚀 Next Steps

Continue your GitHub Copilot journey:

1. **Apply skills to real projects** - Use these techniques in your daily development
2. **Explore advanced features** - Keep up with new Copilot capabilities
3. **Share knowledge** - Teach these techniques to your team
4. **Contribute feedback** - Help improve Copilot through usage and feedback
5. **Stay updated** - Follow GitHub Copilot updates and new features

---

**🏆 GitHub Copilot Master!** You've completed the entire workshop and mastered all aspects of GitHub Copilot! You're now equipped with cutting-edge AI development skills that will transform your productivity! 🤖

[![🎉 Workshop Complete! Back to Home](https://img.shields.io/badge/🎉-Workshop%20Complete!%20Back%20to%20Home-gold?style=flat-square)](../README.md)

