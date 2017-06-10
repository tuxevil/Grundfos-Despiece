using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Grundfos_Despiece
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            FtpWatcherInstance.fwc = new FtpWatcher();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}