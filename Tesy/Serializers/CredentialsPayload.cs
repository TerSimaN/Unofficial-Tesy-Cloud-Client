using System.Text.Json;

namespace Tesy.Serializers
{
    class CredentialsParams
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class CredentialsPayload
    {
        /// <summary>
        /// Serializes credentials as JSON string.
        /// </summary>
        /// <param name="email">The <c>email</c> to serialize.</param>
        /// <param name="password">The <c>password</c> to serialize.</param>
        /// <returns>Serialized JSON string.</returns>
        public string SerializeParamsAsJsonString(string email, string password)
        {
            var @params = new CredentialsParams
            {
                Email = email,
                Password = password
            };

            string jsonString = JsonSerializer.Serialize(@params, TesyConstants.SerializerOptions);

            return jsonString;
        }
    }
}