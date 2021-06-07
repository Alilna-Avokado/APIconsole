using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace APIconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ApiKey = "ccd07fd87a54f4899fb3778c88570e58";
            var character = "rick";
            var url = $"https://rickandmortyapi.com/api/character?appid=ccd07fd87a54f4899fb3778c88570e58&q={character}";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine(result);
                var data = JsonConvert.DeserializeObject<Root>(result);
                //Console.WriteLine();
            }

        }
    }
}

