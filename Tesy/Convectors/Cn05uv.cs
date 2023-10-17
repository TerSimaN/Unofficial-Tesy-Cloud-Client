using Tesy.Commands;

namespace Tesy.Convectors
{
    public class Cn05uv
    {
        private string token = "";
        private string macAddress = "";
        private string model = "";
        private readonly MyDevices myDevices;

        public Cn05uv(MyDevices myDevices)
        {
            this.myDevices = myDevices;
            TryAddConvectorData();
        }

        /// <summary>
        /// Tries to set <c>token</c>, <c>macAddress</c> and <c>model</c> values
        /// for current <c>Cn05uvConvector</c> object using the given <c>TesyHttpClass</c>.
        /// </summary>
        private async void TryAddConvectorData()
        {
            var myDevicesContent = await myDevices.GetMyDevices();
            foreach (var deviceParam in myDevicesContent)
            {
                token = deviceParam.Value.Token;
                macAddress = deviceParam.Value.State.Mac;
                model = deviceParam.Value.Model;
            }
        }

        public string Token
        {
            get { return token; }
        }

        public string MacAddress
        {
            get { return macAddress; }
        }

        public string Model
        {
            get { return model; }
        }
    }
}