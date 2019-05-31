namespace IRunes.App.Controllers
{
    using IRunes.App.Extensions;
    using IRunes.Data;
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer;
    using SIS.WebServer.Attributes;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsController : Controller
    {
        public IHttpResponse All(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            this.ViewData["Albums"] = "There are currently no albums.";

            using (var context = new RunesDbContext())
            {
                var albums = context.Albums.Select(a => a).ToList();
                if (albums.Count > 0)
                {
                    this.ViewData["Albums"] = string.Join(string.Empty, albums.Select(a => a.ToHtmlAll()).ToList());
                }
            }
            return this.View();
        }

        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost (ActionName = "Create")]
        public IHttpResponse CreateConfirm(IHttpRequest httpRequest)
        {
            using (var context = new RunesDbContext())
            {
                string name = ((ISet<string>)httpRequest.FormData["name"]).FirstOrDefault();
                string cover = ((ISet<string>)httpRequest.FormData["cover"]).FirstOrDefault();

                var newAlbum = new Album()
                {
                    Name = name,
                    Cover = cover
                };

                context.Albums.Add(newAlbum);
                context.SaveChanges();
            }

            return this.Redirect("/Albums/All");
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            var albumId = httpRequest.QueryData["id"].ToString();

            using (var context = new RunesDbContext())
            {
                var album = context.Albums
                    .Include(a => a.Tracks)
                    .FirstOrDefault(a => a.Id == albumId);
                this.ViewData["Album"] = album.ToViewDetails();
            }

            return this.View();
        }
    }
}
