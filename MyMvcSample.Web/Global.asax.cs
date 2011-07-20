﻿using System.Web;
using MyMvcSample.Infrastructure;

namespace MyMvcSample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Start();
        }
    }
}