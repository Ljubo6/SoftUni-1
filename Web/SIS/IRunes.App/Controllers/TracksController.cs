using IRunes.Data;
using IRunes.Models;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.App.Controllers
{
    public class TracksController : BaseController
    {
        public IHttpResponse Create(string id)
        {
            this.ViewData["AlbumId"] = id;
            return this.View();
        }

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
            var trackId = httpRequest.QueryData["id"].ToString();

            using (var context = new RunesDbContext())
            {
                var track = context.Tracks.FirstOrDefault(a => a.Id == trackId);
                //this.ViewData["Track"] = track.ToViewDetails();
            }

            return this.View();
        }
    }
}
