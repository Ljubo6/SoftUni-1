namespace IRunes.App.Extensions
{
    using IRunes.Models;
    using System.Linq;
    using System.Net;

    public static class EntityExtensions
    {
        public static string GetTracks(this Album album)
        {
            return string.Join("<br>", album.Tracks.Select((track, index) => track.ToHtmlAll(album.Id, index + 1)));
        }
        public static string ToHtmlAll(this Album album)
        {
            return $"<h3><a href=\"/Albums/Details?id={album.Id}\">{WebUtility.UrlDecode(album.Name)}</a></h3>";
        }

        public static string ToViewDetails(this Album album)
        {
            return "<div class=\"album-details d-flex justify-content-between row\">" +
                   "    <div class=\"album-data col-md-5\">" +
                   $"       <img src=\"{WebUtility.UrlDecode(album.Cover)}\" class=\"img-thumbnail\"/>" +
                   $"       <h1 class=\"text-center\">Album Name: {WebUtility.UrlDecode(album.Name)}</h1>" +
                   $"       <h1 class=\"text-center\">Album Price: ${album.Price:F2}</h1>" +
                   "        <div class=\"d-flex justify-content-between\">" +
                   $"           <a class=\"btn bg-success text-white\" href=\"/Tracks/Create?albumId={album.Id}\">Create Track</a>" +
                   "            <a class=\"btn bg-success text-white\" href=\"/Albums/All\">Back To All</a>" +
                   "        </div>" +
                   "    </div>" +
                   "    <div class=\"album-tracks col-md-6\">" +
                   "        <h1>Tracks</h1>" +
                   $"       {album.GetTracks()}" +
                   "    </div>" +
                   "</div>";
        }

        public static string ToHtmlAll(this Track track, string albumId, int index)
        {
            return $"<li><strong>{index}</strong>. <a href=\"/Tracks/Details?albumId={albumId}&trackId={track.Id}\"><i>{WebUtility.UrlDecode(track.Name)}</i></a></li>";
        }

        public static string ToViewDetails(this Track track)
        {
            return "<div class=\"album-details d-flex justify-content-between row\">" +
                   "    <div class=\"album-data col-md-5\">" +
                   $"       <img src=\"{WebUtility.UrlDecode(track.Link)}\" class=\"img-thumbnail\"/>" +
                   $"       <h1 class=\"text-center\">Album Name: {WebUtility.UrlDecode(track.Name)}</h1>" +
                   $"       <h1 class=\"text-center\">Album Price: ${track.Price:F2}</h1>" +
                   "        <div class=\"d-flex justify-content-between\">" +
                   $"           <a class=\"btn bg-success text-white\" href=\"/Tracks/Create?trackId={track.Id}\">Create Track</a>" +
                   "            <a class=\"btn bg-success text-white\" href=\"/Albums/All\">Back To All</a>" +
                   "        </div>" +
                   "    </div>" +
                   "</div>";
        }
    }
}
