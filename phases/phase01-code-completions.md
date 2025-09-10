# 🔧 Phase 01: Code Completions - Project Foundation

**🎯 GitHub Copilot Feature**: [Code Completions](https://docs.github.com/en/copilot/using-github-copilot/getting-code-suggestions-in-your-ide-with-github-copilot)

[![⬅️ Back to Workshop Home](https://img.shields.io/badge/⬅️-Back%20to%20Workshop%20Home-blue?style=flat-square)](../README.md)

## 🎯 Objective

Learn how GitHub Copilot's code completion feature works by setting up the foundation of our Task Management API project. You'll experience how Copilot suggests entire lines and blocks of code based on context.

## 📖 About Code Completions

GitHub Copilot's code completions provide intelligent suggestions as you type:
- **Real-time suggestions** appear as gray text
- **Context-aware** - understands your project structure
- **Multi-line completions** for complex patterns
- **Tab to accept** suggestions, **Escape to dismiss**

## 🛠️ What You'll Build

In this phase, you'll create:
- ✅ New .NET Web API project
- ✅ Project structure and configuration
- ✅ Basic model classes
- ✅ DbContext setup

## 📋 Step-by-Step Instructions

### Step 1: Create the Project Structure 🏗️

**Follow these exact steps to create your project:**

1. **Open VS Code:**
   - Launch Visual Studio Code
   - If you have an existing workspace open, close it: File → Close Workspace

2. **Open integrated terminal:**
   - Press `Ctrl+` ` (Windows/Linux) or `Cmd+` ` (Mac)
   - OR go to View → Terminal

3. **Navigate to your workspace directory:**
   ```bash
   cd "d:\Customers\customer\workshop_dotnet"
   ```

4. **Create a new Web API project:**
   - Type this exact command:
   ```bash
   dotnet new webapi -n TaskManagementAPI --framework net8.0
   ```
   - ✅ Verify: You see "The template was created successfully" message

5. **Navigate to the project directory:**
   ```bash
   cd TaskManagementAPI
   ```

6. **Open the project in current VS Code window:**
   ```bash
   code . -r
   ```
   - ✅ Verify: Project files appear in VS Code Explorer panel

7. **Trust the workspace:**
   - When prompted "Do you trust the authors of the files in this folder?", click "Yes, I trust the authors"

8. **Install required packages:**
   - In the terminal, run these commands one by one:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
   ```
   - ✅ Verify: Each package installation completes successfully

### Step 2: Experience Your First Code Completion 🤖

**Learn how Copilot code completions work:**

1. **Open the Program.cs file:**
   - Click on `Program.cs` in the VS Code Explorer panel
   - ✅ Verify: File opens in the editor

2. **Position your cursor for completion:**
   - Scroll to the bottom of the file
   - Click at the end of the last line `app.Run();`
   - Press `Enter` to create a new line

3. **Start typing a comment to trigger Copilot:**
   - Type exactly: `// Add`
   - ⏱️ Wait 2-3 seconds
   - ✅ Watch: Gray text suggestions appear from Copilot
   - 💡 Example: You might see `// Add database configuration` or similar

4. **Accept your first completion:**
   - Press `Tab` to accept the suggestion
   - OR press `Escape` to dismiss it
   - Try typing different comment starters like `// TODO:` or `// Configure`

5. **Test code completion with actual code:**
   - Delete the comment you just added
   - Type: `var`
   - ⏱️ Wait for Copilot suggestions
   - ✅ Watch: Copilot suggests variable declarations
   - Press `Escape` to dismiss (we'll add real code next)
### Step 3: Create Models with Code Completion 📋

**Build your first model classes using Copilot assistance:**

1. **Create Models folder:**
   - Right-click on the project root in Explorer panel
   - Select "New Folder"
   - Type: `Models`
   - Press `Enter`

2. **Create TaskItem model:**
   - Right-click on the `Models` folder
   - Select "New File"
   - Type: `TaskItem.cs`
   - Press `Enter`

3. **Let Copilot help build the model:**
   - In the empty `TaskItem.cs` file, start typing:
   ```csharp
   using System.ComponentModel.DataAnnotations;

   namespace TaskManagementAPI.Models;

   public class TaskItem
   {
   ```
   - ⏱️ Wait for Copilot suggestions after typing the opening brace
   - ✅ Watch: Copilot suggests properties for a task model
   - Press `Tab` to accept useful suggestions

4. **Complete the TaskItem model with specific properties:**
   - Continue typing (let Copilot help with each property):
   ```csharp
   public int Id { get; set; }
   
   [Required]
   [StringLength(200)]
   public string Title { get; set; } = string.Empty;
   
   public string? Description { get; set; }
   ```
   - ✅ Notice: Copilot suggests additional properties as you type
   - Accept suggestions for properties like `IsCompleted`, `CreatedAt`, etc.

5. **Add enum for task status:**
   - Create new file: `Models/TaskStatus.cs`
   - Start typing:
   ```csharp
   namespace TaskManagementAPI.Models;

   public enum TaskStatus
   {
   ```
   - ✅ Watch: Copilot suggests enum values like `NotStarted`, `InProgress`, `Completed`
   - Accept the suggestions by pressing `Tab`

6. **Create TaskPriority enum:**
   - Create new file: `Models/TaskPriority.cs`
   - Type the namespace and enum declaration
   - Let Copilot suggest priority values (`Low`, `Medium`, `High`, `Critical`)

7. **Complete the TaskItem model:**
   - Go back to `TaskItem.cs`
   - Add more properties with Copilot's help:
   ```csharp
   public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
   public TaskPriority Priority { get; set; } = TaskPriority.Medium;
   public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
   public DateTime? UpdatedAt { get; set; }
   public DateTime? DueDate { get; set; }
   public bool IsCompleted { get; set; }
   public string? AssigneeId { get; set; }
   ```

3. **Continue typing to add Entity Framework:**
   ```csharp
   // Add Entity Framework Core
   builder.Services.AddDbContext
   ```
   ✨ **Copilot Magic:** Press `Tab` when Copilot suggests the complete method signature

### Step 3: Add Required NuGet Packages 📦

1. **In Terminal, add Entity Framework packages:**
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Microsoft.EntityFrameworkCore.Design
   ```

### Step 4: Create Model Classes with Copilot 📝

1. **Create a new folder** called `Models` (right-click in Explorer → New Folder)

2. **Create `TaskItem.cs`** in the Models folder:
   ```csharp
   namespace TaskManagementAPI.Models;
   
   // Define a task item model for our task management system
   ```
   
   **🎯 Copilot Prompt Practice:** 
   - Position cursor after the comment
   - Start typing `public class TaskItem`
   - Let Copilot suggest the complete class structure
   - Accept suggestions with `Tab`

   **Expected Result:**
   ```csharp
   namespace TaskManagementAPI.Models;
   
   public class TaskItem
   {
       public int Id { get; set; }
       public string Title { get; set; } = string.Empty;
       public string Description { get; set; } = string.Empty;
       public bool IsCompleted { get; set; }
       public DateTime CreatedAt { get; set; }
       public DateTime? CompletedAt { get; set; }
       public Priority Priority { get; set; }
   }
   ```

3. **Create `Priority.cs`** enum in Models folder:
   ```csharp
   namespace TaskManagementAPI.Models;
   
   // Priority levels for tasks
   public enum Priority
   ```
   
   **🎯 Copilot Prompt Practice:**
   - Let Copilot complete the enum values
   - Expected: `Low, Medium, High, Critical`

### Step 4: Create DbContext with Smart Completions 🗄️

**Set up Entity Framework DbContext with Copilot assistance:**

1. **Create Data folder:**
   - Right-click project root → "New Folder" → Name it `Data`

2. **Create ApplicationDbContext file:**
   - Right-click `Data` folder → "New File" → Name it `ApplicationDbContext.cs`

3. **Start with using statements:**
   ```csharp
   using Microsoft.EntityFrameworkCore;
   using TaskManagementAPI.Models;

   namespace TaskManagementAPI.Data;

   // Database context for task management system
   public class ApplicationDbContext : DbContext
   {
   ```

4. **Let Copilot suggest the constructor:**
   - Position cursor after the opening brace `{`
   - Start typing: `public ApplicationDbContext(`
   - ✅ Watch: Copilot suggests constructor with `DbContextOptions<ApplicationDbContext> options`
   - Press `Tab` to accept:
   ```csharp
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
   {
   }
   ```

5. **Add DbSet properties:**
   - Type: `public DbSet<`
   - ✅ Watch: Copilot suggests `TaskItem> Tasks { get; set; }`
   - Accept the suggestion

6. **Configure entity relationships:**
   - Start typing: `protected override void OnModelCreating(`
   - Let Copilot complete the method and add configurations

7. **Register DbContext in Program.cs:**
   - Open `Program.cs`
   - After `builder.Services.AddControllers();`, add:
   ```csharp
   builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   ```

8. **Add connection string to appsettings.json:**
   - Open `appsettings.json`
   - Add after the existing content:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagementDB;Trusted_Connection=true;MultipleActiveResultSets=true"
   }
   ```
   public class TaskDbContext : DbContext
   ```
   
   **🎯 Copilot Prompt Practice:**
   - Position cursor after the class declaration
   - Start typing constructor - let Copilot suggest the complete constructor
   - Add DbSet properties - watch Copilot suggest the pattern

   **Expected Result:**
   ```csharp
   using Microsoft.EntityFrameworkCore;
   using TaskManagementAPI.Models;
   
   namespace TaskManagementAPI.Data;
   
   public class TaskDbContext : DbContext
   {
       public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
       {
       }
   
       public DbSet<TaskItem> Tasks { get; set; }
   
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
           
           modelBuilder.Entity<TaskItem>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
               entity.Property(e => e.Description).HasMaxLength(1000);
               entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
           });
       }
   }
   ```

### Step 6: Configure Services in Program.cs 🔧

1. **Open `Program.cs`** and modify it:
   ```csharp
   using Microsoft.EntityFrameworkCore;
   using TaskManagementAPI.Data;
   
   var builder = WebApplication.CreateBuilder(args);
   
   // Add services to the container
   builder.Services.AddControllers();
   
   // Configure Entity Framework
   ```
   
   **🎯 Copilot Prompt Practice:**
   - After the comment, start typing `builder.Services.AddDbContext`
   - Let Copilot suggest the complete configuration
   - Accept the suggestion for SQL Server configuration

   **Expected Completion:**
   ```csharp
   builder.Services.AddDbContext<TaskDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   ```

2. **Complete the Program.cs configuration:**
   ```csharp
   builder.Services.AddEndpointsApiExplorer();
   builder.Services.AddSwagger();
   
   var app = builder.Build();
   
   // Configure the HTTP request pipeline
   if (app.Environment.IsDevelopment())
   {
       app.UseSwagger();
       app.UseSwaggerUI();
   }
   
   app.UseHttpsRedirection();
   app.UseAuthorization();
   app.MapControllers();
   
   app.Run();
   ```

### Step 7: Add Configuration 📄

1. **Update `appsettings.json`:**
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagementDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

## ✅ Phase 1 Verification

**Follow these steps to verify your setup:**

1. **Build the project:**
   - Open VS Code terminal (`Ctrl+` ` or View → Terminal)
   - Run the build command:
   ```bash
   dotnet build
   ```
   - ✅ Verify: "Build succeeded" message appears
   - ✅ Verify: No compilation errors

2. **Check project structure:**
   - Verify these folders and files exist:
   ```
   TaskManagementAPI/
   ├── Models/
   │   ├── TaskItem.cs
   │   ├── TaskStatus.cs
   │   └── TaskPriority.cs
   ├── Data/
   │   └── ApplicationDbContext.cs
   ├── Program.cs
   └── appsettings.json
   ```

3. **Test Entity Framework setup:**
   - Run this command to verify EF tools:
   ```bash
   dotnet ef
   ```
   - ✅ Verify: EF commands list appears (not an error)

4. **Create your first migration:**
   ```bash
   dotnet ef migrations add InitialCreate
   ```
   - ✅ Verify: Migration files created in `Migrations` folder

5. **Validate code completion experience:**
   - Open any `.cs` file
   - Start typing a comment: `// This`
   - ✅ Verify: Gray Copilot suggestions appear
   - Press `Escape` to dismiss
   - ✅ Verify: You can trigger and accept completions

## 🎉 What You've Learned

In this phase, you experienced:

- ✅ **Real-time code suggestions** as you type
- ✅ **Context-aware completions** based on your project structure
- ✅ **Multi-line suggestions** for complex patterns
- ✅ **Smart import suggestions** for namespaces
- ✅ **Pattern recognition** for common .NET structures

## 🧠 Key Copilot Tips from Phase 1

1. **Write descriptive comments** - Copilot uses them as context
2. **Use meaningful names** - They help Copilot understand your intent
3. **Be patient** - Sometimes better suggestions appear after a short pause
4. **Accept partially** - Use `Ctrl+→` to accept word by word
5. **Reject and retry** - Press `Escape` and try typing differently

## 🔄 Troubleshooting

**Problem:** Copilot not showing suggestions
- ✅ Check the Copilot icon in status bar (should be green)
- ✅ Sign in to GitHub in VS Code
- ✅ Restart VS Code

**Problem:** Suggestions not relevant
- ✅ Add more context with comments
- ✅ Use more descriptive variable/class names
- ✅ Ensure proper namespaces are imported

**💡 Pro Tip**: Start with simple comments and let Copilot surprise you with its understanding of your intent. The more context you provide through descriptive naming and comments, the better suggestions you'll receive!


## 🎯 Next Phase

Ready to dive deeper? In [Phase 02: Copilot Chat](./phase02-copilot-chat.md), you'll learn how to have interactive conversations with GitHub Copilot to design and implement complex features! 💬

---

**🏆 Congratulations!** You've completed Phase 01 and experienced the power of GitHub Copilot's code completions. The AI suggested entire code blocks based on minimal input - imagine the productivity boost! 🚀

[![➡️ Next: Phase 02 - Copilot Chat](https://img.shields.io/badge/➡️-Next%3A%20Phase%2002%20Copilot%20Chat-green?style=flat-square)](phase02-copilot-chat.md)

