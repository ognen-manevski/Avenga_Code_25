namespace Class10.Disposable;

internal class OurWriter : IDisposable
{

    private string _path;

    private readonly StreamWriter _writer;

    private bool _disposed;

    public OurWriter(string filePpath)
    {
        _path = filePpath;
        _writer = new StreamWriter(filePpath);
    }

    public void Write(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Must provide valid text value.");
        }
        if (_disposed)
        {
            throw new ObjectDisposedException("OurWriter is disposed");
        }
        _writer.WriteLine(text);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _writer.Dispose();
            }
            _path = string.Empty;
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

internal class OurReader : IDisposable
{
    private string _path;

    private readonly StreamReader _reader;

    private bool _disposed;

    public OurReader(string filePpath)
    {
        _path = filePpath;
        _reader = new StreamReader(filePpath);
    }


    public string Read()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException("OurReader is disposed");
        }
        return _reader.ReadToEnd();
    }
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _reader.Dispose();
            }
            _path = string.Empty;
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


}
