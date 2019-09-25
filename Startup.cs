using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HCServices.Context;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HCServices.Startup))]

namespace HCServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            System.Data.Entity.Database.SetInitializer(new DatabaseInitializer());
            log4net.Config.XmlConfigurator.Configure();

        }
    }
}
