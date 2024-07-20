using System;
using System.Web;
using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System.Collections.Generic;

namespace WebApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            MercadoPagoConfig.AccessToken = "TEST-5397071701946627-071923-5e269bd0d0382ee66da77d58a58e6567-246774397";
        }
    }
}