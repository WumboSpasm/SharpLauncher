using System.Text;
using Newtonsoft.Json.Linq;

namespace SharpLauncher
{
    public static class Config
    {
        // Configuration data
        public static string FlashpointPath { get; set; } = ".";
        public static string CLIFpPath { get; set; } = @".\CLIFp\CLIFp.exe";
        public static string FlashpointServer { get; set; } = "http://infinity.unstable.life/Flashpoint";

        public static bool NeedsRefresh { get; set; } = true;

        // Replace data with values from config file
        public static void Read()
        {
            using (StreamReader jsonStream = new("config.json"))
            {
                JObject readConfig = JObject.Parse(jsonStream.ReadToEnd());

                if (((JToken)readConfig["FlashpointPath"]).Type != JTokenType.Null)
                {
                    Config.FlashpointPath = (string?)readConfig["FlashpointPath"];
                }

                if (((JToken)readConfig["CLIFpPath"]).Type != JTokenType.Null)
                {
                    Config.CLIFpPath = (string?)readConfig["CLIFpPath"];
                }

                if (((JToken)readConfig["FlashpointServer"]).Type != JTokenType.Null)
                {
                    Config.FlashpointServer = (string?)readConfig["FlashpointServer"];
                }
            }
        }

        // Write data values to config file
        public static void Write()
        {
            using (FileStream config = new("config.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                lock (config)
                {
                    config.SetLength(0);
                }

                JObject writeConfig = new();

                writeConfig["FlashpointPath"] = Config.FlashpointPath;
                writeConfig["CLIFpPath"] = Config.CLIFpPath;
                writeConfig["FlashpointServer"] = Config.FlashpointServer;

                config.Write(Encoding.ASCII.GetBytes(writeConfig.ToString()));
            }
        }
    }
}