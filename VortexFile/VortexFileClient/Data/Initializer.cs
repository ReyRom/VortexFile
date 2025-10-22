using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VortexFileClient.Data
{
    public static class Initializer
    {
        public static void Initialize()
        {
            var config = Path.Combine(Environment.CurrentDirectory, "config.txt");
            if (File.Exists(config))
            {
                string strings = File.ReadAllText(config);
                var adminPass = Regex.Match(strings, @"^admpass#(?<data>.+)$", RegexOptions.Multiline).Groups["data"].Value.TrimEnd('\r');
                if (adminPass == Properties.Settings.Default.AdminPassword)
                {
                    var connectionString = Regex.Match(strings, @"^cnctstr#(?<data>.+)$", RegexOptions.Multiline).Groups["data"].Value.TrimEnd('\r');
                    var ftpAddress = Regex.Match(strings, @"^ftpaddrs#(?<data>.+)$", RegexOptions.Multiline).Groups["data"].Value.TrimEnd('\r');
                    if (!String.IsNullOrWhiteSpace(connectionString))
                    {
                        Properties.Settings.Default.ConnectionString = connectionString;
                        Properties.Settings.Default.Save();
                    }
                    if (!String.IsNullOrWhiteSpace(ftpAddress))
                    {
                        Properties.Settings.Default.FtpAddress = ftpAddress;
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }
    }
}
