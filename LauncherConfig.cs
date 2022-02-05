using System.Text;

namespace WumboLauncher
{
    public class LauncherConfig
    {
        // Configuration data
        private List<string> _Data = new()
        {
            // Flashpoint path
            ".",
            // CLIFp path
            @".\CLIFp\CLIFp.exe",
            // Flashpoint server
            "http://infinity.unstable.life/Flashpoint"
        };

        public List<string> Data
        {
            get
            {
                return _Data;
            }
            set
            {
                if (_Data != value)
                    _Data = value;
            }
        }

        // Replace list contents with values from config file
        public void Read()
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
        public void Write()
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