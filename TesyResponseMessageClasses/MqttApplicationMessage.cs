public static class MqttApplicationMessage
{
    private readonly static string formatedResponseMessagesFilePath = TesyConstants.PathToFormatedResponseMessagesFile;
    private static string contentToWrite = "";
    private readonly static TesyFileEditor tesyFileEditor = new();
    private readonly static ResponseDeserializer responseDeserializer = new();

    private static GetStatusContent? getStatusContentResponse;
    private static SetTempStatisticContent? setTempStatisticContentResponse;
    private static AppOnOffContent? appOnOffContentResponse;
    private static ConvectorOnOffContent? convectorOnOffContentResponse;
    private static AppSetAntiFrostContent? appSetAntiFrostContentResponse;
    private static ConvectorSetAntiFrostContent? convectorSetAntiFrostContentResponse;
    private static AppSetDelayedStartContent? appSetDelayedStartContentResponse;
    private static ConvectorSetDelayedStartContent? convectorSetDelayedStartContentResponse;
    private static AppSetSleepTempContent? appSetSleepTempContentResponse;
    private static ConvectorSetSleepTempContent? convectorSetSleepTempContentResponse;
    private static AppSetComfortTempContent? appSetComfortTempContentResponse;
    private static ConvectorSetComfortTempContent? convectorSetComfortTempContentResponse;
    private static AppSetEcoTempContent? appSetEcoTempContentResponse;
    private static ConvectorSetEcoTempContent? convectorSetEcoTempContentResponse;
    private static AppSetModeContent? appSetModeContentResponse;
    private static ConvectorSetModeContent? convectorSetModeContentResponse;
    private static AppSetTCorrectionContent? appSetTCorrectionContentResponse;
    private static ConvectorSetTCorrectionContent? convectorSetTCorrectionContentResponse;
    private static AppPingContent? appPingContentResponse;
    private static AppSetLockDeviceContent? appSetLockDeviceContentResponse;
    private static ConvectorSetLockDeviceContent? convectorSetLockDeviceContentResponse;
    private static AppSetOpenedWindowContent? appSetOpenedWindowContentResponse;
    private static ConvectorSetOpenedWindowContent? convectorSetOpenedWindowContentResponse;
    private static AppSetAdaptiveStartContent? appSetAdaptiveStartContentResponse;
    private static ConvectorSetAdaptiveStartContent? convectorSetAdaptiveStartContentResponse;
    private static ConvectorWifiInfoContent? convectorWifiInfoContentResponse;
    private static AppGetSSIDContent? appGetSSIDContentResponse;
    private static AppSetUVContent? appSetUVContentResponse;
    private static ConvectorSetUVContent? convectorSetUVContentResponse;
    private static AppSetProgramContent? appSetProgramContentResponse;
    private static ConvectorSetProgramContent? convectorSetProgramContentResponse;
    private static ConvectorSetStatisticContent? convectorSetStatisticContentResponse;
    private static AppDeleteProgramContent? appDeleteProgramContentResponse;
    private static ConvectorDeleteProgramContent? convectorDeleteProgramContentResponse;
    private static AppTimeResponseContent? appTimeResponseContentResponse;
    private static AppDeleteAllProgramsContent? appDeleteAllProgramsContentResponse;
    
    public static void DeserializeApplicationMessagePayload(string payload)
    {
        if (payload.Contains("null") && payload.Contains("getStatus"))
        {
            getStatusContentResponse = responseDeserializer.GetStatusContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildGetStatusContentString(getStatusContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setTempStatistic"))
        {
            setTempStatisticContentResponse = responseDeserializer.GetSetTempStatisticContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildSetTempStatisticContentString(setTempStatisticContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("onOff"))
        {
            appOnOffContentResponse = responseDeserializer.GetAppOnOffContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppOnOffContentString(appOnOffContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("onOff"))
        {
            convectorOnOffContentResponse = responseDeserializer.GetConvectorOnOffContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorOnOffContentString(convectorOnOffContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setAntiFrost"))
        {
            appSetAntiFrostContentResponse = responseDeserializer.GetAppSetAntiFrostContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetAntiFrostContentString(appSetAntiFrostContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setAntiFrost"))
        {
            convectorSetAntiFrostContentResponse = responseDeserializer.GetConvectorSetAntiFrostContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetAntiFrostContentString(convectorSetAntiFrostContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setDelayedStart"))
        {
            appSetDelayedStartContentResponse = responseDeserializer.GetAppSetDelayedStartContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetDelayedStartContentString(appSetDelayedStartContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setDelayedStart"))
        {
            convectorSetDelayedStartContentResponse = responseDeserializer.GetConvectorSetDelayedStartContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetDelayedStartContentString(convectorSetDelayedStartContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setSleepTemp"))
        {
            appSetSleepTempContentResponse = responseDeserializer.GetAppSetSleepTempContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetSleepTempContentString(appSetSleepTempContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setSleepTemp"))
        {
            convectorSetSleepTempContentResponse = responseDeserializer.GetConvectorSetSleepTempContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetSleepTempContentString(convectorSetSleepTempContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setComfortTemp"))
        {
            appSetComfortTempContentResponse = responseDeserializer.GetAppSetComfortTempContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetComfortTempContentString(appSetComfortTempContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setComfortTemp"))
        {
            convectorSetComfortTempContentResponse = responseDeserializer.GetConvectorSetComfortTempContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetComfortTempContentString(convectorSetComfortTempContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setEcoTemp"))
        {
            appSetEcoTempContentResponse = responseDeserializer.GetAppSetEcoTempContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetEcoTempContentString(appSetEcoTempContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setEcoTemp"))
        {
            convectorSetEcoTempContentResponse = responseDeserializer.GetConvectorSetEcoTempContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetEcoTempContentString(convectorSetEcoTempContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setMode"))
        {
            appSetModeContentResponse = responseDeserializer.GetAppSetModeContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetModeContentString(appSetModeContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setMode"))
        {
            convectorSetModeContentResponse = responseDeserializer.GetConvectorSetModeContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetModeContentString(convectorSetModeContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setTCorrection"))
        {
            appSetTCorrectionContentResponse = responseDeserializer.GetAppSetTCorrectionContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetTCorrectionContentString(appSetTCorrectionContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setTCorrection"))
        {
            convectorSetTCorrectionContentResponse = responseDeserializer.GetConvectorSetTCorrectionContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetTCorrectionContentString(convectorSetTCorrectionContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("ping"))
        {
            appPingContentResponse = responseDeserializer.GetAppPingContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppPingContentString(appPingContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setLockDevice"))
        {
            appSetLockDeviceContentResponse = responseDeserializer.GetAppSetLockDeviceContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetLockDeviceContentString(appSetLockDeviceContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setLockDevice"))
        {
            convectorSetLockDeviceContentResponse = responseDeserializer.GetConvectorSetLockDeviceContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetLockDeviceContentString(convectorSetLockDeviceContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setOpenedWindow"))
        {
            appSetOpenedWindowContentResponse = responseDeserializer.GetAppSetOpenedWindowContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetOpenedWindowContentString(appSetOpenedWindowContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setOpenedWindow"))
        {
            convectorSetOpenedWindowContentResponse = responseDeserializer.GetConvectorSetOpenedWindowContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetOpenedWindowContentString(convectorSetOpenedWindowContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setAdaptiveStart"))
        {
            appSetAdaptiveStartContentResponse = responseDeserializer.GetAppSetAdaptiveStartContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetAdaptiveStartContentString(appSetAdaptiveStartContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setAdaptiveStart"))
        {
            convectorSetAdaptiveStartContentResponse = responseDeserializer.GetConvectorSetAdaptiveStartContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetAdaptiveStartContentString(convectorSetAdaptiveStartContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("wifiinfo"))
        {
            convectorWifiInfoContentResponse = responseDeserializer.GetConvectorWifiInfoContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorWifiInfoContentString(convectorWifiInfoContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("getSSID"))
        {
            appGetSSIDContentResponse = responseDeserializer.GetAppGetSSIDContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppGetSSIDContentString(appGetSSIDContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setUV"))
        {
            appSetUVContentResponse = responseDeserializer.GetAppSetUVContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetUVContentString(appSetUVContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setUV"))
        {
            convectorSetUVContentResponse = responseDeserializer.GetConvectorSetUVContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetUVContentString(convectorSetUVContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("setProgram"))
        {
            appSetProgramContentResponse = responseDeserializer.GetAppSetProgramContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppSetProgramContentString(appSetProgramContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setProgram"))
        {
            convectorSetProgramContentResponse = responseDeserializer.GetConvectorSetProgramContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetProgramContentString(convectorSetProgramContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("setStatistic"))
        {
            convectorSetStatisticContentResponse = responseDeserializer.GetConvectorSetStatisticContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorSetStatisticContentString(convectorSetStatisticContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("deleteProgram"))
        {
            appDeleteProgramContentResponse = responseDeserializer.GetAppDeleteProgramContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppDeleteProgramContentString(appDeleteProgramContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("deleteProgram"))
        {
            convectorDeleteProgramContentResponse = responseDeserializer.GetConvectorDeleteProgramContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildConvectorDeleteProgramContentString(convectorDeleteProgramContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("timeResponse"))
        {
            appTimeResponseContentResponse = responseDeserializer.GetAppTimeResponseContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppTimeResponseContentString(appTimeResponseContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
        else if (payload.Contains("null") && payload.Contains("deleteAllPrograms"))
        {
            appDeleteAllProgramsContentResponse = responseDeserializer.GetAppDeleteAllProgramsContent(payload);
            contentToWrite = ResponseMessageContentBuilder.BuildAppDeleteAllProgramsContentString(appDeleteAllProgramsContentResponse);
            tesyFileEditor.WriteToFile(formatedResponseMessagesFilePath, contentToWrite);
        }
    }
}