
using System.Net;
using InternetOnNotificator.Player;

namespace InternetOnNotificator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача запущена");

            var timer = new Timer(async (s) => {              
                var result = await CheckInternet();
                Console.WriteLine($"internet checking: {result}");
                if (result)
                {
                    Play();       
                }
            }, null, 
                0, Convert.ToInt64(new TimeSpan(0, 1, 0).TotalMilliseconds));

            Console.WriteLine("Задача завершена. Нажмине enter");
            Console.ReadLine();
        }

        private static void Play()
        {
            //todo в ресурсы
            Console.WriteLine("play sound");
            var pl = new NetMedia();
            pl.Play(@"D:\YandexDisk\YandexDisk\Workspace_git\InternetOnNotificator\InternetOnNotificator\Sounds\Ring05.wav");
        }

        private static async Task<bool> CheckInternet()
        {
            try
            {
                await GetAsync("http://www.google.com");
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private static async Task<string> GetAsync(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

    }
}