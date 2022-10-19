
using System.Diagnostics;

namespace InternetOnNotificator
{
    internal class WMPlayer : ISoundPlayer
    {
        ProcessStartInfo _pi;

        public void Play(string path)
        {
            _pi = new ProcessStartInfo(
                @"c:\Program Files (x86)\Windows Media Player\wmplayer.exe")
            {
                Arguments = $@" ""{path}"" ",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            StartProcess(_pi);
        }

        private void StartProcess(ProcessStartInfo pi)
        {
            var p = new Process();
            p.EnableRaisingEvents = true;
            p.StartInfo = pi;
            p.Start();
            p.WaitForExit();
        }

        private static void PlayRepeat()
        {
            var timer = new Timer(async (s) => {
                    Console.WriteLine("play sound");
                    var pl = new WMPlayer();
                    pl.Play(@"D:\YandexDisk\YandexDisk\Workspace_git\InternetOnNotificator\InternetOnNotificator\Sounds\Ring05.wav");
                }, null,
                0, Convert.ToInt64(new TimeSpan(0, 0, 5).TotalMilliseconds));
        }

    }
}
