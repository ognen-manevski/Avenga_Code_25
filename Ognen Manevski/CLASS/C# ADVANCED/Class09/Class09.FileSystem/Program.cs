
Console.WriteLine("\n============= WORKING WITH FILE SYSTEM =============\n");

#region Paths

Console.WriteLine("\n============= PATHS =============\n");


//absolute paths
string studentRepoClassFullPath = @"C:\Users\code\Desktop\Ognen Manevski\Ognen Manevski\CLASS\C# ADVANCED\Class09";
string studentRepoHomeworksPath = @"C:\Users\code\Desktop\Ognen Manevski\Ognen Manevski\CLASS\C# ADVANCED\Class09\Homeworks";

//relative paths
string classReadmeRelativePath = @"..\..\..\README.md"; //starting from bin\Debug\net10.0

#endregion


#region Directory

Console.WriteLine("\n============= Directory =============\n");


//get urrent directory
string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine($"Current Directory: {currentDirectory}");

//check if directory exists
string testFolderPath = @"..\..\..\TestFolder";

bool testFolderExists = Directory.Exists(testFolderPath);

Console.WriteLine("The folder 'TestFolder' exists: {0}", testFolderExists); //what is this 0?
                                                                            //{0} is a placeholder for the value of testFolderExists

//create new folder
if(!testFolderExists)
{
    Directory.CreateDirectory(testFolderPath);
    Console.WriteLine("The folder 'TestFolder' has been created.");
}
else
{
    Console.WriteLine("The folder 'TestFolder' already exists.");
}

//delete a folder

if (Directory.Exists(testFolderPath))
{
    Directory.Delete(testFolderPath, true); //the second parameter is for recursive deletion,
                                            //if the folder is not empty it will delete all the contents of the folder
                                            //because it will throw an exception if the folder is not empty
    Console.WriteLine("The folder 'TestFolder' has been deleted.");
}

#endregion

#region File

Console.WriteLine("\n============= FILE =============\n");

//check if file exists
string testFolderPath2 = @"..\..\..\TestFolder2";
string fileName = "example.txt";

string filePath = @$"{testFolderPath2}\{fileName}";
string filePath2 = Path.Combine(testFolderPath2, fileName); // takes care of the path separator depending on the operating system!

//create a file

if (!Directory.Exists(testFolderPath2))
{
    Directory.CreateDirectory(testFolderPath2);
    Console.WriteLine("The folder 'TestFolder2' has been created.");
}

bool fileExists = File.Exists(filePath2);


if (!fileExists)
{
    File.Create(filePath2).Dispose(); // Dispose is called to release the file handle immediately
                                      // so we can delete it later without it being locked by the process
    //File.Create(filePath2).Close();
    // this works as well, but Dispose is more concise and is the recommended way to release resources in C#
    Console.WriteLine($"The file 'example.txt' has been created at {filePath2}.");
}
else
{
    Console.WriteLine($"The file 'example.txt' already exists at {filePath2}.");
}

//delete a file

if (File.Exists(filePath2))
{
    File.Delete(filePath2);    
    Console.WriteLine($"The file 'example.txt' has been deleted from {filePath2}.");
}


//write to a file

File.WriteAllText(filePath2, "Hello, World!");
// this will create the file if it doesn't exist, or overwrite it if it does exist

File.WriteAllText(filePath2, "Hello2"); //overwrites
File.AppendAllText(filePath2, "\nHello again!"); //appends to the file

//read from a file
string fileContent = File.ReadAllText(filePath2);
Console.WriteLine("File Content:");
Console.WriteLine(fileContent);

//get file info
FileInfo file2Info = new FileInfo(filePath2);
Console.WriteLine("The file's info:");
Console.WriteLine($"Full Name: {file2Info.FullName}");
Console.WriteLine($"Name: {file2Info.Name}");
Console.WriteLine($"Extension: {file2Info.Extension}");
Console.WriteLine($"Directory: {file2Info.DirectoryName}");
Console.WriteLine($"Size: {file2Info.Length} bytes");
Console.WriteLine($"Created: {file2Info.CreationTime}");
Console.WriteLine($"Last Accessed: {file2Info.LastAccessTime}");
Console.WriteLine($"Last Modified: {file2Info.LastWriteTime}");

#endregion


