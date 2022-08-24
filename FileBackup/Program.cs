using FileBackup;



BackupSettings backupSettings = new BackupSettings()
{
    LogLevel = LogLevel.Info,
    SourceFolders = new List<string>
    {
        @"C:\Users\laki\YandexDisk\Работа\Infotecs\Исходная папка"
    },
    TargetFolders = new List<string>
    {
        @"C:\Users\laki\YandexDisk\Работа\Infotecs\Целевая папка"
    }
};

backupSettings.SaveSettings();

Console.WriteLine("Hello, World!");
