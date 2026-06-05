using Class11.Serialization.Classes;
using System.Text;

namespace Class11.Serialization;

internal static class OurJsonSerializer
{

    public static string SearializeStudent(Student student)
    {
        //string json = "{\n";
        //json += $"  \"FirstName\": \"{student.FirstName}\",\n";
        //json += $"  \"LastName\": \"{student.LastName}\",\n";
        //json += $"  \"Age\": {student.Age},\n";
        //json += $"  \"IsPartTime\": {student.IsPartTime.ToString().ToLower()}\n";
        //json += "}";
        //return json;

        // using string builder is more efficient
        var sb = new StringBuilder();
        sb.AppendLine("{");
        sb.AppendLine($"  \"FirstName\": \"{student.FirstName}\",");
        sb.AppendLine($"  \"LastName\": \"{student.LastName}\",");
        sb.AppendLine($"  \"Age\": {student.Age},");
        sb.AppendLine($"  \"IsPartTime\": {student.IsPartTime.ToString().ToLower()}");
        sb.AppendLine("}");
        return sb.ToString();
    }

    public static string DeserializeStudent(string json)
    {
        /*
       {
           FirstName = "Bob",
           LastName = "Bobsky",
           Age = 33,
           IsPartTime = false
       }
        */

        string content = json.Trim().Trim('{', '}').Trim();
        string[] lines = content.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        Student student = new Student();
        foreach (string line in lines)
        {
            string[] parts = line.Split(
                new[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                string key = parts[0].Trim().Trim('"');
                string value = parts[1].Trim().Trim(',').Trim('"');
                switch (key)
                {
                    case "FirstName":
                        student.FirstName = value;
                        break;
                    case "LastName":
                        student.LastName = value;
                        break;
                    case "Age":
                        if (int.TryParse(value, out int age))
                        {
                            student.Age = age;
                        }
                        break;
                    case "IsPartTime":
                        if (bool.TryParse(value, out bool isPartTime))
                        {
                            student.IsPartTime = isPartTime;
                        }
                        break;
                }
            }
        }

        return null;

    }
}

