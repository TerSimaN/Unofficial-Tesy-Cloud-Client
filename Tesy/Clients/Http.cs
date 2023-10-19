namespace Tesy.Clients
{
    public class Http
    {
        private Uri BaseUrl = new Uri("https://tesycloud.studioxbeta.dev/rest/", UriKind.Absolute);
        private string userEmail = "";
        private string userPass = "";

        public Http() {}

        /// <summary>
        /// Constructor of the HttpClient class.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="userPass">The user password.</param>
        public Http(string userEmail, string userPass)
        {
            this.userEmail = userEmail;
            this.userPass = userPass;
        }

        /// <summary>
        /// Builds a query string using the given <c>queryParameters</c>.
        /// </summary>
        /// <param name="queryParams">The <c>queryParameters</c> used to build the query string.</param>
        /// <returns>The query string.</returns>
        private string BuildQueryString(Dictionary<string, string>? queryParams)
        {
            string queryString = "?";
            Dictionary<string, string> queryStringParts = new();
            queryStringParts.Add("userEmail", userEmail);
            queryStringParts.Add("userPass", userPass);

            if (queryParams != null)
            {
                foreach (var queryParam in queryParams)
                {
                    queryStringParts.Add(queryParam.Key, queryParam.Value);
                }
            }

            foreach (var queryStringPart in queryStringParts)
            {
                queryString += $"{queryStringPart.Key}={queryStringPart.Value}";
                queryString += queryStringParts.Last().Equals(queryStringPart) ? "" : "&";
            }

            return queryString;
        }

        /// <summary>
        /// Makes a <c>GET</c> request using the given parameters.
        /// </summary>
        /// <param name="path">The <c>path</c> given to the <c>GET</c> request.</param>
        /// <param name="queryParams">The <c>queryParameters</c> given to the <c>GET</c> request.</param>
        /// <returns>The <c>HttpResponseMessage</c> returned from sending the <c>GET</c> request.</returns>
        public HttpResponseMessage Get(string path, Dictionary<string, string>? queryParams)
        {
            HttpClient httpClient = new();
            string queryString = BuildQueryString(queryParams);
            
            Uri requestUri = new Uri(BaseUrl, new Uri(path + queryString, UriKind.Relative));
            // Console.WriteLine($"RequestUri: {requestUri}");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpResponseMessage httpResponseMessage = httpClient.Send(httpRequestMessage);
            
            return httpResponseMessage;
        }

        /// <summary>
        /// Makes a <c>POST</c> request using the given parameters.
        /// </summary>
        /// <param name="path">The <c>path</c> given to the <c>POST</c> request.</param>
        /// <param name="queryParams">The query <c>queryParameters</c> given to the <c>POST</c> request.</param>
        /// <returns>The <c>HttpResponseMessage</c> returned from sending the <c>POST</c> request.</returns>
        public HttpResponseMessage Post(string path, Dictionary<string, string>? queryParams)
        {
            HttpClient httpClient = new();
            string queryString = BuildQueryString(queryParams);

            Uri requestUri = new Uri(BaseUrl, new Uri(path + queryString, UriKind.Relative));
            // Console.WriteLine($"RequestUri: {requestUri}");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            HttpResponseMessage httpResponseMessage = httpClient.Send(httpRequestMessage);

            return httpResponseMessage;
        }
    }
}