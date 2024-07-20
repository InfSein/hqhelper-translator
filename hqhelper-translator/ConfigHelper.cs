using Newtonsoft.Json;

namespace hqhelper_translator;

internal class ConfigHelper
{
    public struct ConfigModel
    {
        public string HqhelperPath { get; set; }
    }

    private static string SavePath {
        get {
            return Environment.CurrentDirectory + @"\config.json";
        }
    }

    public static ConfigModel Value
    {
        get
        {
            var s = LocalFile.Read(SavePath);
            var c = new ConfigModel();
            try
            {
                c = JsonConvert.DeserializeObject<ConfigModel>(s);
            }
            catch (Exception e)
            {
                c = new ConfigModel();
            }
            return c;
        }
        set
        {
            var s = JsonConvert.SerializeObject(value);
            LocalFile.Write(SavePath, s);
        }
    }
}
