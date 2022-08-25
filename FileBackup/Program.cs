using FileBackup;
using Microsoft.Extensions.Configuration;
using Serilog;


BackupSettings backupSettings = new BackupSettings();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("settings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .WriteTo.File($"Logs\\log ({DateTime.Now.ToString("MM.dd.yyyy HH.mm.ss")}).txt")
        .CreateLogger();

Log.Logger.Information("Программа запущена");
backupSettings.LoadSettings();

FileBackupper.MakeCopy(backupSettings);

Console.WriteLine("Копирование завершено");
Console.WriteLine("Нажмите любую кнопку для завершения");
Console.ReadKey(false);

Log.CloseAndFlush();
