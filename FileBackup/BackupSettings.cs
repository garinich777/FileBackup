using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace FileBackup
{
    public enum LogLevel
    {
        Error,
        Info,
        Debug
    }

    public class BackupSettings
    {
        public List<string> SourceFolders { get; set; }
        public List<string> TargetFolders { get; set; }
        public LogLevel LogLevel { get; set; }

        public async void SaveSettings()
        {
            var JsonSerializerOptions = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string settings = JsonSerializer.Serialize(this, JsonSerializerOptions);
            await File.WriteAllTextAsync("settings.json", settings, Encoding.Unicode);
        }

        public void LoadSettings()
        {

        }
    }
}
