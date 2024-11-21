using System.Globalization;
using CsvHelper;

public class CsvHelperExample
{
    public static void WriteToCSV(string filePath, List<User> users)
    {
        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(users);
    }

    public static List<User> ReadFromCSV(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<User>().ToList();
        }
    }
}