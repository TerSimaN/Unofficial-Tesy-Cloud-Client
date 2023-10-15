using System.Text.Json;

public class ResponseDeserializer
{
    private readonly JsonSerializerOptions options = new() { AllowTrailingCommas = true };

    public GetStatusContent GetStatusContent(string content)
    {
        var response = JsonSerializer.Deserialize<GetStatusContent>(content);
        return response ?? new(
            -1, "Message not found", "AppId not found", "Command not found",
            new(
                new GetStatusOnOffPayload(
                    new GetStatusOnOffPayloadContent("Status not found")
                ),
                new GetStatusSetModePayload(
                    new GetStatusSetModePayloadContent("Name not found")
                ),
                new GetStatusSetTempPayload(
                    new GetStatusSetTempPayloadContent(-1)
                ),
                new GetStatusSetAdaptiveStartPayload(
                    new GetStatusSetAdaptiveStartPayloadContent("Status not found")
                ),
                new GetStatusSetOpenedWindowPayload(
                    new GetStatusSetOpenedWindowPayloadContent("Status not found")
                ),
                new GetStatusSetDelayedStartPayload(
                    new GetStatusSetDelayedStartPayloadContent("Status not found", -1, -1)
                ),
                new GetStatusSetTCorrectionPayload(
                    new GetStatusSetTCorrectionPayloadContent(-1)
                ),
                new GetStatusSetAntiFrostPayload(
                    new GetStatusSetAntiFrostPayloadContent("Status not found")
                ),
                new GetStatusSetComfortTempPayload(
                    new GetStatusSetComfortTempPayloadContent(-1)
                ),
                new GetStatusSetEcoTempPayload(
                    new GetStatusSetEcoTempPayloadContent(-1, -1)
                ),
                new GetStatusSetSleepTempPayload(
                    new GetStatusSetSleepTempPayloadContent(-1, -1)
                ),
                new GetStatusSetUVPayload(
                    new GetStatusSetUVPayloadContent("Status not found")
                ),
                new GetStatusSetLockDevicePayload(
                    new GetStatusSetLockDevicePayloadContent("Status not found")
                )
            )
        );
    }

    public SetTempStatisticContent GetSetTempStatisticContent(string content)
    {
        var response = JsonSerializer.Deserialize<SetTempStatisticContent>(content);
        return response ?? new(
            -1, "Message not found", -1, "Command not found",
            new(-1, -1, -1, -1, "Command not found", "Heating not found")
        );
    }

    public AppOnOffContent GetAppOnOffContent(string content)
    {
        var response = JsonSerializer.Deserialize<AppOnOffContent>(content);
        return response ?? new(
            -1, "Message not found", "AppId not found", "Command not found",
            new("Status not found")
        );
    }

    public ConvectorOnOffContent GetConvectorOnOffContent(string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorOnOffContent>(content);
        return response ?? new(
            -1, "Message not found", -1, "Command not found",
            new("Status not found", -1)
        );
    }

