using System.Text.Json;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.DataAccess.FileHandlers;

public static class JsonFileHandler
{

    //using JsonSerializer to read and write to json files,
    //so we can store the data in a structured format


    //===================================
    // READ FROM FILE
    //===================================
    public static List<T> ReadFromFile<T>(string filePath) where T : BaseEntity
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string jsonContent = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                return new List<T>();
            }

            var data = JsonSerializer.Deserialize<List<T>>(jsonContent);

            return data ?? new List<T>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return new List<T>();
        }
        //returns an empty list in case of error, so the app doesnt crash
    }

    //===================================
    // WRITE TO FILE
    //===================================

    public static void WriteToFile<T>(string filePath, List<T> data) where T : BaseEntity
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                //enable pretty print
                WriteIndented = true
            };

            string jsonContent = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, jsonContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }


    //===================================
    // CHECK EXISTS
    //===================================


    //initiate the file and dir if it doesnt exist
    public static void EnsureFileExists(string filePath)
    {
        try
        {
            //GetDirectoryName returns null if the path is null, empty or root.
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error ensuring file exists: {ex.Message}");
        }
    }
}
