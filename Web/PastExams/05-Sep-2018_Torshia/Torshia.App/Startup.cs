﻿namespace Torshia.App
{
using SIS.MvcFramework;
using SIS.MvcFramework.DependencyContainer;
using SIS.MvcFramework.Routing;
using Torshia.Data;
using Torshia.Services;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new TorshiaDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            //serviceProvider.Add<IAlbumService, AlbumService>();
            //serviceProvider.Add<ITrackService, TrackService>();
            serviceProvider.Add<IUserService, UserService>();
        }
    }
}