using Class10.Disposable;

Console.WriteLine("=============== Disposing ===============");

string FolderPath = @"..\..\..\TextFolder";
string FilePath = Path.Combine(FolderPath, "text.txt");


static void CreateFolder(string path)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path); //cant dispose + no need
    }
}

static void CreateFile(string path)
{
    if (!File.Exists(path))  // we need to close the file stream after creating the file, otherwise it will be locked and we won't be able to write to it
    {
        File.Create(path).Close();
    }
}

CreateFolder(FolderPath);
CreateFile(FilePath);


Console.WriteLine("============= Manual dispose methods ===================");

void AppendTextInFile(string text, string filePath)
{
    StreamWriter sw = new StreamWriter(filePath, true);
    sw.WriteLine(text);
    sw.Dispose();
}

void ReadFromFile(string path)
{
    StreamReader sr = new StreamReader(path);
    Console.WriteLine(sr.ReadToEnd());
    sr.Dispose();
}

void ManualDisposeExample()
{
    Console.WriteLine("Enter text part 1: ");
    string text1 = Console.ReadLine();
    AppendTextInFile(text1, FilePath);

    Console.WriteLine("Enter text part 2: ");
    string text2 = Console.ReadLine();
    AppendTextInFile(text2, FilePath);

    Console.WriteLine("Enter text part 3: ");
    string text3 = Console.ReadLine();
    AppendTextInFile(text3, FilePath);

    Console.ReadLine();

    Console.WriteLine("---------------- Read -----------------");
    ReadFromFile(FilePath);

    //clean the file
    File.WriteAllText(FilePath, string.Empty);
}

//ManualDisposeExample();



Console.WriteLine("============ Dispose with Using block ===================");


void AppendTextInFileWithUsing(string text, string filePath)
{
    StreamWriter sw = new StreamWriter(filePath, true);
    using (sw)
    {
        sw.WriteLine(text);
    }
}



void ReadFromFileWithUsing(string path)
{
    StreamReader sr = new StreamReader(path);
    using (sr)
    {
        Console.WriteLine(sr.ReadToEnd());
    }
}

void ManualDisposeExampleWithUsing()
{
    Console.WriteLine("Enter text part 1: ");
    string text1 = Console.ReadLine();
    AppendTextInFileWithUsing(text1, FilePath);

    Console.WriteLine("Enter text part 2: ");
    string text2 = Console.ReadLine();
    AppendTextInFileWithUsing(text2, FilePath);

    Console.WriteLine("Enter text part 3: ");
    string text3 = Console.ReadLine();
    AppendTextInFileWithUsing(text3, FilePath);

    Console.ReadLine();

    Console.WriteLine("---------------- Read -----------------");
    ReadFromFileWithUsing(FilePath);

    //clean the file
    File.WriteAllText(FilePath, string.Empty);
}

ManualDisposeExampleWithUsing();

Console.WriteLine("============ Disposing with our own \"disposable\" class ===================");


static void AppendTextInFileCustomDisposing(string text, string path)
{
    //OurWriter writer = new OurWriter(path);
    //OurWriter.Write(text);
    //OurWriter.Dispose();

    using (OurWriter writer = new OurWriter(path))
    {
        writer.Write(text);
    }
}

void ReadTExtFromFileOurCustomDisposing(string path)
{
    using (OurReader reader = new OurReader(path))
    {
        Console.WriteLine(reader.Read());
    }
}



void OurDisposableExample()
{
    Console.WriteLine("Enter text part 1: ");
    string text1 = Console.ReadLine();
    AppendTextInFileCustomDisposing(text1, FilePath);
    Console.WriteLine("Enter text part 2: ");
    string text2 = Console.ReadLine();
    AppendTextInFileCustomDisposing(text2, FilePath);
    Console.WriteLine("Enter text part 3: ");
    string text3 = Console.ReadLine();
    AppendTextInFileCustomDisposing(text3, FilePath);
    Console.ReadLine();
    Console.WriteLine("---------------- Read -----------------");
    ReadTExtFromFileOurCustomDisposing(FilePath);
    //clean the file
    File.WriteAllText(FilePath, string.Empty);
}

OurDisposableExample();