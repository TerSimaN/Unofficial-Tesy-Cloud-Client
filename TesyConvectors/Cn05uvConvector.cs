public class Cn05uvConvector
{
    private string token = "";
    private string macAddress = "";
    private string model = "";

    public Cn05uvConvector(TesyHttpClass tesyHttpClass)
    {
        TryAddConvectorData(tesyHttpClass);
    }

    /// <summary>
    /// Tries to set <c>token</c>, <c>macAddress</c> and <c>model</c> values
    /// for current <c>Cn05uvConvector</c> object using the given <c>TesyHttpClass</c>.
    /// </summary>
    /// <param name="tesyHttpClass">The <c>TesyHttpClass</c> object to use.</param>
    private void TryAddConvectorData(TesyHttpClass tesyHttpClass)
    {
        Dictionary<string, MyDevicesContent> myDevicesContent = tesyHttpClass.MyDevicesContentResponse;
        foreach (var deviceParam in myDevicesContent)
        {
            Token = deviceParam.Value.Token;
            MacAddress = deviceParam.Value.State.Mac;
            Model = deviceParam.Value.Model;
        }
    }

    public string Token
    {
        get { return token; }
        set { token = value; }
    }

    public string MacAddress
    {
        get { return macAddress; }
        set { macAddress = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}