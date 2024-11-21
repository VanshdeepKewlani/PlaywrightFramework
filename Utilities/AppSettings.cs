using Microsoft.Extensions.Configuration;

namespace PlaywrightFramework
{
    public static class GlobalAppSettings
    {
        private static readonly string CsvFilePath;
        public static IConfiguration Configuration { get; private set; }
        public static string _dataFolderPath { get; private set; }
        public static string _filename { get; private set; }
        public static string _foldername { get; private set; }

        static GlobalAppSettings()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;    //path1

            string fileName = Configuration["test data:file_name"];

            CsvFilePath = Path.Combine(basePath, fileName);
        }

        //Method to get the CSV filepath
        public static string GetCsvFilePath()
        {
            return CsvFilePath;
        }
    }
}