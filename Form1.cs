using System;
using System.IO;
using System.Security.Cryptography;

namespace FNFCoverManager
{
    public partial class Form1 : Form
    {
        private Program.Config _config;
        private string selectedCoverName;

        internal Form1(Program.Config config)
        {
            InitializeComponent();
            _config = config;

            // Populate songsBox with song names
            if (_config != null && _config.SongDirs != null)
            {
                foreach (var songDir in _config.SongDirs)
                {
                    songsBox.Items.Add(songDir.Name);
                }
            }
        }

        private string GetSongPath(string songName)
        {
            foreach (var songDir in _config.SongDirs)
            {
                if (songDir.Name.Equals(songName, StringComparison.OrdinalIgnoreCase))
                {
                    return songDir.Path;
                }
            }
            return null; // Song not found
        }
        private string GetCoverPath(string songName, string coverName)
        {
            foreach (var coverDir in _config.CoverDirs)
            {
                if (coverDir.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase) &&
                    coverDir.CoverName.Equals(coverName, StringComparison.OrdinalIgnoreCase))
                {
                    return coverDir.Path;
                }
            }
            return null; // Cover not found
        }

        public static string GetFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                }
            }
        }

        public string GetDebugTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"Press OK to test if we got the config", "something", MessageBoxButtons.OK, MessageBoxIcon.Error);{_config.SongDirs[0]}
            // Display a MessageBox with debug buttons
            var result = MessageBox.Show("Yes - Config Value Test\nNo - EMPTY\nCancel - EMPTY", "Debug Buttons", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            // Check which button was clicked and perform corresponding action
            switch (result)
            {
                case DialogResult.Yes:
                    MessageBox.Show($"First Directory in the Song List:\nName = {_config.SongDirs[0].Name}\nPath = {_config.SongDirs[0].Path}");
                    // Perform any other actions for Debug action 1
                    break;
                case DialogResult.No:
                    MessageBox.Show("Debug action 2 executed.");
                    // Perform any other actions for Debug action 2
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("Debug action 3 executed.");
                    // Perform any other actions for Debug action 3
                    break;
                default:
                    break;
            }
        }

        private void songsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coversBox.Items.Clear();
            foreach (var coverDir in _config.CoverDirs)
            {
                if (coverDir.SongName.Equals(songsBox.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    // Assuming you want to display or use the cover directory path
                    // You can modify this part based on what you want to do with each cover
                    //MessageBox.Show($"Cover for {songsBox.SelectedItem.ToString()}: {coverDir.CoverName} - Path = {coverDir.Path}");
                    coversBox.Items.Add(coverDir.CoverName);
                }
            }
            currentSong.Text = $"Song: {songsBox.SelectedItem.ToString()}";
            String currentSongPath = GetSongPath(songsBox.SelectedItem.ToString());

            String currentCoverHash = GetFileHash($"{currentSongPath}\\Voices.ogg");

            currentCover.Text = "Current Cover: Checking...";
            foreach (var coverDir in _config.CoverDirs)
            {
                string coverPath = coverDir.Path;
                string coverName = coverDir.CoverName;

                // Get hash of the cover file
                string coverHash = GetFileHash(coverPath);

                // Compare coverHash with currentCoverHash
                if (coverHash.Equals(currentCoverHash, StringComparison.OrdinalIgnoreCase))
                {
                    // Set currentCover.Text to the cover name that matches
                    currentCover.Text = $"Current Cover: {coverName}";
                    selectedCoverName = coverName;
                    break; // Exit the loop once a match is found
                }
                else
                {
                    currentCover.Text = $"Current Cover: Original Voices";
                    selectedCoverName = "Original Voices";
                    break;
                }
            }

            //currentCover.Text = $"Current Cover: {}";
        }

        private void coversBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void setCoverButton_Click(object sender, EventArgs e)
        {
            String currentSongName = songsBox.SelectedItem.ToString();
            String currentSongPath = GetSongPath(currentSongName);
            String currentCoverHash = GetFileHash($"{currentSongPath}\\Voices.ogg");

            String newCoverName = coversBox.SelectedItem.ToString();
            String coverPath = GetCoverPath(currentSongName, newCoverName);
            String newCoverHash = GetFileHash(coverPath);

            if (currentCoverHash == newCoverHash)
            {
                //MessageBox.Show("This cover is already selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorBox.Text = $"[{GetDebugTime()}] This cover is already selected!\n{errorBox.Text}";
            }
            else
            {
                if (!Directory.Exists(currentSongPath))
                {
                    //MessageBox.Show("Destination directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorBox.Text = $"[{GetDebugTime()}] Destination directory does not exist.\n{errorBox.Text}";
                    return; // Exit the program or method if directory doesn't exist
                }

                string destinationFilePath = Path.Combine(currentSongPath, "Voices.ogg");
                try
                {
                    // Copy the file
                    File.Copy(coverPath, destinationFilePath, true); // Set overwrite to true to allow overwriting if the file exists
                    //errorBox.Text =$"[{GetDebugTime()}] File Path = {coverPath} Destination = {destinationFilePath}\n{errorBox.Text}";
                    //MessageBox.Show("File copied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentCover.Text = $"Current Cover: {newCoverName}";
                }
                catch (IOException ee)
                {
                    //MessageBox.Show($"An error occurred while copying the file: {ee.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorBox.Text = $"[{GetDebugTime()}] An error occurred while copying the file: {ee.Message}\n{errorBox.Text}";
                }
                catch (Exception ee)
                {
                    //MessageBox.Show($"An unexpected error occurred: {ee.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorBox.Text = $"[{GetDebugTime()}] An unexpected error occurred: {ee.Message}\n{errorBox.Text}";
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "https://johnbdev.net");
        }
    }
}
