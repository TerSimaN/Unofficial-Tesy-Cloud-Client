using System.Text;

public class TesyFileEditor
{
    private readonly StreamDeserializer deserializer = new();
    private readonly PayloadSerializer payloadSerializer = new();
    private StringBuilder? builder;

    public TesyFileEditor() { }

    /// <summary>
    /// Reads user email and password from a json file.
    /// </summary>
    /// <param name="filePath">The file to read from.</param>
    public CredentialsContent ReadUserCredentialsFromFile(string filePath)
    {
        string readContent = ReadFromFile(filePath);
        var credentialsContentResponse = deserializer.GetUserCredentialsContent(readContent);
        return credentialsContentResponse;
    }

    /// <summary>
    /// Writes serialized credentials to a json file.
    /// </summary>
    /// <param name="email">The <c>email</c> to write.</param>
    /// <param name="password">The <c>password</c> to write.</param>
    /// <param name="filePath">The file to write to.</param>
    public void WriteUserCredentialsToFile(string email, string password, string filePath)
    {
        string serializedCredentials = payloadSerializer.SerializeCredentialsAsJsonString(email, password);
        OverwriteExistingFile(filePath, serializedCredentials);
    }

    /// <summary>
    /// Opens an existing file on the given path and reads from it.
    /// </summary>
    /// <param name="filePath">The file to open for reading.</param>
    /// <returns>The read file contents as a string.</returns>
    public string ReadFromFile(string filePath)
    {
        builder = new();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist!");
        }
        else
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                var readLine = "";
                while ((readLine = sr.ReadLine()) != null)
                {
                    builder.Append(readLine);
                }
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Creates a new file on the given path if no file exists
    /// or writes to the already existing file.
    /// </summary>
    /// <param name="filePath">The file to write to.</param>
    /// <param name="content">The content to write.</param>
    public void WriteToFile(string filePath, string content)
    {
        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.Write(content);
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.Write(content);
            }
        }
    }

    /// <summary>
    /// Re-creates an existing file on the given path and writes to it.
    /// </summary>
    /// <param name="filePath">The file to re-create.</param>
    /// <param name="content">The content to write.</param>
    public void OverwriteExistingFile(string filePath, string content)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist!");
        }
        else
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.Write(content);
            }
        }
    }
}