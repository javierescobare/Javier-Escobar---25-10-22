using System;
using System.IO;
using TodoApp.iOS.Services;
using TodoApp.Services.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSPathService))]
namespace TodoApp.iOS.Services
{
    public class IOSPathService: IPathService
    {
        public string GetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, AppConfig.DatabaseName);
        }
    }
}
