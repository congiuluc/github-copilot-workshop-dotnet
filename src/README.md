# 🚀 Getting Started with Task Management API

This folder contains a **complete .NET 8 Web API project** that serves as the foundation for the GitHub Copilot workshop.

## 📁 Project Structure

```
src/
└── TaskManagement.API/
    ├── Controllers/
    │   └── TasksController.cs      # Complete REST API controller
    ├── Data/
    │   └── ApplicationDbContext.cs # Entity Framework DbContext
    ├── Models/
    │   └── TaskItem.cs            # Task entity model
    ├── Program.cs                 # Application entry point
    ├── appsettings.json          # Configuration
    └── TaskManagement.API.csproj  # Project file
```

## 🎯 What's Included

### ✅ **Complete Task Management API**
- **Full CRUD Operations**: Create, Read, Update, Delete tasks
- **RESTful Endpoints**: GET, POST, PUT, DELETE with proper HTTP status codes
- **Entity Framework Core**: Database integration with SQL Server LocalDB
- **Swagger Documentation**: Interactive API documentation
- **Logging**: Comprehensive logging throughout the application
- **Error Handling**: Proper exception handling and error responses

### ✅ **Ready-to-Use Features**
- **TasksController**: Complete controller with all CRUD operations
- **ApplicationDbContext**: EF Core DbContext with task entity configuration
- **TaskItem Model**: Full entity model with properties and enums
- **Seed Data**: Pre-populated with sample tasks for testing
- **Configuration**: Connection strings and app settings configured

### ✅ **Development Ready**
- **Local Database**: Uses SQL Server LocalDB (no setup required)
- **Swagger UI**: Available at `/swagger` for API testing
- **Development Configuration**: Separate settings for development
- **Modern .NET 8**: Latest framework with all modern features

## 🏁 Quick Start

### 1. **Open the Project**
```bash
# Navigate to the workshop directory
cd d:\Customers\customer\workshop_dotnet

# Open in VS Code
code .
```

### 2. **Restore Dependencies**
```bash
# Restore NuGet packages
dotnet restore
```

### 3. **Run Database Migrations**
```bash
# Create and apply database migrations
dotnet ef migrations add InitialCreate --project src/TaskManagement.API
dotnet ef database update --project src/TaskManagement.API
```

### 4. **Run the Application**
```bash
# Start the API
dotnet run --project src/TaskManagement.API
```

### 5. **Test the API**
- Open browser to: `https://localhost:5001/swagger`
- Use Swagger UI to test all endpoints
- Try creating, reading, updating, and deleting tasks

## 🎨 Perfect for GitHub Copilot Workshop

This project is specifically designed to work with the GitHub Copilot workshop phases:

### **Phase 1**: Code Completions
- Use the existing models and controllers as foundation
- Let Copilot suggest method implementations and properties

### **Phase 2**: Copilot Chat  
- Ask Copilot to review and improve the existing code
- Get architectural suggestions for the API structure

### **Phase 3**: Inline Chat
- Use inline chat to modify specific methods
- Get context-aware suggestions for improvements

### **Phase 4**: Slash Commands
- Use `/explain` on complex methods
- Use `/tests` to generate unit tests for controllers

### **Phase 5+**: Advanced Features
- Build upon this solid foundation
- Add authentication, validation, advanced features

## 🔧 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks` | Get all tasks |
| GET | `/api/tasks/{id}` | Get task by ID |
| POST | `/api/tasks` | Create new task |
| PUT | `/api/tasks/{id}` | Update task |
| DELETE | `/api/tasks/{id}` | Delete task |

## 📊 Sample Data

The database includes sample tasks:
- ✅ **Setup development environment** (Completed)
- 🔄 **Learn GitHub Copilot features** (In Progress)  
- 📋 **Build Task Management API** (Not Started)

## 🎯 Benefits of This Approach

### ✅ **Immediate Productivity**
- Start coding right away with a working API
- No time spent on basic project setup
- Focus on learning Copilot features

### ✅ **Real-World Context**
- Work with actual business logic
- Practice on realistic scenarios  
- See Copilot's suggestions in context

### ✅ **Progressive Enhancement**
- Build upon existing solid foundation
- Add complexity gradually through workshop phases
- See evolution from basic to advanced features

### ✅ **Best Practices Included**
- Modern .NET 8 patterns and conventions
- Proper error handling and logging
- RESTful API design principles
- Entity Framework best practices

## 🚀 Ready to Start!

Your Task Management API is ready to use! Open the project in VS Code and begin exploring GitHub Copilot's powerful features with a real, working codebase.

**Next Step**: Open [Phase 01: Code Completions](./phases/phase01-code-completions.md) and start the workshop! 🎉
