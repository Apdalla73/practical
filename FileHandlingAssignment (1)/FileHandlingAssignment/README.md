# File Handling Assignment (C#)

## Project description
A simple C# Console Application that demonstrates file handling using `StreamWriter`, `StreamReader`, and the `File` class.

## Features
1. Create a text file and write text.
2. Read the text file.
3. Append new text to the file.
4. Delete one selected line.
5. Delete all content while keeping the file.
6. Delete the complete file.

## Classes and methods used
- `StreamWriter`
- `StreamReader`
- `File.CreateText()`
- `File.OpenText()`
- `File.AppendText()`
- `File.Exists()`
- `File.Delete()`
- `WriteLine()`
- `ReadLine()`
- `EndOfStream`
- `Close()` (the project uses `using` blocks to close files automatically)

## How to run
1. Open `FileHandlingAssignment.csproj` in Visual Studio.
2. Set the project as the startup project if needed.
3. Press **F5** or **Ctrl + F5**.
4. Use the menu in the console window.

## File location
`MyFile.txt` is created in the program's working directory when option 1 is selected.

## Important difference
- **Delete All Content** clears the text but keeps `MyFile.txt`.
- **Delete File** removes `MyFile.txt` itself.
