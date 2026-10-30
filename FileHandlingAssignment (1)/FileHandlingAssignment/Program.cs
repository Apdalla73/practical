using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string fileName = "MyFile.txt";

    static void Main()
    {
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("\n===== FILE HANDLING SYSTEM =====");
            Console.WriteLine("1. Create and Write File");
            Console.WriteLine("2. Read File");
            Console.WriteLine("3. Append File");
            Console.WriteLine("4. Delete Specific Line");
            Console.WriteLine("5. Delete All Content");
            Console.WriteLine("6. Delete File");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number.");
                choice = -1;
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateFile();
                    break;
                case 2:
                    ReadFile();
                    break;
                case 3:
                    AppendFile();
                    break;
                case 4:
                    DeleteSpecificLine();
                    break;
                case 5:
                    DeleteAllContent();
                    break;
                case 6:
                    DeleteFile();
                    break;
                case 0:
                    Console.WriteLine("Program closed.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    // Create a new file and write text into it.
    static void CreateFile()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        using (StreamWriter writer = File.CreateText(fileName))
        {
            writer.WriteLine(text);
        }

        Console.WriteLine("File created and text saved successfully.");
    }

    // Read all lines from the file.
    static void ReadFile()
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found. Create the file first.");
            return;
        }

        using (StreamReader reader = File.OpenText(fileName))
        {
            if (reader.EndOfStream)
            {
                Console.WriteLine("The file is empty.");
            }
            else
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }
    }

    // Add new text at the end of the file.
    static void AppendFile()
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found. Create the file first.");
            return;
        }

        Console.Write("Enter new text: ");
        string text = Console.ReadLine();

        using (StreamWriter writer = File.AppendText(fileName))
        {
            writer.WriteLine(text);
        }

        Console.WriteLine("Text appended successfully.");
    }

    // Remove one selected line, then save the remaining lines.
    static void DeleteSpecificLine()
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        List<string> lines = new List<string>();

        using (StreamReader reader = File.OpenText(fileName))
        {
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
        }

        if (lines.Count == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        Console.WriteLine("\nFile contents:");
        for (int i = 0; i < lines.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + lines[i]);
        }

        Console.Write("Enter the line number to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int lineNumber) ||
            lineNumber < 1 || lineNumber > lines.Count)
        {
            Console.WriteLine("Invalid line number.");
            return;
        }

        lines.RemoveAt(lineNumber - 1);

        using (StreamWriter writer = File.CreateText(fileName))
        {
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Selected line deleted successfully.");
    }

    // Keep the file, but remove all text inside it.
    static void DeleteAllContent()
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using (StreamWriter writer = File.CreateText(fileName))
        {
            // Creating the file again clears its previous contents.
        }

        Console.WriteLine("All content deleted. The file still exists.");
    }

    // Delete the file itself.
    static void DeleteFile()
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        File.Delete(fileName);
        Console.WriteLine("File deleted successfully.");
    }
}
