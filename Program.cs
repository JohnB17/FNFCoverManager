using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace FNFCoverManager
{
    internal static class Program
    {
        internal class SongDirectory
        {
            public string Name { get; set; }
            public string Path { get; set; }
        }

        internal class Config
        {
            public List<SongDirectory> SongDirs { get; set; }
            public List<CoverDirectory> CoverDirs { get; set; }
        }

        internal class CoverDirectory
        {
            public string SongName { get; set; }
            public string CoverName { get; set; }
            public string Path { get; set; }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Load the JSON config
            string configPath = @"fnfcovermanager_config.json";
            Config config = LoadConfig(configPath);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(config));
        }

        static Config LoadConfig(string path)
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<Config>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load config: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}