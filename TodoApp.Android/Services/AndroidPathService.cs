using System;
using System.IO;
using TodoApp.Droid.Services;
using TodoApp.Services.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidPathService))]
namespace TodoApp.Droid.Services
{
    public class AndroidPathService: IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppConfig.DatabaseName);
        }
    }
}
