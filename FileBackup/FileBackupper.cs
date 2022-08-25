using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBackup
{
    public static class FileBackupper
    {
        static void Copy(string sourceFolder, string targetFolder)
        {
            Log.Logger.Information("Создание папки:" + targetFolder);
            Directory.CreateDirectory(targetFolder); 
            
            foreach (var file in Directory.GetFiles(sourceFolder))
            {
                Log.Logger.Information("    Копирование файла:" + file);
                File.Copy(file, Path.Combine(targetFolder, Path.GetFileName(file)));
            }

            foreach (var directory in Directory.GetDirectories(sourceFolder))
                Copy(directory, Path.Combine(targetFolder, Path.GetFileName(directory)));
        }

        public static void MakeCopy(BackupSettings settings)
        {
            string sourceError = string.Empty;
            string targetError = string.Empty;
            try
            {
                foreach (var sourceFolder in settings.SourceFolders)
                {
                    sourceError = sourceFolder;
                    foreach (var targetFolder in settings.TargetFolders)
                    {
                        targetError = targetFolder;
                        var newFolder = Path.Combine(targetFolder, DateTime.Now.ToString("MM.dd.yyyy HH.mm.ss"));
                        Directory.CreateDirectory(newFolder);
                        Copy(sourceFolder, newFolder);
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Logger
                    .Error("Произошла ошибка при создании копии" + Environment.NewLine +
                           "исходная папка:" + sourceError + Environment.NewLine +
                           "целевая папка:" + targetError + Environment.NewLine 
                           + e.Message);
                throw;
            }
        }
    }
}
