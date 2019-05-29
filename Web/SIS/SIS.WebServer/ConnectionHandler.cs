namespace SIS.WebServer
{
    using Routing.Contracts;

    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Sessions;
    using SIS.WebServer.Results;

    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.IO;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task ProcessRequestAsync()
        {
            try
            {
                var httpRequest = await this.ReadRequestAsync();
                
                if(httpRequest != null)
                {
                    Console.WriteLine($"Processing: {httpRequest.RequestMethod} {httpRequest.Path}...");
                    var sessionId = this.SetRequestSession(httpRequest);
                    var httpResponse = this.HandleRequest(httpRequest);
                    this.SetResponseSession(httpResponse, sessionId);
                    await this.PrepareResponseAsync(httpResponse);
                }
            }
            catch (BadRequestException badReqestEx)
            {
                await this.PrepareResponseAsync(new TextResult(badReqestEx.ToString(), HttpResponseStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                await this.PrepareResponseAsync(new TextResult(ex.ToString(), HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadRequestAsync()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfbytes = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if(numberOfbytes == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfbytes);
                result.Append(bytesAsString);

                if(numberOfbytes < 1023)
                {
                    break;
                }
            }

            if(result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private IHttpResponse ReturnIfResource(IHttpRequest httpRequest)
        {
            string folderPrefix = "/../../../../";
            string resourcesFolderPath = "Resources/";
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string path = httpRequest.Path;

            string fullPathToResource = assemblyLocation + folderPrefix + resourcesFolderPath + path;

            if (File.Exists(fullPathToResource))
            {
                byte[] content = File.ReadAllBytes(fullPathToResource);
                return new InlineResourceResult(content, HttpResponseStatusCode.Found);
            }
            else
            {
                return new TextResult($"Route with method {httpRequest.RequestMethod} and path \"{httpRequest.Path}\" not found.",
                    HttpResponseStatusCode.NotFound);
            }
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            var requestMethod = httpRequest.RequestMethod;
            var path = httpRequest.Path;

            if (!this.serverRoutingTable.Contains(requestMethod, path))
            {
                return this.ReturnIfResource(httpRequest);
            }

            return this.serverRoutingTable.Get(requestMethod, path).Invoke(httpRequest);
        }

        private async Task PrepareResponseAsync(IHttpResponse httpResponse)
        {
            var byteSegments = httpResponse.GetBytes();
            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = null;
            if (httpRequest.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
            }

            httpRequest.Session = HttpSessionStorage.GetSession(sessionId);

            return httpRequest.Session.Id;
        }

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if(sessionId != null)
            {
                httpResponse.AddCookie(new HttpCookie(HttpSessionStorage.SessionCookieKey, sessionId));
            }
        }
    }
}
