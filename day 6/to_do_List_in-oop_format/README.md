# To-Do List Application (OOP Version)

This is an Object-Oriented Programming (OOP) version of the to-do list application, demonstrating key OOP concepts and principles.

## OOP Concepts Implemented

### 1. **Classes and Objects**
- **Task Class**: Represents individual tasks with properties and methods
- **TaskManager Class**: Manages the collection of tasks and business logic
- **UserInterface Class**: Handles user interactions and display
- **Program Class**: Main application entry point

### 2. **Encapsulation**
- Private fields in classes (e.g., `tasks`, `filename`, `nextId` in TaskManager)
- Public properties and methods for controlled access
- Data hiding - internal implementation details are hidden from other classes

### 3. **Abstraction**
- Complex operations are simplified through method interfaces
- Users interact with high-level methods without knowing implementation details
- Clear separation of concerns between different classes

### 4. **Single Responsibility Principle**
- Each class has a single, well-defined responsibility:
  - `Task`: Represents a single task
  - `TaskManager`: Manages task operations and persistence
  - `UserInterface`: Handles user interaction
  - `Program`: Orchestrates the application

### 5. **Data Persistence**
- Tasks are saved to and loaded from a text file
- Each task is serialized with multiple properties (ID, description, dates, completion status)
- Error handling for file operations

## Features

### Enhanced Functionality
- **Task Completion Tracking**: Mark tasks as complete/incomplete with timestamps
- **Task Filtering**: View all, pending, or completed tasks separately
- **Statistics**: View completion rates and task counts
- **Confirmation Dialogs**: Confirm before deleting tasks
- **Better Error Handling**: Robust input validation and error messages

### Improved User Experience
- Clear menu system with numbered options
- Visual indicators for task completion status ([✓] vs [ ])
- Completion timestamps for completed tasks
- Pause between operations for better readability

## File Structure

```
to_do_List_in-oop_format/
├── Task.cs              # Task class definition
├── TaskManager.cs       # Task management and persistence
├── UserInterface.cs     # User interaction handling
├── Program.cs           # Main application entry point
├── ToDoListOOP.csproj   # Project configuration
└── README.md           # This documentation
```

## How to Run

1. Navigate to the project directory
2. Run the application:
   ```bash
   dotnet run
   ```

## OOP Benefits Demonstrated

1. **Maintainability**: Code is organized into logical, reusable classes
2. **Extensibility**: Easy to add new features by extending existing classes
3. **Testability**: Each class can be tested independently
4. **Reusability**: Classes can be reused in other applications
5. **Readability**: Clear separation of concerns makes code easier to understand

## Comparison with Procedural Version

The original procedural version had all functionality in a single class with static methods. This OOP version:
- Separates concerns into different classes
- Makes the code more modular and maintainable
- Provides better encapsulation and data hiding
- Demonstrates proper object-oriented design principles 