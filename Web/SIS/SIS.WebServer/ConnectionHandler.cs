namespace SIS.WebServer
{
    using Routing.Contracts;
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Net.Sockets;
    using System.Text;

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

        public void ProcessRequest()
        {
            try
            {
                var httpRequest = this.ReadRequest();
                
                if(httpRequest != null)
                {
                    Console.WriteLine($"Processing: {httpRequest.RequestMethod} {httpRequest.Path}...");
                    var httpResponse = this.HandleRequest(httpRequest);
                    this.PrepareResponse(httpResponse);
                }
            }
            catch (BadRequestException badReqestEx)
            {
                this.PrepareResponse(new TextResult(badReqestEx.ToString(), HttpResponseStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                this.PrepareResponse(new TextResult(ex.ToString(), HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private IHttpRequest ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfbytes = this.client.Receive(data.Array, SocketFlags.None);

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

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            var requestMethod = httpRequest.RequestMethod;
            var path = httpRequest.Path;

            if (!this.serverRoutingTable.Contains(requestMethod, path))
            {
                return new TextResult($"Route with method {requestMethod} and path \"{path}\" not found.", 
                    HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Get(requestMethod, path).Invoke(httpRequest);
        }

        private void PrepareResponse(IHttpResponse httpResponse)
        {
            var byteSegments = httpResponse.GetBytes();
            this.client.Send(byteSegments, SocketFlags.None);
        }
    }
}
