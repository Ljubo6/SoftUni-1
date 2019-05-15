namespace SIS
{
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string reqString = "GET /courses/javascript?price=122&day=Monday#fragment HTTP/1.1\r\n"
                              + "Host: www.softuni.bg\r\n"
                              + "User-Agent: Mozilla/5.0\r\n"
                              + "\r\n"
                              + "name=pesho&id=1";

            var response = new HttpResponse(HTTP.Enums.HttpResponseStatusCode.Ok);
            response.AddHeader(new HTTP.Headers.HttpHeader("Host", "www.softuni.bg"));
            response.AddHeader(new HTTP.Headers.HttpHeader("User-Agent", "Mozilla"));


            Console.WriteLine(response.ToString());
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
