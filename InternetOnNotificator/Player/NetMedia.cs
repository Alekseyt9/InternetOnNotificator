
using System.Media;

namespace InternetOnNotificator.Player
{
    internal class NetMedia : ISoundPlayer
    {
        public void Play(string path)
        {
            var player = new SoundPlayer(path);
            player.PlayLooping();
        }
    }
}
