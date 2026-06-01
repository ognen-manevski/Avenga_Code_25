Console.WriteLine("\n=================== FILE STREAMS =============\n");

//setup
string folderPath = @"..\..\..\TestFiles";

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

string fileName = "notes.txt";

string filePath = Path.Combine(folderPath, fileName);


Console.WriteLine("\n=========== StreamWriter =============\n");

try
{
    using (StreamWriter streamWriter = new StreamWriter(filePath)) //if it doesnt exist it will create the file, if it exists it will overwrite the file 
                                                                   //using closes the stream automatically at the end of the block,
                                                                   //even if an exception occurs, so we don't have to worry about it   
    {
        streamWriter.WriteLine("This is a simple note.");
        streamWriter.WriteLine("StreamWriter lets us write text line by line efficiently");
        streamWriter.WriteLine("It also allows you to append OR overwrite.");
    }

    using (StreamWriter streamWriter = new StreamWriter(filePath, true))  //true means append, false means overwrite
    {
        streamWriter.WriteLine("NEW This is a simple note.");
        streamWriter.WriteLine("NEW StreamWriter lets us write text line by line efficiently");
        streamWriter.WriteLine("NEW It also allows you to append OR overwrite.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}


Console.WriteLine("\n=========== StreamReader =============\n");

try
{
    using (StreamReader streamReader = new StreamReader(filePath))
    {
        //Console.WriteLine("Reading from file:");
        //string line1 = streamReader.ReadLine();
        //Console.WriteLine($"First line: {line1}");
        //string line2 = streamReader.ReadLine();
        //Console.WriteLine($"Second line: {line2}");

        string line = string.Empty;

        while ((line = streamReader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}