/* namespace Tesy.Commands;

class Documents
{
  private readonly TesyHttpClient httpClient;
  private readonly Dictionary<string, string> inputQueryParams = new();

  public Documents(TesyHttpClient httpClient)
  {
    this.httpClient = httpClient;
  }

  void getDocuments()
  {
            HttpResponseMessage responseMessage = httpClient.Get(TesyConstants.DocumentsUrl, inputQueryParams);
        Stream stream = responseMessage.Content.ReadAsStream();

        documentsResponse = deserializer.GetTesyDocumentsContent(stream);
        contentToWrite = ContentBuilder.BuildTesyDocumentsContentString(documentsResponse);
        tesyFileEditor.WriteToFile(httpResponseMessagesFilePath, contentToWrite);
  }
} */