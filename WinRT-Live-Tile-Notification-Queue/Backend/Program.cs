using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Tile_Generator;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.Routes.MapHttpRoute("Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            config.Formatters.RemoveAt(0);

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();

                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }

    }

    public class TileUpdaterController : ApiController
    {
        public HttpResponseMessage Get(int position)
        {
            var msg = string.Format("Received request for position {0}", position);
            Console.WriteLine(msg);

            var tileTitle = string.Format("Backend Noti {0}", position);
            var tilesSubtitle = DateTime.UtcNow.AddHours(position);

            var result = Generator.Generate(tileTitle, tilesSubtitle);

            var response = Request.CreateResponse(HttpStatusCode.OK, result);
            response.Headers.Add("X-WNS-Expires", tilesSubtitle.AddMinutes(15).ToString("r"));
            response.Headers.Add("X-WNS-Tag", position.ToString());

            return response;
        }
    }
}
