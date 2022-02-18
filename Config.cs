using System.Text;

namespace WumboLauncher
{
    public static class Config
    {
        // Configuration data
        public static List<string> Data { get; set; } = new()
        {
            // Flashpoint path
            ".",
            // CLIFp path
            @".\CLIFp\CLIFp.exe",
            // Flashpoint server
            "http://infinity.unstable.life/Flashpoint"
        };

        public static bool NeedsRefresh { get; set; } = false;

        // Replace list contents with values from config file
        public static void Read()
        {
            int i = 0;

            foreach (string value in File.ReadLines("config.fp"))
            {
                Data[i++] = value;

                if (i == 3)
                    break;
            }
        }

        // Write values from list to config file
        public static void Write()
        {
            using (FileStream config = new("config.fp", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                lock (config)
                    config.SetLength(0);

                foreach (string value in Data)
                {
                    byte[] byteValue = Encoding.ASCII.GetBytes(value + Environment.NewLine);
                    config.Write(byteValue, 0, byteValue.Length);
                }
            }
        }
    }
}