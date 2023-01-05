using System.IO;
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

        public static bool Configured { get; set; } = false;
        public static bool Initialized { get; set; } = false;
        public static bool InitStarted { get; set; } = false;

        public static readonly object configJsonLock = new object();

        // Update configuration with data from sharpConfig.json.
        public static void Read()
        {
            lock (configJsonLock)
            {
                using (var jsonStream = new StreamReader("sharpConfig.json"))
                {
                    JObject readConfig = JObject.Parse(jsonStream.ReadToEnd());

                    if (readConfig["FlashpointPath"].Type != JTokenType.Null)
                    {
                        FlashpointPath = (string)readConfig["FlashpointPath"];
                    }

                    if ((readConfig["CLIFpPath"]).Type != JTokenType.Null)
                    {
                        CLIFpPath = (string)readConfig["CLIFpPath"];
                    }

                    if ((readConfig["FlashpointServer"]).Type != JTokenType.Null)
                    {
                        FlashpointServer = (string)readConfig["FlashpointServer"];
                    }
                }
            }
        }

        // Write configuration data to sharpConfig.json.
        public static void Write()
        {
            lock (configJsonLock)
            {
                using (var config = new FileStream("sharpConfig.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    config.SetLength(0);

                    var writeConfig = new JObject
                    {
                        ["FlashpointPath"] = FlashpointPath,
                        ["CLIFpPath"] = CLIFpPath,
                        ["FlashpointServer"] = FlashpointServer
                    };

                    byte[] data = Encoding.ASCII.GetBytes(writeConfig.ToString());
                    config.Write(data, 0, data.Length);
                }
            }
        }

        public static bool[] Validate(string flashpointPath, string clifpPath)
        {
            bool pathValid = false;
            bool clifpValid = false;

            string databasePath = flashpointPath + @"\Data\flashpoint.sqlite";
            byte[] header = new byte[16];

            if (File.Exists(databasePath))
            {
                using (var fileStream = new FileStream(databasePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fileStream.Read(header, 0, 16);
                }

                pathValid = Encoding.ASCII.GetString(header).Contains("SQLite format");
            }

            if (File.Exists(clifpPath) && clifpPath.ToLower().EndsWith(".exe"))
            {
                clifpValid = true;
            }

            return new bool[] { pathValid, clifpValid };
        }
    }
}