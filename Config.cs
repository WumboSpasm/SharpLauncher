using System.Text;
using Newtonsoft.Json.Linq;

namespace SharpLauncher
{
    public static class Config
    {
        // Strings to hold configuration data.
        public static string FlashpointPath { get; set; } = ".";
        public static string CLIFpPath { get; set; } = @".\CLIFp\CLIFp.exe";
        public static string FlashpointServer { get; set; } = "http://infinity.unstable.life/Flashpoint";

        public static bool NeedsRefresh { get; set; } = true;

        public static readonly object configJsonLock = new();

        // Update configuration with data from config.json.
        public static void Read()
        {
            lock (configJsonLock)
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
        }

        // Write configuration data to config.json.
        public static void Write()
        {
            lock (configJsonLock)
            {
                using (FileStream config = new("config.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    config.SetLength(0);

                    JObject writeConfig = new();

                    writeConfig["FlashpointPath"] = Config.FlashpointPath;
                    writeConfig["CLIFpPath"] = Config.CLIFpPath;
                    writeConfig["FlashpointServer"] = Config.FlashpointServer;

                    config.Write(Encoding.ASCII.GetBytes(writeConfig.ToString()));
                }
            }
        }
    }
}