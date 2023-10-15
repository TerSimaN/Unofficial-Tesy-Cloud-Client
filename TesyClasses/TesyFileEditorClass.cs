using System.Text;

public class TesyFileEditorClass
{
    private StringBuilder? builder;

    public TesyFileEditorClass() { }

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