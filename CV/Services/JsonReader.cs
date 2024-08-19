using CV.Models;
using System.Text.Json;

namespace CV.Services
{
    public class JsonReader : IJsonReader
    {
        public Experience ReadJsonFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                Experience? Jobs = JsonSerializer.Deserialize<Experience>(jsonString);
                return Jobs ?? new();
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to parse JSON.", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while reading the file.", ex);
            }
        }
    }
}
