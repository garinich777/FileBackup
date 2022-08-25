using FileBackup;
using Microsoft.Extensions.Configuration;
using Serilog;

Console.WriteLine("Hello, World!");
BackupSettings backupSettings = new BackupSettings();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("settings.json")
    .Build();

var a = configuration.GetSection("BackupSattings").GetSection("SourceFolders").GetSection("0");

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

backupSettings.LoadSettings();
Console.ReadLine();

Log.CloseAndFlush();
