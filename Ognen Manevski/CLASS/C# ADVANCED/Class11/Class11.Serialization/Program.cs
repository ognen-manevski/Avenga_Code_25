using Class11.Serialization.Classes;
using Class11.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

void WriteInFile(string filePath, string content)
{
    using (StreamWriter sw = new StreamWriter(filePath))
    {
        sw.Write(content);
    }
}


string ReadFromFile(string filePath, string content)
{
    using (StreamReader sr = new StreamReader(filePath))
    {
        return sr.ReadToEnd();
    }
}




string directoryPath = @"..\..\..\OurData";
string filePath = Path.Combine(directoryPath, "student.json");


#region Manual serializaton /deserialization

if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}


Student bob = new Student()
{
    FirstName = "Bob",
    LastName = "Bobsky",
    Age = 33,
    IsPartTime = false
};



string bobJson = OurJsonSerializer.SearializeStudent(bob);
//string bobJsonFromFile = ReadFromFile(filePath, bobJson);
//Console.WriteLine(bobJsonFromFile);
//Student bobFromJson = OurJsonSerializer.DeserializeStudent(bobJsonFromFile);
//WriteInFile(filePath, bobJson); 

#endregion


#region Newtonsoft JSON serialize / deserialize

string bobSerializedNewtonsoft = JsonConvert.SerializeObject(bob,Formatting.Indented);
WriteInFile(filePath, bobSerializedNewtonsoft);

Student bobDeserializedNewtonsoft = JsonConvert.DeserializeObject<Student>(bobSerializedNewtonsoft);
Console.WriteLine(ReadFromFile(filePath, bobSerializedNewtonsoft));


#endregion