using System.Text;

namespace Tesy.Classes
{
    public static class Generator
    {
        private static readonly string mqttResponseMessagesFilePath = Constants.PathToMqttResponseMessagesFile;
        private static readonly string httpResponseMessagesFilePath = Constants.PathToHttpResponseMessagesFile;
        private static readonly Random random = new();

        private static readonly char[] smallLetters = {
            'a', 'b', 'c', 'd',
            'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p',
            'q', 'r', 's', 't',
            'u', 'v', 'w', 'x',
            'y', 'z'
        };
        private static readonly char[] bigLetters = {
            'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X',
            'Y', 'Z'
        };
        private static readonly char[] numbers = {
            '0', '1', '2', '3', '4',
            '5', '6', '7', '8', '9'
        };
        private static readonly int lengthOfSmallLettersArray = smallLetters.Length - 1;
        private static readonly int lengthOfBigLettersArray = bigLetters.Length - 1;
        private static readonly int lengthOfNumbersArray = numbers.Length - 1;

        /// <summary>
        /// Generates a new MqttResponseMessagesFile.
        /// </summary>
        public static void GenerateMqttResponseMessagesFile()
        {
            if (!File.Exists(mqttResponseMessagesFilePath))
            {
                using (StreamWriter sw = File.CreateText(mqttResponseMessagesFilePath))
                {
                    sw.WriteLine($"{Constants.CurrentTime}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(mqttResponseMessagesFilePath))
                {
                    sw.WriteLine($"{Constants.CurrentTime}");
                }
            }
        }

        /// <summary>
        /// Generates a new HttpResponseMessagesFile.
        /// </summary>
        public static void GenerateHttpResponseMessagesFile()
        {
            if (!File.Exists(httpResponseMessagesFilePath))
            {
                using (StreamWriter sw = File.CreateText(httpResponseMessagesFilePath))
                {
                    sw.WriteLine($"{Constants.CurrentTime}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(httpResponseMessagesFilePath))
                {
                    sw.WriteLine($"{Constants.CurrentTime}");
                }
            }
        }

        /// <summary>
        /// Generates a random string value used for <c>mqttClientId</c>.
        /// </summary>
        /// <returns>The generated string.</returns>
        public static string GenerateRandomMqttClientId()
        {
            StringBuilder clientIdBuilder = new();

            for (int ch = 0; ch < 36; ch++)
            {
                int symbolType = random.Next(1, 3);
                if (symbolType == 1)
                {
                    clientIdBuilder.Append(smallLetters[random.Next(lengthOfSmallLettersArray)]);
                }
                else
                {
                    clientIdBuilder.Append(numbers[random.Next(lengthOfNumbersArray)]);
                }
            }

            // string generatedClientId = clientIdBuilder.ToString();
            // Console.WriteLine($"generatedClientId: {generatedClientId}");

            return clientIdBuilder.ToString();
        }

        /// <summary>
        /// Generates a random string value used for <c>app_id</c>.
        /// </summary>
        /// <returns>The generated string.</returns>
        public static string GenerateRandomApplicationId()
        {
            StringBuilder appIdBuilder = new();

            for (int ch = 0; ch < 12; ch++)
            {
                int symbolType = random.Next(1, 3);
                if (symbolType == 1)
                {
                    appIdBuilder.Append(smallLetters[random.Next(lengthOfSmallLettersArray)]);
                }
                else
                {
                    appIdBuilder.Append(numbers[random.Next(lengthOfNumbersArray)]);
                }
            }

            // string generatedAppId = appIdBulder.ToString();
            // Console.WriteLine($"generatedAppId: {generatedAppId}");

            return appIdBuilder.ToString();
        }
    }
}