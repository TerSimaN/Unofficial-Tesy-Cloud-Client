using System.Text;
using MQTTnet;
using MQTTnet.Client;

public static class TesyMqttClient
{
    private static readonly string filePath = TesyConstants.PathToMqttResponseMessagesFile;
    private static readonly string webSocketServer = "mqtt.tesy.com:8083";
    private static readonly string mqttUsername = "client1";
    private static readonly string mqttPassword = "123";
    private static readonly string appMqttVersion = "v1";
    private static string mqttClientId = Generator.GenerateRandomMqttClientId();

    private static MqttFactory mqttFactory = new MqttFactory();
    private static IMqttClient mqttClient = mqttFactory.CreateMqttClient();
    private static MqttClientOptions mqttClientOptions = new MqttClientOptionsBuilder()
        .WithWebSocketServer(webSocketServer)
        .WithCredentials(mqttUsername, mqttPassword)
        .WithClientId(mqttClientId)
        .WithTls()
        .Build();
    private static MqttClientDisconnectOptions mqttClientDisconnectOptions = new MqttClientDisconnectOptionsBuilder()
        .WithReason(MqttClientDisconnectOptionsReason.NormalDisconnection)
        .Build();
    private static MqttTopicFilterBuilder mqttTopicFilter = new MqttTopicFilterBuilder();

    /// <summary>
    /// Connects the Client to the MQTT Server.
    /// </summary>
    public static async Task ConnectClient()
    {
        var connectResponse = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
        Console.WriteLine("\nThe MQTT client is connected.");
    }

    /// <summary>
    /// Disconnects the Client from the MQTT Server.
    /// </summary>
    public static async Task DisconnectClient()
    {
        mqttClient.InspectPacketAsync += e =>
        {
            Console.WriteLine("\nRecieved inspect packet on disconnect.");

            if (e.Direction == MQTTnet.Diagnostics.MqttPacketFlowDirection.Inbound)
            {
                string bufferIn = Encoding.UTF8.GetString(e.Buffer);
                Console.WriteLine($"IN: {bufferIn}");
            }
            else
            {
                string bufferOut = Encoding.UTF8.GetString(e.Buffer);
                Console.WriteLine($"OUT: {bufferOut}");
            }

            return Task.CompletedTask;
        };

        await mqttClient.DisconnectAsync(mqttClientDisconnectOptions, CancellationToken.None);
        Console.WriteLine("\nThe MQTT client is disconnected.");
    }

    /// <summary>
    /// Subscribes the Client to a Device.
    /// </summary>
    /// <param name="macAddress">The <c>macAddress</c> of the Device to subscribe to.</param>
    public static async Task SubscribeForDevice(string macAddress)
    {
        var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
            .WithTopicFilter(
                mqttTopicFilter.WithTopic($"{appMqttVersion}/{macAddress}/response/#")
            )
            .WithTopicFilter(
                mqttTopicFilter.WithTopic($"{appMqttVersion}/{macAddress}/getStatusResponse")
            )
            .WithTopicFilter(
                mqttTopicFilter.WithTopic($"{appMqttVersion}/{macAddress}/timeRequest/#")
            )
            .WithTopicFilter(
                mqttTopicFilter.WithTopic($"{appMqttVersion}/{macAddress}/pingRequest/#")
            )
            .Build();
        
        var subscribeResponse = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        Console.WriteLine($"\nMQTT client subscribed for {macAddress}.");
    }

    /// <summary>
    /// Unscubscribes the Client from a Device.
    /// </summary>
    /// <param name="macAddress">The <c>macAddress</c> of the Device to unsubscribe from.</param>
    public static async Task UnsubscribeForDevice(string macAddress)
    {
        var mqttUnsubscribeOptions = mqttFactory.CreateUnsubscribeOptionsBuilder()
            .WithTopicFilter($"{appMqttVersion}/{macAddress}/response/#")
            .WithTopicFilter($"{appMqttVersion}/{macAddress}/getStatusResponse")
            .WithTopicFilter($"{appMqttVersion}/{macAddress}/timeRequest/#")
            .WithTopicFilter($"{appMqttVersion}/{macAddress}/pingRequest/#")
            .Build();
        
        var unsubscribeResponse = await mqttClient.UnsubscribeAsync(mqttUnsubscribeOptions, CancellationToken.None);
        Console.WriteLine($"\nMQTT client unsubscribed for {macAddress}.");
    }

    /// <summary>
    /// Publishes a message to the MQTT Server.
    /// </summary>
    /// <param name="macAddress"><c>macAddress</c> of the Device receiving the message.</param>
    /// <param name="requestType"><c>requestType</c> being sent with the message.</param>
    /// <param name="model"><c>model</c> of the Device receiving the message.</param>
    /// <param name="token"><c>token</c> of the Device receiving the message.</param>
    /// <param name="command"><c>command</c> being sent with the message.</param>
    /// <param name="payload"><c>payload</c> being sent with the message.</param>
    public static async Task PublishMessage(string macAddress, string requestType, string model, string token, string command, string payload)
    {
        string topic = $"{appMqttVersion}/{macAddress}/{requestType}/{model}/{token}/{command}";

        var applicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(payload)
            .Build();
        
        var publishResponse = await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
        Console.WriteLine("\nMQTT application message is published.");
    }

    /// <summary>
    /// Handles messages received from the MQTT Server.
    /// </summary>
    public static void HandleRecievedMessages()
    {
        mqttClient.ApplicationMessageReceivedAsync += e =>
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            string currentHour = (currentTime.Hour < 10) ? $"0{currentTime.Hour}" : $"{currentTime.Hour}";
            string currentMinute = (currentTime.Minute < 10) ? $"0{currentTime.Minute}" : $"{currentTime.Minute}";
            string currentSecond = (currentTime.Second < 10) ? $"0{currentTime.Second}" : $"{currentTime.Second}";
            string applicationMessagePayload = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment);

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.Write($"{currentHour}:{currentMinute}:{currentSecond}.{currentTime.Millisecond} ");
                sw.WriteLine($"ApplicationMessage.PayloadSegment: {applicationMessagePayload}");
                sw.WriteLine("------------------------------------------------------------");
            }

            return Task.CompletedTask;
        };
    }
}