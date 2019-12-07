using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    public static class MusicPlaylistReport
    {
        public static string GenerateText(List<MusicPlaylist> Songs)
        {
            string report = "Music Playlist Analyzer Report\n\n";

            if (Songs.Count() < 1)
            {
                report += "No data is available.\r\n";

                return report;
            }

            report += "Songs that received 200 or more plays:\r\n";
            var plays = from entry in Songs where entry.Plays >= 200 select entry;
            if (plays.Count() > 0)
            {
                foreach (var play in plays)
                {
                    report += play + "\r\n";
                }
            }
            else
            {
                report += "not available\r\n";
            }
            report.TrimEnd(',');
            report += "\r\n";

            report += "Number of Alternative songs: ";
            int numalt = 0;
            var alts = from entry in Songs where entry.Genre == "Alternative" select entry;
            if (alts.Count() > 0)
            {
                foreach (var alt in alts)
                {
                    numalt++ ;
                }
                report += numalt;
            }
            else
            {
                report += "not available\r\n";
            }
            report.TrimEnd(',');
            report += "\n\n";

            report += "Number of Hip-Hop/Rap songs: ";
            int numrap = 0;
            var raps = from entry in Songs where entry.Genre == "Hip-Hop/Rap" select entry;
            if (raps.Count() > 0)
            {
                foreach (var rap in raps)
                {
                    numrap++ ;
                }
                report += numrap;
            }
            else
            {
                report += "not available\r\n";
            }
            report.TrimEnd(',');
            report += "\n\n";

            report += "Songs from the album Welcome to the Fishbowl:\r\n";
            var fishbowls = from entry in Songs where entry.Album == "Welcome to the Fishbowl" select entry;
            if (fishbowls.Count() > 0)
            {
                foreach (var fishbowl in fishbowls)
                {
                    report += fishbowl + "\r\n";
                }
            }
            else
            {
                report += "not available\r\n";
            }
            report.TrimEnd(',');
            report += "\r\n";

            report += "Songs from before 1970:\r\n";
            var befores = from entry in Songs where entry.Year < 1970 select entry;
            if (befores.Count() > 0)
            {
                foreach (var before in befores)
                {
                    report += before + "\r\n";
                }
            }
            else
            {
                report += "not available\r\n";
            }
            report.TrimEnd(',');
            report += "\r\n";

            report += "Song names longer than 85 characters:\r\n";
            var names = from entry in Songs where entry.Name.Length > 85 select entry;
            if (names.Count() > 0)
            {
                foreach (var name in names)
                {
                    report += name.Name + "\r\n";
                }
            }
            else
            {
                report += "not available\r\n";
            }
            report.TrimEnd(',');
            report += "\r\n";

            report += "Longest Song:\r\n";
            var longesttime = (from entry in Songs select entry.Time).Max();
            var longestsong = from entry in Songs where entry.Time == longesttime select entry;
            foreach (var longest in longestsong)
            {
                report += longest;
            }
            report.TrimEnd(',');

            return report;
        }
    }
}