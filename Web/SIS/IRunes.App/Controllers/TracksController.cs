namespace IRunes.App.Controllers
{
    using IRunes.App.Extensions;
    using IRunes.Data;
    using IRunes.Models;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer;
    using SIS.WebServer.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    public class TracksController : Controller
    {
        public IHttpResponse Create(string id)
        {
            this.ViewData["AlbumId"] = id;
            return this.View();
        }

        [HttpPost]
        public IHttpResponse CreateConfirm(IHttpRequest httpRequest)
        {
            using (var context = new RunesDbContext())
            {
                var albumId = httpRequest.QueryData["albumId"].ToString();
                var album = context.Albums.FirstOrDefault(a => a.Id == albumId);

                var trackName = ((ISet<string>)httpRequest.FormData["name"]).FirstOrDefault().ToString();
                var trackLink = ((ISet<string>)httpRequest.FormData["link"]).FirstOrDefault().ToString();
                var trackPrice = decimal.Parse(((ISet<string>)httpRequest.FormData["price"]).FirstOrDefault().ToString());

                var newTrack = new Track()
                {
                    Name = trackName,
                    Link = trackLink,
                    Price = trackPrice
                };


                context.Tracks.Add(newTrack);
                album.Tracks.Add(newTrack);
                album.Price = album.Tracks.Sum(t => t.Price) * 0.87m;
                context.Albums.Update(context.Albums.FirstOrDefault(a => a.Id == albumId));
                context.SaveChanges();
            }

            return this.Redirect("/Albums/All");
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            var albumId = httpRequest.QueryData["albumId"].ToString();
            var trackId = httpRequest.QueryData["trackId"].ToString();

            using (var context = new RunesDbContext())
            {
                var track = context.Tracks.FirstOrDefault(a => a.Id == trackId);
                this.ViewData["AlbumId"] = albumId;
                this.ViewData["Track"] = track.ToViewDetails(albumId);
            }

            return this.View();
        }
    }
}
