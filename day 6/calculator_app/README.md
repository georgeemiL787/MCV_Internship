# OOP Calculator Application

A simple calculator application built with Object-Oriented Programming concepts in C#.

## Features

- **Basic Operations**: Addition, Subtraction, Multiplication, Division
- **Advanced Operations**: Percentage calculation, Power calculation, Square root
- **Utility Functions**: Even/Odd number detection
- **Comprehensive Error Handling**: Try-catch blocks throughout the application
- **User-Friendly Interface**: Clear menu system with input validation

## OOP Concepts Applied

1. **Encapsulation**: Calculator logic is encapsulated in the `Calculator` class
2. **Separation of Concerns**: UI logic is separated into `CalculatorUI` class
3. **Single Responsibility**: Each class has a specific responsibility
4. **Error Handling**: Comprehensive exception handling with specific catch blocks

## How to Run

1. **Using .NET CLI**:
   ```bash
   dotnet run
   ```

2. **Using Visual Studio**:
   - Open the project in Visual Studio
   - Press F5 or click "Start Debugging"

3. **Compile and Run**:
   ```bash
   dotnet build
   dotnet run
   ```

## Available Operations

1. **Addition (+)**: Add two numbers
2. **Subtraction (-)**: Subtract second number from first
3. **Multiplication (*)**: Multiply two numbers
4. **Division (/)**: Divide first number by second (with zero division protection)
5. **Percentage (%)**: Calculate percentage of a total value
6. **Even or Odd**: Determine if a number is even or odd
7. **Power (x^y)**: Calculate base number raised to an exponent
8. **Square Root**: Calculate square root of a number
9. **Exit**: Close the application

## Error Handling

The application includes comprehensive error handling for:
- Invalid input formats
- Division by zero
- Negative numbers for square root
- Invalid percentage values
- General exceptions

## Project Structure

```
calculator_app/
├── calculator.cs          # Main calculator application
├── CalculatorApp.csproj   # Project file
└── README.md             # This file
```

## Requirements

- .NET 8.0 or later
- Windows, macOS, or Linux 