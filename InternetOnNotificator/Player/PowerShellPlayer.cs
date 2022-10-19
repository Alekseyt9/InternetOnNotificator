
using System.Diagnostics;

namespace InternetOnNotificator
{
    internal class PowerShellPlayer : ISoundPlayer
    {
        public void Play(string path)
        {
            Process.Start("powershell", $@"-c (NEw-Object Media.SOundPlayer '{path}').Play();");
        }
    }
}
