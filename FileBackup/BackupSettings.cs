using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;
using System.Threading.Tasks;

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

            Log.Logger.Information("Настройеки загружены");
        }
    }
}
