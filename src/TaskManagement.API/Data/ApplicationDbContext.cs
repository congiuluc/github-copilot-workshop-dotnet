// TODO: Phase 1 - Add necessary using statements for Entity Framework Core

namespace TaskManagement.API.Data;

// TODO: Phase 1 - Create ApplicationDbContext class that:
// - Inherits from DbContext
// - Has constructor that accepts DbContextOptions<ApplicationDbContext>
// - Has DbSet<TaskItem> Tasks property
// - Configures TaskItem entity in OnModelCreating method:
//   * Set primary key
//   * Configure string length constraints
//   * Set up enum conversions for Priority and Status
//   * Add useful indexes
//   * Include seed data for demonstration
