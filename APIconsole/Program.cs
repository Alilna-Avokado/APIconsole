using System;
using System.IO;
using Telegram.Bot;
using Newtonsoft.Json;
using System.Net;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {

            TelegramBotClient bot = new TelegramBotClient("1834940961:AAH8Weyp7Ai43AufR97UFFspTEp7aYDTUSw");

            bot.OnMessage += (s, arg) =>
            {
                Console.WriteLine($"{arg.Message.Chat.FirstName}: {arg.Message.Text}");
                bot.SendTextMessageAsync(arg.Message.Chat.Id, Name());
            };

            bot.StartReceiving();

            Console.ReadKey();
        }

        static string Name()
        {

            var ApiKey = "ccd07fd87a54f4899fb3778c88570e58";
            var character = "rick";
            var url = $"https://rickandmortyapi.com/api/character?appid=ccd07fd87a54f..{character}";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                //return "null";
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                //Console.WriteLine(result);
                var data = JsonConvert.DeserializeObject<Root>(result);
                return $"{data.results[5].image}";
                //Console.WriteLine();
            }
        }
    }
}