    public AppSetAntiFrostContent GetAppSetAntiFrostContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetAntiFrostContent>(content);
        return response ?? new(
            -1, "Message not found", "AppId not found", "Command not found",
            new("Status not found")
        );
    }

    public ConvectorSetAntiFrostContent GetConvectorSetAntiFrostContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetAntiFrostContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Status not found", -1)
		);
    }

    public AppSetDelayedStartContent GetAppSetDelayedStartContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetDelayedStartContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new(-1, -1)
		);
    }

    public ConvectorSetDelayedStartContent GetConvectorSetDelayedStartContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetDelayedStartContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Status not found", -1, -1)
		);
    }

    public AppSetSleepTempContent GetAppSetSleepTempContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetSleepTempContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new(-1)
		);
    }

    public ConvectorSetSleepTempContent GetConvectorSetSleepTempContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetSleepTempContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Name not found", -1)
		);
    }

    public AppSetComfortTempContent GetAppSetComfortTempContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetComfortTempContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new(-1)
		);
    }

    public ConvectorSetComfortTempContent GetConvectorSetComfortTempContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetComfortTempContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new(-1, -1)
		);
    }

    public AppSetEcoTempContent GetAppSetEcoTempContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetEcoTempContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new(-1, -1)
		);
    }

    public ConvectorSetEcoTempContent GetConvectorSetEcoTempContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetEcoTempContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new(-1, -1, -1)
		);
    }

    public AppSetModeContent GetAppSetModeContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetModeContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new("Name not found")
		);
    }

    public ConvectorSetModeContent GetConvectorSetModeContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetModeContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Name not found", -1)
		);
    }

    public AppSetTCorrectionContent GetAppSetTCorrectionContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetTCorrectionContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new(-10)
		);
    }

    public ConvectorSetTCorrectionContent GetConvectorSetTCorrectionContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetTCorrectionContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new(-10, -1)
		);
    }

    public AppPingContent GetAppPingContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppPingContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new()
		);
    }

    public AppSetLockDeviceContent GetAppSetLockDeviceContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetLockDeviceContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new("Status not found")
		);
    }

    public ConvectorSetLockDeviceContent GetConvectorSetLockDeviceContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetLockDeviceContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Status not found", -1)
		);
    }

    public AppSetOpenedWindowContent GetAppSetOpenedWindowContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetOpenedWindowContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new("Status not found")
		);
    }

    public ConvectorSetOpenedWindowContent GetConvectorSetOpenedWindowContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetOpenedWindowContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Status not found", -1)
		);
    }

    public AppSetAdaptiveStartContent GetAppSetAdaptiveStartContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetAdaptiveStartContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new("Status not found")
		);
    }

    public ConvectorSetAdaptiveStartContent GetConvectorSetAdaptiveStartContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetAdaptiveStartContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Status not found", -1)
		);
    }

    public ConvectorWifiInfoContent GetConvectorWifiInfoContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorWifiInfoContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("WifiInfo not found", -1)
		);
    }

    public AppGetSSIDContent GetAppGetSSIDContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppGetSSIDContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new()
		);
    }

    public AppSetUVContent GetAppSetUVContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetUVContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new("Status not found")
		);
    }

    public ConvectorSetUVContent GetConvectorSetUVContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetUVContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new("Status not found", -1)
		);
    }

    public AppSetProgramContent GetAppSetProgramContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppSetProgramContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new(-1, "From not found", "To not found", -1, "ProgramNumber not found")
		);
    }

    public ConvectorSetProgramContent GetConvectorSetProgramContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetProgramContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new(-1, "From not found", "To not found", -1, -1, -1)
		);
    }

    public ConvectorSetStatisticContent GetConvectorSetStatisticContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorSetStatisticContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new(-1, -1, -1, -1, "From not found", "To not found", -1, "Command not found")
		);
    }

    public AppDeleteProgramContent GetAppDeleteProgramContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppDeleteProgramContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new("ProgramNumber not found")
		);
    }

    public ConvectorDeleteProgramContent GetConvectorDeleteProgramContent (string content)
    {
        var response = JsonSerializer.Deserialize<ConvectorDeleteProgramContent>(content);
        return response ?? new(
			-1, "Message not found", -1, "Command not found",
            new(-1, -1)
		);
    }

    public AppTimeResponseContent GetAppTimeResponseContent (string content)
    {
        var response = JsonSerializer.Deserialize<AppTimeResponseContent>(content);
        return response ?? new(
			-1, "Message not found", "AppId not found", "Command not found",
            new(-1, "Time not found")
		);
    }

    public AppDeleteAllProgramsContent GetAppDeleteAllProgramsContent(string content)
    {
        var response = JsonSerializer.Deserialize<AppDeleteAllProgramsContent>(content);
        return response ?? new(
            -1, "Message not found", "AppId not found", "Command not found",
            new()
        );
    }
}