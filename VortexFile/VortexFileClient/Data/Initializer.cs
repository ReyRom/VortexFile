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
                Regex regex = new Regex(@"^admpass#(?<pass>\S+)[$]cnctstr#(?<cnctstr>\S+)[$]$");
                Match match = regex.Match(strings);
                var adminPass = match.Groups["pass"].Value;
                var connectionString = match.Groups["cnctstr"].Value;
                if (adminPass == Properties.Settings.Default.AdminPassword)
                {
                    Properties.Settings.Default.ConnectionString = connectionString;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
