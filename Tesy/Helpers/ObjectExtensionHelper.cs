using System.Text.Json;

namespace Tesy.Helpers
{
    public static class ObjectExtensionHelper
    {
        public static TObject DumpToConsole<TObject>(this TObject @object)
        {
            var output = "NULL";
            if (@object != null)
            {
                output = JsonSerializer.Serialize(@object, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }

            Console.WriteLine($"[{@object?.GetType().Name}]:\r\n{output}");
            return @object;
        }

        public static TObject DumpToFile<TObject>(this TObject @object, string filePath)
        {
            var output = "NULL";
            if (@object != null)
            {
                output = JsonSerializer.Serialize(@object, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"[{@object?.GetType().Name}]:\r\n{output}");
            }

            return @object;
        }
    }
}