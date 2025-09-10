// TODO: Phase 2 - Add necessary using statements

namespace TaskManagement.API.Controllers;

// TODO: Phase 2 - Create TasksController class that:
// - Has [ApiController] and [Route("api/[controller]")] attributes
// - Inherits from ControllerBase
// - Injects ApplicationDbContext and ILogger through constructor
// 
// Implement the following endpoints with proper error handling:
// - GET /api/tasks - GetTasks() - Returns all tasks
// - GET /api/tasks/{id} - GetTask(int id) - Returns specific task
// - POST /api/tasks - CreateTask(TaskItem task) - Creates new task  
// - PUT /api/tasks/{id} - UpdateTask(int id, TaskItem task) - Updates task
// - DELETE /api/tasks/{id} - DeleteTask(int id) - Deletes task
//
// Each endpoint should include:
// - Proper HTTP status codes (200, 201, 404, 400, 500)
// - Try-catch blocks for error handling
// - Logging for operations and errors
// - Model validation
// - XML documentation comments
