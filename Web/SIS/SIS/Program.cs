namespace SIS
{
    using SIS.HTTP.Requests;

    public class Program
    {
        public static void Main(string[] args)
        {
            string reqString = "GET /courses/javascript?price=122&day=Monday HTTP/1.1\r\n"
                              + "Host: www.softuni.bg\r\n"
                              + "User-Agent: Mozilla/5.0\r\n"
                              + "\r\n"
                              + "name=pesho&id=1";

            var req = new HttpRequest(reqString);
            System.Console.WriteLine(req.ToString());
        }
    }
}
