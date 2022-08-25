using Serilog;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FileBackup
{
    public class BackupSettings
    {
        public List<string> SourceFolders { get; set; }
        public List<string> TargetFolders { get; set; }

        public void LoadSettings()
        {
            string settings = File.ReadAllText("settings.json");
            var jsNode = JsonNode.Parse(settings)?["BackupSattings"];
            BackupSettings setting = jsNode.Deserialize(typeof(BackupSettings)) as BackupSettings;
            SourceFolders = setting.SourceFolders;
            TargetFolders = setting.TargetFolders;
            Log.Logger.Information("Настройки загружены");
        }
    }
}
