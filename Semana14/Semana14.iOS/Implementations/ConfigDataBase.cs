using System;
using System.IO;
using Xamarin.Forms;
using Semana14.Interfaces;
using Semana14.iOS.Implementations;

[assembly: Dependency(typeof(ConfigDataBase))]
namespace Semana14.iOS.Implementations
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseFileName);
        }
    }
}
